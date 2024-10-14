using Fast.Core.Entities;

namespace Fast.API.Entities
{
    public class CustomerPostModel
    {
        public String Tz { get; set; }
        public string Name { get; set; }
        public String Phone { get; set; }
        public int CityId { get; set; }
    }
}
