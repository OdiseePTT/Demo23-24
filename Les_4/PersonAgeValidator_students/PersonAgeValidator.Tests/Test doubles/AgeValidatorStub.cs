using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator.Tests.Test_doubles
{
    internal class AgeValidatorStubTrue : IAgeValidator
    {
        public bool IsValidAge(int age)
        {
            return true;
        }
    }

    internal class AgeValidatorStubFalse : IAgeValidator
    {
        public bool IsValidAge(int age)
        {
            return false;
        }
    }

    internal class AgeValidatorStub : IAgeValidator
    {
        bool _value;
        public AgeValidatorStub(bool returnValue)
        {
            _value = returnValue;
        }
        public bool IsValidAge(int age)
        {
            return _value;
        }
    }
}
