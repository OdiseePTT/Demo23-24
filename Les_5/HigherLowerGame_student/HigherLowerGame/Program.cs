using Spectre.Console;

namespace HigherLowerGame;
public class Program
{
    public static void Main()
    {
        int maxNumber = AnsiConsole.Ask<int>("Kies een getal tot waar je wil raden");

        HigherLowerApp higherLowerApp = new HigherLowerApp(maxNumber);
        Result result;
        do
        {
            int guess = AnsiConsole.Ask<int>("Doe een gokje");
            result = higherLowerApp.GuessNumber(guess);

            switch (result)
            {
                case Result.Correct:
                    AnsiConsole.WriteLine($"Correct, je hebt het getal geraden na {higherLowerApp.NumberOfGuesses} pogingen");
                    break;
                case Result.Lower:
                    AnsiConsole.WriteLine("Je hebt te hoog gegokt");
                    break;
                case Result.Higher:
                    AnsiConsole.WriteLine("Je hebt te laag gegokt");
                    break;
            }
        } while (result != Result.Correct);
    }
}