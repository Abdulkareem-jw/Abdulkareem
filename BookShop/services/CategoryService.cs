using BookShop.Data;
using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.services
{
    public class CategoryService: ICategoryService
    {
        BookShopContext context;
        Category category; 
        public CategoryService(BookShopContext _context)
        {
            context = _context;
            category = new Category();
        }
        public List<Category> SellectAll()
        {
            CategoryViewModel ctegoryViewModel = new CategoryViewModel();
            ctegoryViewModel.liCategory = context.categories.ToList();
            return ctegoryViewModel.liCategory;
        }
        public bool Insert(Category category)
        {
            
            context.Add(category);
            var result=context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
                return false;
        }
        public void DeleteCategoryById(int id)
        {
        
            
            category = context.categories.Where(Id => Id.Id == id).FirstOrDefault();
            context.Remove(category);
            context.SaveChanges();
        }
        public void DeleteAllCategory()
        {

            List<Category> lic = context.categories.ToList();
            lic.ForEach(x =>
            {
                context.Entry(x).State = EntityState.Deleted;
            });
            context.SaveChanges();
        }

        public Category SelectById(int id)
        {
            
            category = context.categories.Where(Id => Id.Id == id).FirstOrDefault();
            return category;
        }
        public List<Category> SelectByName(string name)
        {
            List<Category> lic=context.categories.Where(n=>n.Name == name).ToList();


            return lic;
        }
        public void Update(Category category)
        {
            context.Attach(category);
            context.Entry(category).State=EntityState.Modified;
            
            context.SaveChanges();

        }
    }
}
