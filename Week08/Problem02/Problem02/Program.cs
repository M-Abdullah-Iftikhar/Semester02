using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem02.BL;

namespace Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("ali", "lahore", "CS", 2022, 8000.0F);
            Student s2 = new Student("bilal", "lahore", "CS", 2022, 9000.0F);


            Staff t1 = new Staff("Laiq", "Sargodha", "UET", 45000.0F);
            Staff t2 = new Staff("Irzam", "Sargodha", "UET", 44000.0F);

            List<Person> P = new List<Person>();



            
            P.Add(s1);
            P.Add(s2);
            P.Add(t1);
            P.Add(t1);

            foreach (Person p in P)
            {
                string str1 = p.toString();
                Console.WriteLine(str1);
            }
            Console.ReadKey();
        }
    }
}
