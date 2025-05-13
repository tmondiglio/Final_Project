using Lab.Project.Domain.Entities;
using Lab.Project.Domain.Repositories;
using Lab.Proyect.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Project.Infraestructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Order
                .Include(o => o.Items)
                .ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
