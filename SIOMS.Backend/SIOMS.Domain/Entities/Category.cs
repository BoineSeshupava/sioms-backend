using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }

        // One Category has Many Products
        public ICollection<Product> Products { get; set; }
    }
}
