using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSalesSystem.Data;
using ProductSalesSystem.Models;
using ProductSalesSystem.Repositories;

namespace ProductSalesSystem.Controllers
{
    public class ProductController : Controller
    {
        public static decimal Earning = 0;

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDTO pro)
        {
            if (ModelState.IsValid)
            {
                if (pro.File != null && pro.File.Length > 0)
                {
                    string extension = Path.GetExtension(pro.File.FileName);
                    string filename = Guid.NewGuid().ToString() + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", filename);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pro.File.CopyTo(stream);
                    }
                    pro.FilePath = "/img/" + filename;
                }
                else
                {
                    ViewBag.Message = "Lütfen bir dosya seçin.";
                    return View(pro);
                }

                _productRepository.AddProduct(pro);
                return RedirectToAction("ProductList");
            }
            return View(pro);
        }

        public IActionResult ProductList()
        {
            var prod = _productRepository.GetAllProduct();
            return View(prod);
        }


        [HttpGet]
        public IActionResult ProductMarketing()
        {
            ViewBag.Product = _productRepository.GetAllProduct();
            ViewBag.TotalPrice = Earning;
            return View();
        }


        [HttpPost]
        public IActionResult ProductMarketing(SellDTO sell)
        {
            if (sell != null)
            {
                _productRepository.ProductMarketing(sell);
                Earning += sell.TotalPrice;
            }
            return RedirectToAction("ProductMarketing");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {

            var product = _productRepository.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductDTO _pro)
        {
            if (ModelState.IsValid)
            {

                if (_pro.File != null && _pro.File.Length > 0)
                {
                    string extension = Path.GetExtension(_pro.File.FileName);
                    string filename = Guid.NewGuid().ToString() + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", filename);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        _pro.File.CopyTo(stream);
                    }
                    _pro.FilePath = "/img/" + filename;
                }
                else
                {
                    ViewBag.Message = "Lütfen bir dosya seçin.";
                    return View(_pro);
                }

                _productRepository.UpdateProduct(_pro);
                return RedirectToAction("ProductList");
            }
            return View(_pro);
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var pro = _productRepository.GetProductById(id);
            _productRepository.DeleteProduct(pro);
            return RedirectToAction("ProductList");
        }

    }
}
