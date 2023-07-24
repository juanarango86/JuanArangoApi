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

        public DbSet<JuanArangoApi.Data.Models.Client> Client { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>().ToTable(nameof(Client));

            base.OnModelCreating(modelBuilder);
        }
    }

}
