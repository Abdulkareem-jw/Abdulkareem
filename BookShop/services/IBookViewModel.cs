using BookShop.Data;
using System.Collections.Generic;
namespace BookShop.services
{
    public interface IBookViewModel
    {
        Book book { get; set; }
        List<Book> Books { get; set; }
        List<Auther> liAuther { get; set; }
        List<Category> liCategory { get; set; }
    }
}
