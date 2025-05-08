using System.ComponentModel.DataAnnotations;

namespace StockApp.Aplication.Common
{
    public class BasicProducViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        public string? Description { get; set; }
        [Required(ErrorMessage = "El Precio es requerido")]
        public double Price { get; set; }

        public string UrlImage { get; set; }
    }
}
