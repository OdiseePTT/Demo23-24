using FluentAssertions;
using NSubstitute.ReceivedExtensions;

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

            // Assert Faalt wegens voorbeeld Nsubstitute
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
                );


            AbsenceHelper sut = new AbsenceHelper(testdouble);

            double result1 = sut.CountPercentageOfPresentStudentsOnDay(date);
            double result2 = sut.CountPercentageOfPresentStudentsOnDay(new DateOnly(2023, 1, 2));

            // Assert
            result1.Should().Be(1.0);
            result2.Should().Be(0.5);
        }

        [Fact]
        public void RemoveStudent_WithStudentInAbsenceChecks_CallsExpectedMethods()
        {
            // Arrange
            IAbsenceTracker testDouble = Substitute.For<IAbsenceTracker>();
            testDouble.GetAbsenceChecks().Returns(GetAbsenceChecks());
            AbsenceHelper sut = new AbsenceHelper(testDouble);


            // Act
            sut.RemoveStudent(_student1);

            // Assert
            testDouble.Received().RemovePresentStudentFromDay(_student1, new DateOnly(2023, 1, 1));
            testDouble.Received().RemovePresentStudentFromDay(_student1, new DateOnly(2023, 1, 2));
            testDouble.Received().RemovePresentStudentFromDay(_student1, new DateOnly(2023, 1, 3));
            testDouble.Received().RemovePresentStudentFromDay(_student1, new DateOnly(2023, 1, 4));

            // Alternatieve Assert
            testDouble.Received().RemovePresentStudentFromDay(Arg.Any<Student>(), Arg.Any<DateOnly>());
            testDouble.ReceivedWithAnyArgs().RemovePresentStudentFromDay(default,default);

            // Alternatief nr 2
            testDouble.Received(4).RemovePresentStudentFromDay(Arg.Any<Student>(), Arg.Any<DateOnly>());
            testDouble.Received(Quantity.Within(1,4)).RemovePresentStudentFromDay(Arg.Any<Student>(), Arg.Any<DateOnly>());
        }


        [Fact]
        public void CreateAbsenceCheck_With1StudentPresentAnd1studentAbsent_ReturnsCorrectAbsenceCheck()
        {
            // Arrange
            IAbsenceTracker tracker = Substitute.For<IAbsenceTracker>();
            AbsenceCheck absenceCheck = new AbsenceCheck();

            tracker.When(sub => sub.AddStudentAsAbsentToToday(Arg.Any<Student>()))
                .Do(callInfo => absenceCheck.AbsentStudents.Add(callInfo.ArgAt<Student>(0)));

            tracker.When(sub => sub.AddStudentAsPresentToToday(Arg.Any<Student>()))
               .Do(callInfo => absenceCheck.PresentStudents.Add(callInfo.ArgAt<Student>(0)));

            tracker.When(sub => sub.AddStudentAsExcusedToToday(Arg.Any<Student>()))
               .Do(callInfo => absenceCheck.ExcusedStudents.Add(callInfo.ArgAt<Student>(0)));

            tracker.GetAbsenceChecks().Returns(new List<AbsenceCheck>());

            tracker.GetAbsenceCheckOnDate(default).ReturnsForAnyArgs(_ => absenceCheck);

            AbsenceHelper sut = new AbsenceHelper(tracker);

            Student student1 = new Student("R1", "John", "Doe");
            Student student2 = new Student("R2", "Jane", "Doe");
            
            List<Student> present = new List<Student> { student1 };
            List<Student> excused = new List<Student>();

            sut.AddNewStudent(student1);
            sut.AddNewStudent(student2);

            // Act
            AbsenceCheck? result = sut.CreateAbsenceCheck(present, excused);

            // Assert
            result.PresentStudents.Should().BeEquivalentTo(new List<Student> { student1 });
            result.ExcusedStudents.Should().BeEmpty();
            result.AbsentStudents.Should().BeEquivalentTo(new List<Student> { student2 });

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
                AbsentStudents = new List<Student>() { _student2 }
            };
        }

        private List<AbsenceCheck> GetAbsenceChecks()
        {
            return new List<AbsenceCheck>()
            {
                new AbsenceCheck(){
                    Day= new DateOnly(2023,1,1),
                    PresentStudents = new List<Student>(){ _student1},
                    AbsentStudents = new List<Student>() {_student2}
                },
                new AbsenceCheck(){
                    Day= new DateOnly(2023,1,2),
                    PresentStudents = new List<Student>(){ _student1, _student2}
                },
                new AbsenceCheck(){
                    Day= new DateOnly(2023,1,3),
                    PresentStudents = new List<Student>(){ _student1},
                    AbsentStudents = new List<Student>() {_student2}
                },
                new AbsenceCheck(){
                    Day= new DateOnly(2023,1,4),
                    PresentStudents = new List<Student>(){ _student1, _student2}
                },
            };
        }
    }
}