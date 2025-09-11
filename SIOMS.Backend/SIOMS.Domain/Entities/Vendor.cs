using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Domain.Entities
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="Vendor Name can only be 20 characters")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
        [Phone]
        public long Phone { get; set; }
        [MaxLength(200,ErrorMessage ="Address should not exceed 200 characters length")]
        public string Address { get; set; }
    }
}
