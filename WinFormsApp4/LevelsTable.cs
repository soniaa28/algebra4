using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class LevelsTable : IComparable<LevelsTable>
    {
        public List<SortedSet<int>> Table { get; set; }

        public int Eccentricity { get => Table.Count; }

        public int Count { get => Table.Count; }

        public LevelsTable()
        {
            Table = new List<SortedSet<int>>();
        }

        public LevelsTable(int vertex)
        {
            Table = new List<SortedSet<int>> { new() { vertex } };
        }

        public void Add(int vertex, int level)
        {
            if (Table.Count <= level + 1)
            {
                Table[level].Add(vertex);
            }
            else
            {
                Table.Add(new SortedSet<int> { vertex });
            }
        }

        public void Add(SortedSet<int> sortedSet)
        {
            Table.Add(sortedSet);
        }

        public void RemoveAt(int index)
        {
            Table.RemoveAt(index);
        }
        public SortedSet<int> this[int row]
        {
            get
            {
                return Table[row];
            }
            set
            {
                Table[row] = value;
            }
        }

        public int CompareTo(LevelsTable other)
        {
            if (other == null)
            {
                return 1;
            }

            return Eccentricity.CompareTo(other.Eccentricity);
        }
    }
}
