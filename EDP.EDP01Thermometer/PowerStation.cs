using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDP.EDP01Thermometer
{
    public class PowerStation
    {
        public Thermometer CoreThermo { get; private set; }
        public Thermometer CoreAmbThermo { get; private set; }
        public Thermometer ExorstThermo { get; private set; }

        public bool SprinklersOn { get; set; }
        public bool VentsOpen { get; set; }
        public bool SoundAlarm { get; private set; }
        public double WatherFlow { get; private set; }

        public PowerStation()
        {
            CoreThermo = new Thermometer(24, 70);
            CoreAmbThermo = new Thermometer(24, 40);
            ExorstThermo = new Thermometer(24, 100);

            CoreThermo.OnAboveSetPoint += CoreThermo_OnAboveSetPoint;
            CoreThermo.OnBelowSetPoint += CoreThermo_OnBelowSetPoint;
            CoreAmbThermo.OnAboveSetPoint += CoreAmbThermo_OnAboveSetPoint;
        }

        private void CoreThermo_OnBelowSetPoint(Thermometer thermometer)
        {
            SoundAlarm = false;
        }

        private void CoreAmbThermo_OnAboveSetPoint(Thermometer thermometer)
        {
            VentsOpen = true;
            Console.WriteLine("OPENING VENTS - IT'S GETTING HOT IN HERE.");
        }

        private void CoreThermo_OnAboveSetPoint(Thermometer thermometer)
        {
            SprinklersOn = true;
            VentsOpen = true;
            SoundAlarm = true;
            WatherFlow = 2.0;
        }

        public void Go()
        {
            Task.Run(BackgroundRunningTask);
        }

        private Task BackgroundRunningTask()
        {
            while (true)
            {
                CoreThermo.TempretureInC += 0.2;
                CoreAmbThermo.TempretureInC += 0.1;

                if (SprinklersOn)
                {
                    CoreThermo.TempretureInC -= 0.5;
                    CoreAmbThermo.TempretureInC -= 0.1;
                }
                if (VentsOpen)
                {
                    CoreThermo.TempretureInC -= 0.25;
                    CoreAmbThermo.TempretureInC -= 0.11;
                }
                CoreThermo.TempretureInC -= WatherFlow * 0.1;

                PrintSatusOfPowerStation();

                Thread.Sleep(250);
            }
        }

        private void PrintSatusOfPowerStation()
        {
            Console.WriteLine("Core temp = " + CoreThermo.TempretureInC);
            Console.WriteLine("Amb  temp = " + CoreAmbThermo.TempretureInC);
            Console.WriteLine("Exor temp = " + ExorstThermo.TempretureInC);

            if (SoundAlarm)
            {
                Console.WriteLine("ALARM!");
            }
        }
    }
}
