
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
    
public partial class LinkDevicesLocation
{

    public long ID { get; set; }

    public Nullable<long> LocationID { get; set; }

    public Nullable<long> DeviceID { get; set; }

    public Nullable<System.DateTime> StartTimeStamp { get; set; }

    public Nullable<System.DateTime> EndTimeStamp { get; set; }

    public string StartByUser { get; set; }

    public string EndByUser { get; set; }



    public virtual AspNetUser AspNetUser { get; set; }

    public virtual AspNetUser AspNetUser1 { get; set; }

    public virtual AspNetUser AspNetUser2 { get; set; }

    public virtual AspNetUser AspNetUser3 { get; set; }

    public virtual Device Device { get; set; }

    public virtual Location Location { get; set; }

}

}
