using Application.Servises;
using Microsoft.AspNetCore.Mvc;
using Web.Mappers;
using WebShobGleb.Models;

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
            return View(ProductMapper.MapToProductVMList(productsVM));
        }

        public IActionResult Delete(Guid id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Products", "Product");
        }

        public IActionResult Edit(Guid id)
        {
            var productVM = _productService.GetProductById(id);
            return View(ProductMapper.MapToProductVM(productVM));
        }

        [HttpPost]
        public IActionResult Edit(ProductVM productEdit, Guid id)
        {
            //if (!ModelState.IsValid)
            //{
            //    var productVM = _productService.GetProductById(id);
            //    return View(productVM);
            //}

            _productService.UpdateProduct(ProductMapper.MapToProductDTO(productEdit), id);
            return RedirectToAction("Products", "Product");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductVM newProduct)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(newProduct);
            //}

            _productService.AddProduct(ProductMapper.MapToProductDTO(newProduct));
            return RedirectToAction("Products", "Product");
        }
    }
}
