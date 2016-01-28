using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEPernits.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PreventRenderingAttribute : Attribute, IMetadataAware
    {
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.ShowForDisplay = false;
            metadata.ShowForEdit = false;
        }
    }

    /*how to use
    [PreventRendering]
    public int Id { get; set; } */

}