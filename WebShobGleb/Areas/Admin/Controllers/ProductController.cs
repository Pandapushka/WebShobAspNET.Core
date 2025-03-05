using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Repository;
using WebShobGleb.Mappers;
using WebShobGleb.Models;
using WebShobGleb.Repository;

namespace WebShobGleb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public IActionResult Products()
        {
            var products = _productsRepository.GetAll();
            return View(products);
        }
        public IActionResult Delete(int id)
        {
            _productsRepository.Delete(id);
            return RedirectToAction("Products", "Product");
        }
        public IActionResult Edit(int id)
        {
            var product = _productsRepository.GetProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductEdit productEdit, int id)
        {
            if (!ModelState.IsValid)
            {
                var product = _productsRepository.GetProduct(id);
                return View(product);
            }
            var productE = ProductMapper.ToProduct(productEdit);
            _productsRepository.Edit(productE, id);
            return RedirectToAction("Products", "Product");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductEdit newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(newProduct);
            }
            var product = ProductMapper.ToProduct(newProduct);
            _productsRepository.Add(product);
            return RedirectToAction("Products", "Product");
        }
    }
}
