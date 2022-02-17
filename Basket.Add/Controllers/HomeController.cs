using Basket.Add.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Add.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            ProductDetailList productDetailLists = new ProductDetailList();
            if (_memoryCache.Get<ProductDetailList>("Basket") != null)
            {
                productDetailLists = _memoryCache.Get<ProductDetailList>("Basket");
            }
            ViewBag.count = productDetailLists.productDetails.Count().ToString();



            return View();
        }

        [HttpPost]
        public ActionResult AddBasket([FromBody] ProductDetail productDetail)
        {

            ProductDetailList productDetailLists = new ProductDetailList();
            if (_memoryCache.Get<ProductDetailList>("Basket") != null)
            {
                productDetailLists = _memoryCache.Get<ProductDetailList>("Basket");
                _memoryCache.Remove("Basket");
            }
            productDetailLists.productDetails.Add(productDetail);
            
            _memoryCache.Set<ProductDetailList>("Basket", productDetailLists);

            return Json(new { result = 1, message = $"Başarılı",countProduct=$"{productDetailLists.productDetails.Count()}" });
        }

        [HttpGet]
        public ActionResult BasketDetail()
        {
            ProductDetailList productDetailLists = new ProductDetailList();
            if (_memoryCache.Get<ProductDetailList>("Basket") != null)
            {
                productDetailLists = _memoryCache.Get<ProductDetailList>("Basket");
            }
            return View(productDetailLists);
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
