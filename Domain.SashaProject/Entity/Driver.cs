using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SashaProject.Entity
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }
        public string PhoneDriver { get; set; }

        public Auto auto { get; set; }
    }
}
