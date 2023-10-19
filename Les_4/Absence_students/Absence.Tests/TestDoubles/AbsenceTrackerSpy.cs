namespace Absence.Tests.TestDoubles
{
    internal class AbsenceTrackerSpy : IAbsenceTracker
    {

        public List<(Student, DateOnly)> RemovedAbsentStudentWithDate { get; private set; } = new List<(Student, DateOnly)>();
        public List<(Student, DateOnly)> RemovedPresentStudentWithDate { get; private set; } = new List<(Student, DateOnly)>();
        public List<(Student, DateOnly)> RemovedExcusedStudentWithDate { get; private set; } = new List<(Student, DateOnly)>();
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
                new AbsenceCheck(){
                    Day = new DateOnly(2023, 1,1),
                    PresentStudents = new List<Student>{student1, student2}
                },
                new AbsenceCheck(){
                    Day = new DateOnly(2023, 1,2),
                    PresentStudents = new List<Student>{student1, student2}
                },
                new AbsenceCheck(){
                    Day = new DateOnly(2023, 1,3),
                    PresentStudents = new List<Student>{student2},
                    AbsentStudents = new List<Student>{student1}
                },
                new AbsenceCheck(){
                    Day = new DateOnly(2023, 1,4),
                    PresentStudents = new List<Student>{student1, student2}
                },
            };
        }

        public void RemoveAbsenceCheck(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemoveAbsentStudentFromDay(Student s, DateOnly date)
        {
            RemovedAbsentStudentWithDate.Add((s, date));
        }

        public void RemoveExcusedStudentFromDay(Student s, DateOnly date)
        {
            RemovedExcusedStudentWithDate.Add((s, date));
        }

        public void RemovePresentStudentFromDay(Student s, DateOnly date)
        {
            RemovedPresentStudentWithDate.Add((s, date));
        }
    }
}
