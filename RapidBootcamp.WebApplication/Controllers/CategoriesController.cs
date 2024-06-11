using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.WebApplication.DAL;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategory _categoryEF;
        public CategoriesController(ICategory categoryEF)
        {
            _categoryEF = categoryEF;
        }

        // GET: CategoriesController
        public ActionResult Index(string categoryname="")
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            IEnumerable<Category> categories;
            if (categoryname != "")
            {
                categories = _categoryEF.GetCategoriesByName(categoryname);
            }
            else
            {
                categories = _categoryEF.GetAll();
            }
           
            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categoryEF.GetById(id);
            return View(category);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                var result = _categoryEF.Add(category);
                TempData["Message"] = $"Category {category.CategoryName} added succsesfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Category not added";
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryEF.GetById(id);
            return View(category);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                var result = _categoryEF.Update(category);
                TempData["Message"] = $"Category {category.CategoryName} updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Category not updated";
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categoryEF.GetById(id);
            return View(category);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int CategoryId)
        {
            try
            {
                _categoryEF.Delete(CategoryId);
                TempData["Message"] = $"Category with id: {CategoryId} Delete succsessfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Category not Deleted";
                return View();
            }
        }
    }
}
