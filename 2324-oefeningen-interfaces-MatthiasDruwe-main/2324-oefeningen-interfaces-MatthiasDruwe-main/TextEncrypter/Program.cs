using Spectre.Console;

namespace TextEncrypter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Kies een optie").AddChoices("Encrypt", "Decrypt"));
            string input = AnsiConsole.Ask<string>("Welke tekst wil je omzetten?");

            List<IEncryptDecrypt> encryptDecrypts = new List<IEncryptDecrypt>() { new Reverse(), new Shift(), new Mirror() };
            List<string> encryptDecryptNames = GetNames(encryptDecrypts);

            string pickedEncryption = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Kies een encryptie methode").AddChoices(encryptDecryptNames));

            IEncryptDecrypt chosenEncryptDecrypt = GetEncryptDecryptFromName(pickedEncryption, encryptDecrypts);

            if(choice == "Encrypt")
            {
                AnsiConsole.WriteLine(chosenEncryptDecrypt.Encrypt(input));
            } else if(choice =="Decrypt")
            {
                AnsiConsole.WriteLine(chosenEncryptDecrypt.Decrypt(input));

            }


        }

        private static IEncryptDecrypt GetEncryptDecryptFromName(string pickedEncryption, List<IEncryptDecrypt> encryptDecrypts)
        {
            foreach (IEncryptDecrypt item in encryptDecrypts)
            {
                if (pickedEncryption == item.Name)
                {
                    return item;

                }
            }

            return null;
        }

        private static List<string> GetNames(List<IEncryptDecrypt> encryptDecrypts)
        {
            List<String> names = new List<string>();

            foreach (IEncryptDecrypt item in encryptDecrypts)
            {
                names.Add(item.Name);
            }
            return names;
        }
    }
}