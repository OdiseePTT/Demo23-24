namespace Les3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 32, 12, 24, 56, 673, 24 };

            IEnumerable<int> squares = numbers.Select(number => number * number);

            //double sum = 0;

            //foreach (int number in numbers)
            //{
            //    sum += number;
            //}


            //double average = sum / numbers.Count();

            double average = numbers.Average();
            double sum = numbers.Sum();
            double min = numbers.Min();
            double max = numbers.Max();


            Console.WriteLine(average);
            Console.WriteLine(sum);
            Console.WriteLine(min);
            Console.WriteLine(max);


            List<Student> students = new List<Student>()
            {
                new Student("Mariam", "Legros", new DateTime(2001, 12, 1) ),
                new Student("Kayley", "Thiel", new DateTime(1985, 1, 14) ),
                new Student("Ewell", "Maggio", new DateTime(2003, 4, 30) ),
                new Student("Evan", "Towne", new DateTime(2000, 2, 11) ),
                new Student("Meggie", "Dach", new DateTime(2001, 2, 28) )
            };

            /*            double ages = 0;
                        foreach (var student in students)
                        {
                            ages += student.Age;
                        }

                        double averageAge = ages / students.Count

*/

            double averageAge = students.Average(student => student.Age);
            double maxAge = students.Max(student => student.Age);
            double minAge = students.Min(student => student.Age);
            double sumAge = students.Sum(student => student.Age);

            // Lijst van studenten die ouder zijn dan 21
            IEnumerable<Student> studentsOlderThen21 = students.Where(student =>
            {
                int age = student.Age;
                return age >= 21;
            });

            foreach (var student in studentsOlderThen21)
            {
                Console.WriteLine(student.FirstName);
            }

            IEnumerable<string> studentnames = students.Select((student) =>
            {
                string firstname = student.FirstName;
                string lastname = student.LastName;

                return $"{firstname} {lastname}";
            });

            foreach (var names in studentnames)
            {
                Console.WriteLine(names);
            }

            Console.WriteLine($"Gemiddelde leeftijd:{averageAge}");

            IEnumerable<string> studentNamesOlderThen21 = students.Where(student => student.Age >= 21).Select(student => $"{student.FirstName} {student.LastName}");


        }

        //static int GetAge(Student s)
        //{
        //    return s.Age;
        //}
    }
}