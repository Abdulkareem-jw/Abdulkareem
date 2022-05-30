using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookShop.Data
{
    [Table("UserShop")]
    public class UserShop
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Price { get; set; }


        
    }
}
