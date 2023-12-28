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
    public class AutoRepository : IAutoRepository
    {
        private readonly TaxtaxContext _context;
        public AutoRepository(TaxtaxContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Auto entity)
        {
           await _context.Autos.AddAsync(entity);
           await  _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Auto entity)
        {
            _context.Autos.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Auto> Get(int id)
        {
            return await _context.Autos.FirstOrDefaultAsync(x => x.AutoId == id);
        }

        public async Task<List<Auto>> Select()
        {
            return await _context.Autos.ToListAsync();
        }

        public async Task<Auto> Update(Auto entity)
        {
            _context.Autos.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
