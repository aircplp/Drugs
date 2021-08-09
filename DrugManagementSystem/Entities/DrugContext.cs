using System;
using Microsoft.EntityFrameworkCore;

namespace DrugManagementSystem.Entities
{
    public class DrugContext: DbContext
    {
        public DbSet<Drug> Drugs { get; set; }

    }
}
