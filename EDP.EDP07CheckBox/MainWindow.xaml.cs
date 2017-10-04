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

namespace EDP.EDP07CheckBox
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

        private void butPressMe_Click(object sender, RoutedEventArgs e)
        {
            int? age;
            if (cbSelected.IsChecked.HasValue && cbSelected.IsChecked.Value)
            {
                MessageBox.Show("I've been checked");
            }
            else
            {
                MessageBox.Show("I've not been checked");
            }
        }
    }
}
