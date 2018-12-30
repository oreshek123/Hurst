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
    //[MyExceptionFilter]
    public class RegistrationController : Controller
    {
        private  SellerService _service = new SellerService();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Seller seller)
        {
            if (ModelState.IsValid)
            {
                _service.CreateSeller(seller);
                return RedirectToAction("MyAccount", new {id = seller.Id});
            }

            return View(seller);
        }

        public ActionResult MyAccount(int id)
        {
           Seller seller = _service.GetSellers().FirstOrDefault(t => t.Id == id);
            return View(seller);
        }
        [HttpPost]
        public ActionResult MyAccount(Seller seller)
        {
            _service.EditSeller(seller);
            ViewBag.Message = "Changes were saved successfully";
            return View(seller);
        }

        public ActionResult Login(User seller)
        {
            if (ModelState.IsValid)
            {

                if(_service.Login(seller.Email, seller.Password))
                return RedirectToAction("Shop", "Shop");
                else
                {
                    ViewBag.Message = "Login or password is incorrect";
                }
            }

            return View("Index");
        }
    }
}