using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JhooneByUju.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Designer { get; set; }
        [Required]
        [Range(1,10000000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000000)]
        public double Price { get; set; }
        [Required]
        [Range(1, 10000000)]
        public double Price10 { get; set; }
        [Required]
        [Range(1, 10000000)]
        public double Price20 { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
