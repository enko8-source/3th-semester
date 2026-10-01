using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISPraktika1
{
    public class Lesson
    {
        public DateTime Date { get; set; }
        public string Classroom { get; set; }
        public string Teacher { get; set; }


        public Lesson(DateTime date, string classroom, string teacher)
        {
            Date = date.Date;
            Classroom = classroom;
            Teacher = teacher;
        }
    }
}
