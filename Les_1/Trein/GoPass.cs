using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trein
{
    internal class GoPass : IKaart
    {
        public string Id => throw new NotImplementedException();

        public bool IsValid(string[] route)
        {
           return true;
        }
    }
}
