using System.ComponentModel.DataAnnotations;

namespace MannariEnterprises.Models{
    public class Product
    {   [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public string? ProductName { get; set; }
        
        public int Price{get;set;}

        public string? ProductDescription {get;set;}

        public string? ImageFileName { get; set; }

        public string? Type{get;set;}

        public int CategoryId{get;set;}
        public Category? Category{get;set;}

    }
}