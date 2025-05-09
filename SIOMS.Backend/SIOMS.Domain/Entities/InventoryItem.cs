using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Domain.Entities
{
    public class InventoryItem
    {
        [Key]
        public Guid OrderId { get; set; } = Guid.NewGuid();
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int SiteId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
