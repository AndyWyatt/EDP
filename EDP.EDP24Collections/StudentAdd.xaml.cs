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

namespace EDP.EDP24Collections
{
    /// <summary>
    /// Interaction logic for StudentAdd.xaml
    /// </summary>
    public partial class StudentAdd : Window
    {
        public Models.Student Student { get; set; }

        public StudentAdd()
        {
            InitializeComponent();

            butCancel.Click += ButCancel_Click;

            butOK.Click += ButOK_Click;
        }

        public StudentAdd(Models.Student student) : this()
        {
            Student = student;

            DataContext = Student;
        }

        private void ButOK_Click(object sender, RoutedEventArgs e)
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
