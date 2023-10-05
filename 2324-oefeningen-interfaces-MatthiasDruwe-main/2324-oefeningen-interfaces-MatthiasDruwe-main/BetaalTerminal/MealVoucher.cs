using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaalTerminal
{
    internal class MealVoucher : IPaymentMethod
    {
        public string Name => "Maaltijdcheques";

        public bool IsPaymentSucceeded { get; private set; }

        public string PaymentSucceededMessage => $"De betaling is geslaagd!";

        public string PaymentFailedMessage => $"De betaling is niet aanvaard! Er staat onvoldoende krediet op de kaart";

        public void StartTransaction(double amount)
        {
            int cardnumber = AnsiConsole.Ask<int>("kaartnummer:");
           
            if(cardnumber%1000 > amount) {
                IsPaymentSucceeded = true;
            } else
            {
                IsPaymentSucceeded = false;
            }
        }
    }
}
