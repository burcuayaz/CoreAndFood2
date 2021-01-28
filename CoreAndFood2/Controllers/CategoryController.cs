using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood2.Data.Models;
using CoreAndFood2.Repositories;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreAndFood2.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index(int page=1)
        { 
            return View(categoryRepository.TList().ToPagedList(page,3));
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd"); //Validationa takıldıysa
            }
            categoryRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);
            Category ct = new Category()
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                CategoryID = x.CategoryID
            };
            return View(ct);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var x= categoryRepository.TGet(p.CategoryID);
            x.CategoryName = p.CategoryName;
            x.CategoryDescription = p.CategoryDescription;
            x.Status =true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepository.TGet(id);
            x.Status = false;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
