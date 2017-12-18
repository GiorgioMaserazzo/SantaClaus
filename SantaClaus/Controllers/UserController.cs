using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using SantaClaus;

namespace SantaClaus.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        string Encrypt(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] resultHash;
            SHA512 shaM = new SHA512Managed();
            resultHash = shaM.ComputeHash(data);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < resultHash.Length; i++)
            {
                result.Append(resultHash[i].ToString("X2"));
            }
            return result.ToString().ToLower();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            user.Password = Encrypt(user.Password);
            MongoDB db = new MongoDB();
            var account = db.GetUser(user);
            if (account != null)
            {
                Session["email"] = account.Email.ToString();
                Session["id"] = account.ID.ToString();
                Session["username"] = account.UserName.ToString();
                Session["isadmin"] = account.IsAdmin.ToString();
                return RedirectToAction($"../Home");
            }
            else
            {
                ModelState.AddModelError("", "Email or Password Error");
            }
            return View();
        }

        public ActionResult Logout()
        {
            if (Session["ID"] != null)
            {
                Session.Clear();
                return RedirectToAction("Logout");
            }
            return View();
        }

    }
}