using Microsoft.AspNetCore.Mvc;
using OnlineShopDB.Models;
using OnlineShopDB.Repository;
using WebShobGleb.Mappers;
using WebShobGleb.Models;
using WebShobGleb.Repository;
using WebShobGleb.Servises;

namespace WebShobGleb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Products()
        {
            var productsVM = _productService.GetAllProducts();
            return View(productsVM);
        }

        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Products", "Product");
        }

        public IActionResult Edit(int id)
        {
            var productVM = _productService.GetProductById(id);
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM productEdit, int id)
        {
            if (!ModelState.IsValid)
            {
                var productVM = _productService.GetProductById(id);
                return View(productVM);
            }

            _productService.UpdateProduct(productEdit, id);
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

            _productService.AddProduct(newProduct);
            return RedirectToAction("Products", "Product");
        }
    }
}
