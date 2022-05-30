using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BookShop.services
{
    public class BookServices: IBookServices
    {
        BookShopContext context;
        public BookServices(BookShopContext _context)
        {
            context= _context;
        }
        public bool Insert (Book book)
        {
            string name = Guid.NewGuid().ToString() + "." + book.Image.FileName.Split(".")[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), "BookImage", name);
            book.Image.CopyTo(new FileStream(path ,FileMode.Create));
            book.Path = "http://localhost/BookShop/BImg/" + name;
            context.books.Add(book);
            context.SaveChanges();
            return true;

        }
        public List<Category> SellectCategory()
        {
            List<Category> list = context.categories.ToList();
            return list;
        }
        public List<Auther> SellectAuther()
        {
            List<Auther> list = context.authers.Include("country").ToList();
            return list;
        }
        public List<Book> SelectAll()
        {
            List<Book> list = context.books.ToList();
            return list;
        }
        public void DeleteById(int id)
        {
            Book book = context.books.Where(b => b.Id == id).FirstOrDefault();
            context.books.Remove(book);
            context.SaveChanges();
        }
        public void DeleteAll()
        {
            List< Book> books = context.books.ToList();
            books.ForEach(b =>
            {
                context.books.Remove(b);
            });
            context.SaveChanges();
        }
        public Book SelectById(int id)
        {
            Book book = context.books.Where(i => i.Id == id).FirstOrDefault();
            return book;

        }
        public void Update(Book book)
        {
            context.books.Attach(book);
            context.Entry(book).State=EntityState.Modified;
            context.SaveChanges();

        }
        public List<Book> SelectByName(string title)
        {
            List<Book> list = context.books.Where(n => n.Title == title).ToList();
            return list;

        }
    }
}
