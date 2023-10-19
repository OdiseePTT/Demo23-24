namespace Absence
{
    public interface IAbsenceTracker
    {
        void AddStudentAsPresentToDay(Student s, DateOnly date);
        void AddStudentAsPresentToToday(Student s);
        void AddStudentAsAbsentToDay(Student s, DateOnly date);
        void AddStudentAsAbsentToToday(Student s);
        void AddStudentAsExcusedToDay(Student s, DateOnly date);
        void AddStudentAsExcusedToToday(Student s);
        void RemovePresentStudentFromDay(Student s, DateOnly date);
        void RemoveAbsentStudentFromDay(Student s, DateOnly date);
        void RemoveExcusedStudentFromDay(Student s, DateOnly date);
        List<AbsenceCheck> GetAbsenceChecks();
        void RemoveAbsenceCheck(DateOnly date);
        AbsenceCheck? GetAbsenceCheckOnDate(DateOnly date);
    }
}
