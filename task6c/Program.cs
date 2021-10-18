using System;

namespace task6c
{
    class Program
    {
        static void Main(string[] args)
        {
            int h, w;
            Console.Write("Generate matrix: \nHeight: ");
            h = Convert.ToInt32(Console.ReadLine());
            Console.Write("Width: ");
            w = Convert.ToInt32(Console.ReadLine());

            Matrix<int> m = new Matrix<int>(h, w);

            //MATRIX GENERATION
            for(int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    m[i, j] = j * (i + 1);
                }
            }
            Console.WriteLine(string.Format("\nGenerated matrix:\n{0}", m));

            Console.WriteLine("\nForeach:");
            int counter = 0;
            foreach(int el in m)
            {
                Console.Write(string.Format("{0}", el));
                if (++counter >= w) { Console.WriteLine(";"); counter = 0; }
                else Console.Write(", ");
            }
        }
    }
}
