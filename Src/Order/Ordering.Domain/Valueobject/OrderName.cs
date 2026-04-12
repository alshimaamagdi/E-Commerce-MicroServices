using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Valueobject
{
    public class OrderName
    {
        private const int DefaultLength = 5;
        public string Value { get; }
        private OrderName(string value) => Value = value;
        public static OrderName Of(string OrderName)
        {
            ArgumentExceptionExtensions.ThrowIfNullOrWhiteSpace(OrderName, nameof(OrderName));
            ArgumentExceptionExtensions.ThrowIfNullOrWhiteSpace(OrderName.Length.ToString(), "Length is not true");
            return new OrderName(OrderName);
        }
    }
}
