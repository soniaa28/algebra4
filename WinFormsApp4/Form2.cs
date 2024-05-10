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
    public partial class Form2 : Form
    {
        public SparseToTapeMatrixConverter converter;
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Matrix A = ParseMatrix(txtMatrix.Text);
            converter = new SparseToTapeMatrixConverter(A);
            int startV = int.Parse(start.Text);
            int endV = int.Parse(end.Text);
            var result = converter.DijkstraAlgorithm(startV, endV);
            if (result.distanceExists)
                resultText.Text = $"Shortest distance from {startV} to {endV} is {result.distance}.";
            else
                resultText.Text = "No path found.";
        }
        private void btnCalcDiameter_Click(object sender, EventArgs e)
        {
            int diameter = converter.CalcDiametr();
            resultText2.Text = $"Diameter of the graph: {diameter}";
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



                        txtMatrix.Text = string.Join(Environment.NewLine, lines);

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
        private void btnGibbs_Click(object sender, EventArgs e)
        {
            Matrix A = ParseMatrix(txtMatrix.Text);
            converter = new SparseToTapeMatrixConverter(A);
            int result = converter.Gibbs();
            result3.Text = $"Result of Gibbs algorithm: {result}";
        }

        private void btnCutHillMcKee_Click(object sender, EventArgs e)
        {
            var vertexEnumeration = converter.CutHillMckee();
            Matrix resultmatrix = converter.ConvertMatrix();
            result4.Text = MatrixToString(resultmatrix);
            // Display vertex enumeration in your UI
        }

      
    }
}
