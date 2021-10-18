using System;
using System.Collections.Generic;

namespace t1
{
    class Program
    {
        static List<Product> products = new List<Product>();
        static void Main(string[] args)
        {
            products.Add(new Product("Lenovo ThinkPad E14 Gen 3", 1.64f, 573.95f));
            products.Add(new Product("ASUS ZenBook Pro 14 UX480", 1.6f, 1075.10f));
            products.Add(new Product("Mi 9", 0.173f, 262.0f));
            products.Add(new Product("IPhone 13", 0.174f, 699.0f));

            Buy curBuy;
            for(int i = 0; i < products.Count; i++)
            {
                curBuy = new Buy(products[i]);
                curBuy.Amount = products.Count - i;
                Check.Print(curBuy);
                Console.WriteLine();
            }
        }
    }
}
