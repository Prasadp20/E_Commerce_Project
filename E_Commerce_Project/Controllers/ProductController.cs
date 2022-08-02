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
            var model = db.ProductList();
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
            string userid = TempData["userid"].ToString();
            Cart cart = new Cart();
            cart.ProdId = id;
            cart.UserId = Convert.ToInt32(userid);
            //cart.UserId = userid;
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
        //public IActionResult RemoveProduct(int cartid)
        //{
        //    var model = cd.RemoveProduct(cartid);
        //    return RedirectToAction("ViewProductInCart");
        //}

        ///ITS A ORIGINAL 
        public ActionResult RemoveProduct(int CartId)
        {
            //var model = cd.RemoveProduct(CartId);
            //return View(model);

            int result = cd.RemoveProduct(CartId);
            if (result == 1)
                return RedirectToAction("ViewProductInCart");
            else
                return View();
        }

            OrderDAL od = new OrderDAL();
        [HttpGet]
        public IActionResult ViewOrder(int id)
        {
            string userid = TempData["userid"].ToString();
            Order order = new Order();
            order.ProdId = id;
            order.UserId = Convert.ToInt32(userid);
            int result = od.PlaceOrder(order);
            if (result == 1)
            {
                return RedirectToAction("ViewOrder");
            }
            else
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult ViewProductInOrder()
        {
            string userid = HttpContext.Session.GetString("userid");
            var model = od.ViewOrder(userid);
            return View(model);
        }

    }
}
