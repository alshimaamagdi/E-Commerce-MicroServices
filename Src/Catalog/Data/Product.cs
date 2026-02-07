namespace Catalog.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }=default!;
        public List<string> Category { get; set; } = new();
        public string Description { get; set; } = default!;
        public string ImageFiles { get; set; } = default!;
        public decimal Price { get; set; } = default!;

    }
}
