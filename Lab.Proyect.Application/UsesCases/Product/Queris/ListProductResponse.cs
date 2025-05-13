using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.Proyect.Application.Dto;
using Lab.Proyect.Domain.Entities;

namespace Lab.Proyect.Application.UsesCases.Product.Queris
{
    public class ListProductResponse
    {
        public List<ProductDto> Products { get; set; }
    }
}
