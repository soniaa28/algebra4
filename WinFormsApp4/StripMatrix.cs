using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class StripMatrix
    {
        private double[] data;
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        private int lowerStripWidth;
        private int upperStripWidth;
        public int LowerStripWidth { get { return lowerStripWidth; } }
        public int UpperStripWidth { get { return upperStripWidth; } }


        public StripMatrix(int rows, int cols, int lowerStripWidth, int upperStripWidth)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.lowerStripWidth = lowerStripWidth;
            this.upperStripWidth = upperStripWidth;
            this.data = new double[rows * (lowerStripWidth + upperStripWidth + 1)];
        }

        public double this[int i, int j]
        {
            get
            {
                int index = (j - i + lowerStripWidth) + i * (lowerStripWidth + upperStripWidth + 1);
                if (i >= 0 && i < Rows && j >= 0 && j < Cols && Math.Abs(j - i) <= Math.Max(lowerStripWidth, upperStripWidth))
                    return data[index];
                else
                    return 0;
            }
            set
            {
                int index = (j - i + lowerStripWidth) + i * (lowerStripWidth + upperStripWidth + 1);
                if (i >= 0 && i < Rows && j >= 0 && j < Cols && Math.Abs(j - i) <= Math.Max(lowerStripWidth, upperStripWidth))
                    data[index] = value;
            }
        }

    }
}
