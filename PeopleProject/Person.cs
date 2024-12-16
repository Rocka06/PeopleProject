using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProject
{
    public class Person
    {
        private static int PersonCount = 0;

        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool IsStudent { get; private set; }
        public int Score { get; private set; }

        public Person(string name, int age, bool isStudent, int score) 
        {
            if(score < 0 || score > 100 || age < 0) throw new ArgumentOutOfRangeException();

            PersonCount++;
            ID = PersonCount;

            Name = name;
            Age = age;
            IsStudent = isStudent;
            Score = score;
        }
    }
}
