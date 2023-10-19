namespace Absence.Tests.TestDoubles
{
    internal class AbsenceTrackerStub : IAbsenceTracker
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
            Student student1 = new Student("R1", "John", "Doe");
            Student student2 = new Student("R2", "Jane", "Doe");
            return new AbsenceCheck()
            {
                PresentStudents = new List<Student> { student1, student2 }
            };
        }

        public List<AbsenceCheck> GetAbsenceChecks()
        {
            Student student1 = new Student("R1", "John", "Doe");
            Student student2 = new Student("R2", "Jane", "Doe");

            return new List<AbsenceCheck>()
            {
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{student1},
                    AbsentStudents = new List<Student>{student2}
                },
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{student1, student2}
                },
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{student1},
                    AbsentStudents = new List<Student>{student2}
                },
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{student1,student2 }
                }
            };
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

    public class AbsenceTrackerStub2 : IAbsenceTracker
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
            return null;
        }

        public List<AbsenceCheck> GetAbsenceChecks()
        {
            throw new NotImplementedException();
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
}
