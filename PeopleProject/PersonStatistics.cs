namespace PeopleProject
{
    public class PersonStatistics
    {
        public List<Person> People { get; set; }

        public PersonStatistics(List<Person> people)
        {
            if (people == null) throw new ArgumentNullException();
            People = people;
        }

        //Functions
        public double GetAverageAge() => (double)People.Sum(x => x.Age) / (double)People.Count;
        public int GetNumberOfStudents() => People.Where(x => x.IsStudent).Count();
        public Person GetPersonWithHighestScore() => People.MaxBy(x => x.Score);
        public double GetAverageScoreOfStudents() => (double)People.Where(x => x.IsStudent).Sum(x => x.Score) / (double)People.Where(x => x.IsStudent).Count();
        public Person GetOldestStudent() => People.Where(x => x.IsStudent).MaxBy(x => x.Age);
        public bool IsAnyoneFailing() => People.Any(x => x.Score < 40);
    }
}
