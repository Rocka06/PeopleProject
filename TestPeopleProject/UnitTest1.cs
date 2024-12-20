using PeopleProject;

namespace TestPeopleProject
{
    public class Tests
    {
        PersonStatistics statistics;

        [SetUp]
        public void SetUp()
        {
            statistics = new(new());
            statistics.People.Add(new("Valaki", 10, true, 80));
            statistics.People.Add(new("Valaki2", 13195, false, 57));
            statistics.People.Add(new("Valaki3", 19, false, 73));
            statistics.People.Add(new("Valaki4", 15, true, 24));
        }

        [Test]
        public void Test_Init_WithEmptyList()
        {
            Assert.DoesNotThrow(() => { PersonStatistics stat = new(new()); });
        }
        [Test]
        public void Test_Init_WithFilledList()
        {
            Assert.DoesNotThrow(() => { 
                PersonStatistics stat = new(
                    new() { 
                        new("Valaki1", 10, false, 0),
                        new("Valaki2", 15, true, 53) 
                    }
                ); 
            });
        }
        [Test]
        public void Test_Init_WithFilledList_InvalidScore()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                PersonStatistics stat = new(
                    new() {
                        new("Valaki1", 10, false, -534),
                        new("Valaki2", 15, true, 101),
                        new("Valaki3", 15, true, 54)
                    }
                );
            });
        }
        [Test]
        public void Test_Init_WithFilledList_InvalidAge()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                PersonStatistics stat = new(
                    new() {
                        new("Valaki1", -20, false, 65),
                        new("Valaki2", 15532, true, 100),
                        new("Valaki3", -9, true, 54)
                    }
                );
            });
        }
        [Test]
        public void Test_Init_WithNull()
        {
            Assert.Throws<ArgumentNullException>(() => {
                PersonStatistics stat = new(null);
            });
        }
        
        
        [Test]
        public void Test_GetAverageAge()
        {
            Assert.That(statistics.GetAverageAge() == 3309.75d);
        }

        [Test]
        public void Test_GetNumberOfStudents()
        {
            Assert.That(statistics.GetNumberOfStudents() == 2);
        }

        [Test]
        public void Test_GetPersonWithHighestScore()
        {
            Assert.That(statistics.GetPersonWithHighestScore() == statistics.People[0]);
        }

        [Test]
        public void Test_GetAverageScoreOfStudents()
        {
            Assert.AreEqual(statistics.GetAverageScoreOfStudents(), 52d);
        }
        
        [Test]
        public void Test_GetOldestStudent()
        {
            Assert.AreEqual(statistics.GetOldestStudent(), statistics.People[3]);
        }
        
        [Test]
        public void Test_IsAnyoneFailing()
        {
            PersonStatistics stat = new(new());
            
            stat.People.Add(new("Valaki1", 32, true, 50));
            stat.People.Add(new("Valaki1", 32, true, 20));
            stat.People.Add(new("Valaki1", 32, true, 64));

            Assert.That(stat.IsAnyoneFailing() == true);

            stat.People.RemoveAt(1);

            Assert.IsFalse(stat.IsAnyoneFailing());
        }
    }
}