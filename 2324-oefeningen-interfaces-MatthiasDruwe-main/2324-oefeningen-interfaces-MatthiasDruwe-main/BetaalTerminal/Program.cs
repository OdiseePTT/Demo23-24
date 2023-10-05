using Spectre.Console;

namespace BetaalTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amount = AnsiConsole.Ask<double>("Welk bedrag wil je betalen ?");

            IPaymentMethod chosenPaymentMethod;

            List<IPaymentMethod> paymentMethods = new List<IPaymentMethod>() { new Paypal(), new Bancontact(), new MealVoucher() };

            List<string> paymentMethodNames = GetMethodNames(paymentMethods);

            string chosenName =  AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Kies een betaalmethode:")
                .AddChoices(paymentMethodNames)
                );

            chosenPaymentMethod = GetPaymentMethodFromName(chosenName, paymentMethods);

            chosenPaymentMethod.StartTransaction(amount);

            if (chosenPaymentMethod.IsPaymentSucceeded)
            {
                AnsiConsole.WriteLine(chosenPaymentMethod.PaymentSucceededMessage);
            } else
            {
                AnsiConsole.WriteLine(chosenPaymentMethod.PaymentFailedMessage);
            }
        }

        private static IPaymentMethod GetPaymentMethodFromName(string chosenName, List<IPaymentMethod> methods)
        {
            foreach (IPaymentMethod paymentMethod in methods)
            {
                if(paymentMethod.Name == chosenName)
                {
                    return paymentMethod;
                }
            }

            // Zou niet kunnen, maar code klaagt zonder return
            return null;
        }

        private static List<string> GetMethodNames(List<IPaymentMethod> paymentMethods)
        {
            List<string> names = new List<string>();

            foreach(IPaymentMethod paymentMethod in paymentMethods)
            {
                names.Add(paymentMethod.Name);
            }

            return names;
        }
    }
}