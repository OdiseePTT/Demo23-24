namespace Absence
{
    public class AbsenceTracker : IAbsenceTracker
    {
        List<AbsenceCheck> _checks;

        public AbsenceTracker()
        {
            _checks = new List<AbsenceCheck>();
        }

        public void AddStudentAsPresentToDay(Student s, DateOnly date)
        {
            AbsenceCheck check = CreateCheckOrFindExisting(date);
            check.PresentStudents.Add(s);
        }

        public void AddStudentAsPresentToToday(Student s)
        {
            AddStudentAsPresentToDay(s, DateOnly.FromDateTime(DateTime.Today));
        }

        public void AddStudentAsAbsentToDay(Student s, DateOnly date)
        {
            AbsenceCheck check = CreateCheckOrFindExisting(date);
            check.AbsentStudents.Add(s);
        }

        public void AddStudentAsAbsentToToday(Student s)
        {
            AddStudentAsAbsentToDay(s, DateOnly.FromDateTime(DateTime.Today));
        }

        public void AddStudentAsExcusedToDay(Student s, DateOnly date)
        {
            AbsenceCheck check = CreateCheckOrFindExisting(date);
            check.ExcusedStudents.Add(s);
        }

        public void AddStudentAsExcusedToToday(Student s)
        {
            AddStudentAsExcusedToDay(s, DateOnly.FromDateTime(DateTime.Today));
        }

        public void RemovePresentStudentFromDay(Student s, DateOnly date)
        {
            AbsenceCheck? check = FindAbsenceCheckForDate(date);

            if (check != null)
            {
                check.PresentStudents.Remove(s);
            }
        }

        public void RemoveAbsentStudentFromDay(Student s, DateOnly date)
        {
            AbsenceCheck? check = FindAbsenceCheckForDate(date);

            if (check != null)
            {
                check.AbsentStudents.Remove(s);
            }
        }

        public void RemoveExcusedStudentFromDay(Student s, DateOnly date)
        {
            AbsenceCheck? check = FindAbsenceCheckForDate(date);

            if (check != null)
            {
                check.ExcusedStudents.Remove(s);
            }
        }
        public List<AbsenceCheck> GetAbsenceChecks()
        {
            return _checks;
        }

        public void RemoveAbsenceCheck(DateOnly date)
        {
            AbsenceCheck? check = FindAbsenceCheckForDate(date);

            if (check != null)
            {
                _checks.Remove(check);
            }
        }

        public AbsenceCheck? GetAbsenceCheckOnDate(DateOnly date)
        {
            return _checks.FirstOrDefault(check => check.Day == date);
        }
        private AbsenceCheck CreateCheckOrFindExisting(DateOnly date)
        {
            AbsenceCheck? check = FindAbsenceCheckForDate(date);

            if (check != null)
            {
                return check;
            }

            return CreateNewCheckForDate(date);
        }


        private AbsenceCheck? FindAbsenceCheckForDate(DateOnly date)
        {
            return _checks.First(check => check.Day == date);
        }

        private AbsenceCheck CreateNewCheckForDate(DateOnly date)
        {
            AbsenceCheck check = new AbsenceCheck();
            check.Day = date;

            _checks.Add(check);

            return check;
        }
    }
}
