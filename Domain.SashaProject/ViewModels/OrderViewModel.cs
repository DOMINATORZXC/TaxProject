using Domain.SashaProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SashaProject.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }


        public Auto auto { get; set; }
    }
}
