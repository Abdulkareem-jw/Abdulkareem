using BookShop.Data;
using BookShop.Models;
using BookShop.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    
    public class UserController : Controller
    {
        IUserServices userServices;
        IUserViewModel userViewModel;
        public UserController(IUserServices _userServices, IUserViewModel _userViewModel)
        {
            userServices = _userServices;
            userViewModel = _userViewModel;
        }
        [Authorize]
        public IActionResult AddNewUser()
        {
                

            ViewData["InsertMessage"] = -1;// -1 => nothing, 0=>error add, 1 => add, 
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            userViewModel.users = userServices.SellectAll();
            userViewModel.countries = userServices.countries();
            userViewModel.Rols = userServices.AllRoles();
            return View("AddNewUser", userViewModel);
        }
        [Authorize]
        public async Task<IActionResult> SignUp(UserViewModel u)
        {
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid)
            {
                var result = await userServices.SignUp(u.user);
                if (result.Succeeded)
                {
                    ViewData["InsertMessage"] = 1;


                }
            }
            else
            {
                ViewData["InsertMessage"] = 0;
            }
            userViewModel.users = userServices.SellectAll();
            userViewModel.countries = userServices.countries();
            userViewModel.Rols = userServices.AllRoles();

            return View("AddNewUser", userViewModel);
        }
        [Authorize]
        public IActionResult DeleteById(string id)
        {
            ViewData["InsertMessage"] = -1;
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid && id != "")
            {
                userServices.DeleteById(id);
            }
            userViewModel.users = userServices.SellectAll();
            userViewModel.countries = userServices.countries();
            userViewModel.Rols = userServices.AllRoles();

            return View("AddNewUser", userViewModel);
        }
        [Authorize]
        public IActionResult DeleteAll()
        {
            ViewData["InsertMessage"] = -1;
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            if (ModelState.IsValid)
            {
                userServices.DeleteAll();
            }
            userViewModel.users = userServices.SellectAll();
            userViewModel.countries = userServices.countries();
            userViewModel.Rols = userServices.AllRoles();

            return View("AddNewUser", userViewModel);
        }
        [Authorize]
        public async Task<IActionResult> Update(string id)
        {

            ViewData["InsertMessage"] = -1;

            
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid)
            {
                ViewData["updateMessage"] = true;
                //userViewModel.user= await userServices.SelectById(id);
                return Json(await userServices.SelectById(id));
            }
            userViewModel.users = userServices.SellectAll();
            userViewModel.countries = userServices.countries();
            userViewModel.Rols = userServices.AllRoles();


            return View("AddNewUser", userViewModel);
        }
        [Authorize]
        public IActionResult SaveUpdate(UserViewModel vm, string id)
        {
            ViewData["InsertMessage"] = -1;

            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid)
            {
                vm.user.Id = id;
                userServices.UpdateUser(vm.user);
            }
            userViewModel.users = userServices.SellectAll();
            userViewModel.countries = userServices.countries();
            userViewModel.Rols = userServices.AllRoles();


            return View("AddNewUser", userViewModel);
        }
        public IActionResult EnabeldOFF(string id)
        {
            ViewData["InsertMessage"] = -1;

            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if(ModelState.IsValid)
            {
                userServices.EnabeldUserOFF(id);
            }
            userViewModel.users = userServices.SellectAll();
            userViewModel.countries = userServices.countries();
            userViewModel.Rols = userServices.AllRoles();
            return View("AddNewUser", userViewModel);
        }
        public async Task<IActionResult> SignIn (SignIn signIn)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                
                 status = await userServices.CheckSignIn(signIn);
            }
                if (status)
                {
                string x = userServices.GetPath(signIn.UserName);
                TempData["ImagePath"] = x;
                    return RedirectToAction("AddNewBook", "Book");
                }
                else
                {
                    return RedirectToAction("LogIn");
                }
            
        }
        public IActionResult SingOut()
        {
            
            userServices.SingOut();
            return RedirectToAction("LogIn");
        }
        public IActionResult LogIn()
        {
            return View();
        }
        public async Task<IActionResult> SelectByName()
        {
            ViewData["updateMessage"] = false;
            ViewData["InsertMessage"] = -1;
            ViewData["Number"] = 1;
           
            userViewModel.countries = userServices.countries();
            userViewModel.Rols = userServices.AllRoles();

            string name = Request.Form["search"];
            if (name == "" || name == "Required Field!!!")
            {
                ViewData["ErrorSearch"] = "Required Field!!!";
                userViewModel.users = userServices.SellectAll();
            }
            else
            {

                userViewModel.users = userServices.SelectByName(name);
               
                if (userViewModel.users.Count == 0)
                {
                    ViewData["ErrorSearch"] = "Not Found";
                    userViewModel.users = userServices.SellectAll();
                }
                else
                {
                    ViewData["ErrorSearch"] = "";
                }
            }

            return View("AddNewUser", userViewModel);
        }

    }
}
