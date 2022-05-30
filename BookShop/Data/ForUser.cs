using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class ForUser
    {
        public string Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string RoleId { get; set; }
        public int Gender { get; set; }
        public IFormFile Image { get; set; }
        public int CountryId { get; set; }
        [Required,Compare("ConfirmPassword")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
