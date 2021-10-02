using System;
using System.Collections.Generic;
using System.Text;

namespace t1
{
    class Buy
    {
        private static long buys = 0;

        public readonly long id;

        public int Amount { get; set; }
        public Product Product { get; }
        public float Total { get{ return this.Product.Price * Amount; } }

        public Buy(Product product)
        {
            id = Buy.buys++;
            this.Product = product;
        }

    }
}