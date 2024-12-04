using HexagonalApp.Domain.Entities;
using HexagonalApp.Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalApp.Infrastructure.Context
{
    public class HexagonalAppContext: DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }
        private readonly IConfiguration _configuration;
        public HexagonalAppContext(DbContextOptions<HexagonalAppContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LOCALHOST;Initial Catalog=GenericDB; Integrated Security=true;Trust Server Certificate=true");
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientsConfig());
        }
        #endregion
    }
}