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

        public Category Category { get; }
        public Type Type { get; }

        public Meat() : base("", 0.0f, 0.0f) { }

        public Meat(string name, float weight, float price, Category category, Type type) : base(name, weight, price)
        {
            this.Category = category;
            this.Type = type;
        }
    }
}
