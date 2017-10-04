using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP.EDP01Thermometer
{
    public class Thermometer
    {
        private double previousTempreture;

        private double tempretureInC;
        public double TempretureInC
        {
            get
            {
                return tempretureInC;
            }
            set
            {
                previousTempreture = tempretureInC;

                tempretureInC = value;

                if (previousTempreture != tempretureInC)
                {
                    OnTempretureChanged?.Invoke(this);
                }
                if (previousTempreture < tempretureInC)
                {
                    OnIncreseOfTempreture?.Invoke(this);
                }
                if (previousTempreture > tempretureInC)
                {
                    OnDecreaseOfTempreture?.Invoke(this);
                }
                if (previousTempreture < SetPoint &&
                    tempretureInC >= SetPoint)
                {
                    OnAboveSetPoint?.Invoke(this);
                }
                if (previousTempreture > SetPoint &&
                    tempretureInC <= SetPoint)
                {
                    OnBelowSetPoint?.Invoke(this);
                }
            }
        }

        public double SetPoint { get; set; }

        public delegate void ThermometerHandler(Thermometer thermometer);

        public event ThermometerHandler OnTempretureChanged;
        public event ThermometerHandler OnAboveSetPoint;
        public event ThermometerHandler OnBelowSetPoint;
        public event ThermometerHandler OnIncreseOfTempreture;
        public event ThermometerHandler OnDecreaseOfTempreture;

        public Thermometer(int tempreture, int setPoint)
        {
            previousTempreture = tempretureInC = tempreture;
            SetPoint = setPoint;
        }
    }
}
