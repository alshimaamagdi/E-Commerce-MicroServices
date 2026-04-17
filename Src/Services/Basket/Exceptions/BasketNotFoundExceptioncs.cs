using BuildingBlocks.Exceptions;

namespace Basket.Exceptions
{
    public class BasketNotFoundException : NotFoundException
    {
        public BasketNotFoundException(string username) : base("Basket", username)
        {
        }
    }
}
