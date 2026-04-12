using Ordering.Domain.Valueobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Models
{
    internal class Product:Aggregate<ProductId>
    {
        public string Name { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;

        public static Product Create(ProductId productId, string name, decimal price)
        {
            ArgumentExceptionExtensions.ThrowIfNullOrWhiteSpace(name, nameof(name));

            var product = new Product
            {
                Id = productId,
                Name = name,
                Price = price
            };

            return product;
        }
    }
}
