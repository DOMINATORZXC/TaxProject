using Domain.SashaProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SashaProject.ViewModels
{
    public class DriverViewModel
    {
        public int DriverId { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }
        public string PhoneDriver { get; set; }

        public Auto auto { get; set; }
    }
}
