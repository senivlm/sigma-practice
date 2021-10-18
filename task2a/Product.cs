using System;
using System.Collections.Generic;
using System.Text;

namespace t1
{
    class Product
    {
        protected float price;

        public string Name { get; set; }
        public virtual float Price 
        {
            get => this.price; 
            //set changes price by specified percent value
            set => this.price *= 1.0f + (value / 100.0f);
        }
        public float Weight { get; set; }

        public Product() : this("", 0.0f, 0.0f) {}
        
        public Product(string name, float weight, float price)
        {
            this.Name = name;
            this.price = price;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return "  Name: " + this.Name + ";\n" +
                "  Weight: " + this.Weight + ";\n" +
                String.Format("  Price: ${0:.00}", this.Price);
        }
    }
}
