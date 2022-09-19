using JhooneByUjuWeb.Data;
using JhooneByUjuWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace JhooneByUjuWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoriesList = _db.Categories;

            return View(categoriesList);
        }

        //GET
        [HttpGet]       
        public IActionResult Create()
        {
            return View();
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,DisplayOrder,CreatedDateTIme")] Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot be exactly the same as Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(category);
            
        }
        
    }
}
