using BookShop.Data;
using BookShop.services;
using System.Collections.Generic;

namespace BookShop.Models
{
    public class CategoryViewModel
    {
        public Category category { get; set; }
        public List<Category> liCategory { get; set; }
    }
}
