using System;
using System.Text;

namespace sigma_t3
{
    class Flat
    {
        // kWt values to store per quarter
        public const int VALUES = 4;

        private int current;
        private float[] vals = new float[VALUES];
        public int Quarter { get; set; }
        public int Number { get; private set; }
        public string Owner { get; set; }
        public int CurrentMonth
        {
            get { return current; }
        }
        public float Total 
        {
            get
            {
                return this.vals[current - 1] - this.vals[0];
            }
        }

        public Flat() : this(0, "", 0.0f) { }

        public Flat(int number, string owner, params float[] kWt)
        {
            this.Quarter = 1;
            this.Number = number;
            this.Owner = owner;
            this.current = kWt?.Length < VALUES ? kWt.Length : VALUES;
            for(int i = 0; i < current; i++)
            {
                this.vals[i] = kWt[i];
            }
        }

        public float this[int index]
        {
            get
            {
                if (index >= current)
                    return 0.0f;
                return this.vals[index];
            }
        }

        public void EndMonth(float kWt)
        {
            if (current < VALUES)
                this.vals[current++] = kWt;
        }

        public float CurrentDebt(float price)
        {
            return price * this.Total;
        }

        //returns total kWt for quarter
        public float EndQuarter()
        {
            float result = this.Total;
            this.vals[0] = this.vals[current - 1];
            for(int i = 1; i < current; i++)
            {
                this.vals[i] = 0.0f;
            }
            current = 1;
            return result;
        }

        //returns debt for current quarter
        public float EndQuarter(float price) { return price * this.EndQuarter(); }

        public string ToShortString()
        {
            return Number + ", " + Owner + ", " + string.Join(", ", vals);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Flat #" + Number + " belongs to " + Owner);
            DateTime month;
            for(int i = 0; i < VALUES - 1; i++)
            {
                if (vals[i + 1] < vals[i]) break;
                month = new DateTime(1971, (Quarter - 1) * 4 + i + 1, 1);
                sb.AppendLine(String.Format("\t{0}: {1:0.00} - {2:0.00} = {3:0.00} kWt", 
                    month.ToString("MMMM"), vals[i + 1], vals[i], vals[i + 1] - vals[i]));
            }
            return sb.ToString();
        }
    }
}
