using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SashaProject.Enum
{
    public enum Color
    {
        [Display(Name = "Красный")]
        Red = 0,
        [Display(Name = "Зеленый")]
        Green = 1,
        [Display(Name = "Синий")]
        Blue = 2,
        [Display(Name ="Белый")]
        White = 3,
        [Display(Name ="Красный")]
        Yellow = 4
    }
}
