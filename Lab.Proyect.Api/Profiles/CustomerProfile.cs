using AutoMapper;
using Lab.Project.Api.DTOs;
using Lab.Project.Application.Dto;
using Lab.Project.Domain.Entities;

namespace Lab.Project.Api.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
         
            CreateMap<CreateCustomerRequest, CustomerDto>();
            CreateMap<CustomerDto, CreateCustomerRequest>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
