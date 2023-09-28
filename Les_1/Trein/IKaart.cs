using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trein
{
    internal interface IKaart
    {
        string Id { get; }
        bool IsValid(string[] route);
    }
}
