using BookShop.Models;
using BookShop.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Authorize]
    public class AutherController : Controller
    {
        IAutherServices autherServices;
        AutherViewModel vm;
        public AutherController(IAutherServices _autherServices)
        {
            autherServices = _autherServices;
            vm = new AutherViewModel();
        }
        public IActionResult AddNewAuther()
        {
            ViewData["InsertMessage"] = -1;// -1 => nothing, 0=>error add, 1 => add, 
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            vm.liAuther= autherServices.SellectAll();
            vm.country = autherServices.countries();

            return View("AddNewAuther",vm);
        }
        public IActionResult SaveNewAuther(AutherViewModel vm2)
        {
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            if (ModelState.IsValid)
            {
               bool state= autherServices.Insert(vm2.auther);
                if (state)
                {
                    ViewData["InsertMessage"] = 1;
                    

                }
                else
                {
                    ViewData["InsertMessage"] = 0;
                }
            }
            vm2.liAuther = autherServices.SellectAll();
            vm2.country = autherServices.countries();
            return View("AddNewAuther", vm2);
        }
        
        public IActionResult SearchByName()
        {
            ViewData["updateMessage"] = false;
            ViewData["InsertMessage"] = -1;
            ViewData["Number"] = 1;
            string name = Request.Form["search"];

            if (name == "" || name == "Required Field!!!")
            {
                ViewData["ErrorSearch"] = "Required Field!!!";
                vm.liAuther = autherServices.SellectAll();
                vm.country = autherServices.countries();
            }
            else
            {
                vm.liAuther = autherServices.SelectByName(name);
                if (vm.liAuther.Count == 0)
                {
                    ViewData["ErrorSearch"] = "Not Found";
                    vm.liAuther = autherServices.SellectAll();
                    vm.country = autherServices.countries();
                }
                else
                {
                    ViewData["ErrorSearch"] = "";
                    vm.country = autherServices.countries();
                }
            }

            return View("AddNewAuther", vm);
        }
        public IActionResult DeleteAllAuthers()
        {
            ViewData["InsertMessage"] = -1;
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            autherServices.DeleteAll();
            vm.liAuther = autherServices.SellectAll();
            vm.country = autherServices.countries();
            return View("AddNewAuther", vm);
        }
        public IActionResult UpdateAuther(int id)
        {
            ViewData["InsertMessage"] = -1;

            ViewData["updateMessage"] = true;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            if (ModelState.IsValid)
            {
                vm.auther = autherServices.SelectById(id);
            }
            vm.liAuther = autherServices.SellectAll();
            vm.country = autherServices.countries();

            return View("AddNewAuther", vm);
        }
        public IActionResult SaveUpdateAuther(AutherViewModel vm2,int id)
        {
            ViewData["InsertMessage"] = -1;

            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid)
            {
                vm2.auther.Id = id;
                autherServices.Update(vm2.auther);
            }
            vm.liAuther = autherServices.SellectAll();
            vm.country = autherServices.countries();

            return View("AddNewAuther", vm);
        }
        public IActionResult DeleteAutherById(int id)
        {
            ViewData["InsertMessage"] = -1;
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid && id != 0)
            {
                autherServices.DeleteCategoryById(id);
            }
            vm.liAuther = autherServices.SellectAll();
            vm.country = autherServices.countries();
            return View("AddNewAuther", vm);
            ;
        }
    }
}
