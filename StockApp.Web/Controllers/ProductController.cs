using Microsoft.AspNetCore.Mvc;
using StockApp.Aplication.Services;
using StockApp.Aplication.ViewModel;
using StokApp.Persistence.Contexts;

namespace StockApp.Web.Controllers
{
    public class ProductController : Controller
    {

        public readonly ProductService _service;

        public ProductController(StockAppContext dbcontext)
        {
            this._service = new(dbcontext);
        }


        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveProduct", new SaveProductViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProduct", vm);
            }
            await _service.Add(vm);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _service.GetById(id);
            return View("SaveProduct", product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveProductViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProduct", vm);
            }
            await _service.UpdateProductViewModel(vm);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }

        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var product = await _service.GetById(id);
            await _service.RemoveProductViewModel(product);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }
    }
}
