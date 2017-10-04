using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EDP.EDP13DialCustomControl
{
    /// <summary>
    /// Interaction logic for Dial.xaml
    /// </summary>
    public partial class Dial : UserControl
    {
        private double min = 0.0;
        public double Min
        {
            get
            {
                return min;
            }
            set
            {
                if (value <= Max)
                {
                    min = value;
                }
            }
        }
        private double max = 1.0;
        public double Max
        {
            get
            {
                return max;
            }
            set
            {
                if (value >= Min)
                {
                    max = value;
                }
            }
        }
        private double _value = 0.0;
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value < Min)
                {
                    _value = Min;
                }
                else if (value > Max)
                {
                    _value = Max;
                }
                else
                {
                    _value = value;
                }

                double bottomAngle = -132.0;
                double topAngle = 132.0;
                double percent = (this._value + Min) / (Min + Max);
                double angle = (topAngle - bottomAngle) * percent + bottomAngle;
                rtNeedleAngle.Angle = angle;
            }
        }

        public Dial()
        {
            InitializeComponent();

            //DispatcherTimer dispatcherTimer = new DispatcherTimer();
            //dispatcherTimer.Tick += new EventHandler(AnimateTick);
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            //dispatcherTimer.Start();
        }

        //private void AnimateTick(object sender, EventArgs e)
        //{
        //    rtNeedleAngle.Angle += 0.1;
        //}
    }
}
