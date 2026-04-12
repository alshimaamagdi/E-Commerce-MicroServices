using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Valueobject
{
    public class Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string? EmailAddress { get; } = default!;
        public string AddressLine { get; } = default!;
        public string Country { get; } = default!;
        public string State { get; } = default!;
        public string ZipCode { get; } = default!;
        protected Address()
        {
        }

        private Address(string firstName, string lastName, string emailAddress, string addresLine, string country, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addresLine;
            Country = country;
            State = state;
            ZipCode = zipCode;
        }

        public static Address Of(string firstName, string lastName, string emailAddress, string addresLine, string country, string state, string zipCode)
        {
            ArgumentExceptionExtensions.ThrowIfNullOrWhiteSpace(emailAddress, nameof(emailAddress));
            ArgumentExceptionExtensions.ThrowIfNullOrWhiteSpace(addresLine,nameof(addresLine));

            return new Address(firstName, lastName, emailAddress, addresLine, country, state, zipCode);
        }
    }
}
