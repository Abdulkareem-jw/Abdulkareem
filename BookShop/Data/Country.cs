using BookShop.services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Data
{
    [Table("Country")]
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<ApplicationUser> users { get; set; }
        public List<Auther> authers { get; set; }
    }
}
