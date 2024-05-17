using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class Matrix
    {
        private double[,] data;
        public int Rows => data.GetLength(0);
        public int Cols => data.GetLength(1);

        public double[,] Data => data;
        public Matrix(int rows, int cols)
        {
            data = new double[rows, cols];
        }

        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }


        public Matrix(Matrix a)
        {
            data = new double[a.Rows, a.Cols];
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    data[i, j] = a[i, j];
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new ArgumentException("Matrix dimensions do not match.");

            Matrix result = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    result[i, j] = a[i, j] + b[i, j];
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new ArgumentException("Matrix dimensions do not match.");

            Matrix result = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    result[i, j] = a[i, j] - b[i, j];
            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
                throw new ArgumentException("Matrix dimensions do not match for multiplication.");

            Matrix result = new Matrix(a.Rows, b.Cols);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < b.Cols; j++)
                    for (int k = 0; k < a.Cols; k++)
                        result[i, j] += a[i, k] * b[k, j];
            return result;
        }
        public static Vector operator *(Matrix m, Vector v)
        {
            if (m.Cols != v.Size)
                throw new ArgumentException("Matrix columns and vector size do not match.");

            Vector result = new Vector(m.Rows);
            for (int i = 0; i < m.Rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < m.Cols; j++)
                {
                    sum += m[i, j] * v[j];
                }
                result[i] = sum;
            }
            return result;
        }
        public static Vector operator *(Vector v, Matrix m)
        {
            if (m.Cols != v.Size)
                throw new ArgumentException("Matrix columns and vector size do not match.");

            Vector result = new Vector(m.Rows);
            for (int i = 0; i < m.Rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < m.Cols; j++)
                {
                    sum += m[i, j] * v[j];
                }
                result[i] = sum;
            }
            return result;
        }
        public static Matrix operator *(Matrix m, double scalar)
        {
            Matrix result = new Matrix(m.Rows, m.Cols);
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    result[i, j] = m[i, j] * scalar;
                }
            }
            return result;
        }
        public static Matrix Identity(int n)
        {
            var identity = new Matrix(n, n);
            for (int i = 0; i < n; i++)
            {
                identity[i, i] = 1;
            }
            return identity;
        }
        public void SwapRows(int row1, int row2)
        {
            if (row1 < 0 || row1 >= Rows || row2 < 0 || row2 >= Rows)
                throw new ArgumentException("Row index is out of bounds.");

            for (int i = 0; i < Cols; i++)
            {
                double temp = this[row1, i];
                this[row1, i] = this[row2, i];
                this[row2, i] = temp;
            }
        }
        public double EuclideanNorm()
        {
            double sum = 0;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    sum += data[i, j] * data[i, j];
            return Math.Sqrt(sum);
        }

        public double MaxNorm()
        {
            double max = double.MinValue;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    if (Math.Abs(data[i, j]) > max)
                        max = Math.Abs(data[i, j]);
            return max;
        }
        public Matrix ToAdjacencyMatrix()
        {
            Matrix adjacencyMatrix = new Matrix(Rows, Cols);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    adjacencyMatrix[i, j] = data[i, j] != 0 ? 1 : 0;
                }
            }
            return adjacencyMatrix;
        }
        public int[,] ToIntArray()
        {
            int[,] intArray = new int[Rows, Cols];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    intArray[i, j] = (int)data[i, j];
                }
            }
            return intArray;
        }
    }
}
