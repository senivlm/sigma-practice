using System;

namespace sigma_t3
{
    class Program
    {
        static void Main(string[] args)
        {
            // FILE GENERATION
            QuarterReport genQR = QuarterReport.Random(2, 10);
            genQR.ToFile("input.txt");

            // READING FROM FILE
            QuarterReport qr = new QuarterReport("input.txt");
            Console.WriteLine(qr.ToString());

            // OWNER WHO DID NOT USE ELICTRICITY
            Flat result = qr.GetEmptyFlat();
            if(result == null)
                Console.WriteLine("\nEverybody has been using electricity this quarter.");
            else
                Console.WriteLine(String.Format("\n{0} from flat #{1} didn't use electricity this quarter.",
                result.Owner, result.Number));

            // THE HIGHEST DEBT
            Console.Write("\nEnter electricity price: ");
            float price = float.Parse(Console.ReadLine());
            result = qr.GetMaxDebt(price);
            Console.WriteLine(String.Format("{0} from flat #{1} has the highest debt(${2:0.00}).",
                result.Owner, result.Number, result.CurrentDebt(price)));

            // INFO ABOUT ONE QUARTER
            Console.Write("\nEnter flat number: ");
            int number = int.Parse(Console.ReadLine());
            result = qr[number - 1];
            Console.WriteLine(result.ToString() + String.Format("\tTotal: {0:0.00}kWt", result.Total));
        }
    }
}
