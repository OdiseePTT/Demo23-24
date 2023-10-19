namespace Absence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("r123456", "test", "test");
            Student s2 = new Student("r123457", "test2", "test2");
            AbsenceHelper absenceHelper = new AbsenceHelper();
            
            absenceHelper.AddNewStudent(s);
            
            absenceHelper.CreateAbsenceCheck(new List<Student>(){s}, new List<Student>());
        }
    }
}