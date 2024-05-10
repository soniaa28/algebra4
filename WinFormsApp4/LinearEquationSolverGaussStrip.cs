using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class LinearEquationSolverGaussStrip
    {
        public static Vector SolveGaussStrip(StripMatrix A, Vector b)
        {
            int n = A.Rows;
            int lowerStripWidth = A.LowerStripWidth;
            int upperStripWidth = A.UpperStripWidth;

            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(A[i, i]) < 1e-12)
                {
                    throw new Exception("Matrix is singular or nearly singular");
                }

                for (int k = i + 1; k <= Math.Min(i + lowerStripWidth, n - 1); k++)
                {
                    double coeff = A[k, i] / A[i, i];
                    for (int j = Math.Max(i, k - upperStripWidth); j <= Math.Min(n - 1, i + upperStripWidth); j++)
                    {
                        A[k, j] -= A[i, j] * coeff;
                    }
                    b[k] -= b[i] * coeff;
                }
            }

            Vector x = new Vector(n);
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = b[i];
                for (int j = i + 1; j <= Math.Min(n - 1, i + upperStripWidth); j++)
                {
                    x[i] -= A[i, j] * x[j];
                }
                x[i] /= A[i, i];
            }

            return x;
        }
    }
}
