using Absence.Tests.TestDoubles;
using FluentAssertions;
using NuGet.Frameworks;
using Xunit.Sdk;

namespace Absence.Tests
{
    public class AbsenceHelperTests
    {

        [Fact]
        public void GetPresentPercentageForStudents_WithAlwaysPresent_Returns1()
        {
            // Arrange
            IAbsenceTracker absenceTracker = new AbsenceTrackerStub();
            AbsenceHelper sut = new AbsenceHelper(absenceTracker);
            Student student = new Student("R1", "John", "Doe");

            // Act
            double result = sut.GetPresencePercentageForStudent(student);

            // Assert
            result.Should().Be(1.0);
        }

        [Fact]
        public void GetPresentPercentageForStudents_WithAStudentHalfOfTheTimePresent_Returns50Percent()
        {
            // Arrange
            IAbsenceTracker absenceTracker = new AbsenceTrackerStub();
            AbsenceHelper sut = new AbsenceHelper(absenceTracker);
            Student student = new Student("R2", "Jane", "Doe");

            // Act 
            double result = sut.GetPresencePercentageForStudent(student);

            // Assert
            result.Should().Be(0.5);
        }

        [Fact]
        public void CreateAbsenceCheck_With1StudentPresentAnd1studentAbsent_ReturnsCorrectAbsenceCheck()
        {
            // Arrange
            IAbsenceTracker tracker = new AbsenceTrackerFake();
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

        [Fact]
        public void AddNewStudent_WithExistingAbsenceChecks_CallsAddStudentAsAbsentToDay()
        {
            // Arrange
            IAbsenceTracker tracker = new AbsenceTrackerMock();
            AbsenceHelper sut = new AbsenceHelper(tracker);
            Student student = new Student("R1", "John", "Doe");

            // Act
            Action act = () => sut.AddNewStudent(student);

            // Assert

            act.Should().Throw<MethodCalled>();

        }
        [Fact]
        public void RemoveStudent_WithStudentInAbsenceChecks_CallsExpectedMethods()
        {
            // Arrange
            AbsenceTrackerSpy tracker = new AbsenceTrackerSpy();
            AbsenceHelper sut = new AbsenceHelper(tracker);
            Student s = new Student("R1", "John", "Doe");

            // Act
            sut.RemoveStudent(s);

            // Assert
            tracker.RemovedAbsentStudentWithDate.Should().BeEquivalentTo(
                new List<(Student, DateOnly)> {
                    (s, new DateOnly(2023,1,3))
                });

            tracker.RemovedExcusedStudentWithDate.Should().BeEmpty();
            tracker.RemovedPresentStudentWithDate.Should().BeEquivalentTo(
                new List<(Student, DateOnly)>{
                    (s, new DateOnly(2023, 1, 1)),
                    (s, new DateOnly(2023, 1, 2)),
                    (s, new DateOnly(2023, 1, 4))
                });
        }

        [Fact]
        public void CreateAbsenceCheck_WithNonExisting_ThrowsStudentNotFoundException()
        {
            // Arrange
            IAbsenceTracker tracker = null; // Dummy
            AbsenceHelper sut = new AbsenceHelper(tracker);
            Student student1 = new Student("R1", "John", "Doe");
            Student student2 = new Student("R2", "Jane", "Doe");
            List<Student> present = new List<Student> { student1 };
            List<Student> excused = new List<Student>();

            // Act
            Action act = () => { AbsenceCheck? result = sut.CreateAbsenceCheck(present, excused); };

            // Assert
            act.Should().Throw<StudentNotFoundException>()
                .Which.NotFoundStudents.Should().BeEquivalentTo(new List<Student> { student1 });

        }

        [Fact]
        public void AddNewStudent_WithNewStudentAndNoExistingAbsenceChecks_DoesntCallAddStudentAsAbsentToDay()
        {
            // Arrange
            IAbsenceTracker absenceTracker = new AbsenceTrackerMock2();
            AbsenceHelper sut = new AbsenceHelper(absenceTracker);
            Student s = new Student("R1", "John", "Doe");

            // Act
            Action act = () => sut.AddNewStudent(s);

            // Assert
            act.Should().NotThrow<MethodCalled>();
        }

        [Fact]
        public void RemoveStudent_WithNonExistingStudent_DoesntCallRemoveMethods()
        {
            // Arrange
            IAbsenceTracker tracker = new AbsenceTrackerMock3();
            AbsenceHelper sut = new AbsenceHelper(tracker);
            Student s = new Student("R1", "John", "Doe");

            // Act
            Action act = () => sut.RemoveStudent(s);

            // Assert
            act.Should().NotThrow<MethodCalled>();
        }

        [Fact]
        public void CountPercentageOfPresentStudentsOnDay_MetIedereenAanwezig_Geeft1Terug()
        {
            // Arrange
            IAbsenceTracker tracker = new AbsenceTrackerStub();
            AbsenceHelper sut = new AbsenceHelper(tracker);

            // Act
            double result = sut.CountPercentageOfPresentStudentsOnDay(new DateOnly(2023, 1, 1));

            // Assert
            result.Should().Be(1.0);
        }

        [Fact]
        public void CountPercentageOfPresentStudentsOnDay_ForDateWithNoAbsenceCheck_Returns0()
        {
            // Arrange
            IAbsenceTracker tracker = new AbsenceTrackerStub2();
            AbsenceHelper sut = new AbsenceHelper(tracker);

            // Act
            double result = sut.CountPercentageOfPresentStudentsOnDay(new DateOnly(2023, 1, 1));

            // Assert
            result.Should().Be(0.0);
        }

    }
}
