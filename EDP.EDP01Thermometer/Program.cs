using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDP.EDP01Thermometer
{
    class Program
    {
        static void Main(string[] args)
        {
            PowerStation ps = new PowerStation();
            ps.Go();

            int option = 0;
            do
            {
                Console.WriteLine("1: Change vents");
                Console.WriteLine("2: Exit");
                Console.WriteLine("Please give option");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ps.VentsOpen = !ps.VentsOpen;
                        break;
                    case 2:
                        Console.WriteLine("Exiting");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            } while (option != 2);
        }
    }
}
