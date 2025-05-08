using StockApp.Aplication.Common;
using StockApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace StockApp.Aplication.ViewModel
{
    public class SaveProductViewModel : BasicProducViewModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public int CategoryId { get; set; }

        public Category? Categories { get; set; }
    }
}
