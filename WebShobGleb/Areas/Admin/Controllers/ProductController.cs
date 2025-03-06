using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Models;
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
            var productsVM = ProductMapper.MapToProductVMList(products);
            return View(productsVM);
        }
        public IActionResult Delete(int id)
        {
            _productsRepository.Delete(id);
            return RedirectToAction("Products", "Product");
        }
        public IActionResult Edit(int id)
        {
            var product = _productsRepository.GetProduct(id);
            var productVM = ProductMapper.MapToProductVM(product);
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM productEdit, int id)
        {
            if (!ModelState.IsValid)
            {
                var product = _productsRepository.GetProduct(id);
                var productVM = ProductMapper.MapToProductVM(product);
                return View(productVM);
            }
            var productE = ProductMapper.MapToProduct(productEdit);
            _productsRepository.Edit(productE, id);
            return RedirectToAction("Products", "Product");
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductVM newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(newProduct);
            }
            var product = ProductMapper.MapToProduct(newProduct);
            _productsRepository.Add(product);
            return RedirectToAction("Products", "Product");
        }
    }
}
