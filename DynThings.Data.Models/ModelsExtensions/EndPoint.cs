﻿/////////////////////////////////////////////////////////////////
// Created by : Caesar Moussalli                               //
// TimeStamp  : 31-1-2016                                      //
// Content    : Extend the properties of EndPoint Model        //
// Notes      : Don't add Behavior in this class               //
/////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynThings.Data.Models
{
    public partial class Endpoint
    {
        /// <summary>
        /// Get the Latest Input from EndPoint
        /// </summary>
        public EndPointIO LastInput
        {
            get
            {
                EndPointIO result = new EndPointIO() ;
                DynThingsEntities db = new DynThingsEntities();
                List<EndPointIO> io = this.EndPointIOs.Where(i => i.IOTypeID == 1).OrderByDescending(eio => eio.TimeStamp).Take(1).ToList();
                if(io.Count >0 )
                {
                result = io[0];
                }
                else
                {

                }
                return result;
            }
        }
    }
}
