using Core.Entities;
using Infra.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra
{
    public class appDbContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<SavingAccount> SavingAccounts { get; set; }
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }

        public appDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(UserMap)));
            base.OnModelCreating(modelBuilder);            

        }


    }
}