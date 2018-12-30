using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hurst.BLL;
using Hurst.DAL;
using Hurst.Models;

namespace Hurst.Controllers
{
    public class ShopController : Controller
    {
        private  ProductService _service = new ProductService();
        // GET: Shop
        public ActionResult Shop()
        {
            ModelShop model = new ModelShop(){Products = _service.GetProducts() , Search = ""};
            return View(model);
        }

        public ActionResult AddProduct()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {

            if (_service.AddProduct(product))
            {
                return RedirectToAction("Shop");
            }
            return View(product);
        }

        public ActionResult EditProduct(int id)
        {
            Product product = _service.GetProducts().Find(t => t.Id == id);           
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (_service.EditProduct(product))
            {
                return RedirectToAction("Shop");
            }
            return View();
        }

        public ActionResult DeleteProduct(int id)
        {
            Product product = _service.GetProducts().Find(t => t.Id == id);
            return View(product);
        }
        [HttpPost]
        public ActionResult DeleteProduct(Product product)
        {
            if (_service.DeleteProduct(product))
            {
                return RedirectToAction("Shop");
            }
            return View(product);
        }

        public ActionResult Search(ModelShop model)
        {
            var k = _service.GetProducts();
            List<Product> products = k.Where(t => t.Name.ToLower().Contains(model.Search.ToLower())).ToList();
            model.Products = products;
            return View("Shop", model);
        }
    }
}