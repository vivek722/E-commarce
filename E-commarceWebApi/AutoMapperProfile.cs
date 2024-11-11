using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.Employee;
using E_commerce.Ef.Core.Payment;
using E_commerce.Ef.Core.Product;
using E_commerce.Ef.Core.User;
using E_Commrece.Domain.ProductData;

namespace E_commarceWebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CountrieDto, Countrie>()
            .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.CityNames.Select(cityName => new Citie { CityName = cityName })));

            CreateMap<Countrie, CountrieDto>()
              .ForMember(dest => dest.CityNames, opt => opt.MapFrom(src => src.Cities.Select(c => c.CityName)));

            CreateMap<Users, UserDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employees, EmployeeDto>().ReverseMap();
            CreateMap<Projects, ProjectDto>().ReverseMap();
            CreateMap<EmployeeProject, EmployeeDto>().ReverseMap();
            CreateMap<Products, ProductDto>().ReverseMap();
            CreateMap<SupplierDto, Supplier>().ReverseMap();
            CreateMap<Inventory, InventoryDto>().ReverseMap();
            CreateMap<Warehouse, InventoryDto>().ReverseMap();
            CreateMap<Wishlist, WishListDto>().ReverseMap();
            CreateMap<AddToCart, AddToCartDto>().ReverseMap();
        }
    }
}
