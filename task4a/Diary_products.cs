using System;
using System.Collections.Generic;
using System.Text;

namespace t1
{
    class Diary_products : Product
    {
        public override float Price
        {
            get => base.Price;

            //set changes
            set
            {
                //changes price by passed value
                base.Price = value;
                //changes price by expiration date
                base.Price = ExpiresAfter / 100.0f;
            }
        }

        public Diary_products() : base("", 0.0f, 0.0f, 0) { }

        public Diary_products(string name, float weight, float price, long expiresAfter)
            : base(name, weight, price, expiresAfter) { }
        public Diary_products(string name, float weight, float price, DateTime dateOfManufacture, long expiresAfter)
            : base(name, weight, price, dateOfManufacture, expiresAfter) { }

        // sets object's fields from string ("Diary: name, weight, price, dd.mm.yyyy, days")
        public override void Parse(string product)
        {
            string[] args = product.Split(':');
            if (args.Equals("Diary") && args.Length >= 2)
                base.Parse(args[1].Trim());
            else
                throw new FormatException("Cannot parse diary product from this string!");
        }
    }
}
