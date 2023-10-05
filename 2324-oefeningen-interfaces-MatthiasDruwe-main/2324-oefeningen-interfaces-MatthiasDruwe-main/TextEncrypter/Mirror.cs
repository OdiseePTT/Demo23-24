namespace TextEncrypter
{
    internal class Mirror : IEncryptDecrypt
    {
        public string Name => "A=Z, B=Y,... ,Z=A";

        public string Decrypt(string input)
        {
            return MirrorText(input);
        }

        public string Encrypt(string input)
        {
            return MirrorText(input);
        }


        public string MirrorText(string input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                char newChar;

                if (Char.IsLetter(c))
                {

                    if (Char.IsUpper(c))
                    {
                        newChar = (char)('A' + 'Z' - c);

                    }
                    else
                    {
                        newChar = (char)('a' + 'z' - c);
                    }
                }
                else
                {
                    newChar = c;
                }

                result += newChar;
            }

            return result;
        }
    }
}
