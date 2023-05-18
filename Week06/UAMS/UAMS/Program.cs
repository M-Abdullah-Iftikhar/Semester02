using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine(currentTime);



            // Declare two dates
            var prevDate = new DateTime(2023, 1, 15); //15 July 2021
            var today = DateTime.Now;

            //get difference of two dates
            var diffOfDates = today - prevDate;

            Console.WriteLine("Difference in Timespan: {0}", diffOfDates);
            Console.WriteLine("Difference in Days: {0}", diffOfDates.Days);
            Console.WriteLine("Difference in Hours: {0}", diffOfDates.Hours);
            Console.WriteLine("Difference in Miniutes: {0}", diffOfDates.Minutes);
            Console.WriteLine("Difference in Seconds: {0}", diffOfDates.Seconds);
            Console.WriteLine("Difference in Milliseconds: {0}", diffOfDates.Milliseconds);
            Console.WriteLine("Difference in Ticks: {0}", diffOfDates.Ticks);

            Console.ReadKey();
        }
    }
}
