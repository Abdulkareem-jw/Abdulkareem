using System.ComponentModel.DataAnnotations;

namespace BookShop.Data
{
    public class SignIn
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
