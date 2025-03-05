using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Repository;
using WebShobGleb.Models;
using WebShobGleb.Repository;

namespace WebShobGleb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public IActionResult Index(int id)
        {
            var product = _productsRepository.GetProduct(id);
            return View(product);
        }

        
    }
}
