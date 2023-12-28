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
    public class ClientRepository : IClientRepository
    {
        private readonly TaxtaxContext _context;
        public ClientRepository(TaxtaxContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Client entity)
        {
            await _context.Clients.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Client entity)
        {
            _context.Clients.Remove(entity);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<Client> Get(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.ClientId == id);
        }

        public async Task<List<Client>> Select()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> Update(Client entity)
        {
            _context.Clients.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
        
}
