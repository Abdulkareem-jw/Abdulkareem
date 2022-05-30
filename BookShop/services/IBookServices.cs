using BookShop.Data;
using System.Collections.Generic;

namespace BookShop.services
{
    public interface IBookServices
    {
        bool Insert(Book book);
        List<Category> SellectCategory();
        List<Auther> SellectAuther();
        List<Book> SelectAll();
        void DeleteById(int id);
        void DeleteAll();
        Book SelectById(int id);
        void Update(Book book);
        List<Book> SelectByName(string title);
    }
}
