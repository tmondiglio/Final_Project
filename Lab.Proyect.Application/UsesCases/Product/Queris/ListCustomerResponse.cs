using Lab.Project.Application.Dto;
using Lab.Proyect.Application.Dto;

namespace Lab.Proyect.Application.UseCases.Customer.Queries
{
    public class ListCustomersResponse
    {
        public IEnumerable<CustomerDto> Customer { get; set; } 
    }
}
