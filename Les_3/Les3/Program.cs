namespace Les3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 32, 12, 24, 56, 673, 24 };

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



        }
    }
}