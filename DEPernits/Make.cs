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
    
    public partial class Make
    {
        public Make()
        {
            this.Models = new HashSet<Model>();
            this.DECars = new HashSet<DECar>();
        }
    
        public int MakeID { get; set; }
        [Display(Name = "Make")]
        public string Make1 { get; set; }
    
        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<DECar> DECars { get; set; }
    }
}
