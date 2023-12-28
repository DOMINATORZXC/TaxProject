using System;
using System.Collections.Generic;
using Domain.SashaProject.Entity;
using Microsoft.EntityFrameworkCore;


namespace Dal.SashaProject
{
    public partial class TaxtaxContext : DbContext
    {
        public TaxtaxContext()
        {
        }

        public TaxtaxContext(DbContextOptions<TaxtaxContext> options)
            : base(options)
        {
         
        }

        public virtual DbSet<Auto> Autos { get; set; }
        public virtual DbSet<OfficeTaxTax> OfficeTax { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Manager> Managers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Realization> Realizations { get; set; }

        public virtual DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}


