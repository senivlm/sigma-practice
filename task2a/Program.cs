using System;
using System.Collections.Generic;

namespace t1
{
    class Program
    {
        static List<Product> products = new List<Product>();
        static void Main(string[] args)
        {
            products.Add(new Meat("Chicken shin", 1.64f, 573.95f, Category.HighestGrade, Type.Chicken));
            products.Add(new Diary_products("Cheese", 1.6f, 1075.10f, 30));
            products.Add(new Meat("Thigh", 0.173f, 262.0f, Category.SecondGrade, Type.Pork));
            products.Add(new Diary_products("Milk", 0.174f, 699.0f, 5));

            //storage created
            Storage storage = new Storage(products.ToArray());
            //changed price
            storage.ChangePrice(10.0f);
            //printing info
            Console.WriteLine("In storage:");
            Console.WriteLine(storage.PrintInfo());
            //printing meat products
            Console.WriteLine("Meat products:");
            foreach(Product product in storage.getMeatProducts())
            {
                Console.WriteLine(Check.Print(product));
            }

            //creating new storage
            Console.Write("Create storage of size: ");
            int storageSize = Convert.ToInt32(Console.ReadLine());
            Product[] newProducts = new Product[storageSize];
            string name;
            int productType, type, category, expiration;
            float weight, price;
            Category newCategory;
            Type newType;
            for(int i = 0; i < storageSize; i++)
            {
                Console.Write("Enter product {0} name: ", i);
                name = Console.ReadLine();
                Console.Write("Enter product {0} type (1 - Meat, 2 - Diary, 3 - else): ", i);
                productType = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter product {0} weight: ", i);
                weight = (float)Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter product {0} price: ", i);
                price = (float)Convert.ToDouble(Console.ReadLine());
                switch(productType)
                {
                    case 1:
                        Console.Write("Enter meat type \n(1 - Mutton, 2 - Veal, 3 - Pork, 4 - Chicken): ", i);
                        type = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter meat category \n(1 - First grade, 2 - Second grade, 3 - Highest grade): ", i);
                        category = Convert.ToInt32(Console.ReadLine());
                        switch (type)
                        {
                            case 1:
                                newType = Type.Mutton;
                                break;
                            case 2:
                                newType = Type.Veal;
                                break;
                            case 3:
                                newType = Type.Pork;
                                break;
                            case 4:
                            default:
                                newType = Type.Chicken;
                                break;

                        }
                        switch (category)
                        {
                            case 1:
                                newCategory = Category.FirstGrade;
                                break;
                            case 2:
                                newCategory = Category.SecondGrade;
                                break;
                            case 3:
                            default:
                                newCategory = Category.HighestGrade;
                                break;

                        }
                        newProducts[i] = new Meat(name, weight, price, newCategory, newType);
                        break;
                    case 2:
                        Console.Write("Enter diary expiration time (days): ", i);
                        expiration = Convert.ToInt32(Console.ReadLine());
                        newProducts[i] = new Diary_products(name, weight, price, expiration);
                        break;
                    default:
                        newProducts[i] = new Product(name, weight, price);
                        break;
                }
                Console.WriteLine();
            }

            storage = new Storage(newProducts);
            Console.WriteLine("\nNew storage created:");
            Console.Write(storage.PrintInfo());
            Console.WriteLine();
        }
    }
}
