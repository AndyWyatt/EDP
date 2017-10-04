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

namespace EDP.EDP13Password
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            butEnterPassword.Click += ButEnterPassword_Click;
            butLogin.Click += ButLogin_Click;
        }

        private void ButLogin_Click(object sender, RoutedEventArgs e)
        {
            LogIn winLogIn = new LogIn();
            //winLogIn.OnDone += (s, e1) =>
            //{
            //    if (winLogIn.Username?.ToLower() == "andy" &&
            //        winLogIn.Password == "letmein")
            //    {
            //        rctLogin.Fill = new SolidColorBrush(Colors.Green);
            //    }
            //    else
            //    {
            //        rctLogin.Fill = new SolidColorBrush(Colors.Red);
            //    }
            //};
            if (winLogIn.ShowDialog() == true)
            {
                if (winLogIn.Username?.ToLower() == "andy" &&
                    winLogIn.Password == "letmein")
                {
                    rctLogin.Fill = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    rctLogin.Fill = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void ButEnterPassword_Click(object sender, RoutedEventArgs e)
        {
            //Hide();
            PasswordBox winPasswordBox = new PasswordBox();
            winPasswordBox.OnDone += WinPasswordBox_OnDone;
            winPasswordBox.OnCancel += WinPasswordBox_OnCancel;
            winPasswordBox.ShowDialog();
        }

        private void WinPasswordBox_OnCancel(object sender, EventArgs e)
        {
            
        }

        private void WinPasswordBox_OnDone(object sender, EventArgs e)
        {
            PasswordBox winPasswordBox = sender as PasswordBox;
            if (winPasswordBox.Password == "letmein")
            {
                MessageBox.Show("Welcome");
            }
            else
            {
                MessageBox.Show("Go Away!");
            }
        }
    }
}
