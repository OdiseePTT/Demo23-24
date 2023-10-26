using FluentAssertions;

namespace Absence.Tests.NSubstitute
{
    public class AbsenceHelperTests
    {


        Student _student1 = new Student("R1", "John", "Doe");
        Student _student2 = new Student("R2", "Janneke", "Doe");

        [Fact]
        public void GetPresentPercentageForStudents_WithAlwaysPresent_Returns1()
        {
            // Arrange      
            IAbsenceTracker testDouble = Substitute.For<IAbsenceTracker>();
            testDouble.GetAbsenceChecks().Returns(GetAbsenceChecks());

            AbsenceHelper sut = new AbsenceHelper(testDouble);

            // Act
            double result = sut.GetPresencePercentageForStudent(_student1);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        // Normaal zouden hier 2 tests voor nodig zijn.
        public void CountPercentageOfStudentsOnDay_WithItems_CalculatesCorrectPercentage()
        {
            // Arrange
            IAbsenceTracker testdouble = Substitute.For<IAbsenceTracker>();
            DateOnly date = new DateOnly(2023, 1, 1);
            
            testdouble.GetAbsenceCheckOnDate(date).Returns(GetAbsenceCheckWithEverybodyPresent());
            

            testdouble.GetAbsenceCheckOnDate(new DateOnly(2023, 1, 2)).Returns(GetAbsenceCheckWithHalfOfStudentsPresent());

            AbsenceHelper sut = new AbsenceHelper(testdouble);

            double result1 = sut.CountPercentageOfPresentStudentsOnDay(date);
            double result2 = sut.CountPercentageOfPresentStudentsOnDay(new DateOnly(2023, 1, 2));

            // Assert
            result1.Should().Be(1.0);
            result2.Should().Be(0.5);
        }


        [Fact]
        // Normaal zouden hier 2 tests voor nodig zijn.
        public void CountPercentageOfStudentsOnDay_WithItems_CalculatesCorrectPercentageOptie2()
        {
            // Arrange
            IAbsenceTracker testdouble = Substitute.For<IAbsenceTracker>();
            DateOnly date = new DateOnly(2023, 1, 1);
            // optie 1
            testdouble.GetAbsenceCheckOnDate(Arg.Any<DateOnly>()).Returns(GetAbsenceCheckWithEverybodyPresent());
            //optie 2
            testdouble.GetAbsenceCheckOnDate(default).ReturnsForAnyArgs(GetAbsenceCheckWithHalfOfStudentsPresent());

            AbsenceHelper sut = new AbsenceHelper(testdouble);

            double result1 = sut.CountPercentageOfPresentStudentsOnDay(date);
            double result2 = sut.CountPercentageOfPresentStudentsOnDay(new DateOnly(2023, 1, 2));

            // Assert
            result1.Should().Be(1.0);
            result2.Should().Be(0.5);
        }


        [Fact]
        // Normaal zouden hier 2 tests voor nodig zijn.
        public void CountPercentageOfStudentsOnDay_WithItems_CalculatesCorrectPercentageOptie3()
        {
            // Arrange
            IAbsenceTracker testdouble = Substitute.For<IAbsenceTracker>();
            DateOnly date = new DateOnly(2023, 1, 1);
            // optie 1
            testdouble.GetAbsenceCheckOnDate(Arg.Any<DateOnly>()).Returns(
                GetAbsenceCheckWithEverybodyPresent(),
                GetAbsenceCheckWithHalfOfStudentsPresent()
                ) ;
     

            AbsenceHelper sut = new AbsenceHelper(testdouble);

            double result1 = sut.CountPercentageOfPresentStudentsOnDay(date);
            double result2 = sut.CountPercentageOfPresentStudentsOnDay(new DateOnly(2023, 1, 2));

            // Assert
            result1.Should().Be(1.0);
            result2.Should().Be(0.5);
        }



        private AbsenceCheck GetAbsenceCheckWithEverybodyPresent()
        {
            return new AbsenceCheck()
            {
                PresentStudents = new List<Student>() { _student1, _student2 }
            };
        }

        private AbsenceCheck GetAbsenceCheckWithHalfOfStudentsPresent()
        {
            return new AbsenceCheck()
            {
                PresentStudents = new List<Student>() { _student1 },
                AbsentStudents = new List<Student>() { _student2}
            };
        }

        private List<AbsenceCheck> GetAbsenceChecks()
        {
            return new List<AbsenceCheck>()
            {
                new AbsenceCheck(){
                    PresentStudents = new List<Student>(){ _student1},
                    AbsentStudents = new List<Student>() {_student2}
                },
                new AbsenceCheck(){
                    PresentStudents = new List<Student>(){ _student1, _student2}
                },
                new AbsenceCheck(){
                    PresentStudents = new List<Student>(){ _student1},
                    AbsentStudents = new List<Student>() {_student2}
                },
                new AbsenceCheck(){
                    PresentStudents = new List<Student>(){ _student1, _student2}
                },
            };
        }
    }
}