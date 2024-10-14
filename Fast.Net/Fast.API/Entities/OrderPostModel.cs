using Fast.Core.Entities;

namespace Fast.API.Entities
{
    public class OrderPostModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployyeId { get; set; }
        public DateTime Date { get; set; }
        public String ToAddress { get; set; }
        public Boolean Status { get; set; }
    }
}
