using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Exceptions
{
    public static class ArgumentExceptionExtensions
    {
        public static void ThrowIfNullOrWhiteSpace(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{paramName} cannot be null or whitespace", paramName);
            }
        }

        public static void ThrowIfNegativeOrZero(decimal value, string paramName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, $"{paramName} must be greater than zero");
            }
        }
    }
}
