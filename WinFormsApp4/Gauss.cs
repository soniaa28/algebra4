using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Gauss : Form
    {
        public Gauss()
        {
            InitializeComponent();
        }
        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                Matrix A = ParseMatrix(txtMatrix.Text);
                Vector b = ParseVector(txtVector.Text);

                (Vector solution, Matrix Dec, Matrix Ai, Matrix Inverse) = LinearEquationSolverGauss.SolveGauss(A, b);

                txtDecomMatrix.Text = VectorToString(solution);
                txtDecomMatrix.Text = MatrixToString(Dec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDecomMatrix.Text = "Error";
            }
        }
        private void btnSolveStrip_Click(object sender, EventArgs e)
        {
            try
            {
                StripMatrix A = ParseStripMatrix(txtMatrixStrip.Text);
                Vector b = ParseVector(txtVectorStrip.Text);

                Vector solution = LinearEquationSolverGaussStrip.SolveGaussStrip(A, b);

                txtResultStrip.Text = VectorToString(solution);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResultStrip.Text = "Error";
            }
        }

        private void btnLoadData1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);
                    if (lines.Length > 0)
                    {
                        bool isSingleNumber = true;
                        bool isVector = true;

                        foreach (string line in lines)
                        {
                            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length > 1)
                            {
                                isVector = false;
                                break;
                            }
                            if (lines.Length > 1)
                            {
                                isSingleNumber = false;
                            }
                        }


                        if (isVector)
                        {
                            txtVector.Text = string.Join(Environment.NewLine, lines);
                        }
                        else
                        {
                            txtMatrix.Text = string.Join(Environment.NewLine, lines);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: Не вдалося прочитати файл з диску. Помилка: {ex.Message}");
                }
            }
        }

        private void btnLoadData2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);
                    if (lines.Length > 0)
                    {
                        bool isSingleNumber = true;
                        bool isVector = true;

                        foreach (string line in lines)
                        {
                            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length > 1)
                            {
                                isVector = false;
                                break;
                            }
                            if (lines.Length > 1)
                            {
                                isSingleNumber = false;
                            }
                        }

                        if (isVector)
                        {
                            txtVector.Text = string.Join(Environment.NewLine, lines);
                        }
                        else
                        {
                            txtMatrix.Text = string.Join(Environment.NewLine, lines);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: Не вдалося прочитати файл з диску. Помилка: {ex.Message}");
                }
            }
        }
        private string MatrixToString(Matrix matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    sb.Append(String.Format("{0:F2} ", matrix[i, j]));
                }
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }

        private string VectorToString(Vector vector)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < vector.Size; i++)
            {
                sb.AppendLine(String.Format("{0:F2}", vector[i]));
            }
            return sb.ToString().TrimEnd();
        }
        private Matrix ParseMatrix(string text)
        {
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int rows = lines.Length;
            int cols = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Matrix matrix = new Matrix(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                string[] nums = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = double.Parse(nums[j]);
                }
            }

            return matrix;
        }

        private Vector ParseVector(string text)
        {
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Vector vector = new Vector(lines.Length);
            for (int i = 0; i < lines.Length; i++)
            {
                vector[i] = double.Parse(lines[i].Trim());
            }
            return vector;
        }

        private StripMatrix ParseStripMatrix(string text)
        {
            string[] parts = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            double[] mainDiagonal = parts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            double[] upperDiagonal = parts.Length > 1 ? parts[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray() : new double[0];
            double[] lowerDiagonal = parts.Length > 2 ? parts[2].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray() : new double[0];

            int n = mainDiagonal.Length;
            StripMatrix matrix = new StripMatrix(n, n, lowerDiagonal.Length, upperDiagonal.Length);

            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = mainDiagonal[i];
                if (i < n - 1 && upperDiagonal.Length > 0) matrix[i, i + 1] = upperDiagonal[i];
                if (i > 0 && lowerDiagonal.Length > 0) matrix[i, i - 1] = lowerDiagonal[i - 1];
            }

            return matrix;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);
                    if (lines.Length > 0)
                    {
                        bool isSingleNumber = true;
                        bool isVector = true;

                        foreach (string line in lines)
                        {
                            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length > 1)
                            {
                                isVector = false;
                                break;
                            }
                            if (lines.Length > 1)
                            {
                                isSingleNumber = false;
                            }
                        }


                        if (isVector)
                        {
                            txtVectorStrip.Text = string.Join(Environment.NewLine, lines);
                        }
                        else
                        {
                            txtMatrixStrip.Text = string.Join(Environment.NewLine, lines);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: Не вдалося прочитати файл з диску. Помилка: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);
                    if (lines.Length > 0)
                    {
                        bool isSingleNumber = true;
                        bool isVector = true;

                        foreach (string line in lines)
                        {
                            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length > 1)
                            {
                                isVector = false;
                                break;
                            }
                            if (lines.Length > 1)
                            {
                                isSingleNumber = false;
                            }
                        }

                        if (isVector)
                        {
                            txtVectorStrip.Text = string.Join(Environment.NewLine, lines);
                        }
                        else
                        {
                            txtMatrixStrip.Text = string.Join(Environment.NewLine, lines);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: Не вдалося прочитати файл з диску. Помилка: {ex.Message}");
                }
            }
        }
    }
}
