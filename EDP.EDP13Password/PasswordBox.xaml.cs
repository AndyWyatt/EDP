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
using System.Windows.Shapes;

namespace EDP.EDP13Password
{
    /// <summary>
    /// Interaction logic for PasswordBox.xaml
    /// </summary>
    public partial class PasswordBox : Window
    {
        public string Password { get; set; }

        public event EventHandler OnDone;
        public event EventHandler OnCancel;

        public PasswordBox()
        {
            InitializeComponent();

            DataContext = this;

            butCancel.Click += ButCancel_Click;
            butOK.Click += ButOK_Click;
        }

        private void ButOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
            OnDone?.Invoke(this, EventArgs.Empty);
        }

        private void ButCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
            OnCancel?.Invoke(this, EventArgs.Empty);
        }
    }
}
