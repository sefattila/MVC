using _13_MVC_ETrade.Models.DTOs;
using _13_MVC_ETrade.Models.Entities;
using _13_MVC_ETrade.Models.Entities.Deneme;
using _13_MVC_ETrade.Models.VMs;
using AutoMapper;

namespace _13_MVC_ETrade.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryListVM>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(cat => cat.Name)).ReverseMap();

            //Employee sınıfından EmployeeDTO ya eşleşme yapıcam
            CreateMap<Employee, EmployeeDTO>().ForMember(dest => dest.FullName, opt => opt.MapFrom(emp => emp.FirstName + " " + emp.LastName));

            CreateMap<Product,ProductCreateVM>().ForMember(dest => dest.Categories, opt => opt.Ignore()).ReverseMap();
        }
    }
}
