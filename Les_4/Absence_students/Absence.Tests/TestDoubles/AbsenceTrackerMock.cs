using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Absence.Tests.TestDoubles
{

    public class MethodCalled: Exception
    {  
    }
    public class AbsenceTrackerMock : IAbsenceTracker
    {
        public void AddStudentAsAbsentToDay(Student s, DateOnly date)
        {
            throw new MethodCalled(); // Assert.Pass() kunnen we niet gebruiken want Xunit ondersteund dit niet. Dus Exception.
        }

        public void AddStudentAsAbsentToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsExcusedToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsExcusedToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsPresentToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsPresentToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public AbsenceCheck? GetAbsenceCheckOnDate(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public List<AbsenceCheck> GetAbsenceChecks()
        {
            return new List<AbsenceCheck>() { new AbsenceCheck() };
        }

        public void RemoveAbsenceCheck(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemoveAbsentStudentFromDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemoveExcusedStudentFromDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemovePresentStudentFromDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }
    }

    public class AbsenceTrackerMock2 : IAbsenceTracker
    {
        public void AddStudentAsAbsentToDay(Student s, DateOnly date)
        {
            throw new MethodCalled(); // Assert.Pass() kunnen we niet gebruiken want Xunit ondersteund dit niet. Dus Exception.
        }

        public void AddStudentAsAbsentToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsExcusedToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsExcusedToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsPresentToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsPresentToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public AbsenceCheck? GetAbsenceCheckOnDate(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public List<AbsenceCheck> GetAbsenceChecks()
        {
            return new List<AbsenceCheck>() ;
        }

        public void RemoveAbsenceCheck(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemoveAbsentStudentFromDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemoveExcusedStudentFromDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemovePresentStudentFromDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }
    }

    public class AbsenceTrackerMock3 : IAbsenceTracker
    {
        public void AddStudentAsAbsentToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsAbsentToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsExcusedToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsExcusedToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsPresentToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsPresentToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public AbsenceCheck? GetAbsenceCheckOnDate(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public List<AbsenceCheck> GetAbsenceChecks()
        {
            Student student1 = new Student("R1", "John", "Doe");
            Student student2 = new Student("R2", "Jane", "Doe");

            return new List<AbsenceCheck>()
            {
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{},
                    AbsentStudents = new List<Student>{student2}
                },
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{ student2}
                },
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{},
                    AbsentStudents = new List<Student>{student2}
                },
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{student2 }
                }
            };
        }

        public void RemoveAbsenceCheck(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemoveAbsentStudentFromDay(Student s, DateOnly date)
        {
            throw new MethodCalled();
        }

        public void RemoveExcusedStudentFromDay(Student s, DateOnly date)
        {
            throw new MethodCalled();
        }

        public void RemovePresentStudentFromDay(Student s, DateOnly date)
        {
            throw new MethodCalled();
        }
    }
}
