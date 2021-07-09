using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandHelper helper = new CommandHelper();
            Console.WriteLine("Welcome to SchoolDB. Type 'Help' if you would like a list of commands.");

            while (true)
            {
                var command = Console.ReadLine();
                string[] commands = helper.ParseCommand(command);
                helper.ExecuteCommand(commands);
            }
        }
    }
}
