using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaalTerminal
{
    internal class Paypal : IPaymentMethod
    {

        private double _amount;

        public string Name => "Paypall";

        public bool IsPaymentSucceeded { get; private set; }

        public string PaymentSucceededMessage => $"De betaling van {_amount} euro is geslaagd!";

        public string PaymentFailedMessage => $"De betaling van {_amount} euro is niet aanvaard!";

        public void StartTransaction(double amount)
        {
            _amount = amount;
            string username = AnsiConsole.Ask<string>("Gebruikersnaam:");
            string password = AnsiConsole.Prompt(new TextPrompt<string>("Wachtwoord:").Secret());

            if(username == "demo" && password == "demo")
            {
                IsPaymentSucceeded = AnsiConsole.Confirm("Wil je de betaling uitvoeren?");
            }
            else
            {
                IsPaymentSucceeded = false;
            }
        }
    }
}
