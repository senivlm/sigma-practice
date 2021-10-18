using System;
using System.Collections.Generic;
using System.Text;

namespace t1
{
    class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }

        public Product() : this("", 0.0f, 0.0f) {}
        
        public Product(string name, float weight, float price)
        {
            this.Name = name;
            this.Price = price;
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
