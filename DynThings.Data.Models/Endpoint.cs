
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
    
public partial class Endpoint
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Endpoint()
    {

        this.EndPointCommands = new HashSet<EndPointCommand>();

        this.EndPointIOs = new HashSet<EndPointIO>();

    }


    public long ID { get; set; }

    public System.Guid GUID { get; set; }

    public System.Guid KeyPass { get; set; }

    public string PinCode { get; set; }

    public string Title { get; set; }

    public long DeviceID { get; set; }

    public long TypeID { get; set; }

    public long ThingID { get; set; }

    public bool IsNumericOnly { get; set; }

    public Nullable<float> MinValue { get; set; }

    public Nullable<float> MaxValue { get; set; }

    public Nullable<float> LowRange { get; set; }

    public Nullable<float> HighRange { get; set; }

    public Nullable<long> LastIOID { get; set; }

    public Nullable<float> LastIONumericValue { get; set; }

    public string LastIOValue { get; set; }

    public Nullable<System.DateTime> LastIOTimeStamp { get; set; }

    public Nullable<System.DateTime> LastIOTimeStampUTC { get; set; }

    public int ObjectStatusID { get; set; }



    public virtual Device Device { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<EndPointCommand> EndPointCommands { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<EndPointIO> EndPointIOs { get; set; }

    public virtual Thing Thing { get; set; }

    public virtual EndPointType EndPointType { get; set; }

}

}
