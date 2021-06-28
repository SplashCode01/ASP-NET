using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolList
{
    public class School : ISchoolList
    {
        private Dictionary<string, int> _students;

        public School()
        {
            _students = new Dictionary<string, int>();
        }

        // I can also make the checks for whether a person exists by using
        // _students.TryGetValue()
        public void AddPerson(string name)
        {
            try
            {
                _students.Add(name, -1);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"{name} is already in the school list!");
                return;
            }
            Console.WriteLine($"{name} has been added to the school list.");
        }

        public void GetPersonPoint(string name)
        {
            if (!_students.ContainsKey(name))
            {
                Console.WriteLine($"{name} hasn't been added to the school list!");
            }
            else if (_students[name] == -1)
            {
                Console.WriteLine($"{name} hasn't been assigned points yet!");
            }
            else
            {
                Console.WriteLine($"{name} has accrued {_students[name]} points!");
            }
        }

        public void RemovePerson(string name)
        {
            if (_students.ContainsKey(name))
            {
                _students.Remove(name);
                Console.WriteLine($"{name} has been removed from the school list.");
            }
            else
            {
                Console.WriteLine($"{name} hasn't been added to the school list!");
            }
        }

        public void SetPoint(string name, int point)
        {
            if (!_students.ContainsKey(name))
            {
                Console.WriteLine($"{name} hasn't been added to the school list.");
            }
            else
            {
                _students[name] = point;
                Console.WriteLine($"{name} has been assigned {point} points!");
            }
        }
    }
}
