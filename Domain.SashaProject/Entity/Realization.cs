using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SashaProject.Entity
{
    public class Realization
    {
        [Key]
        public int NumOrder { get; set; }

        public Auto Auto { get; set; }
        public OfficeTaxTax office {  get; set; }

        public Manager Manager { get; set; }

        public Client client { get; set; }
    }
}
