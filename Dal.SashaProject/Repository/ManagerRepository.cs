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
    public class ManagerRepository : IManagerRepository
    {
        private readonly TaxtaxContext _context;
        public ManagerRepository(TaxtaxContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Manager entity)
        {
            await _context.Managers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Manager entity)
        {
            _context.Managers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Manager> Get(int id)
        {
            return await _context.Managers.FirstOrDefaultAsync(x=> x.ManagerId == id);      
        }

        public async Task<List<Manager>> Select()
        {
            return await _context.Managers.ToListAsync();
        }

        public async Task<Manager> Update(Manager entity)
        {
            _context.Managers.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
