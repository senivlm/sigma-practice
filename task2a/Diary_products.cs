using System;
using System.Collections.Generic;
using System.Text;

namespace t1
{
    class Diary_products : Product
    {
        public long ExpirationDate { get; }

        public override float Price
        {
            get => base.Price;

            //set changes
            set
            {
                //changes price by passed value
                base.Price = value;
                //changes price by expiration date
                base.Price = ExpirationDate / 100.0f;
            }
        }

        public Diary_products() : base("", 0.0f, 0.0f) { }

        public Diary_products(string name, float weight, float price, long expirationDate) : base(name, weight, price)
        {
            this.ExpirationDate = expirationDate;
        }
    }
}
