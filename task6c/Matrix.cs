using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace task6c
{
    class Matrix<T> : IEnumerable<T>
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private T[,] matrix;

        public Matrix(int height, int width)
        {
            Width = width;
            Height = height;
            this.matrix = new T[height, width];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public T this[int row, int col]
        {
            get { return this.matrix[row, col]; }
            set
            {
                if (col < 0 || row < 0 || row >= Height || col >= Width)
                    throw new IndexOutOfRangeException();
                matrix[row, col] = value; 
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int maxLength = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (this[i, j].ToString().Length > maxLength)
                        maxLength = this[i, j].ToString().Length;
                }

            }
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append(string.Format("{0," + maxLength + "} ", this[i, j]));
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public class Enumerator : IEnumerator<T>
        {
            private Matrix<T> matrix;
            private int curCol, curRow;

            public T Current
            {
                get
                {
                    if (curRow < 0) throw new InvalidOperationException();
                    return matrix[curRow, curCol];
                }
            }
            object IEnumerator.Current
            {
                get
                {
                    if (curRow < 0) throw new InvalidOperationException();
                    return matrix[curRow, curCol];
                }
            }   

            internal Enumerator(Matrix<T> matrix)
            {
                this.matrix = matrix;
                curCol = matrix.Width;
                curRow = matrix.Height - 1;
            }

            public bool MoveNext()
            {
                //Console.WriteLine(Current);
                if (--curCol < 0)
                {
                    curCol = matrix.Width - 1;
                    curRow--;
                }
                if (curRow < 0) return false;
                return true;
            }

            public void Reset()
            {
                curCol = matrix.Width - 1;
                curRow = matrix.Height - 1;
            }

            public void Dispose()
            {
                curRow = -1;
            }
        }
    }
}
