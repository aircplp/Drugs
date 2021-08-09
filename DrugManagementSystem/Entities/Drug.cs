using System;
using System.ComponentModel.DataAnnotations;

namespace DrugManagementSystem.Entities
{
    public class Drug
    {
        [StringLength(30)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Label { get; set; }

        public string Description { get; set; }

        [Range(0.0, (Double) Decimal.MaxValue)]
        public decimal Price { get; set; }
    }
}
