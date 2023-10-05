using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaalTerminal
{
    internal interface IPaymentMethod
    {
        string Name { get; }
        void StartTransaction(double amount);

        bool IsPaymentSucceeded { get; }
        string PaymentSucceededMessage { get; }
        string PaymentFailedMessage { get; }
    }
}
