using Fast.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Core.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }
        public DateTime Date { get; set; }
        public String ToAddress { get; set; }
        public Boolean Status { get; set; }
    }
}
