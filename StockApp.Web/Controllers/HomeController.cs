using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StockApp.Web.Models;

namespace StockApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
}
