using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JuanArangoApi.Data.Models;

namespace JuanArangoApi.Data
{
    public class JuanArangoApiContext : DbContext
    {
        public JuanArangoApiContext (DbContextOptions<JuanArangoApiContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<UserRole> UserRole { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Formularios> Formularios { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<Formularios>().ToTable(nameof(Formularios));

            base.OnModelCreating(modelBuilder);
        }
    }

}
