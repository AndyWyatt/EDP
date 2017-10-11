using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace EDP.EDP13DialCustomControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _numebr;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Number
        {
            get
            {
                return _numebr;
            }
            set
            {
                _numebr = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Number"));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            butUp.Click += (o, s) =>
            {
                dial1.Value += 0.05;
                dial2.Value += 0.05;
                dial3.Value += 0.05;
            };
            butDown.Click += (o, s) =>
            {
                dial1.Value -= 0.05;
                dial2.Value -= 0.05;
                dial3.Value -= 0.05;
            };

            DataContext = this;
        }
    }
}
