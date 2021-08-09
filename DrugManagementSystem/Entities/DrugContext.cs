using System;
using Microsoft.EntityFrameworkCore;

namespace DrugManagementSystem.Entities
{
    public class DrugContext: DbContext
    {
        // TODO: move to config file
        private static string _connectionString = "Server=localhost;Database=DrugsDb;User Id=sa;Password=TesTing*1265;";

        public DbSet<Drug> Drugs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

    }
}
