using System;
using System.Collections.Generic;
using System.Text;

namespace t1
{
    static class Check
    {
        public static void Print(Buy buy)
        {
            Console.WriteLine("Purchase ID: {0};", buy.id);
            Console.WriteLine("Product: \n{0};", buy.Product);
            Console.WriteLine("Amount: {0};", buy.Amount);
            Console.WriteLine("Total: ${0:.00};", buy.Total);
        }
    }
}
