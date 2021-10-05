using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace t1
{
    class Storage
    {
        private List<Product> products;

        public int Length { 
            get
            {
                if (products == null)
                    return 0;
                return products.Count;
            }
        }

        public Storage() 
        {
            products = new List<Product>();
        }

        public Storage(params Product[] products)
        {
            setProducts(products);
        }

        public void ChangePrice(float percent)
        {
            for(int i = 0; i < products.Count; i++)
            {
                if (products[i] is Meat)
                    (products[i] as Meat).Price = percent;
                if (products[i] is Diary_products)
                    (products[i] as Diary_products).Price = percent;
            }
        }

        public void setProducts(params Product[] products)
        {
            for(int i = 0; i < products.Length; i++)
            {
                this.products.Add(products[1]);
            }
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

        public void Add(Product product)
        {
            this.products.Add(product);
        }

        public void RemoveExpired(string path) { this.RemoveExpired(path, DateTime.Now); }

        public void RemoveExpired(string path, DateTime byDate)
        {
            StringBuilder sb = new StringBuilder("Expired products to be removed:\n");
            bool removed = false;
            for (int i = 0; i < this.Length; i++)
                if (products[i].IsExpired(byDate))
                {
                    sb.Append($"Product {i}:\n" + products[i].ToString());
                    products.RemoveAt(i);
                    removed = true;
                }
            if (File.Exists(path)) throw new FileNotFoundException();
            if (!removed)
            {
                sb.Clear();
                sb.Append("Good news! There are not any expired products!");
            }
            using (StreamWriter writer = new StreamWriter(path))
                writer.Write(sb.ToString());

        }

        public void Read(string path)
        {
            bool error = false;
            string[] lines = null;
            try { lines = System.IO.File.ReadAllLines(path); }
            catch (Exception) { error = true; }
            if (error) throw new IOException("Cannot read file!");

            Product product = new Product();
            Diary_products diary = new Diary_products();
            Meat meat = new Meat();
            foreach(string line in lines)
            {
                try 
                {
                    meat.Parse(line);
                    this.Add(meat);
                    meat = new Meat();
                }
                catch (Exception)
                {
                    try
                    {
                        diary.Parse(line);
                        this.Add(diary);
                        diary = new Diary_products();
                    }
                    catch (Exception)
                    {
                        try
                        {
                            product.Parse(line);
                            this.Add(product);
                            product = new Product();
                        }
                        catch (Exception)
                        {
                            error = true;
                            break;
                        }
                    }
                }
                if (error) throw new FormatException("Cannot parse any type of product!");
            }
        }

        public override string ToString()
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
