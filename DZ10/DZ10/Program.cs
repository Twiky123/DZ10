using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Dz10
{
    delegate void ReactionToEventDelegate(string eventName);
    class Program
    {
        static public event ReactionToEventDelegate ReactionToEvent;

        static public List<List<Student>> DividesStudentsIntoGroups(List<Student> studentsList)
        {
            int firstElement = 0;
            List<List<Student>> studentsDividedByGroups = new List<List<Student>>();

            studentsList = studentsList.OrderBy(student => student.GroupNumber).ToList<Student>();

            for (int i = 1; i < studentsList.Count; i++)
            {
                if ((studentsList[i].GroupNumber != studentsList[i - 1].GroupNumber) || (i == studentsList.Count - 1))
                {
                    List<Student> studentsInOneGroup = new List<Student>();

                    for (int j = firstElement; j < i; j++)
                    {
                        studentsInOneGroup.Add(studentsList[j]);
                    }

                    studentsDividedByGroups.Add(studentsInOneGroup);
                    firstElement = i;
                }
            }

            if (studentsList[studentsList.Count - 1].GroupNumber == studentsList[studentsList.Count - 2].GroupNumber)
            {
                studentsDividedByGroups[studentsDividedByGroups.Count - 1].Add(studentsList[studentsList.Count - 1]);
            }
            else
            {
                List<Student> studentsInOneGroup = new List<Student> { studentsList[studentsList.Count - 1] };
                studentsDividedByGroups.Add(studentsInOneGroup);
            }

            return studentsDividedByGroups;
        }

        static void Main()
        {
            bool isTaskEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("Меню задач");

                Console.WriteLine("Подсказка:\n" +
                                  "Задание №1.           -   цифра 1\n" +
                                  "Задание №2.           -   цифра 2\n" +
                                  "Выйти из программы    -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":

                        Console.Clear();
                        Console.WriteLine("Задание 1");

                        string studentDataPath = "ProgramFiles/StudentData.txt";
                        string studetEventsPath = "ProgramFiles/StudentEventsData.txt";

                        bool isInputCompleted = false;

                        string[] studentDataArray = File.ReadAllLines(studentDataPath);
                        List<Student> studentsList = new List<Student>();

                        for (int i = 1; i < studentDataArray.Length; i++)
                        {
                            string[] studentDetailsArray = studentDataArray[i].Split(new string[] { " # " }, StringSplitOptions.RemoveEmptyEntries);

                            Student student = new Student(studentDetailsArray);
                            studentsList.Add(student);
                        }

                        List<List<Student>> studentsDividedByGroups = DividesStudentsIntoGroups(studentsList);

                        do
                        {
                            Console.Write("Чтобы закончить, введите ЗАКОНЧИТЬ. Чтобы продолжить, введите ЛЮБОЕ СЛОВО: ");
                            string finishingPhrase = Console.ReadLine();

                            if (finishingPhrase.ToLower() == "закончить")
                            {
                                isInputCompleted = true;
                                Console.Clear();
                            }
                            else
                            {
                                Console.Write("Введите дату мероприятия: ");
                                string eventDate = Console.ReadLine();
                                Console.Write("Введите описание мероприятия: ");
                                string eventDescription = Console.ReadLine();
                                Console.Write("Введите количество участников (целое число): ");
                                bool parseResult = int.TryParse(Console.ReadLine(), out int numberOfParticipants);

                                if (parseResult)
                                {
                                    StudentEvent studentEvent = new StudentEvent(eventDate, eventDescription, numberOfParticipants);
                                    studentEvent.AddEventToFile(studetEventsPath);

                                    studentEvent.SelectionOfParticipants(studentsDividedByGroups, studetEventsPath);

                                    File.WriteAllText(studentDataPath, String.Empty);
                                    File.AppendAllText(studentDataPath, studentDataArray[0] + "\n");

                                    for (int i = 0; i < studentsList.Count; i++)
                                    {
                                        string personData = $"{studentsList[i].StudentSurname} # {studentsList[i].StudentName} # {studentsList[i].GroupNumber} # {studentsList[i].NumberOfRecentEventsAttended}\n";
                                        File.AppendAllText(studentDataPath, personData);
                                    }

                                    Console.WriteLine("Файлы обновлены");

                                    Console.Write("Чтобы продолжить выполнение упражнения, нажмите на любую кнопку ");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Введенные данные некорректны");

                                    Console.Write("Чтобы продолжить выполнение упражнения, нажмите на любую кнопку ");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                        } while (!isInputCompleted);

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Задание 2");
                        string[] events = { "выход нового фильма", "концерт любимого исполнителя", "выход нового сезона сериала", "выход нового музыкального альбома" };

                        Person sanya = new Person("Саня", events[0], events[3]);
                        ReactionToEvent += sanya.ReactsToEvent;
                        Person danya = new Person("Даня", events[0], events[1], events[3]);
                        ReactionToEvent += danya.ReactsToEvent;
                        Person doonya = new Person("Дуня", events[2]);
                        ReactionToEvent += doonya.ReactsToEvent;

                        isInputCompleted = false;
                        string eventNumber;

                        do
                        {
                            Console.WriteLine("Подсказка:\n" +
                                              "Выход нового фильма                       -   цифра 1\n" +
                                              "Концерт любимого исполнителя              -   цифра 2\n" +
                                              "Выход нового сезона сериала               -   цифра 3\n" +
                                              "Выход нового музыкального альбома         -   цифра 4\n" +
                                              "Закончить выполнение задания и выйти      -   цифра 0\n");

                            Console.Write("Введите номер события: ");
                            eventNumber = Console.ReadLine();

                            switch (eventNumber)
                            {
                                case "1":
                                case "2":
                                case "3":
                                case "4":
                                    ReactionToEvent.Invoke(events[int.Parse(eventNumber) - 1]);

                                    Console.Write("Чтобы продолжить выполнение упражнения, нажмите на любую кнопку ");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;

                                case "0":
                                    isInputCompleted = true;
                                    Console.Clear();
                                    break;

                                default:
                                    Console.Clear();
                                    Console.WriteLine("Такого события нет");
                                    break;
                            }
                        } while (!isInputCompleted);
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("Завершние работы");
                        isTaskEnd = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Такого задания нет");
                        break;
                }
            } while (!isTaskEnd);
        }
    }
}