using System;
using System.Text.RegularExpressions;

namespace sigma_t5
{
    class Program
    {
        static void Main(string[] args)
        {
            //TASK 1
            string input = "#This program is #to make\n #this \ntext# beautifully# formatted#";
            Console.WriteLine("TASK 1:");
            Console.WriteLine("Input text:\n" + input);
            Console.WriteLine("\nResult:\n" + Formatter.AngleBrackets(input));

            //TASK 2
            Console.WriteLine("\n\nTASK 2:");
            Shape3D s;
            int size = 50;
            Console.Write("Enter shape size (default " + size + "): ");
            try { size = Convert.ToInt32(Console.ReadLine()); }
            catch (FormatException) {}
            Console.Write("\nSelect shape:\n1.Random\n2.Sphere\nEnter selection (default: Random) [1..2] ");
            switch (Console.ReadLine())
            {
                case "2": 
                    s = Shape3D.Sphere(size);
                    break;
                default:
                    s = Shape3D.Random(size);
                    break;
            }
            Console.WriteLine("\nShadow XY:\n" + s.shadowXY());
            Console.WriteLine("Shadow YZ:\n" + s.shadowYZ());
            Console.WriteLine("Shadow XZ:\n" + s.shadowXZ());

            //TASK 2
            Console.WriteLine("\n\nTASK 2:");
            Console.Write("Enter file path: ");
            input = Console.ReadLine();
            PathSplitter ps = new PathSplitter(input);
            Console.WriteLine("File name:\n" + ps.GetFileName(true) + "  (with extension)\n" +
                ps.GetFileName() + "  (without extension)");
            Console.WriteLine("\nFile root directory:\n" + ps.GetRootDir());
        }
    }
}