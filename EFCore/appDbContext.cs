using Core.Entities;
using Infra.Personels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra
{
    public class appDbContext :DbContext
    {
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public appDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(PersonelMap)));
            base.OnModelCreating(modelBuilder);
        }


    }
}