using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DEPernits.Models
{
    public class CreatePermitViewModel
    {


        public IEnumerable<DEmployee> DEmployee { get; set; }
        public IEnumerable<DECar> DECar { get; set; }
        public IEnumerable<DEPermits_History> DEPermits_History { get; set; }


        ////general

        //public string BUSNUM { get; set; }
        
        //// empl
        //[Key]
        //public int EmplID { get; set; }
        //[Display(Name="Employee Name")]
        //public string Name { get; set; }
        //[Display(Name = "Address")]
        //public string EmplAddress { get; set; }
        //[Display(Name = "State")]
        //public string EmplState { get; set; }
        //[Display(Name = "City")]
        //public string EmplCity { get; set; }
        //[Display(Name = "Phone")]
        //public string EmplZipCode { get; set; }
        //[Display(Name = "License")]
        //public string DEP_DL { get; set; }
        //[Display(Name = "License State")]
        //public string DEP_DLSTATE { get; set; }
        //[Display(Name = "email")]
        //public string email { get; set; }
        //[Display(Name = "Phone")]
        //public string phone { get; set; }
                
        //public virtual ICollection<DECar> DECars { get; set; }
        //public virtual State State { get; set; }
        //public virtual State State1 { get; set; }


        //// cars
        //[Key]
        //public int DECarsID { get; set; }
        //public int OwnerId { get; set; }
        //public int MakeID { get; set; }
        //public int ModelID { get; set; }
        //public string CarMakeModel { get; set; }
        //public Nullable<int> CarYear { get; set; }
        //public string Color { get; set; }
        //public string Plate { get; set; }
        //public string PlateState { get; set; }
        
        ////public string BUSNUM { get; set; }

        //public virtual Color Color1 { get; set; }
        //public virtual Make Make { get; set; }
        //public virtual Model Model { get; set; }
        
        //public virtual ICollection<DEPermits_History> DEPermits_History { get; set; }
        //public virtual DEmployee DEmployee { get; set; }
        ////public virtual State State { get; set; }


        ////public string FullName
        ////{
        ////    get { return LastName + ", " + FirstMidName; }
        ////}


        ////permits
        //public int DEPermits_History1 { get; set; }
        ////[Required]
        //public string DEPermitNumberV { get; set; }
        ////public Nullable<int> DEPermitNumberI { get; set; }
        ////public Nullable<System.Guid> EgovID { get; set; }
        ////public string BUSNum { get; set; }
        //public Nullable<int> EmployersContactsID { get; set; }
        //public int DECarID { get; set; }
        //public int StatusID { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public System.DateTime DEP_APPDATE { get; set; }
        //public Nullable<System.DateTime> DEP_RENEWDATE { get; set; }
        //public string Notes { get; set; }
        ////public string Custom1 { get; set; }
        ////public string Custom2 { get; set; }
        ////public Nullable<int> Custom3 { get; set; }
        ////public bool Terminated { get; set; }
        ////public Nullable<System.DateTime> TerminationDate { get; set; }
        ////public bool Deleted { get; set; }
        ////public Nullable<System.DateTime> DeletionDate { get; set; }
        ////public System.DateTime sys_created_date { get; set; }
        ////public string sys_created_user { get; set; }
        //public string EmployerName { get; set; }
        //public string EmployerAddress { get; set; }
        //public string EmployerEmail { get; set; }
        //public string EmployerPhone { get; set; }

        //public virtual DECar DECar { get; set; }
        ////public virtual Status Status { get; set; }



    }
}