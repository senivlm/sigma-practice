using System;

namespace sigma_t4_b
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial p0 = Polynomial.Parse("1.11 + 2.22*x^1 + 10*x^2 + 0*x^3 + 5.55*x^4");
            Polynomial p1 = Polynomial.Parse("8.89 + 7.78*x^1 + 0*x^2 + 10*x^3 + 4.45*x^4");
            Console.WriteLine("Polynomial 1:\n" + p0.ToString());
            Console.WriteLine("Polynomial 2:\n" + p1.ToString());
            Console.WriteLine("\nSum:\n" + (p0 + p1).ToString());
            Console.WriteLine("Subtraction:\n" + (p0 - p1).ToString());
            Console.WriteLine("Multiplication:\n" + (p0 * p1).ToString());

            Polynomial p2 = Polynomial.Parse("-1 + 2*x^1 - 3*x^2 + 4*x^3 - 5*x^4");
            Console.WriteLine("\nPolynomial with negative coefficients:\n" + p2.ToString());

            bool again = true;
            string input;
            while (again)
            {
                Console.WriteLine("\nEnter your polynomial: ");
                input = Console.ReadLine();
                try 
                { 
                    p2 = Polynomial.Parse(input);
                    again = false;
                }
                catch (FormatException fe)
                {
                    again = true;
                    Console.WriteLine("An error occured:\n" + fe.Message + "\nTry Again!");
                }
            }
            Console.WriteLine("\nYour polynomial:\n" + p2.ToString());

            Console.Write("\nEnter real number: ");
            p0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Your polynomial (order == 0):");
            Console.WriteLine(p0);
        }
    }
}
