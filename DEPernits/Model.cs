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
    
    public partial class Model
    {
        public Model()
        {
            this.DECars = new HashSet<DECar>();
        }
    
        public int ModelID { get; set; }
        public Nullable<int> MakeID { get; set; }
        [Display(Name = "Model")]
        public string Model1 { get; set; }
        public string CarName { get; set; }
    
        public virtual Make Make { get; set; }
        public virtual ICollection<DECar> DECars { get; set; }
    }
}
