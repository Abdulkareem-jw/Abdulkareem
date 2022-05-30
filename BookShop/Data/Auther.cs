using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookShop.Data
{
    [Table("Auther")]
    public class Auther
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public DateTime Age { get; set; }
        public int Gender { get; set; }
        [ForeignKey("country")]
        public int CountryId { get; set; }
        public Country country { get; set; }
        public List<Book> books { get; set; }
    }
}
