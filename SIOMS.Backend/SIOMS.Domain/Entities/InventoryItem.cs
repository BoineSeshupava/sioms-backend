using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Domain.Entities
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int SiteId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
