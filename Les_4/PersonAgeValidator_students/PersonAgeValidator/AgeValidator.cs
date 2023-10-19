using System;

namespace PersonAgeValidator
{

    public interface IAgeValidator
    {
        bool IsValidAge(int age);
    } 


    public class AgeValidator: IAgeValidator
    {
        public bool IsValidAge(int age)
        {
            return age >= 18 && age <= 70;
        }
    }
}