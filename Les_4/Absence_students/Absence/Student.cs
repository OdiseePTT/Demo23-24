using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Absence
{
    public class Student
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public Student(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        private bool Equals(Student other)
        {
            return Id == other.Id && FirstName == other.FirstName && LastName == other.LastName;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Student)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstName, LastName);
        }
    }
}