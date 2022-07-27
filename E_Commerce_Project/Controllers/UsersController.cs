using E_Commerce_Project.DAL;
using E_Commerce_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace E_Commerce_Project.Controllers
{
    public class UsersController : Controller
    {
        UsersDAL db = new UsersDAL(); 
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Users users)
        {
            int result = db.UserSignUp(users);
            if (result == 1)
            {
                return RedirectToAction("SignIn");
            }
            else
            {
                return View();
            }
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(Users users)
        {
            Users user = db.UserLogin(users);
            if (user.Password == users.Password)
            {
                HttpContext.Session.SetString("username", user.UserName);
                HttpContext.Session.SetString("userid", user.UserId.ToString());

                if (user.RoleId == 1)
                {
                    return RedirectToAction("AddProduct", "DeleteProduct", "Product"); 
                }
                else if (user.RoleId == 2)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
