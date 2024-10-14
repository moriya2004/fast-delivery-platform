using Fast.Core.Entities;

namespace Fast.API.Entities
{
    public class EmployeePostModel
    {
        public string Name { get; set; }
        public DateTime StartWorking { get; set; }
        public String Phone { get; set; }
        public int CityId { get; set; }
        public int DeliveryTypeId { get; set; }
        public double PaymentPerHour { get; set; }
    }
}
