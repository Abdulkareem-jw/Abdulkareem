using BookShop.Data;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.services
{
    public class CountryServices: ICountryServices
    {
        BookShopContext context;
        public CountryServices(BookShopContext _context)
        {
            context = _context;
        }
        public List<Country> SelectAll()
        {
            List<Country> countryList = new List<Country>();
            countryList = context.countries.ToList();
            return countryList;
        }
        public bool SaveNewCountry(Country country)
        {
            context.countries.Add(country);
            context.SaveChanges();
            return true;
        }
        public List<Country> SelectByName(string name)
        {
            List<Country> list= context.countries.Where(n=>n.Name==name).ToList();
            
            return list;
        }
        public void DeleteAll()
        {
            List<Country> list= context.countries.ToList();
            list.ForEach(li =>
            {
                context.countries.Remove(li);
            });
            
        }
        public void DeleteById(int id)
        {
            Country country= context.countries.Where(i=>i.Id==id).FirstOrDefault();
            context.countries.Remove(country);
            context.SaveChanges();
            
        }
        public Country Update(int id)
        {
            Country country= context.countries.Where(i=>i.Id==id).FirstOrDefault();
            return country;
            
        }
        public void SaveUpdate(Country country)
        {
            
            context.countries.Attach(country);
            context.Entry(country).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            
            
        }
    }
}
