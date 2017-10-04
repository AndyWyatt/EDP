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

namespace EDP.EDP07Silly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void butNo_MouseEnter(object sender, MouseEventArgs e)
        {
            butNo.Visibility = Visibility.Hidden;
        }

        private void butYes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Oh yes you are!");
        }

        private void butMaybe_MouseEnter(object sender, MouseEventArgs e)
        {
            butMaybe.Visibility = Visibility.Hidden;
        }
    }
}
