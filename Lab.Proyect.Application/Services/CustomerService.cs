using AutoMapper;
using Lab.Project.Application.Dto;
using Lab.Project.Application.Services;
using Lab.Project.Domain.Entities;
using Lab.Project.Domain.Repositories;
using Lab.Proyect.Application.Dto;
using Lab.Proyect.Domain.Entities;
using Lab.Proyect.Domain.Repositories;

namespace Lab.Proyect.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> ListAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<CustomerDto>>(list);
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CustomerDto>(entity);
        }

        public async Task<CustomerDto> CreateAsync(CustomerDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<CustomerDto>(entity);
        }

        public async Task<CustomerDto> UpdateAsync(CustomerDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<CustomerDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            _repository.DeleteAsync(customer!.Id);
        }
    }
}
