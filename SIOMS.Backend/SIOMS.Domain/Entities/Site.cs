using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Domain.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
