using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP.EDP24Collections.Models
{
    public class Student
    {
        private static int _nextIdNumber = 3000000;

        public int Id { get; private set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        public Student(string forename, string surname)
        {
            Id = _nextIdNumber;
            _nextIdNumber++;
            Forename = forename;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"{Forename} {Surname} ({Id})";
        }
    }
}
