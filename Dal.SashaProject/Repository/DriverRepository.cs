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
    public class DriverRepository : IDriverRepository
    {
        private readonly TaxtaxContext _context;
        public DriverRepository(TaxtaxContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Driver entity)
        {
            await _context.Drivers.AddAsync(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Driver entity)
        {
            _context.Drivers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Driver> Get(int id)
        {
            return await _context.Drivers.FirstOrDefaultAsync(x => x.DriverId == id);
        }

        public Task<List<Driver>> Select()
        {
            return _context.Drivers.ToListAsync();
        }

        public async Task<Driver> Update(Driver entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

    }
}
