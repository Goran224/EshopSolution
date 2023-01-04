using System.ComponentModel.DataAnnotations;

namespace Eshop_Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
    }
}
