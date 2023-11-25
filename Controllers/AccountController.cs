using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EdithTour.Models;
using EdithTour.Areas.Admin;
using System.Dynamic;

namespace EdithTour.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public EdithTourEntities db = new EdithTourEntities();
        // GET: Account
        public ActionResult Index()
        {
            if (Session["ID_customer"] != null)
            {
                return View("Index", "Home");
            }
            else if (Session["ID_admin"] != null)
            {
                return View("Index", "HomeAdmin");
            }
            return Index();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password,Customer customer,Admin admin)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data_cus = db.Customers.Where(s => s.Username == customer.Username && s.Password == customer.Password);
                var data_ad = db.Admins.Where(s => s.Username == customer.Username && s.Password == customer.Password);
                if (data_cus.Count() > 0)
                {
                    //add session
                    Session["Name"] = data_cus.FirstOrDefault().Name;
                    Session["Email"] = data_cus.FirstOrDefault().Email;
                    Session["ID_Customer"] = data_cus.FirstOrDefault().ID_customer;
                    Session["Phone"] = data_cus.FirstOrDefault().Phone;
                    Session["Address"] = data_cus.FirstOrDefault().Address;
                    Session["Birthday"] = data_cus.FirstOrDefault().Birthday;
                    Session["Avatar"] = data_cus.FirstOrDefault().Avatar;
                    return RedirectToAction("Index", "Home");
                }
                else if (data_ad.Count() > 0)
                {
                    //add session
                    Session["Name"] = data_ad.FirstOrDefault().Name;
                    Session["Email"] = data_ad.FirstOrDefault().Email;
                    Session["ID_admin"] = data_ad.FirstOrDefault().ID_admin;
                    Session["Phone"] = data_cus.FirstOrDefault().Phone;
                    Session["Address"] = data_cus.FirstOrDefault().Address;
                    Session["Birthday"] = data_cus.FirstOrDefault().Birthday;
                    Session["Avatar"] = data_cus.FirstOrDefault().Avatar;
                    return View("~/Areas/Admin/Views/HomeAdmin/Index.cshtml");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();

        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer, Admin admin)
        {
            if (ModelState.IsValid)
            {
                var check = db.Customers.FirstOrDefault(s => s.Username == customer.Username);
                var check_ad = db.Admins.FirstOrDefault(s=>s.Username == customer.Username);
                if (check == null)
                {
                    customer.Password = GetMD5(customer.Password);
                    customer.Name = customer.Name;
                    customer.Email = customer.Email;
                    customer.Phone = customer.Phone;
                    customer.Address = customer.Address;
                    customer.Birthday = customer.Birthday;
                    customer.Avatar = customer.Avatar;
                    return RedirectToAction("Index", "Home");



                }
                else if (check_ad==null)
                {
                    admin.Password = GetMD5(admin.Password);
                    admin.Name = admin.Name;
                    admin.Email = admin.Email;
                    admin.Phone = admin.Phone;
                    admin.Address = admin.Address;
                    admin.Birthday = admin.Birthday;
                    admin.Avatar = admin.Avatar;
                    return View("~/Areas/Admin/Views/HomeAdmin/Index.cshtml");

                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }


}