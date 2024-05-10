using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    public class Vector
    {
        private double[] data;

        public Vector(int size)
        {
            data = new double[size];
        }

        public Vector(Vector b)
        {
            data = new double[b.Size];
            for (int i = 0; i < b.Size; i++)
            {
                data[i] = b[i];
            }
        }


        public double this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }

        public int Size => data.Length;

        public static Vector operator +(Vector a, Vector b)
        {
            if (a.Size != b.Size)
                throw new ArgumentException("Vector sizes do not match.");

            Vector result = new Vector(a.Size);
            for (int i = 0; i < a.Size; i++)
                result[i] = a[i] + b[i];
            return result;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            if (a.Size != b.Size)
                throw new ArgumentException("Vector sizes do not match.");

            Vector result = new Vector(a.Size);
            for (int i = 0; i < a.Size; i++)
                result[i] = a[i] - b[i];
            return result;
        }
        public static double operator *(Vector a, Vector b)
        {
            if (a.Size != b.Size)
                throw new ArgumentException("Vector sizes do not match.");

            double sum = 0;
            for (int i = 0; i < a.Size; i++)
                sum += a[i] * b[i];
            return sum;
        }
        public static Vector operator *(Vector v, double scalar)
        {
            Vector result = new Vector(v.Size);
            for (int i = 0; i < v.Size; i++)
            {
                result[i] = v[i] * scalar;
            }
            return result;
        }

        public double EuclideanNorm()
        {
            double sum = 0;
            for (int i = 0; i < Size; i++)
                sum += data[i] * data[i];
            return Math.Sqrt(sum);
        }

        public double MaxNorm()
        {
            double max = double.MinValue;
            for (int i = 0; i < Size; i++)
                if (Math.Abs(data[i]) > max)
                    max = Math.Abs(data[i]);
            return max;
        }
        public void CopyFrom(Vector other)
        {
            if (this.Size != other.Size)
                throw new ArgumentException("Vectors must be of the same size.");

            for (int i = 0; i < this.Size; i++)
            {
                this[i] = other[i];
            }
        }
    }
}
