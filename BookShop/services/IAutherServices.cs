using BookShop.Data;
using System.Collections.Generic;

namespace BookShop.services
{
    public interface IAutherServices
    {
        List<Auther> SellectAll();
        bool Insert(Auther auther);
        List<Auther> SelectByName(string name);
        Auther SelectById(int id);
        void Update(Auther auther);
        void DeleteCategoryById(int id);
        void DeleteAll();
        List<Country> countries();
    }
}
