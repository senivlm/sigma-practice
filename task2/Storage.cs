using System;
using System.Collections.Generic;
using System.Text;

namespace t1
{
    class Storage
    {
        private Product[] products;

        public int Length { 
            get
            {
                if (products == null)
                    return 0;
                return products.Length;
            }
        }

        public Storage() 
        {
            products = new Product[0];
        }

        public Storage(params Product[] products)
        {
            setProducts(products);
        }

        public void ChangePrice(float percent)
        {
            for(int i = 0; i < products.Length; i++)
            {
                if (products[i] is Meat)
                    (products[i] as Meat).Price = percent;
                if (products[i] is Diary_products)
                    (products[i] as Diary_products).Price = percent;
            }
        }

        public void setProducts(params Product[] products)
        {
            this.products = products;
        }

        public Product[] getMeatProducts()
        {
            List<Product> meat = new List<Product>();
            for (int i = 0; i < Length; i++)
            {
                if (this[i] is Meat)
                    meat.Add(this[i]);
            }
            return meat.ToArray();
        }

        public string PrintInfo()
        {
            return Check.Print(this);
        }

        public Product this[int index] 
        {
            get { return products[index]; }
            set { products[index] = value; }
        }
    }
}
