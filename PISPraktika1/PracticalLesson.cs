using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISPraktika1
{
    internal class PracticalLesson: Lesson
    {
        public string Textbook { get; set; }
        public int TasksNum { get; set; }

        public PracticalLesson(DateTime date, string classroom, string teacher, string textbook, int tasksnum)
    : base(date, classroom, teacher)
        {
            Textbook = textbook;
            TasksNum = tasksnum;
        }
    }
}
