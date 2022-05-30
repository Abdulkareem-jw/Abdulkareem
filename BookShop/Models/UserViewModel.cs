using BookShop.Data;
using BookShop.services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BookShop.Models
{
    public class UserViewModel: IUserViewModel
    {
        public ForUser user { get; set; }
        public List<ApplicationUser> users { get; set; }
        public List<Country> countries { get; set; }
        public List<IdentityRole>  Rols{ get; set; }



    }
}
