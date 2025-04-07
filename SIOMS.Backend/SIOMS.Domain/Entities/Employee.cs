using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOMS.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
