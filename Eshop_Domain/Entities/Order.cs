using System.ComponentModel.DataAnnotations;

namespace Eshop_Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Address { get; set; }
        public decimal Total { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        public OrderStatus Status { get; set; }

    }
}
