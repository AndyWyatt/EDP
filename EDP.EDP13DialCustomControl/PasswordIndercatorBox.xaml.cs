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

namespace EDP.EDP13DialCustomControl
{
    /// <summary>
    /// Interaction logic for PasswordIndercatorBox.xaml
    /// </summary>
    public partial class PasswordIndercatorBox : UserControl
    {
        public string Password
        {
            get
            {
                return pbMain.Password;
            }
            set
            {
                pbMain.Password = value;

                ChangeColour();
            }
        }

        public string PasswordExpected { get; set; }

        public PasswordIndercatorBox()
        {
            InitializeComponent();

            DataContext = this;

            pbMain.PasswordChanged += PbMain_PasswordChanged;

            ChangeColour();
        }

        private void PbMain_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ChangeColour();
        }

        private void ChangeColour()
        {
            if (Password == PasswordExpected)
            {
                pbMain.Background = Brushes.Green;
            }
            else
            {
                pbMain.Background = Brushes.Red;
            }
        }
    }
}
