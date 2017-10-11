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

namespace EDP.EDP24Collections
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Models.Student> VacinationQueue { get; set; } 
            = new ObservableCollection<Models.Student>();

        public MainWindow()
        {
            InitializeComponent();

            butAddStudent.Click += ButAddStudent_Click;
            butStabStudent.Click += ButStabStudent_Click;

            DataContext = this;
        }

        private void ButStabStudent_Click(object sender, RoutedEventArgs e)
        {
            VacinationQueue.RemoveAt(0);

            if (VacinationQueue.Count == 0)
            {
                butStabStudent.IsEnabled = false;
            }
        }

        private void ButAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Models.Student newStudent = new Models.Student(string.Empty, string.Empty);
            StudentAdd dlgStudentAdd = new StudentAdd(newStudent);
            if (dlgStudentAdd.ShowDialog() == true)
            {
                VacinationQueue.Add(newStudent);

                butStabStudent.IsEnabled = true;
            }
        }
    }
}
