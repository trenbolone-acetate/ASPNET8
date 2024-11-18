using ASPNET8.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET8.Views.Shared.Components;

public class ProductsTableViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<Product> products)
    {
        return View(products);
    }
}