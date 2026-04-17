using BuildingBlocks.Cqrs;

namespace Basket.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : Icommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);
}
