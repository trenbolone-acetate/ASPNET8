using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASPNET8.Models;

namespace ASPNET8.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var products = new List<Product>
        {
            new() { ID = 1, Name = "Apple", Price = 4, CreatedDate = DateTime.Now },
            new() { ID = 2, Name = "Banana", Price = 6, CreatedDate = DateTime.Now },
            new() { ID = 3, Name = "Orange", Price = 9, CreatedDate = DateTime.Now }
        };

        return View(products);
    }
}