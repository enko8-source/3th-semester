using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace PISPraktika1
{
    internal class Program
    {
        static void Main()
        {
            List<Lesson> lessons;

            if (File.Exists("lessons.txt"))
            {
                lessons = LoadFromFile("lessons.txt");
            }
            else
            {
                string[] inputs =
                {
                    "Lesson 2024.01.15 \"301\" \"Иванов И.И.\"",
                    "Lecture 2024.02.10 \"А-101\" \"Петров П.П.\" \"Основы ООП\" 90",
                    "PracticalLesson 2024.03.10 \"202\" \"Сидоров С.С.\" \"C# для чайников\" 15",
                    "Lesson 2024.05.20 \"15\" \"Иванов И.И.\"",
                    "PracticalLesson 2024.06.01 \"401\" \"Абрамов А.А.\" \"Алгоритмы\" 20"
                };

                lessons = new List<Lesson>();
                for (int i = 0; i < inputs.Length; i++)
                    lessons.Add(Parse(inputs[i]));
            }

            while (true)
            {
                Console.WriteLine("\n1 - добавить\n2 - выход\n3 - показать список\n4 - считать с файла");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Введите: Тип yyyy.mm.dd \"аудитория\" \"ФИО\" [свои поля]");
                    string input = Console.ReadLine();
                    lessons.Add(Parse(input));
                }
                else if (choice == "2")
                {
                    break;
                }
                else if (choice == "3")
                {
                    Listing(lessons);
                    
                }

                else if (choice == "4")
                {
                    Console.WriteLine("Введите имя файла:");
                    string path = Console.ReadLine();

                    if (File.Exists(path))
                    {
                        lessons = LoadFromFile(path);
                        Console.WriteLine("Загружено: " + lessons.Count);
                    }
                    else
                    {
                        Console.WriteLine("Файл не найден");
                    }
                }
            }
        }

        static List<Lesson> LoadFromFile(string path)
        {
            List<Lesson> lessons = new List<Lesson>();
            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
                lessons.Add(Parse(lines[i]));

            return lessons;
        }

        static void Listing(List<Lesson> lessons)
        {
            for (int i = 0; i < lessons.Count; i++)
            {
                Lesson l = lessons[i];

                if (l is Lecture lec)
                {
                    Console.WriteLine($"{lec.Date:dd.MM.yyyy} {lec.Classroom} {lec.Teacher} {lec.Topic} {lec.Duration}");
                }
                else if (l is PracticalLesson pr)
                {
                    Console.WriteLine($"{pr.Date:dd.MM.yyyy} {pr.Classroom} {pr.Teacher} {pr.Textbook} {pr.TasksNum}");
                }
                else
                {
                    Console.WriteLine($"{l.Date:dd.MM.yyyy} {l.Classroom} {l.Teacher}");
                }
            }
        }

        static Lesson Parse(string s)
        {
            string[] parts = s.Split('"');
            string[] head = parts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string type = head[0];
            string[] d = head[1].Split('.');
            DateTime date = new DateTime(int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]));

            switch (type)
            {
                case "Lesson":
                    return new Lesson(date, parts[1], parts[3]);

                case "Lecture":
                    {
                        // parts[0]="Lecture 2024... ", parts[1]=аудитория, parts[2]=" ",
                        // parts[3]=препод, parts[4]=" ", parts[5]=тема, parts[6]=" 90"
                        string topic = parts[5];
                        int duration = int.Parse(parts[6].Trim());
                        return new Lecture(date, parts[1], parts[3], topic, duration);
                    }

                case "PracticalLesson":
                    {
                        string textbook = parts[5];
                        int tasksNum = int.Parse(parts[6].Trim());
                        return new PracticalLesson(date, parts[1], parts[3], textbook, tasksNum);
                    }

                default:
                    throw new Exception("Неизвестный тип: " + type);
            }

          
        }

        static int Numb(List<Lesson> lessons)
        {
            int count = 0;

            DateTime minDate = lessons[0].Date;
            DateTime maxDate = lessons[0].Date;
            for (int i = 0; i < lessons.Count; i++)
            {
                if (lessons[i].Date < minDate)
                {
                    minDate = lessons[i].Date;
                }

                if (lessons[i].Date < maxDate)
                {
                    maxDate = lessons[i].Date;
                }
            }

            int daysCount = 0;
            for (DateTime date = minDate; date <= maxDate; date=date.AddDays(1))
            {
                daysCount++;
                for (int d = 0; d < lessons.Count; d++)
                {
                    if (lessons[d].Date==date)
                    {
                        count++;
                    }
                }
            }
            return daysCount - count;
        }
    }
}
