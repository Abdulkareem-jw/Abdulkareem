using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class UserShopController : Controller
    {
        public IActionResult AddToUserShops()
        {
            return View();
        }
    }
}
