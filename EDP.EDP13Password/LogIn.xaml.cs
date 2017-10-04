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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public event EventHandler OnDone;
        public event EventHandler OnCancel;

        public LogIn()
        {
            InitializeComponent();

            DataContext = this;

            butCancel.Click += ButCancel_Click;
            butOK.Click += ButOK_Click;

            txtUsername.Focus();
        }

        private void ButOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
            OnDone?.Invoke(this, EventArgs.Empty);
        }

        private void ButCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
            OnCancel?.Invoke(this, EventArgs.Empty);
        }
    }
}
