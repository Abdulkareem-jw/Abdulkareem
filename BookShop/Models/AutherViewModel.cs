using BookShop.Data;
using System.Collections.Generic;

namespace BookShop.Models
{
    public class AutherViewModel
    {
        public Auther auther{ get; set; }
        public List<Auther> liAuther { get; set; }
        public List<Country> country { get; set; }
    }
}
