using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class SparseToTapeMatrixConverter
    {
        public Matrix Matrix { get; set; }
        public int Diametr { get; set; }
        public StreamWriter? Writer { get; private set; }
        List<int> Powers { get; set; }

        public SparseToTapeMatrixConverter(Matrix matrix)
        {
            Matrix = new(matrix);
        }

        public (bool distanceExists, int distance) DijkstraAlgorithm(int startV, int endV)
        {
            // Отримуємо кількість вершин у графі
            int vertexesNum = Matrix.Rows;

            // Створюємо відсортований набір для відслідковування вершин та їх відстаней
            SortedSet<Tuple<int, int>> sortedSet = new SortedSet<Tuple<int, int>>();

            // Масив для зберігання найкоротших відстаней до кожної вершини
            int[] distances = new int[vertexesNum];

            // Ініціалізуємо всі відстані як нескінченні
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }

            // Додаємо початкову вершину до відсортованого набору
            sortedSet.Add(Tuple.Create(0, startV));
            distances[startV] = 0;

            // Починаємо цикл, поки не розглянемо всі вершини або не знайдемо кінцеву
            while (sortedSet.Count != 0)
            {
                // Беремо вершину з мінімальною відстанню
                int fromV = sortedSet.First().Item2;
                sortedSet.Remove(sortedSet.First());

                // Якщо ця вершина - кінцева, завершуємо алгоритм
                if (fromV == endV) break;

                // Обхід сусідів поточної вершини
                for (int j = 0; j < vertexesNum; ++j)
                {
                    int toV, weight;

                    // Якщо існує ребро між поточною вершиною та сусідньою
                    if (Matrix[fromV, j] == 1)
                    {
                        toV = j;
                        weight = 1; // Вагу ребра приймаємо як 1

                        // Перевіряємо, чи можна оновити відстань до сусідньої вершини
                        if (distances[toV] > distances[fromV] + weight)
                        {
                            distances[toV] = distances[fromV] + weight;
                            // Додаємо сусідню вершину до набору з новою відстанню
                            sortedSet.Add(Tuple.Create(distances[toV], toV));
                        }
                    }
                }
            }

            // Повертаємо відстань від початкової до кінцевої вершини
            // та індикатор існування шляху між ними
            return distances[endV] == int.MaxValue ? (false, -1) : (true, distances[endV]);
        }



        public int CalcDiametr()
        {
            Matrix w = new Matrix(Matrix);
            Matrix nextW = new Matrix(Matrix);
            Diametr = 1;

            do
            {
                nextW = MatrixMultiplication(nextW, w);
                Diametr++;
            } while (nextW.Data.Length != MatrixElementsSum(nextW));

            return Diametr;
        }

        public int Gibbs()
        {
            
            List<LevelsTable> tables = new();
            LevelsTable table = BuildLevels(GetIndexFirstVertexWithMinPower());
            do
            {
                if (tables.Count != 0)
                    table = tables.Max();
                foreach (var vertex in table[table.Count - 1])
                {
                    tables.Add(BuildLevels(vertex));
                }
            } while (tables.All((t) => t.Eccentricity != table.Eccentricity));

            return table[0].ElementAt(0);
        }

        public List<int> CutHillMckee()
        {
            int startVertex = Gibbs();
            List<int> vertexEnumeration = new();
            SortedSet<int> visitedVertexes = new();

            vertexEnumeration.Add(startVertex);
            visitedVertexes.Add(startVertex);
            List<Tuple<int, int>> vertexWithPower = new();
            int insertedCount = 1;

            do
            {
                List<int> range = vertexEnumeration.GetRange(visitedVertexes.Count - insertedCount, insertedCount);
                foreach (int vertex in range)
                {
                    for (int i = 0; i < Matrix.Cols; i++)
                    {
                        if (vertex != i && Matrix[vertex, i] == 1 && !visitedVertexes.Contains(i))
                        {
                            vertexWithPower.Add(new(i, Powers[i]));
                            visitedVertexes.Add(i);
                        }
                    }
                }

                vertexWithPower.Sort((a, b) => a.Item2.CompareTo(b.Item2));
                insertedCount = vertexWithPower.Count;
                foreach (var pair in vertexWithPower)
                {
                    vertexEnumeration.Add(pair.Item1);
                }
                vertexWithPower.Clear();

            } while (visitedVertexes.Count != Matrix.Rows);
            return vertexEnumeration;
        }

        public Matrix ConvertMatrix()
        {
            List<int> vertexEnumeration = CutHillMckee();
            Matrix resultMatrix = new(Matrix);
            for (int i = 0; i < resultMatrix.Rows; i++)
            {
                for (int j = 0; j < resultMatrix.Cols; ++j)
                {
                    resultMatrix[i, j] = Matrix[vertexEnumeration[i], vertexEnumeration[j]];
                }
            }

            Console.WriteLine(resultMatrix);
            return resultMatrix;
        }

        public LevelsTable BuildLevels(int startVertex)
        {
            int level = 0;

            SortedSet<int> levelCandidates = new SortedSet<int> { startVertex };
            SortedSet<int> usedVertexes = new SortedSet<int> { startVertex };

            LevelsTable levels = new(startVertex);

            while (levelCandidates.Count != 0)
            {
                levelCandidates.Clear();
                foreach (var vertex in levels[level])
                {
                    for (int j = 0; j < Matrix.Cols; ++j)
                    {
                        if (vertex == j || usedVertexes.Contains(j))
                            continue;
                        if ((int)Matrix[vertex, j] == 1)
                        {
                            levelCandidates.Add(j);
                            usedVertexes.Add(j);
                        }
                    }


                }

                ++level;
                levels.Add(new SortedSet<int>(levelCandidates));
            }

            levels.RemoveAt(levels.Count - 1);

            return levels;
        }

        public static Matrix MatrixMultiplication(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
            {
                throw new InvalidOperationException("Invalid matrix dimensions for multiplication");
            }

            Matrix result = new(a.Rows, b.Cols);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Cols; j++)
                {
                    for (int k = 0; k < a.Cols; k++)
                    {
                        result.Data[i, j] = (int)result.Data[i, j] | (int)(a.Data[i, k] * b.Data[k, j]);
                    }
                }
            }

            return result;
        }

        public double MatrixElementsSum(Matrix matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; ++j)
                {
                    sum += matrix[i, j];
                }
            }

            return sum;
        }

        public int GetIndexFirstVertexWithMinPower()
        {
            List<int> vertexesPowers = new List<int>();
            int vertexPower = 0;
            for (int i = 0; i < Matrix.Rows; i++)
            {
                for (int j = 0; j < Matrix.Cols; ++j)
                {
                    if (i == j)
                        continue;
                    if ((int)Matrix[i, j] == 1)
                        ++vertexPower;
                }

                vertexesPowers.Add(vertexPower);
                vertexPower = 0;
            }

            Powers = vertexesPowers;
            return vertexesPowers.IndexOf(vertexesPowers.Min());
        }
    }
}
