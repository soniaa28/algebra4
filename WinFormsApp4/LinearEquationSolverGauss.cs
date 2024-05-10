using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class LinearEquationSolverGauss
    {
        public static (Vector, Matrix, Matrix, Matrix) SolveGauss(Matrix A, Vector b)
        {
            int n = A.Rows;
            Matrix Ai = new Matrix(A);
            Vector Bi = new Vector(b);
            Matrix inverseMatrix = Matrix.Identity(A.Rows);
            Matrix decA = new Matrix(A.Rows, A.Cols);

            for (int i = 0; i < n; i++)
            {
                int leadingRowIdx = GetRowWithLeadingElement(Ai, i, i);
                if (i != leadingRowIdx)
                {
                    Ai.SwapRows(leadingRowIdx, i);
                    inverseMatrix.SwapRows(leadingRowIdx, i);
                    (Bi[leadingRowIdx], Bi[i]) = (Bi[i], Bi[leadingRowIdx]);
                }

                if (Ai[i, i] == 0)
                    throw new Exception("Matrix is singular or ill-conditioned.");

                Matrix matrixT = MakeTransformationMatrixT(Ai, i);
                FillDecA(decA, matrixT, false, i);
                Ai = matrixT * Ai;
                Bi = matrixT * Bi;
                inverseMatrix = matrixT * inverseMatrix;

                for (int j = i + 1; j < n; j++)
                {
                    double factor = Ai[j, i] / Ai[i, i];
                    for (int k = i; k < n; k++)
                    {
                        Ai[j, k] -= Ai[i, k] * factor;
                    }
                    Bi[j] -= Bi[i] * factor;
                }
            }

            FillDecA(decA, Ai, true);

            for (int i = Ai.Cols - 1; i >= 0; i--)
            {
                Matrix transformationMatrix = MakeTransformationMatrixV(Ai, i);
                Ai = transformationMatrix * Ai;
                Bi = transformationMatrix * Bi;
                inverseMatrix = transformationMatrix * inverseMatrix;
            }

            Vector x = BackSubstitution(Ai, Bi, n);

            return (x, decA, Ai, inverseMatrix);
        }

        private static Vector BackSubstitution(Matrix Ai, Vector Bi, int n)
        {
            Vector x = new Vector(n);
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = Bi[i];
                for (int j = i + 1; j < n; j++)
                {
                    x[i] -= Ai[i, j] * x[j];
                }
                x[i] /= Ai[i, i];
            }
            return x;
        }

        private static Matrix MakeTransformationMatrixT(Matrix A, int column)
        {
            Matrix matrixT = Matrix.Identity(A.Rows);
            double divisor = A[column, column];
            for (int i = column + 1; i < A.Rows; i++)
            {
                matrixT[i, column] = -A[i, column] / divisor;
            }
            matrixT[column, column] = 1 / divisor;
            return matrixT;
        }

        private static Matrix MakeTransformationMatrixV(Matrix A, int column)
        {
            Matrix transformationMatrix = Matrix.Identity(A.Rows);
            for (int i = column - 1; i >= 0; i--)
            {
                transformationMatrix[i, column] = -A[i, column] / A[column, column];
            }
            return transformationMatrix;
        }

        private static void FillDecA(Matrix decA, Matrix fromM, bool fromTriangleM, int column = -1)
        {
            if (fromTriangleM)
            {
                for (int i = 0; i < decA.Rows; i++)
                {
                    for (int j = i + 1; j < decA.Cols; j++)
                    {
                        decA[i, j] = fromM[i, j];
                    }
                }
            }
            else
            {
                for (int i = column; i < decA.Rows; i++)
                {
                    decA[i, column] = fromM[i, column];
                }
            }
        }

        private static int GetRowWithLeadingElement(Matrix A, int startRow, int column)
        {
            double maxAbs = 0.0;
            int maxRow = startRow;
            for (int i = startRow; i < A.Rows; i++)
            {
                double absValue = Math.Abs(A[i, column]);
                if (absValue > maxAbs)
                {
                    maxAbs = absValue;
                    maxRow = i;
                }
            }
            return maxRow;
        }
    }
}
