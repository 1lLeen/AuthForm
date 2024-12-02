using AuthForm.Infrastucture.Config;
using AuthForm.Infrastucture.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthForm.Infrastucture
{
    public class AuthFormDbContext:DbContext
    {
        public AuthFormDbContext(DbContextOptions<AuthFormDbContext> options):base(options) { }
        public AuthFormDbContext()
        {
        }
        public DbSet<UserModel> Usesrs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BaseConfiguration<UserModel>());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=authformdb");
        }

    }
}
