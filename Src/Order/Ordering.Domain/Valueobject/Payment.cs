using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Valueobject
{
    public class Payment
    {
        public string? CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!;

        protected Payment()
        {
        }

        public Payment(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            CVV = cvv;
            PaymentMethod = paymentMethod;
        }

        public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
        {
            ArgumentExceptionExtensions.ThrowIfNullOrWhiteSpace(cardName,nameof(cardName));
            ArgumentExceptionExtensions.ThrowIfNullOrWhiteSpace(cardNumber,nameof(cardNumber));

            return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
        }
    }
}
