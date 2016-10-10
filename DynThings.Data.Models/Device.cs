
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
    
public partial class Device
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Device()
    {

        this.DeviceCommands = new HashSet<DeviceCommand>();

        this.DeviceIOs = new HashSet<DeviceIO>();

        this.Endpoints = new HashSet<Endpoint>();

        this.LinkDevicesLocations = new HashSet<LinkDevicesLocation>();

    }


    public long ID { get; set; }

    public Nullable<System.Guid> GUID { get; set; }

    public Nullable<System.Guid> KeyPass { get; set; }

    public string PinCode { get; set; }

    public string Title { get; set; }

    public Nullable<long> StatusID { get; set; }

    public int UTC_Diff { get; set; }

    public int IsConnectedDelay { get; set; }

    public bool IsConnected { get; set; }

    public Nullable<System.DateTime> LastConnectionTimeStamp { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DeviceCommand> DeviceCommands { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DeviceIO> DeviceIOs { get; set; }

    public virtual DeviceStatu DeviceStatu { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Endpoint> Endpoints { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<LinkDevicesLocation> LinkDevicesLocations { get; set; }

}

}
