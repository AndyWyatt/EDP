using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP.EDP01DelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightController fc = new FlightController();

            fc.OnFlightChanged += fc.UpdateLogs;
            fc.OnFlightChanged += fc.UpdateDisplay;
            fc.OnFlightChanged += SendEmailToCustomers;

            fc.CheckIfFlightChanged();
        }

        private static void SendEmailToCustomers(string flightNo, int delay)
        {
            Console.WriteLine("Sending email to customers about " + flightNo);
        }
    }
}
