using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SashaProject.Entity
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneManager {  get; set; }
    }
}
