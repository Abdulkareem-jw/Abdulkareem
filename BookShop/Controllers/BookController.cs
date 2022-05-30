using BookShop.Models;
using BookShop.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        IBookServices bookServices;
        IBookViewModel bookViewModel;
        public BookController(IBookServices _bookServices, IBookViewModel _bookViewModel)
        {
            bookServices = _bookServices;
            bookViewModel = _bookViewModel;
        }
        public IActionResult AddNewBook()
        {
            ViewData["ImagePath"] = TempData["ImagePath"];
            ViewData["InsertMessage"] = -1;// -1 => nothing, 0=>error add, 1 => add, 
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            bookViewModel.liCategory = bookServices.SellectCategory();
            bookViewModel.liAuther = bookServices.SellectAuther();
            bookViewModel.Books = bookServices.SelectAll();
            return View("AddNewBook", bookViewModel);
        }
        public IActionResult SaveNewBook(BookViewModel vm)
        {
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            if (ModelState.IsValid)
            {
                bool state = bookServices.Insert(vm.book);
                if (state)
                {
                    ViewData["InsertMessage"] = 1;


                }
            }
            else
            {
                ViewData["InsertMessage"] = 0;
            }
            bookViewModel.liCategory = bookServices.SellectCategory();
            bookViewModel.liAuther = bookServices.SellectAuther();
            bookViewModel.Books = bookServices.SelectAll();
            return View("AddNewBook", bookViewModel);
        }

        public IActionResult DeleteBook(int id)
        {
            ViewData["InsertMessage"] = -1;
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid && id != 0)
            {
                bookServices.DeleteById(id);
            }
            bookViewModel.liCategory = bookServices.SellectCategory();
            bookViewModel.liAuther = bookServices.SellectAuther();
            bookViewModel.Books = bookServices.SelectAll();
            return View("AddNewBook", bookViewModel);
        }

        public IActionResult DeleteAllBooks()
        {
            ViewData["InsertMessage"] = -1;
            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;
            if (ModelState.IsValid)
            {
                bookServices.DeleteAll();
            }
            bookViewModel.liCategory = bookServices.SellectCategory();
            bookViewModel.liAuther = bookServices.SellectAuther();
            bookViewModel.Books = bookServices.SelectAll();
            return View("AddNewBook", bookViewModel);
        }
        public IActionResult UpdateBook(int id)
        {

            ViewData["InsertMessage"] = -1;

            ViewData["updateMessage"] = true;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid)
            {
                bookViewModel.book = bookServices.SelectById(id);
            }
            bookViewModel.liCategory = bookServices.SellectCategory();
            bookViewModel.liAuther = bookServices.SellectAuther();
            bookViewModel.Books = bookServices.SelectAll();

            return View("AddNewBook", bookViewModel);
        }
        public IActionResult SaveUpdateBook(BookViewModel vm, int id)
        {
            ViewData["InsertMessage"] = -1;

            ViewData["updateMessage"] = false;
            ViewData["ErrorSearch"] = "";
            ViewData["Number"] = 1;

            if (ModelState.IsValid)
            {
                vm.book.Id = id;
                bookServices.Update(vm.book);
            }
            bookViewModel.liCategory = bookServices.SellectCategory();
            bookViewModel.liAuther = bookServices.SellectAuther();
            bookViewModel.Books = bookServices.SelectAll();


            return View("AddNewBook", bookViewModel);
        }

        public IActionResult SearchByName()
        {
            ViewData["updateMessage"] = false;
            ViewData["InsertMessage"] = -1;
            ViewData["Number"] = 1;
            bookViewModel.liCategory = bookServices.SellectCategory();
            bookViewModel.liAuther = bookServices.SellectAuther();

            string name = Request.Form["search"];
            if (name == "" || name == "Required Field!!!")
            {
                ViewData["ErrorSearch"] = "Required Field!!!";
                
                bookViewModel.Books = bookServices.SelectAll();
            }
            else
            {
                bookViewModel.Books = bookServices.SelectByName(name);
                if (bookViewModel.Books.Count == 0)
                {
                    ViewData["ErrorSearch"] = "Not Found";
                    
                    bookViewModel.Books = bookServices.SelectAll();
                }
                else
                {
                    ViewData["ErrorSearch"] = "";
                    
                }
            }

            return View("AddNewBook", bookViewModel);
        }
    }
}
