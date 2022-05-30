using BookShop.Models;
using BookShop.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        CategoryViewModel vm; 
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
            vm=new CategoryViewModel();
        }
        public IActionResult AddNewCategory()
        {

            ViewData["InsertMessage"] = -1;// -1 => nothing, 0=>error add, 1 => add, 
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            vm.liCategory = categoryService.SellectAll();
            return View(vm);
        }
        public IActionResult SaveNewCategory(CategoryViewModel vm)
        {
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            if (ModelState.IsValid)
            {
                bool state = categoryService.Insert(vm.category);
                if (state)
                {
                    ViewData["InsertMessage"] = 1;
                    

                }
            }
            else
            {
                ViewData["InsertMessage"] = 0;
            }
            vm.liCategory = categoryService.SellectAll();
            return View("AddNewCategory", vm);
        }
        public IActionResult DeleteCategory(int id) 
        {
            ViewData["InsertMessage"] = -1;
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid && id != 0) 
            {
                categoryService.DeleteCategoryById(id);
            }
            vm.liCategory = categoryService.SellectAll();
            return View("AddNewCategory", vm);
        }
        public IActionResult DeleteAllCategory()
        {
            ViewData["InsertMessage"] = -1;
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            if (ModelState.IsValid)
            {
                categoryService.DeleteAllCategory();
            }
            vm.liCategory = categoryService.SellectAll();
            return View("AddNewCategory", vm);
        }
        
        public IActionResult UpdateCategory(int id)
        {

            ViewData["InsertMessage"] = -1;

            ViewData["updateMessage"] = true;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid)
            {
                return Json( categoryService.SelectById(id));
            }
             vm.liCategory = categoryService.SellectAll();

            
            return View("AddNewCategory", vm);
        }
        public IActionResult SaveUpdateCategory(CategoryViewModel vm,int id)
        {
            ViewData["InsertMessage"] = -1;

            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid)
            {
                vm.category.Id = id;
                categoryService.Update(vm.category);
            }
             vm.liCategory = categoryService.SellectAll();

            
            return View("AddNewCategory", vm);
        }
        public IActionResult SearchByName()
        {
            ViewData["updateMessage"] = false;
            ViewData["InsertMessage"] = -1;
            ViewData["Number"] = 1;

            string name = Request.Form["search"];
            if(name==""||name== "Required Field!!!")
            {
                ViewData["ErrorSearch"] = "Required Field!!!";
                vm.liCategory = categoryService.SellectAll();
            }
            else
            {
                vm.liCategory=categoryService.SelectByName(name);
                if(vm.liCategory.Count==0)
                {
                    ViewData["ErrorSearch"] = "Not Found";
                    vm.liCategory = categoryService.SellectAll();
                }
                else
                {
                    ViewData["ErrorSearch"] = "";
                }
            }
            
            return View("AddNewCategory", vm);
        }

        
    }
}
