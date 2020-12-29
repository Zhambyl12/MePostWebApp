using MePostWebApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MePostWebApp.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            ViewBag.Table = Calculate.GetTeable().ToList(); 
            return View(new Poster());
        }
        [HttpPost]
        public ActionResult Index(Poster poster)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Table = Calculate.GetTeable().ToList();
                ViewBag.Error = "Данные для вычисления не полный!";
                return View(poster);
            }
            var res = Calculate.Calc(poster); 
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("Uz");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("Uz");
            ViewBag.Result = Convert.ToDecimal(res).ToString("C"); 
            ViewBag.Table = Calculate.GetTeable().ToList();
            return View(poster);
        }
        public ActionResult Process()
        {
            ViewBag.Table = Calculate.GetTeable().ToList();
            return View(new Poster());
        }
        [HttpPost]
        public ActionResult Process(string Country,string Type,string Height,string Width,string Length, string Weight)
        {
            double hg = Double.Parse(Height);
            double ln = Double.Parse(Length);
            double wd = Double.Parse(Width);
            double wg = Double.Parse(Weight);

            Poster poster = new Poster();
            poster.Country = Country;
            poster.Height = hg;
            poster.Length = ln;
            poster.Width = wd;
            poster.Weight = wg;
            poster.Type = Type;

            if (!ModelState.IsValid)
            {
                ViewBag.Table = Calculate.GetTeable().ToList();
                ViewBag.Error = "Данные для вычисления не полный!";
                return View(poster);
            }

            var res = Calculate.Calc(poster);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("Uz");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("Uz");
            ViewBag.Result = Convert.ToDecimal(res).ToString("C");
            ViewBag.Table = Calculate.GetTeable().ToList();
            return View(poster);
        }
    }
}