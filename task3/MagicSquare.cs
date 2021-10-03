using System;
using System.Collections.Generic;
using System.Text;

namespace sigma_t3
{
    class MagicSquare
    {
        public int Size { get; private set; }
        private int[,] square;

        public MagicSquare() : this(1) { }

        public MagicSquare(int size) {
            this.Size = size;
            this.square = new int[size, size];
            if (size % 2 == 1) generateOdd(size);
            else throw new ArgumentException("Size should be odd number!");
        }

        private void generateOdd(int size)
        {
            int col = size / 2,
                row = 0,
                curNum = 1,
                nRow, nCol;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.square[row, col] = curNum++;
                    nRow = row + (j >= size - 1 ? 1 : -1);
                    nCol = col + (j >= size - 1 ? 0 : 1);
                    row = nRow % size;
                    col = nCol % size;
                    if (row < 0) row += size;
                    if (col < 0) col += size;
                }
            }
        }

        public override string ToString()
        {
            int num = Size * Size;
            int counter = 0;
            while (num > 0)
            {
                num /= 10;
                counter++;
            }
            
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    sb.Append(string.Format("{0, " + counter + "} ", square[i, j]));
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
