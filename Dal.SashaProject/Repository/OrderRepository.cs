using Dal.SashaProject.Interfaces;
using Domain.SashaProject.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.SashaProject.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TaxtaxContext _context;
        public OrderRepository(TaxtaxContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Order entity)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Order> Get(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x=>x.OrderId == id);
        }

        public async Task<List<Order>> Select()
        {
            return await _context.Orders.ToListAsync();

        }

        public async Task<Order> Update(Order entity)
        {
            _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
