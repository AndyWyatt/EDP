using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP.EDP01DelegateExample
{
    public class FlightController
    {
        public delegate void FlightChanged(string flightNo, int delay);

        public event FlightChanged OnFlightChanged;

        public void UpdateLogs(string flightNo, int delay)
        {
            Console.WriteLine("I'm updating log for " + flightNo);
        }

        public void UpdateDisplay(string flightNo, int delay)
        {
            Console.WriteLine("I've updated airport display for " + flightNo);
        }

        public void CheckIfFlightChanged()
        {
            // Lots of code that checks stuff
            if (true) // This would be a check of sort
            {
                OnFlightChanged("EZ999", 60);
            }
        }
    }
}
