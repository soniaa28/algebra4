using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class LinearEquationSolverSimpleIteration
    {
        // Метод SolveSimpleIteration вирішує систему лінійних рівнянь методом простої ітерації.
        public static (Vector, int, double) SolveSimpleIteration(Matrix A, Vector b, Vector x0, double tolerance, int maxIterations)
        {
            int n = A.Rows;
            Vector x = new Vector(x0); // Ініціалізуємо початкове наближення x
            int iterations = 0; // Лічильник ітерацій
            double residualNorm = double.MaxValue; // Ініціалізуємо норму залишкового вектора дуже великим числом

            while (iterations < maxIterations && residualNorm > tolerance) // Початок циклу while для ітераційного процесу
            {

                // Оновлюємо кожну компоненту x
                for (int i = 0; i < n; i++)
                {
                    double sum = 0.0;
                    // Сумуємо компоненти з попереднього наближення, помножені на відповідні коефіцієнти матриці
                    for (int j = 0; j < n; j++)
                    {
                        if (j != i)
                        {
                            sum += A[i, j] * x[j];
                        }
                    }

                    // Оновлюємо значення поточної компоненти x за формулою простої ітерації
                    x[i] = (b[i] - sum) / A[i, i];
                }

                // Обчислюємо залишковий вектор та його Євклідову норму
                Vector residual = b - A * x;
                residualNorm = residual.EuclideanNorm();
                iterations++; // Інкрементуємо лічильник ітерацій
            }

            // Повертаємо результати: оновлений вектор x, кількість ітерацій та норму залишкового вектора
            return (x, iterations, residualNorm);
        }
    }
}
