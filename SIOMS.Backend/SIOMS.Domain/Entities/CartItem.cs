

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIOMS.Domain.Entities{
    public class CartItem
    {
        [Key]
        public Guid CartItemId { get; set; } = Guid.NewGuid();
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
    }
}
