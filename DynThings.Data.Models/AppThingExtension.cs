
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DynThings.Data.Models
{

using System;
    using System.Collections.Generic;
    
public partial class AppThingExtension
{

    public long ID { get; set; }

    public System.Guid GUID { get; set; }

    public string Code { get; set; }

    public long AppID { get; set; }

    public string AppThingCategoryCode { get; set; }

    public string Title { get; set; }

    public int DataTypeID { get; set; }

    public bool IsList { get; set; }



    public virtual App App { get; set; }

    public virtual DataType DataType { get; set; }

}

}
