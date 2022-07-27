using E_Commerce_Project.DAL;
using E_Commerce_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace E_Commerce_Project.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL db = new ProductDAL();

        public IActionResult Index()
        {
            var model = db.ProductsList();
            return View(model);
        }

        CartDAL cd = new CartDAL();
        //public IActionResult AddToCart()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddToCart(Cart ProdId)
        //{
        //    int result = cd.AddToCart(ProdId);
        //    if (result == 1)
        //    {
        //        return RedirectToAction("ViewCart");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //CartDAL cd = new CartDAL();

        //public IActionResult ViewInCart()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult ViewInCart(int id)
        {
            Cart cart = new Cart();
            cart.ProdId = id;
            cart.UserId = Convert.ToInt32(HttpContext.Session.GetString("userid"));
            int result = cd.AddToCart(cart);
            if (result == 1)
            {
                return RedirectToAction("ViewProductInCart");
            }
            else
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult ViewProductInCart()
        {
            string userid = HttpContext.Session.GetString("userid");
            var model = cd.ViewInCart(userid);
            return View(model);
        }


        // GET: ProductController/Delete/5
        public ActionResult RemoveProduct(int id)
        {
            var model = db.Remove(id);
            return View(model);
        }
    }
}
