using AutoMapper;
using Fast.API.Entities;
using Fast.Core.Entities;

namespace Fast.API.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile() {
            CreateMap<OrderPostModel, Order>();
            CreateMap<CustomerPostModel, Customer>();
            CreateMap<EmployeePostModel, Employee>();
        }

    }
}
