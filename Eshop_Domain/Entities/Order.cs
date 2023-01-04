using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public User User { get; set; }

    }
}
