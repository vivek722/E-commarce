﻿using AutoMapper;
using E_commarceWebApi.RequestModel;
using E_commerce.Ef.Core.Employee;
using E_commerce.Ef.Core.User;

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

            CreateMap<UserDto, Users>()
                .ForMember(dest => dest.Addresse, opt => opt.MapFrom(src => new List<Addresse>
                {
        new Addresse
        {
            Street = src.Street,
            City = src.City,
            State = src.State,
            ZipCode = src.ZipCode
        }
                }));

            CreateMap<Users, UserDto>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Addresse.FirstOrDefault().Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Addresse.FirstOrDefault().City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Addresse.FirstOrDefault().State))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Addresse.FirstOrDefault().ZipCode));

            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employees, EmployeeDto>().ReverseMap();
            CreateMap<Projects, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeProject, EmployeeDto>().ReverseMap();

        }
    }
}
