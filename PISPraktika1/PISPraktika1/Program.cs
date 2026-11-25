using System;
using System.Collections.Generic;

namespace PISPraktika1
{

    internal class Program
    {
        static void Main()
        {
            string[] inputs =
            {
                "Lesson 2024.01.15 \"301\" \"Иванов И.И.\"",
                "Lesson 2024.09.01 \"А-101\" \"Петров П.П.\"",
                "Lesson 2024.03.10 \"202\" \"Сидоров С.С.\"",
                "Lesson 2024.05.20 \"15\" \"Иванов И.И.\"",
                "Lesson 2024.02.01 \"401\" \"Абрамов А.А.\""
            };

            List<Lesson> lessons = new List<Lesson>();

            for (int i = 0; i < inputs.Length; i++)
                lessons.Add(Parse(inputs[i]));

            while (true)
            {
                Console.WriteLine("Вы хотите добавить новый объект?\n 1 - да\n 2 - нет\n 3 - хочу просмотреть список");
                string WonnaNew = Console.ReadLine();
                if (WonnaNew == "1")
                {
                    Console.WriteLine("Введите новые данные в формате Lesson yyyy.mm.dd \"аудитория\" \"ФИО\"");
                    string input = Console.ReadLine();
                    lessons.Add(Parse(input));
                }

                if (WonnaNew == "2")
                {
                    break;
                }
                if (WonnaNew == "3")
                {
                    Listing(lessons);                        
                }
            }
        }


        static void Listing(List<Lesson> lessons)
        {
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine(lessons[i].Date.ToString("dd.MM.yyyy") + " " + lessons[i].Classroom + " " + lessons[i].Teacher);
            }
        }

        static Lesson Parse(string s)
        {
            string[] parts = s.Split('"');
            string[] head = parts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] d = head[1].Split('.');

            DateTime date = new DateTime(int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]));

            return new Lesson(date, parts[1], parts[3]);
        }
    }
}