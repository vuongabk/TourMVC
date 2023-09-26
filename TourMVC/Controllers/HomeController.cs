using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourMVC.Models;

namespace TourMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            //Kiểm tra Email và Password trống?
            if (string.IsNullOrEmpty(email) == true | string.IsNullOrEmpty(password) == true)
            {
                ViewBag.thongbao = "Hãy điền đầy đủ Email và Password";
                return View();
            }
            //Tìm acc trong db
            var customer = new mapCustomer().TimKiem(email);
            //Kiểm tra tồn tại
            if(customer == null)
            {
                ViewBag.thongbao = "Email hoặc Password không đúng";
                ViewBag.email = email;
                return View();
            }
            //Lưu session
            Session["user"] = customer;
            //Chuyển về trang chủ
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.Remove("user");
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer model)
        {
            mapCustomer map = new mapCustomer();
            model.Address = "";
            if (ModelState.IsValid)
            {
                if (map.TimKiem(model.Email) != null)
                {
                    ViewBag.thongbao = "Email hoặc Số điện thoại đã tồn tại";
                    return View(model);
                }
                if (map.ThemMoi(model) == true)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }

        }
    }
}