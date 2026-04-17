
namespace Basket.Basket.GetBasket
{
    public record GetBasketQuery(string UserName) : Iquery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
}
