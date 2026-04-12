namespace Catalog.Exceptions
{
    public class ProductNotFundException:Exception
    {
        public ProductNotFundException():base("Product Not Found")
        {
            
        }
    }
}
