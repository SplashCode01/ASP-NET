using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolList
{
    class Program
    {
        static void Main(string[] args)
        {
            School s = new School();
            s.AddPerson("Shota");
            s.GetPersonPoint("Shota");
            s.SetPoint("Shota", 10);

            s.GetPersonPoint("Arkadi");
            s.RemovePerson("Arkadi");

            s.RemovePerson("Shota");

            s.AddPerson("Levan");
            s.SetPoint("Levan", 10);
            s.GetPersonPoint("Levan");

            Console.ReadKey();
        }
    }
}
