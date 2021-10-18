using System;
using System.Collections.Generic;
using System.Text;

namespace t1
{
    sealed class Check
    {
        public static string Print(Buy buy)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Purchase ID: {0};\n", buy.id));
            sb.Append("Products:\n");
            for(int i = 0; i < buy.Length; i++)
            {
                sb.Append(Print(buy[i].Item1, i));
                sb.Append(string.Format("Amount: {0};\n", buy[i].Item2));
            }
            sb.Append(string.Format("Total: ${0:.00};\n", buy.Total));
            return sb.ToString();
        }

        public static string Print(Storage storage)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < storage.Length; i++) {
                sb.Append(Print(storage[i], i));
            }
            return sb.ToString();
        }

        public static string Print(Product product, int index = -1)
        {
            StringBuilder sb = new StringBuilder();
            if (index >= 0) sb.Append(string.Format("Product {0}:\n", index));
            else sb.Append(string.Format("Product:\n"));
            if(product is Meat) sb.Append(string.Format("  Type: Meat;\n"));
            else if (product is Diary_products) sb.Append(string.Format("  Type: Diary;\n"));

            sb.Append(string.Format(product.ToString()) + "\n");
            return sb.ToString();
        }

    }
}
