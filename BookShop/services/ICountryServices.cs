using BookShop.Data;
using System.Collections.Generic;

namespace BookShop.services
{
    public interface ICountryServices
    {
        List<Country> SelectAll();
        bool SaveNewCountry(Country country);
        List<Country> SelectByName(string name);
        void DeleteAll();
        void DeleteById(int id);
        Country Update(int id);
        void SaveUpdate(Country country2);
    }
}
