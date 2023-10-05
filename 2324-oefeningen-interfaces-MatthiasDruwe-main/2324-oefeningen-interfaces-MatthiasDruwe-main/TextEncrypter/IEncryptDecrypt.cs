using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter
{
    internal interface IEncryptDecrypt
    {
        string Name { get; }
        string Encrypt(string input);
        string Decrypt(string input);
    }
}
