using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEPernits.Models
{
    public class CarsDropDownListData
    {
        public int? MakeID { get; set; }
        public int? ModelID { get; set; }

        public IEnumerable<Make> Makes { get; set; }
        public IEnumerable<Model> Models { get; set; }
    }
}