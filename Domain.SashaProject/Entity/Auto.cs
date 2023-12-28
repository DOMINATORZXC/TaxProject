using Domain.SashaProject.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SashaProject.Entity
{
    public class Auto
    {
        [Key]
        public int AutoId { get; set; }

        public string Name { get; set; }

        public DateTime YearIssue { get; set; }

        public Color Color { get; set; }

        public CPP CPP { get; set; }

        public decimal Price { get; set; }
    }
}
