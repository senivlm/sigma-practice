using System;
using System.Collections.Generic;
using System.Text;

namespace sigma_t5
{
    class Shadow2D
    {
        private static readonly char[] DEPTH = {' ', '`', '.', ',', '|', '^', '\'', '\\', '/', '~', '!', '_', '-', ';', ':', ')', '(', '"', '>', '<', '¬', '?', '*', '+', '7', 'j', '1', 'i', 'l',
            'J', 'y', 'c', '&', 'v', 't', '0', '$', 'V', 'r', 'u', 'o', 'I', '=', 'w', 'z', 'C', 'n', 'Y', '3', '2', 'L', 'T', 'x', 's', '4', 'Z', 'k', 'm',
            '5', 'h', 'g', '6', 'q', 'f', 'U', '9', 'p', 'a', 'O', 'S', '#', '£', 'e', 'X', '8', 'D', '%', 'b', 'd', 'R', 'P', 'G', 'F', 'K', '@', 'A', 'M',
            'Q', 'N', 'W', 'H', 'E', 'B'};
        private int _h, _w;
        private int[,] _shadow;
        public Shadow2D() : this(0, 0) { }

        public Shadow2D(int h, int w)
        {
            _h = h; _w = w;
            _shadow = new int[h, w];
        }
        
        public int this[int index1, int index2]
        {
            get { return _shadow[index1, index2]; }
            set { _shadow[index1, index2] = value; }
        }

        public override string ToString()
        {
            int sym, max = Max();
            float ratio;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < _h; i++)
            {
                for (int j = 0; j < _w; j++)
                {
                    ratio = max == 0 ? DEPTH.Length - 1 : (float)this[i, j] / max;
                    sym = (int)(ratio * (DEPTH.Length - 1));
                    sb.Append(string.Format("{0} ", DEPTH[sym]));
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public int Max()
        {
            int result = this[0, 0];
            for (int i = 0; i < _h; i++)
            {
                for (int j = 0; j < _w; j++)
                {
                    if (this[i, j] > result)
                        result = this[i, j];
                }
            }
            return result;
        }
    }
}
