using Ordering.Domain.Valueobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    public class Customer:Aggregate<CustomerId>
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public static Customer Create(CustomerId id, string name, string email)
        {
            ArgumentExceptionExtensions.ThrowIfNullOrWhiteSpace(name,nameof(name));
            ArgumentExceptionExtensions.ThrowIfNullOrWhiteSpace(email, nameof(email));

            var customer = new Customer
            {
                Id = id,
                Name = name,
                Email = email
            };

            return customer;
        }
    }
}
