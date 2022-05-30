using BookShop.Data;
using System.Collections.Generic;

namespace BookShop.services
{
    public interface ICountryVeiwModel
    {
        Country country { get; set; }
        List<Country> licountry { get; set; }
    }
}
