using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public IFormFile imageUrl { get; set; }
        public string imagePath { get; set; }
    }
}
