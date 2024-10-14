using Fast.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Core.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public String Tz { get; set; }
        public string Name { get; set; }
        public String Phone { get; set; }
        public int CityId { get; set; }
        public CityDto? City { get; set; }
    }
}
