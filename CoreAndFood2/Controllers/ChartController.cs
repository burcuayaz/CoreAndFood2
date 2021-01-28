using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood2.Data;
using CoreAndFood2.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood2.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
             proname="Computer",
             stock=150
            });
            cs.Add(new Class1()
            {
             proname="LCD",
             stock=75
            });
            cs.Add(new Class1()
            {
                proname = "Usb Disk",
                stock = 220
            });
            return cs;
        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using(var c=new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stock
                }).ToList();              
            }
            return cs2;
        }
        public IActionResult Statistics()
        {
            Context c = new Context();

            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;

            var deger2 = c.Categories.Count();
            ViewBag.d2 = deger2;

            var foid = c.Categories.Where(x => x.CategoryName == "Fruit").Select(x => x.CategoryID).FirstOrDefault();
            ViewBag.d = foid;
            var deger3 = c.Foods.Where(x=>x.CategoryID ==foid).Count();
            ViewBag.d3 = deger3;

            var deger4 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(z => z.CategoryName == "Vegetables").Select(z => z.CategoryID).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;

            var deger5 = c.Foods.Sum(x => x.Stock);
            ViewBag.d5 = deger5;

            var deger6 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(y => y.CategoryName == "Legumes").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;

            return View();
        }
    }
}
