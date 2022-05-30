using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Data
{
    
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string RoleId { get; set; }
        public int Gender { get; set; }
        public DateTime JoinDate { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [ForeignKey("country")]
        public int CountryId { get; set; }

        public Country country { get; set; }
        
    }
}
