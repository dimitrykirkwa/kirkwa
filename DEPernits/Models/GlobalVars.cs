using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEPernits.Models
{
    public class GlobalVars
    {
        // read-write variable
        //public static string BUSNumVar
        //{
        //    get
        //    {
        //        return HttpContext.Current.Application["BUSNumVar"] as string;
        //    }
        //    set
        //    {
        //        HttpContext.Current.Application["BUSNumVar"] = value;
        //    }
        //}

        public static string BUSNumG { get; set; }


    }
}