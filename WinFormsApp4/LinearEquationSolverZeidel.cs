using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class LinearEquationSolverZeidel
    {
        // Метод SolveZeidel вирішує систему лінійних рівнянь методом Зейделя.
        public static (Vector, int, double) SolveZeidel(Matrix A, Vector b, Vector x0, double tolerance, int maxIterations)
        {
            int n = A.Rows;
            Vector x = new Vector(x0); // Ініціалізуємо початкове наближення x
            Vector prevX = new Vector(x0); // Ініціалізуємо попереднє наближення x
            int iterations = 0; // Лічильник ітерацій
            double residualNorm; // Норма залишкового вектора

            do // Початок циклу do-while для ітераційного процесу
            {
                // Копіюємо поточне наближення x у попереднє наближення prevX
                for (int i = 0; i < n; i++)
                {
                    prevX[i] = x[i];
                }

                // Оновлюємо кожну компоненту x
                for (int i = 0; i < n; i++)
                {
                    double sum1 = 0.0;
                    // Сумуємо компоненти з попередніх ітерацій, які знаходяться перед поточною компонентою
                    for (int j = 0; j < i; j++)
                    {
                        sum1 += A[i, j] * x[j];
                    }

                    double sum2 = 0.0;
                    // Сумуємо компоненти з попередніх ітерацій, які знаходяться після поточної компоненти
                    for (int j = i + 1; j < n; j++)
                    {

                        sum2 += A[i, j] * prevX[j];
                    }

                    // Оновлюємо значення поточної компоненти x за формулою Зейделя
                    x[i] = (b[i] - sum1 - sum2) / A[i, i];
                }

                // Обчислюємо залишковий вектор та його Євклідову норму
                Vector residual = b - A * x;
                residualNorm = residual.EuclideanNorm();
                iterations++; // Інкрементуємо лічильник ітерацій

            } while (iterations < maxIterations && residualNorm > tolerance); // Перевіряємо умови зупинки

            // Викидаємо виняток, якщо досягнута максимальна кількість ітерацій
            if (iterations == maxIterations)
            {
                throw new Exception("Метод не збігається або потрібно більше ітерацій.");
            }

            // Повертаємо результати: оновлений вектор x, кількість ітерацій та норму залишкового вектора
            return (x, iterations, residualNorm);
        }
    }
}
