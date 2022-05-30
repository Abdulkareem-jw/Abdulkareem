using BookShop.Data;
using BookShop.services;
using System.Collections.Generic;

namespace BookShop.Models
{
    public class CountryViewModel: ICountryVeiwModel
    {
       public Country country { get; set; }
        public List<Country> licountry { get; set; }
    }
}
