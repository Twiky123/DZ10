using System;

namespace Dz10
{

    class Person
    {
        readonly string personName;
        private string[] hobbies;


        public string[] Hobbies
        {
            get
            {
                return hobbies;
            }
        }

        public void ReactsToEvent(string eventName)
        {
            if (Array.IndexOf(hobbies, eventName) != -1)
            {
                Console.WriteLine($"\n{personName} так рад(-а), что скоро будет {eventName}");
            }
        }


        public Person(string personName, params string[] hobbies)
        {
            this.personName = personName;
            this.hobbies = hobbies;
        }
    }
}