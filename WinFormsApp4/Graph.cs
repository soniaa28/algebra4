using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class Graph
    {
        private int[,] matrix;
        private bool[] visited;
        private List<List<int>> paths;

        public Graph(int[,] adjacencyMatrix)
        {
            matrix = adjacencyMatrix;
            visited = new bool[matrix.GetLength(0)];
            paths = new List<List<int>>();
        }

        // Depth-first search to find all paths between fromVertex and toVertex
        private void DFS(int fromVertex, int toVertex, List<int> path)
        {
            visited[fromVertex] = true;
            path.Add(fromVertex);

            if (fromVertex == toVertex)
            {
                paths.Add(new List<int>(path));
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[fromVertex, i] == 1 && !visited[i])
                    {
                        DFS(i, toVertex, path);
                    }
                }
            }

            visited[fromVertex] = false;
            path.RemoveAt(path.Count - 1);
        }

        // Method to find all possible paths between fromVertex and toVertex
        public List<List<int>> FindAllPaths(int fromVertex, int toVertex)
        {
            paths.Clear();
            DFS(fromVertex, toVertex, new List<int>());
            return paths;
        }
    }
}
