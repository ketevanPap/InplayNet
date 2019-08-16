using AutoMapper;
using Inplaynet.Model.DbModels;
using Inplaynet.Model.Dtos;

namespace Inplaynet.Main.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
        }
    }
}
