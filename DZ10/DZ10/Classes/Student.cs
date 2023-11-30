using System;

namespace Dz10
{
    class Student
    {
        private string studentSurname;
        private string studentName;
        private int groupNumber;
        private int numberOfRecentEventsAttended;

        public string StudentSurname
        {
            get
            {
                return studentSurname;
            }
        }


        public string StudentName
        {
            get
            {
                return studentName;
            }
        }

        public int GroupNumber
        {
            get
            {
                return groupNumber;
            }
        }


        public int NumberOfRecentEventsAttended
        {
            get
            {
                return numberOfRecentEventsAttended;
            }
        }



        public bool VoluntaryRegistration()
        {
            Random random = new Random();

            if (random.Next(0, 2) == 1)
            {
                numberOfRecentEventsAttended = (numberOfRecentEventsAttended == 3) ? 3 : (numberOfRecentEventsAttended + 1);
                return true;
            }

            numberOfRecentEventsAttended = (numberOfRecentEventsAttended == 0) ? 0 : (numberOfRecentEventsAttended - 1);
            return false;
        }


        public void ForcedRegistration()
        {
            numberOfRecentEventsAttended = (numberOfRecentEventsAttended == 3) ? 3 : (numberOfRecentEventsAttended + 1);
        }


        public void RefusesToRegister()
        {
            numberOfRecentEventsAttended = (numberOfRecentEventsAttended == 0) ? 0 : (numberOfRecentEventsAttended - 1);
        }

        public Student(string[] studentDetailsArray)
        {
            studentSurname = studentDetailsArray[0];
            studentName = studentDetailsArray[1];
            groupNumber = int.Parse(studentDetailsArray[2]);
            numberOfRecentEventsAttended = int.Parse(studentDetailsArray[3]);
        }
    }
}