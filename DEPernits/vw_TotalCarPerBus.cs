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
    
    public partial class vw_TotalCarPerBus
    {
        public string BUSNum { get; set; }
        [Display(Name = "Total cars per business")]
        public Nullable<int> TotalCarsPerBus { get; set; }
        [Display(Name = "Total Employee in the programm")]
        public Nullable<int> TotalEmplPerBus { get; set; }
        public int EmplID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Cars per Employee")]
        public Nullable<int> TotalCarsPerEmpl { get; set; }
    }
}
