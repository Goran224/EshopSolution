using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop_Domain.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
