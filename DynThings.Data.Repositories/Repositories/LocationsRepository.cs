﻿/////////////////////////////////////////////////////////////////
// Created by : Caesar Moussalli                               //
// TimeStamp  : 31-1-2016                                      //
// Content    : Handle Locations CRUD                          //
// Notes      :                                                //
/////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynThings.Data.Models;

namespace DynThings.Data.Repositories
{
    public class LocationsRepository
    {
        private DynThingsEntities db;

        #region Constructor
        public LocationsRepository( DynThingsEntities dbContext)
        {
            db = dbContext;
        }
        #endregion


        /// <summary>
        /// Find Location by Location ID
        /// </summary>
        /// <param name="id">Location ID</param>
        /// <returns>Location object</returns>
        public Location Find(int id)
        {
            Location loc = new Location();
            List<Location> locs =  db.Locations.Where(l => l.ID == id).ToList();
            if (locs.Count == 1)
            {
                loc = locs[0];
            }
            else
            {
                throw new Exception("Not Found");
            }
            return loc;
        }

    }
}