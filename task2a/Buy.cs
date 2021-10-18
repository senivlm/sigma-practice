using System;
using System.Collections.Generic;
using System.Text;

namespace t1
{
    class Buy
    {
        private static long buys = 0;
        public readonly long id;
        private List<Tuple<Product, int>> products;

        public float Total { 
            get
            {
                float result = 0;
                foreach(Tuple<Product, int> product in products)
                {
                    result += product.Item1.Price * product.Item2;
                }
                return result; 
            } 
        }

        public int Length
        {
            get { return this.products.Count; }
        }

        public Buy()
        {
            id = Buy.buys++;
            this.products = new List<Tuple<Product, int>>();
        }

        public void Add(Product product, int amount = 1)
        {
            this.products.Add(new Tuple<Product, int>(product, amount));
        }

        public Tuple<Product, int> this[int index]
        {
            get { return products[index]; }
            set { this.products[index] = value; }
        }

    }
}