using BookShop.Models;
using BookShop.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Authorize]
    public class CountryController : Controller
    {
        ICountryServices countryServices;
        ICountryVeiwModel countryVeiwModel;
        public CountryController(ICountryServices _countryServices, ICountryVeiwModel _countryVeiwModel)
        {
            countryServices = _countryServices;
            countryVeiwModel = _countryVeiwModel;
        }
        public IActionResult AddNewCountry()
        {
            ViewData["InsertMessage"] = -1;// -1 => nothing, 0=>error add, 1 => add, 
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            countryVeiwModel.licountry= countryServices.SelectAll();
            return View("AddNewCountry", countryVeiwModel);
        }
        public IActionResult SaveNewCountry(CountryViewModel countryVeiwModel2)
        {
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            if (ModelState.IsValid)
            {
                bool state = countryServices.SaveNewCountry(countryVeiwModel2.country);
                if (state)
                {
                    ViewData["InsertMessage"] = 1;


                }
                else
                {
                    ViewData["InsertMessage"] = 0;
                }
                countryVeiwModel2.licountry = countryServices.SelectAll();
            }
            return View("AddNewCountry", countryVeiwModel2);
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
                countryVeiwModel.licountry = countryServices.SelectAll();
            }
            else
            {
                countryVeiwModel.licountry = countryServices.SelectByName(name);
                if (countryVeiwModel.licountry.Count == 0)
                {
                    ViewData["ErrorSearch"] = "Not Found";
                    countryVeiwModel.licountry = countryServices.SelectAll();
                }
                else
                {
                    ViewData["ErrorSearch"] = "";
                }
            }
            return View("AddNewCountry", countryVeiwModel);
        }
        public IActionResult DeleteAllCategory()
        {
            ViewData["InsertMessage"] = -1;
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            if (ModelState.IsValid)
            {
                countryServices.DeleteAll();
            }
            countryVeiwModel.licountry = countryServices.SelectAll();
            return View("AddNewCountry", countryVeiwModel);
        }
        public IActionResult DeleteById(int id)
        {
            ViewData["InsertMessage"] = -1;
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            if (ModelState.IsValid)
            {
                countryServices.DeleteById(id);
            }
            countryVeiwModel.licountry = countryServices.SelectAll();
            return View("AddNewCountry", countryVeiwModel);
        }
        public IActionResult Update(int id)
        {
            ViewData["InsertMessage"] = -1;

            ViewData["updateMessage"] = true;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            if (ModelState.IsValid)
            {
                countryVeiwModel.country = countryServices.Update(id);
            }
            countryVeiwModel.licountry = countryServices.SelectAll();

            return View("AddNewCountry", countryVeiwModel);
        }
        public IActionResult SaveUpdate(CountryViewModel countryVeiwModel2,int id)
        {
            ViewData["InsertMessage"] = -1;
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid)
            {
                countryVeiwModel2.country.Id = id;
                countryServices.SaveUpdate(countryVeiwModel2.country);
            }
            countryVeiwModel.licountry = countryServices.SelectAll();

            return View("AddNewCountry", countryVeiwModel);
        }
    }
}
