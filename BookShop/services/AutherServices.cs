using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.services
{
    public class AutherServices: IAutherServices
    {
        BookShopContext context;
        public AutherServices(BookShopContext _context)
        {
            context = _context;
        }
        public List<Auther> SellectAll()
        {
            List<Auther> list = context.authers.Include("country").ToList();
            return list;
        }
        public bool Insert(Auther auther)
        {
            auther.Age = auther.Age.Date;
            
            context.authers.Add(auther);
            context.SaveChanges();
            return true;
            
        }
        public List<Auther> SelectByName(string name)
        {
            List<Auther> list = context.authers.Where(n => n.FullName == name).Include("country").ToList();
            return list;

        }
        public Auther SelectById(int id)
        {
            Auther auther = context.authers.Where(i=>i.Id==id).Include("country").FirstOrDefault();
            return auther;

        }
        public void DeleteAll()
        {
            List<Auther> list = context.authers.ToList();
            list.ForEach(d =>
            {
                context.Entry(d).State = EntityState.Deleted;
            });
            context.SaveChanges();

        }
        public void Update(Auther auther)
        {
            context.authers.Attach(auther);
            context.Entry(auther).State = EntityState.Modified;
            context.SaveChanges();

        }
        public void DeleteCategoryById(int id)
        {
            Auther auther= context.authers.Where(i => i.Id == id).FirstOrDefault();
            context.authers.Remove(auther);
            context.SaveChanges();

        }
        public List<Country> countries()
        {
            List<Country> list= context.countries.ToList();
            return list;
        }

    }
}
