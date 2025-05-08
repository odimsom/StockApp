namespace StockApp.Core.Entities
{
    public class BaseBasicEntity<T>
    {
        public T Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool? Remove { get; set; }
    }
}
