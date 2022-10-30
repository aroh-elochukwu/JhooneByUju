using JhooneByUju.DataAccess;
using JhooneByUju.DataAccess.Repository.IRepository;
using JhooneByUju.Models;
using Microsoft.AspNetCore.Mvc;

namespace JhooneByUjuWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork  _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoriesList = _unitOfWork.Category.GetAll();

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
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";

                return RedirectToAction("Index");

            }
            return View(category);
            
        }

        //GET
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category requestedCategory = _unitOfWork.Category.GetFirstOrDefault(u => u.Name == "id");

            return View(requestedCategory);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,DisplayOrder,CreatedDateTIme")] Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot be exactly the same as Name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category edited successfully";

                return RedirectToAction("Index");

            }
            return View(category);

        }

        //GET
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category requestedCategory = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            return View(requestedCategory);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("Id,Name,DisplayOrder,CreatedDateTIme")] Category category)
        {
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }

    }
}
