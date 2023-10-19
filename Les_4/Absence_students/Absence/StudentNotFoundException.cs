using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence
{
    public class StudentNotFoundException: Exception
    {
        IEnumerable<Student> NotFoundStudents { get; }

        public StudentNotFoundException(IEnumerable<Student> notFoundStudents)
        {
            NotFoundStudents = notFoundStudents;
        }
    }
}
