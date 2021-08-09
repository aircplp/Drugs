using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static DrugManagementSystem.SiteConfiguration;

namespace DrugManagementSystem.Entities
{
    public class DrugContext: DbContext
    {
        private readonly ConnectionStringsOptions _connectionStringsOptions;

        public DbSet<Drug> Drugs { get; set; }

        public DrugContext(IOptions<ConnectionStringsOptions> connectionStringsOptions) : base()
        {
            _connectionStringsOptions = connectionStringsOptions.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = "Server=localhost;Database=DrugsDb;User Id=sa;Password=TesTing*1265;";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    this._connectionStringsOptions.DrugsConnectionStr?? conn);
            }
        }
    }
}
