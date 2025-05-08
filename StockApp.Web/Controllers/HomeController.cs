using Microsoft.AspNetCore.Mvc;
using StockApp.Aplication.Services;
using StokApp.Persistence.Contexts;

namespace StockApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _service;

    public HomeController(StockAppContext dbcontext)
    {
        _service = new(dbcontext);
    }

    public async Task<IActionResult> Index()
    {
        var listProduct = await _service.GetAllViewModel();
        return View(listProduct);
    }
}
