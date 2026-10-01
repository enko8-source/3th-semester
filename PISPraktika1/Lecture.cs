using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISPraktika1
{
    internal class Lecture: Lesson
    {
        public string Topic { get; set; }
        public int Duration { get; set; }

        public Lecture(DateTime date, string classroom, string teacher, string topic, int duration)
    : base(date, classroom, teacher)
        {
            Topic = topic;
            Duration = duration;
        }

    }
}
