using BookShop.Data;
using BookShop.services;
using System.Collections.Generic;

namespace BookShop.Models
{
    public class BookViewModel: IBookViewModel
    {
        public Book book { get; set; }
        public List<Book>  Books { get; set; }
        public List<Auther> liAuther { get; set; }
        public List<Category> liCategory { get; set; }

    }
}
