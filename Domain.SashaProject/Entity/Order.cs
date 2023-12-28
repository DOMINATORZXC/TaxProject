using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SashaProject.Entity
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        
        public DateTime OrderDate { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }
        
        
        public Auto auto { get; set; }
    }
}
