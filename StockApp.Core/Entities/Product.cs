namespace StockApp.Core.Entities
{
    public class Product : BaseBasicEntity<int>
    {
        public double Price { get; set; }

        public string PathImage { get; set; }

        public int CategoryId { get; set; }//FK

        //Navigate Property
        public Category? Category { get; set; }
    }
}
