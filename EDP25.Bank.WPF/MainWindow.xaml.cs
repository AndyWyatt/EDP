using System;
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
        public ObservableCollection<BO.BankAccountNote> Notes { get; set; }

        public static DataLayer.Repository DB { get; set; } = new DataLayer.Repository();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            butAddAccount.Click += ButAddAccount_Click;
            butEditAccount.Click += ButEditAccount_Click;
            butRemoveAccount.Click += ButRemoveAccount_Click;

            butAddNote.Click += ButAddNote_Click;
            butRemoveNote.Click += ButRemoveNote_Click;

            butRemoveNote.IsEnabled = butAddNote.IsEnabled = butEditAccount.IsEnabled = butRemoveAccount.IsEnabled = false;
            lbAccounts.SelectionChanged += LbAccounts_SelectionChanged;
            lbNotes.SelectionChanged += LbNotes_SelectionChanged;

            Accounts = new ObservableCollection<BO.BankAccount>(DB.BankAccountGetAll());
            Notes = new ObservableCollection<BO.BankAccountNote>();
        }

        private void LbNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            butRemoveNote.IsEnabled = lbNotes.SelectedItem != null;
        }

        private void ButRemoveNote_Click(object sender, RoutedEventArgs e)
        {
            BO.BankAccountNote note = lbNotes.SelectedItem as BO.BankAccountNote;
            BO.BankAccount account = lbAccounts.SelectedItem as BO.BankAccount;

            if (note != null && account != null)
            {
                Notes.Remove(note);
                account.Notes.Remove(note);
                DB.BankAccountNoteDelete(note);
                DB.SaveChanges();
            }
        }

        private void ButAddNote_Click(object sender, RoutedEventArgs e)
        {
            NoteAdd dlgNoteAdd = new NoteAdd();
            if (dlgNoteAdd.ShowDialog() == true)
            {
                BO.BankAccountNote note = new BO.BankAccountNote(
                    lbAccounts.SelectedItem as BO.BankAccount,
                    dlgNoteAdd.Note);
                DB.SaveChanges();
                Notes.Add(note);
            }
        }

        private void ButEditAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountEdit dlgAccountEdit = new AccountEdit(lbAccounts.SelectedItem as BO.BankAccount);
            if (dlgAccountEdit.ShowDialog() == true)
            {
                DB.SaveChanges();
            }
        }

        private void LbAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            butEditAccount.IsEnabled = butRemoveAccount.IsEnabled = lbAccounts.SelectedItem != null;
            BO.BankAccount account = lbAccounts.SelectedItem as BO.BankAccount;
            Notes = account == null ? new ObservableCollection<BO.BankAccountNote>() : new ObservableCollection<BO.BankAccountNote>(account.Notes);
            lbNotes.ItemsSource = Notes;

            butAddNote.IsEnabled = account != null;
            butRemoveNote.IsEnabled = false;
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
