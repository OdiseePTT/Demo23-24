using Absence.Tests.TestDoubles;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            result.ExcusedStudents.Should().BeEmpty() ;
            result.AbsentStudents.Should().BeEquivalentTo(new List<Student> { student2 });

        }
    }
}
