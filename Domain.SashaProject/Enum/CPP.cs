using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SashaProject.Enum
{
    public enum CPP
    {
        [Display(Name = "Автомат")]
        AMT = 0,
        [Display(Name = "Механика")]
        MT = 1
    }
}
