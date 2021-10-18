using System;
using System.Collections.Generic;
using System.Text;

namespace sigma_t5
{
    class Shape3D
    {
        private bool[,,] _shape;
        private int _h, _w, _d;
        public Shape3D(int h, int w, int d)
        {
            _h = h; _w = w; _d = d;
            _shape = new bool[h, w, d];
        }
        public Shape3D(int dim) : this(dim, dim, dim) { }

        public bool this[int index1, int index2, int index3]
        {
            get { return _shape[index1, index2, index3]; }
            set 
            { 
                if(index1 >= 0 && index2 >= 0 && index3 >= 0 &&
                    index1 < _h && index2 < _w && index3 < _d)
                    _shape[index1, index2, index3] = value; 
            }
        }

        public static Shape3D Sphere(int d)
        {
            const int offset = 1;
            int x, y, z,
                r = d / 2,
                dim = r * 2 + offset * 2 + 1;
            Shape3D result = new Shape3D(dim);
            double dist;
            for (x = 0; x <= r * 2; x++)
            {
                for (y = 0; y <= r * 2; y++)
                {
                    for (z = 0; z <= r * 2; z++)
                    {
                        dist = Math.Sqrt(Math.Pow(x - r, 2) +
                            Math.Pow(y - r, 2) +
                            Math.Pow(z - r, 2));
                        result[x + offset, y + offset, z + offset] = dist > r ? false : true;
                    }
                }
            }
            return result;
        }
        public static Shape3D Random(int d)
        {
            if (d < 3) throw new ArgumentException();
            Random rand = new Random();
            const int offset = 1;
            Shape3D result = new Shape3D(d + offset * 2);
            for (int i = 0; i < Math.Pow(d, 3) / 2; i++)
            {
                int[] pos = new int[3];
                for(int j = 0; j < 3; j++)
                {
                    // random Gaussian number generator
                    pos[j] = (int)(d/2 + (d / 10) *
                        (Math.Sqrt(-2.0 * Math.Log(1.0 - rand.NextDouble())) *
                        Math.Sin(2.0 * Math.PI * (1.0 - rand.NextDouble()))));
                }
                result[pos[0], pos[1], pos[2]] = true;
            }
            return result;
        }

        public Shadow2D shadowXY()
        {
            Shadow2D result = new Shadow2D(_h, _w);
            for (int x = 0; x < _h; x++)
            {
                for (int y = 0; y < _w; y++)
                {
                    for (int z = 0; z < _d; z++)
                    {
                        if (this[x, y, z]) result[x, y]++;
                    }
                }
            }
            return result;
        }
        public Shadow2D shadowYZ()
        {
            Shadow2D result = new Shadow2D(_w, _d);
            for (int x = 0; x < _h; x++)
            {
                for (int y = 0; y < _w; y++)
                {
                    for (int z = 0; z < _d; z++)
                    {
                        if (this[x, y, z]) result[y, z]++;
                    }
                }
            }
            return result;
        }
        public Shadow2D shadowXZ()
        {
            Shadow2D result = new Shadow2D(_h, _d);
            for (int x = 0; x < _h; x++)
            {
                for (int y = 0; y < _w; y++)
                {
                    for (int z = 0; z < _d; z++)
                    {
                        if (this[x, y, z]) result[x, z]++;
                    }
                }
            }
            return result;
        }
    }
}
