using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SantaClaus;
using SantaClaus.Models;

namespace SantaClaus.Controllers
{
    public class ToyController : Controller
    {
        // GET: Toy
        public ActionResult Index()
        {
            MongoDB db = new MongoDB();
            var toys = db.GetAllToy();
            Toys model = new Toys();
            model.EntityList = toys.ToList();

            return View(model);
        }
    }
}