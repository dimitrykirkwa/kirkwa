//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DEPernits
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Color
    {
        public Color()
        {
            this.DECars = new HashSet<DECar>();
        }

        [Display(Name = "Color")]
        public string Color1 { get; set; }

        public virtual ICollection<DECar> DECars { get; set; }
    }
}
