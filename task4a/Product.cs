using System;
using System.Collections.Generic;
using System.Text;

namespace t1
{
    class Product
    {
        protected float price;
        protected DateTime DateOfManufacture { get; set; }
        protected long ExpiresAfter { get; set; }
        public string Name { get; set; }
        public virtual float Price 
        {
            get => this.price; 
            //set changes price by specified percent value
            set => this.price *= 1.0f + (value / 100.0f);
        }
        public float Weight { get; set; }

        public Product() : this("", 0.0f, 0.0f, 0) {}

        public Product(string name, float weight, float price, long expiresAfter) 
            : this(name, weight, price, DateTime.Now, expiresAfter) {}

        public Product(string name, float weight, float price, DateTime dateOfManufacture, long expiresAfter)
        {
            this.Name = name;
            this.price = price;
            this.Weight = weight;
            this.DateOfManufacture = dateOfManufacture;
            this.ExpiresAfter = expiresAfter;
        }

        // sets object's fields from string ("name, weight, price, dd.mm.yyyy, days")
        public virtual void Parse(string product)
        {
            string[] args = product.Split(',');
            if (args.Length < 5) throw new ArgumentException("Not enough parameters!");
            this.Name = args[0].Trim();
            this.Weight = float.Parse(args[1]);
            this.price = float.Parse(args[2]);
            string[] date = args[3].Split('.');
            if (date.Length < 3) throw new ArgumentException("Data should be formatted as follows: dd.mm.yyyy");
            this.DateOfManufacture = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));
            this.ExpiresAfter = long.Parse(args[3]);
        }

        public bool IsExpired() 
        {
            return IsExpired(DateTime.Now);
        }

        public bool IsExpired(DateTime byDate)
        {
            DateTime expirationDate = DateOfManufacture;
            expirationDate.AddDays(ExpiresAfter);
            if (DateTime.Compare(expirationDate, byDate) < 0)
                return false;
            return true;
        }

        public override string ToString()
        {
            return "  Name: " + this.Name + ";\n" +
                "  Weight: " + this.Weight + ";\n" +
                String.Format("  Price: ${0:.00}", this.Price);
        }
    }
}
