using BookShop.Data;
using System.Collections.Generic;

namespace BookShop.services
{
    public interface ICategoryService
    {
        List<Category> SellectAll();
        bool Insert(Category category);
        void DeleteCategoryById(int id);
        Category SelectById(int id);
        void Update(Category category);
        List<Category> SelectByName(string name);
        void DeleteAllCategory();
    }
}
