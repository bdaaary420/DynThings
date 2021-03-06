﻿/////////////////////////////////////////////////////////////////
// Created by : Caesar Moussalli                                //
// TimeStamp  : 07-04-2016                                      //
// Content    :  APIEndPoint Properties                         //
// Notes      :                                                 //
/////////////////////////////////////////////////////////////////
using DynThings.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using DynThings.Data.Models;

namespace DynThings.WebAPI.Models
{
    public class APIEndPoint
    {
        #region :: Public Properties ::
        public long ID { get; set; }
        public System.Guid GUID { get; set; }
        public System.Guid KeyPass { get; set; }
        public string Title { get; set; }

        #region Master Types
        public APIEndPointType EndPointType { get; set; }
        #endregion

        #region Parents
        public APIDevice Device { get; set; }

        #endregion


        #endregion

        #region :: Constructor ::
        public APIEndPoint()
        {
            this.ID = 0;
            //this.Guid = Guid.Empty;
            this.KeyPass = Guid.Empty;
            this.Title = "";
            this.Device = new APIDevice();
            this.EndPointType = new APIEndPointType();
        }
        #endregion
    }
   

}