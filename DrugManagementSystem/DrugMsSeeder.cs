using System;
using System.Collections.Generic;
using System.Linq;
using DrugManagementSystem.Entities;

namespace DrugManagementSystem
{
    public class DrugMsSeeder
    {
        private readonly DrugContext _drugContext;

        public DrugMsSeeder(DrugContext drugContext)
        {
            _drugContext = drugContext;
        }

        public void Seed()
        {
            if (!_drugContext.Drugs.Any())
            {
                InsertSampleData();
            }
        }

        private void InsertSampleData()
        {
            var drugs = new List<Drug>()
            {
               new Drug {
                   Code = "Paracetamol",
                   Label = "Paracetamol 500 mg suppositories 10 Pcs",
                   Description = "contains the active ingredient..",
                   Price = 5
               },
               new Drug {
                   Code = "BEN-U-RON",
                   Label = "BEN-U-RON 250 mg suppositories",
                   Description = "contains the active ingredient of paracetamos",
                   Price = 15
               }
            };

            _drugContext.AddRange(drugs);
            _drugContext.SaveChanges();
        }
    }
}
