using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qmark
{
    public class Student
    {
        private string name;
        private int grade;
        public Student(string name, int grade)
        {
            this.name = name;
            this.grade = grade;
        }
        public int GetGrade()
        {
            return grade;
        }
        public override string ToString()
        {
            string str2return=name + " " + grade;
            return str2return;
        }
    }
}
