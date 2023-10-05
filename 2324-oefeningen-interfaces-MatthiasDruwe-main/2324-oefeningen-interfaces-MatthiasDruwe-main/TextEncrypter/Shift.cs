namespace TextEncrypter
{
    internal class Shift : IEncryptDecrypt
    {
        public string Name => "A=B, B=C,.... Z=A";

        public string Decrypt(string input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {

                char c = input[i];
                if (Char.IsLetter(c))
                {
                    char nextCharacter = (char)(c - 1);

                    if (c == 'a')
                    {
                        nextCharacter = 'z';
                    }
                    else if (c == 'A')
                    {
                        nextCharacter = 'Z';
                    }
                    result += nextCharacter;
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }

        public string Encrypt(string input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (Char.IsLetter(c))
                {
                    char nextCharacter = (char)(c + 1);

                    if (c == 'z')
                    {
                        nextCharacter = 'a';
                    }
                    else if (c == 'Z')
                    {
                        nextCharacter = 'A';
                    }
                    result += nextCharacter;
                }
                else
                {
                    result += c;
                }
            }

            return result;
        }
    }
}
