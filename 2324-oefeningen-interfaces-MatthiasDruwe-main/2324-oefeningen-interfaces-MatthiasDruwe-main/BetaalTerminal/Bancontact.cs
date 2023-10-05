using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaalTerminal
{
    internal class Bancontact: IPaymentMethod
    {
        private double _amount;

        public string Name => "Bancontact";

        public bool IsPaymentSucceeded { get; private set; }

        public string PaymentSucceededMessage => $"De betaling van {_amount} euro is geslaagd!";

        public string PaymentFailedMessage => $"De betaling van {_amount} euro is niet aanvaard!";

        public void StartTransaction(double amount)
        {
            _amount = amount;
            string cardNumber = AnsiConsole.Ask<string>("Kaartnummer:");
            string pincode = AnsiConsole.Prompt(new TextPrompt<string>("pincode:").Secret());

            if (cardNumber.Contains(pincode))
            {
                IsPaymentSucceeded = true;
            }
            else
            {
                IsPaymentSucceeded = false;
            }
        }
    }
}
