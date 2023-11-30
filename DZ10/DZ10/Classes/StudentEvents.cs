using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Dz10
{
    class StudentEvent
    {
        private string studentEventDate;
        private string studentEventDescription;
        private int numberOfParticipants;


        public string StudentEventDate
        {
            get
            {
                return studentEventDate;
            }
        }


        public string StudentEventDescription
        {
            get
            {
                return studentEventDescription;
            }
        }


        public int NumberOfParticipants
        {
            get
            {
                return numberOfParticipants;
            }
        }

        public void AddEventToFile(string studetEventsPath)
        {
            File.AppendAllText(studetEventsPath, $"{studentEventDate} пройдет мероприятие {studentEventDescription}. Для участия " +
                                                 $"необходимо по {numberOfParticipants} человек из каждой группы. Участники: \n");
        }

        public void SelectionOfParticipants(List<List<Student>> studentsDividedByGroups, string studetEventsPath)
        {
            int[] numberOfRegistrants = new int[studentsDividedByGroups.Count];

            for (int i = 0; i < studentsDividedByGroups.Count; i++)
            {
                List<Student> registeredStudents = new List<Student>();

                for (int j = 0; j < studentsDividedByGroups[i].Count; j++)
                {
                    if ((numberOfRegistrants[i] + 1) < (numberOfParticipants * 0.5))
                    {
                        bool registrationResult = studentsDividedByGroups[i][j].VoluntaryRegistration();

                        if (registrationResult)
                        {
                            numberOfRegistrants[i] += 1;
                            registeredStudents.Add(studentsDividedByGroups[i][j]);
                            File.AppendAllText(studetEventsPath, $"{studentsDividedByGroups[i][j].StudentSurname}_{studentsDividedByGroups[i][j].StudentName}\n");
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                studentsDividedByGroups[i] = studentsDividedByGroups[i].OrderBy(student => student.NumberOfRecentEventsAttended).ToList<Student>();

                for (int j = 0; j < studentsDividedByGroups[i].Count; j++)
                {
                    if ((!registeredStudents.Contains(studentsDividedByGroups[i][j])) && (numberOfRegistrants[i] + 1 <= numberOfParticipants))
                    {
                        numberOfRegistrants[i] += 1;
                        studentsDividedByGroups[i][j].ForcedRegistration();
                        registeredStudents.Add(studentsDividedByGroups[i][j]);
                        File.AppendAllText(studetEventsPath, $"{studentsDividedByGroups[i][j].StudentSurname}_{studentsDividedByGroups[i][j].StudentName}\n");
                    }
                }

                for (int j = 0; j < studentsDividedByGroups[i].Count; j++)
                {
                    if (!registeredStudents.Contains(studentsDividedByGroups[i][j]))
                    {
                        studentsDividedByGroups[i][j].RefusesToRegister();
                    }
                }
            }
        }

        public StudentEvent(string studentEventDate, string studentEventDescription, int numberOfParticipants)
        {
            this.studentEventDate = studentEventDate;
            this.studentEventDescription = studentEventDescription;
            this.numberOfParticipants = numberOfParticipants;
        }
    }
}