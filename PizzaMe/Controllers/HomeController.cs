//using PizzaMe.Data;
using PizzaMe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaMe.Controllers
{
    

    public class HomeController : Controller
    {

        PizzaMeDbContext db = new PizzaMeDbContext();

        public ActionResult Index()
        {

            ViewBag.hello = db.Companies.Where(x => x.CompanyName == "dominos");
            return View();
        }
        
        public ActionResult Order(int NoOfPizzas, DietaryRequirements DR, bool Delivery)
        {
            ViewBag.NoOfPizzas = NoOfPizzas;
            ViewBag.DR = DR;
            ViewBag.Delivery = Delivery;

            var Coupon241 = db.Coupons.Where(x => x.NoOfPizzasTwoForOne == NoOfPizzas).ToList();


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public enum DietaryRequirements
    {
        None, GlutenFree, Hindu, Vegetarian, Vegan, SeafoodOnly, NoPork
    }
}