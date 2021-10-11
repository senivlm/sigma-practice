using System;
using System.Collections.Generic;
using System.Text;

namespace sigma_t4_b
{
    class Polynomial
    {
        private Dictionary<int, float> coefficients;

        public int Order
        {
            get
            {
                int max = 0;
                foreach (var order 
                    in this.coefficients.Keys)
                {
                    if (order > max) max = order;
                }
                return max;
            }
        }

        public Polynomial(params float[] coefficients)
        {
            this.coefficients = new Dictionary<int, float>();
            for (int i = 0; i < coefficients.Length; i++)
                this.coefficients.Add(i, coefficients[i]);
        }
        public Polynomial(Polynomial polynomial)
        {
            this.coefficients = new Dictionary<int, float>();
            foreach (KeyValuePair<int, float> mem in polynomial.coefficients)
            {
                this[mem.Key] = mem.Value;
            }
        }

        public static Polynomial Parse(string polynomial)
        {
            Polynomial result = new Polynomial();
            bool success = true;
            string[] adds = polynomial.Replace(" - ", " + -").Split(" + ");
            string[] add;
            try
            {
                result[0] = float.Parse(adds[0]);
                for(int i = 1; i < adds.Length; i++)
                {
                    add = adds[i].Trim().Split("*x^");
                    result[int.Parse(add[1])] = float.Parse(add[0]);
                }
            }
            catch (Exception) { success = false; }
            if(!success) throw new FormatException("Polynomial should be written in its canonical form!");
            return result;
        }

        public float this[int index]
        {
            get 
            {
                try { return coefficients[index]; } 
                catch (KeyNotFoundException) { return 0.0f; }
            }
            set 
            {
                float coef;
                if (coefficients.TryGetValue(index, out coef))
                {
                    if (value == 0)
                        coefficients.Remove(index);
                    else
                        coefficients[index] = value;
                }
                else if (value != 0)
                {
                    coefficients.Add(index, value);
                }
            }
        }

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            Polynomial result = new Polynomial(p1);
            foreach (KeyValuePair<int, float> mem in p2.coefficients)
            {
                result[mem.Key] += mem.Value;
            }
            return result;
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            Polynomial result = new Polynomial(p1);
            foreach (KeyValuePair<int, float> mem in p2.coefficients)
            {
                result[mem.Key] -= mem.Value;
            }
            return result;
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            Polynomial result = new Polynomial(p1);
            for (int i = 0; i < p2.Order + 1; i++)
            {
                result[i] *= p2[i];
            }
            return result;
        }

        public static implicit operator Polynomial(double num)
        {
            return new Polynomial((float)num);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0:0.00}", this[0]));
            for (int i = 1; i < this.Order + 1; i++)
            {
                sb.Append(string.Format((this[i] < 0 ? " -" : " +") + " {0:0.00}*x^{1}", Math.Abs(this[i]), i));
            }
            return sb.ToString();
        }
    }
}
