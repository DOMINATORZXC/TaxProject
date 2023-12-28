using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SashaProject.Requests
{
    public class ClientCreateRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
