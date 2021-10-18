using System;

namespace sigma_t3
{
    class Program
    {
        static void Main(string[] args)
        {

            // ODD-SIZED MAGIC SQUARE GENERATION
            int size;
            MagicSquare ms;
            while (true)
            {
                Console.Write("Enter magic square size (odd): ");
                size = int.Parse(Console.ReadLine());
                try
                {
                    ms = new MagicSquare(size);
                    Console.WriteLine(ms.ToString());
                    break;
                }
                catch (ArgumentException ae) 
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }
            }
        }
    }
}
