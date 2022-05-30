using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookShop.Data
{
    [Table("VistorRate")]
    public class VistorRate
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [ForeignKey("book")]
        public int BookId { get; set; }
        public Book book { get; set; }

    }
}
