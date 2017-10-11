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

namespace EDP.EDP24Collections
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            butAddStudent.Click += ButAddStudent_Click;
        }

        private void ButAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Models.Student newStudent = new Models.Student(string.Empty, string.Empty);
            StudentAdd dlgStudentAdd = new StudentAdd(newStudent);
            if (dlgStudentAdd.ShowDialog() == true)
            {
                // Process the adding of the student
            }
        }
    }
}
