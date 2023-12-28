using Domain.SashaProject.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SashaProject.ViewModels
{
    public class AutoViewModel
    {
        public int AutoId { get; set; }

        public string Name { get; set; }

        public DateTime YearIssue { get; set; }

        public string Color { get; set; }

        public string CPP { get; set; }

        public decimal Price { get; set; }
    }
}
