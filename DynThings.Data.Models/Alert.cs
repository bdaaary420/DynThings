
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
    
public partial class Alert
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Alert()
    {

        this.AlertConditions = new HashSet<AlertCondition>();

        this.LinkUsersAlerts = new HashSet<LinkUsersAlert>();

    }


    public long ID { get; set; }

    public string Title { get; set; }

    public string Message { get; set; }

    public bool IsActive { get; set; }

    public bool Sunday { get; set; }

    public bool Monday { get; set; }

    public bool Tuesday { get; set; }

    public bool Wednesday { get; set; }

    public bool Thursday { get; set; }

    public bool Friday { get; set; }

    public bool Saturday { get; set; }

    public System.TimeSpan StartTime { get; set; }

    public System.TimeSpan EndTime { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<AlertCondition> AlertConditions { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<LinkUsersAlert> LinkUsersAlerts { get; set; }

}

}
