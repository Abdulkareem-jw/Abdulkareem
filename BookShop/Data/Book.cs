using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookShop.Data
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Year { get; set; }
        [Required]
        public string Price { get; set; }
        public double MemoryImprovment { get; set; }
        [Required]
        public string Language { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string Path { get; set; }
        public double? Rate { get; set; }
        [RegularExpression("/d{2}-/d{2}")]
        public string? TargetGroup { get; set; }
        [ForeignKey("auther")]
        public int AutherId { get; set; }
        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Auther auther { get; set; }
        public Category category { get; set; }
        public List<VistorRate> vistorRates{ get; set; }
    }
}
