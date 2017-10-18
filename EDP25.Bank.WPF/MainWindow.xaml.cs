﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EDP25.Bank.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<BO.BankAccount> Accounts { get; set; }

        public static DataLayer.Repository DB { get; set; } = new DataLayer.Repository();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            butAddAccount.Click += ButAddAccount_Click;
            butRemoveAccount.Click += ButRemoveAccount_Click;

            butRemoveAccount.IsEnabled = false;
            lbAccounts.SelectionChanged += LbAccounts_SelectionChanged;

            Accounts = new ObservableCollection<BO.BankAccount>(DB.BankAccountGetAll());
        }

        private void LbAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            butRemoveAccount.IsEnabled = lbAccounts.SelectedItem != null;
        }

        private void ButRemoveAccount_Click(object sender, RoutedEventArgs e)
        {
            BO.BankAccount selectedItem = lbAccounts.SelectedItem as BO.BankAccount;

            DB.BankAccountDelete(selectedItem);
            DB.SaveChanges();

            Accounts.Remove(selectedItem);
        }

        private void ButAddAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountAdd dlgAccountAdd = new AccountAdd();
            if (dlgAccountAdd.ShowDialog() == true)
            {
                BO.BankAccount account = new BO.BankAccount(
                    dlgAccountAdd.BankAccount.OwnerName,
                    dlgAccountAdd.BankAccount.Ballance);

                DB.BankAccountInsert(account);
                DB.SaveChanges();

                Accounts.Add(account);
            }
        }
    }
}
