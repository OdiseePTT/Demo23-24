using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncrypter
{
    internal class Reverse : IEncryptDecrypt
    {
        public string Name => "Achterstevooren";

        public string Decrypt(string input)
        {
            return ReverseString(input);
        }

        public string Encrypt(string input)
        {
            return ReverseString(input);
        }


        private string ReverseString(string input)
        {
            string result = "";
            for(int i = input.Length-1; i>=0; i--)
            {
                char c = input[i];
                result += c;
            }
            return result;
        }
    }
}
