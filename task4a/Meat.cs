using System;
using System.Collections.Generic;
using System.Text;

namespace t1
{
    enum Category
    {
        HighestGrade = 25,
        FirstGrade = 15,
        SecondGrade = 10
    }

    enum Type
    {
        Mutton, 
        Veal,
        Pork,
        Chicken
    }

    class Meat : Product
    {

        public override float Price { 
            get => base.Price;

            //set changes
            set
            {
                //changes price by passed value
                base.Price = value;
                //changes price by category constant
                base.Price = (int)Category;
            }
        }

        public Category Category { get; private set; }
        public Type Type { get; private set; }

        public Meat() : base("", 0.0f, 0.0f, 0) { }

        public Meat(string name, float weight, float price, long expiresAfter, Category category, Type type)
            : base(name, weight, price, expiresAfter)
        {
            this.Category = category;
            this.Type = type;
        }

        public Meat(string name, float weight, float price, DateTime dateOfManufacture, long expiresAfter, Category category, Type type)
            : base(name, weight, price, dateOfManufacture, expiresAfter)
        {
            this.Category = category;
            this.Type = type;
        }

        // sets object's fields from string ("Meat, category(0|1|2), type(0|1|2|3): name, weight, price, dd.mm.yyyy, days")
        public override void Parse(string product)
        {
            string[] args = product.Split(':');
            if(args.Length < 2)
                throw new FormatException("Cannot parse meat product from this string!");
            string[] arg = args[0].Split(", ");
            if(arg.Length < 3 || !arg[0].Equals("Meat"))
                throw new FormatException("Cannot parse meat product from this string!");
            switch (int.Parse(arg[1]))
            {
                case 0:
                    this.Category = Category.HighestGrade;
                    break;
                case 1:
                    this.Category = Category.FirstGrade;
                    break;
                case 2:
                    this.Category = Category.SecondGrade;
                    break;
                default:
                    throw new ArgumentException("No such category!");
            }
            int type = int.Parse(arg[2]);
            if(type > 3 || type < 0) throw new ArgumentException("No such type!");
            base.Parse(args[1]);
        }
    }
}
