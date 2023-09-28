using Spectre.Console;

namespace spectre_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AnsiConsole.Write(new Markup("[bold yellow]Hello[/] [red]World![/]"));

            int prijs = AnsiConsole.Ask<int>("Wat is de prijs van ijscreme?");
            AnsiConsole.WriteLine($"De prijs van ijscreme is {prijs}");

            AnsiConsole.Clear();

            List<string> favorieteSmaaken = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                .Title("Wat is je favoriete smaak")
                .AddChoices("Vanille", "Chocolade", "Aardbei")
                );


            switch (favorieteSmaaken.First())
            {
                case "Vanille":
                    AnsiConsole.Write("eikes");
                    break ;
                default:
                    AnsiConsole.Write("Goed gekozen!");
                    break;
            }

            bool check = AnsiConsole.Confirm("Eet je graag ijscreme?");

            if (check)
            {
                AnsiConsole.WriteLine("Leuk voor jou");
            } else
            {
                AnsiConsole.WriteLine("jammer");
            }
        }
    }
}