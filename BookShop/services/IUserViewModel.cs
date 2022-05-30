using BookShop.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BookShop.services
{
    public interface IUserViewModel
    {
         ForUser user { get; set; }
        List<ApplicationUser> users { get; set; }
        List<Country> countries { get; set; }
        List<IdentityRole> Rols { get; set; }
    }
}
