namespace StockApp.Core.Entities
{
    public class Category : BaseBasicEntity<int>
    {
        public ICollection<Product>? Products { get; set; }
    }
}
