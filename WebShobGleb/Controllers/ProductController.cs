﻿using Application.Servises;
using Microsoft.AspNetCore.Mvc;
using Core.Repository;
using Web.Mappers;
using WebShobGleb.Mappers;
using WebShobGleb.Models;
using WebShobGleb.Repository;
using WebShobGleb.Servises;

namespace WebShobGleb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(Guid id)
        {
            var productVM = _productService.GetProductById(id);
            return View(ProductMapper.MapToProductVM(productVM));
        } 
    }
}
