using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetRestApi.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [MaxLength(30)]
        public string Name {get; set;}

        [Required]
        [MaxLength(50)]
        public string Description {get; set;}
        public decimal Price {get; set;}

        [Required]
        [MaxLength(250)]
        public string ImageUrl {get; set;}
        public float stock {get; set;}
        public DateTime CreatedAt {get; set;}

        public Category Category {get; set;}
        public int CategoryId {get; set;}
    }
}