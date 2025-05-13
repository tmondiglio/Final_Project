using Lab.Proyect.Api.DTOs;
using Lab.Proyect.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Lab.Proyect.Domain.Entities;

namespace Lab.Proyect.Api.Profiles
{
    public class ProductControllerProfile : Profile
    {
        public ProductControllerProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<CreateProductRequest, ProductDto>();
        }
    }
}
