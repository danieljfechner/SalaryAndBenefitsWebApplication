using AutoMapper;
using HumanResourcesAndPayrollApp.Models;
namespace HumanResourcesAndPayrollApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, DataAccess.Models.Employee>().ReverseMap();
            CreateMap<EntityBase, DataAccess.Models.EntityBase>().ReverseMap();
            CreateMap<Dependent, DataAccess.Models.Dependent>().ReverseMap();
            CreateMap<PersonBase, DataAccess.Models.PersonBase>().ReverseMap();
            CreateMap<Spouse, DataAccess.Models.Spouse>().ReverseMap();
        }
    }
}
