using AutoMapper;
using STTestTaskProject.Models;
using STTestTaskProject.ViewModels;

namespace STTestTaskProject.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StaffViewModel, Staff>().ReverseMap();
            CreateMap<PositionViewModel, Position>().ReverseMap();
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
        }
    }
}