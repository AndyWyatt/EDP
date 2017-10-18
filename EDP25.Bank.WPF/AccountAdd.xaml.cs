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

namespace EDP25.Bank.WPF
{
    /// <summary>
    /// Interaction logic for AccountAdd.xaml
    /// </summary>
    public partial class AccountAdd : Window
    {
        public Models.BankAccount BankAccount { get; set; }

        public AccountAdd()
        {
            InitializeComponent();

            BankAccount = new Models.BankAccount();

            DataContext = BankAccount;

            butCancel.Click += ButCancel_Click;
            butOk.Click += ButOk_Click;

            txtOwnerName.Focus();
        }

        private void ButOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void ButCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
