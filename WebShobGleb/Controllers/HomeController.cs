using System.Diagnostics;
using Application.Servises;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Web.Mappers;
using WebShobGleb.Models;

namespace WebShobGleb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            var productsVM = ProductMapper.MapToProductVMList(products);
            return View(productsVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
