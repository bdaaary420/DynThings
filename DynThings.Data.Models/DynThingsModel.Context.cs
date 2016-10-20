﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class DynThingsEntities : DbContext
{
    public DynThingsEntities()
        : base("name=DynThingsEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<AlertCondition> AlertConditions { get; set; }

    public virtual DbSet<AlertConditionType> AlertConditionTypes { get; set; }

    public virtual DbSet<AlertLevel> AlertLevels { get; set; }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<DeviceCommand> DeviceCommands { get; set; }

    public virtual DbSet<DeviceIO> DeviceIOs { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<DeviceStatu> DeviceStatus { get; set; }

    public virtual DbSet<DynSetting> DynSettings { get; set; }

    public virtual DbSet<EndPointCommand> EndPointCommands { get; set; }

    public virtual DbSet<EndPointIO> EndPointIOs { get; set; }

    public virtual DbSet<IOType> IOTypes { get; set; }

    public virtual DbSet<LinkDevicesLocation> LinkDevicesLocations { get; set; }

    public virtual DbSet<LinkLocationsLocationView> LinkLocationsLocationViews { get; set; }

    public virtual DbSet<LinkThingsLocation> LinkThingsLocations { get; set; }

    public virtual DbSet<LinkUsersAlert> LinkUsersAlerts { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationView> LocationViews { get; set; }

    public virtual DbSet<LocationViewType> LocationViewTypes { get; set; }

    public virtual DbSet<MediaFile> MediaFiles { get; set; }

    public virtual DbSet<ResultMessage> ResultMessages { get; set; }

    public virtual DbSet<ThingCategory> ThingCategorys { get; set; }

    public virtual DbSet<Thing> Things { get; set; }

    public virtual DbSet<UserNotification> UserNotifications { get; set; }

    public virtual DbSet<UserNotificationType> UserNotificationTypes { get; set; }

    public virtual DbSet<VThingEnd> VThingEnds { get; set; }

    public virtual DbSet<Endpoint> Endpoints { get; set; }

    public virtual DbSet<EndPointTypeCategory> EndPointTypeCategorys { get; set; }

    public virtual DbSet<EndPointType> EndPointTypes { get; set; }


    public virtual ObjectResult<Rpt_EndPoint_IOs_Months_Result> Rpt_EndPoint_IOs_Months(Nullable<long> ePID, string year)
    {

        var ePIDParameter = ePID.HasValue ?
            new ObjectParameter("EPID", ePID) :
            new ObjectParameter("EPID", typeof(long));


        var yearParameter = year != null ?
            new ObjectParameter("Year", year) :
            new ObjectParameter("Year", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Rpt_EndPoint_IOs_Months_Result>("Rpt_EndPoint_IOs_Months", ePIDParameter, yearParameter);
    }


    public virtual ObjectResult<Rpt_EndPoint_IOs_Days_Result> Rpt_EndPoint_IOs_Days(Nullable<long> ePID)
    {

        var ePIDParameter = ePID.HasValue ?
            new ObjectParameter("EPID", ePID) :
            new ObjectParameter("EPID", typeof(long));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Rpt_EndPoint_IOs_Days_Result>("Rpt_EndPoint_IOs_Days", ePIDParameter);
    }


    public virtual ObjectResult<Rpt_EndPoint_IOs_HOURs_Result> Rpt_EndPoint_IOs_HOURs(Nullable<long> ePID)
    {

        var ePIDParameter = ePID.HasValue ?
            new ObjectParameter("EPID", ePID) :
            new ObjectParameter("EPID", typeof(long));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Rpt_EndPoint_IOs_HOURs_Result>("Rpt_EndPoint_IOs_HOURs", ePIDParameter);
    }


    public virtual ObjectResult<Rpt_EndPoint_IOs_Minutes_Result> Rpt_EndPoint_IOs_Minutes(Nullable<long> ePID)
    {

        var ePIDParameter = ePID.HasValue ?
            new ObjectParameter("EPID", ePID) :
            new ObjectParameter("EPID", typeof(long));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Rpt_EndPoint_IOs_Minutes_Result>("Rpt_EndPoint_IOs_Minutes", ePIDParameter);
    }


    public virtual ObjectResult<Rpt_ThingEnd_IOs_Minutes_Result> Rpt_ThingEnd_IOs_Minutes(Nullable<long> thingID, Nullable<long> typeID)
    {

        var thingIDParameter = thingID.HasValue ?
            new ObjectParameter("ThingID", thingID) :
            new ObjectParameter("ThingID", typeof(long));


        var typeIDParameter = typeID.HasValue ?
            new ObjectParameter("TypeID", typeID) :
            new ObjectParameter("TypeID", typeof(long));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Rpt_ThingEnd_IOs_Minutes_Result>("Rpt_ThingEnd_IOs_Minutes", thingIDParameter, typeIDParameter);
    }


    public virtual ObjectResult<Rpt_ThingEnd_IOs_Hours_Result> Rpt_ThingEnd_IOs_Hours(Nullable<long> thingID, Nullable<long> typeID)
    {

        var thingIDParameter = thingID.HasValue ?
            new ObjectParameter("ThingID", thingID) :
            new ObjectParameter("ThingID", typeof(long));


        var typeIDParameter = typeID.HasValue ?
            new ObjectParameter("TypeID", typeID) :
            new ObjectParameter("TypeID", typeof(long));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Rpt_ThingEnd_IOs_Hours_Result>("Rpt_ThingEnd_IOs_Hours", thingIDParameter, typeIDParameter);
    }


    public virtual ObjectResult<Rpt_ThingEnd_IOs_Days_Result> Rpt_ThingEnd_IOs_Days(Nullable<long> thingID, Nullable<long> typeID)
    {

        var thingIDParameter = thingID.HasValue ?
            new ObjectParameter("ThingID", thingID) :
            new ObjectParameter("ThingID", typeof(long));


        var typeIDParameter = typeID.HasValue ?
            new ObjectParameter("TypeID", typeID) :
            new ObjectParameter("TypeID", typeof(long));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Rpt_ThingEnd_IOs_Days_Result>("Rpt_ThingEnd_IOs_Days", thingIDParameter, typeIDParameter);
    }


    public virtual ObjectResult<Rpt_ThingEnd_IOs_Months_Result> Rpt_ThingEnd_IOs_Months(Nullable<long> thingID, Nullable<long> typeID, Nullable<long> year)
    {

        var thingIDParameter = thingID.HasValue ?
            new ObjectParameter("ThingID", thingID) :
            new ObjectParameter("ThingID", typeof(long));


        var typeIDParameter = typeID.HasValue ?
            new ObjectParameter("TypeID", typeID) :
            new ObjectParameter("TypeID", typeof(long));


        var yearParameter = year.HasValue ?
            new ObjectParameter("Year", year) :
            new ObjectParameter("Year", typeof(long));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Rpt_ThingEnd_IOs_Months_Result>("Rpt_ThingEnd_IOs_Months", thingIDParameter, typeIDParameter, yearParameter);
    }


    public virtual ObjectResult<GetThingEnds_Result> GetThingEnds(Nullable<long> locationID, Nullable<long> thingID, Nullable<long> thingCategoryID, Nullable<long> endPointID, Nullable<long> endPointTypeID)
    {

        var locationIDParameter = locationID.HasValue ?
            new ObjectParameter("LocationID", locationID) :
            new ObjectParameter("LocationID", typeof(long));


        var thingIDParameter = thingID.HasValue ?
            new ObjectParameter("ThingID", thingID) :
            new ObjectParameter("ThingID", typeof(long));


        var thingCategoryIDParameter = thingCategoryID.HasValue ?
            new ObjectParameter("ThingCategoryID", thingCategoryID) :
            new ObjectParameter("ThingCategoryID", typeof(long));


        var endPointIDParameter = endPointID.HasValue ?
            new ObjectParameter("EndPointID", endPointID) :
            new ObjectParameter("EndPointID", typeof(long));


        var endPointTypeIDParameter = endPointTypeID.HasValue ?
            new ObjectParameter("EndPointTypeID", endPointTypeID) :
            new ObjectParameter("EndPointTypeID", typeof(long));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetThingEnds_Result>("GetThingEnds", locationIDParameter, thingIDParameter, thingCategoryIDParameter, endPointIDParameter, endPointTypeIDParameter);
    }

}

}

