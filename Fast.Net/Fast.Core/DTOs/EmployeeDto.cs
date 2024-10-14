using Fast.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartWorking { get; set; }
        public String Phone { get; set; }
        public int CityId { get; set; }
        public CityDto? City { get; set; }
        public int DeliveryTypeId { get; set; }
        public DeliveryTypeDto DeliveryType { get; set; }
        public double PaymentPerHour { get; set; }
    }
}
