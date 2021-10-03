using System;
using System.IO;
using System.Text;

namespace sigma_t3
{
    
    class QuarterReport
    {
        public int Quarter { get; private set; }
        public int Amount { get { return flats.Length; } }
        private Flat[] flats;

        public QuarterReport() : this(1, 10) { }

        public QuarterReport(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                string[] args = file.ReadLine().Trim().Split(" ");
                flats = new Flat[int.Parse(args[0])];
                Quarter = int.Parse(args[1]);
                for(int i = 0; i < flats.Length; i++)
                {
                    args = file.ReadLine().Split(",");
                    flats[i] = new Flat(int.Parse(args[0]),
                                        args[1].Trim(),
                                        float.Parse(args[2]));
                    flats[i].Quarter = Quarter;
                    for(int j = 3; j < args.Length; j++)
                    {
                        if(float.Parse(args[j]) != 0)
                            flats[i].EndMonth(float.Parse(args[j]));
                    }
                }
            }
        }

        private QuarterReport(int quarter, int amount)
        {
            this.flats = new Flat[amount];
        }

        public Flat this[int index]
        {
            get
            {
                if(index < this.Amount)
                    return flats[index];
                return null;
            }
            set
            {
                if (index < this.Amount)
                    this.flats[index] = value;
            }
        }

        public static QuarterReport Random(int quarter, int amount)
        {
            Random rand = new Random();
            float kWt = (float)rand.NextDouble() * 1000.0f;
            QuarterReport result = new QuarterReport(quarter, amount);
            result.Quarter = quarter;
            for (int i = 0; i < amount; i++)
            {
                result[i] = new Flat(i + 1, "Owner " + (i + 1), kWt);
                result[i].Quarter = quarter;
                for (int j = 0; j < Flat.VALUES - 1; j++)
                {
                    kWt += (float)rand.NextDouble() * 100;
                    result[i].EndMonth(kWt);
                }
            }
            return result;
        }

        public Flat GetMaxDebt(float price = 1.0f)
        {
            int result = 0;
            float max = flats[0].CurrentDebt(price);
            float cur;
            for(int i = 1; i < Amount; i++)
            {
                if((cur = flats[i].CurrentDebt(price)) > max)
                {
                    result = i;
                    max = cur;
                }
            }
            return flats[result];
        }

        public Flat GetEmptyFlat()
        {
            for (int i = 1; i < Amount; i++)
            {
                if (flats[i].Total == 0.0f)
                {
                    return flats[i];
                }
            }
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("Report about {0} quarter from {1} flats:",
                Quarter, Amount));
            for(int i = 0; i < Amount; i++)
            {
                sb.Append(flats[i].ToString() + (i < Amount - 1 ? "\n" : ""));
            }
            return sb.ToString();
        }

        public void ToFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(Amount + " " + Quarter);
                for (int i = 0; i < Amount; i++)
                {
                    writer.Write(flats[i].ToShortString() + (i < Amount - 1 ? "\n" : ""));
                }
            }
        }
    }
}
