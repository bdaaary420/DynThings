﻿/////////////////////////////////////////////////////////////////
// Created by : Caesar Moussalli                               //
// TimeStamp  : 31-1-2016                                      //
// Content    : Handel the Locations Actions                   //
// Notes      :                                                //
//                                                             //
/////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DynThings.Core;
using DynThings.Data.Models;
using DynThings.Data.Repositories;
using PagedList;
using Microsoft.AspNet.Identity;

namespace DynThings.WebPortal.Controllers
{
    public class LocationsController : BaseController
    {
        UnitOfWork_Repositories uof_repos = new UnitOfWork_Repositories();

        #region ActionResult: Views
        public ActionResult Index()
        {
            if (ValidateUserPermissions(false, false) == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            if (ValidateUserPermissions(false, false) == false)
            {
                return RedirectToAction("Login", "Account");
            }
            Location loc = uof_repos.repoLocations.Find(id);
            return View(loc);
        }

        #endregion

        #region PartialViewResult: Partial Views

        #region DetailsPV : Main
        public PartialViewResult DetailsMainPV(int id)
        {
            Location locs = uof_repos.repoLocations.Find(id);
            return PartialView("_Details_Main", locs);
        }
        #endregion

        #region DetailsPV : GeoLocation
        public PartialViewResult DetailsGeoLocationPV(int id)
        {
            Location locs = uof_repos.repoLocations.Find(id);
            return PartialView("_Details_GeoLocation", locs);
        }

        #endregion

        #region ListPV
        [HttpGet]
        public PartialViewResult ListPV(string searchfor = null, int page = 1, int recordsperpage = 0)
        {
            PagedList.IPagedList locs = uof_repos.repoLocations.GetPagedList(searchfor, page, Helpers.Configs.validateRecordsPerMaster(recordsperpage));
            return PartialView("_List", locs);
        }
        #endregion

        #region AddPV
        [HttpGet]
        public PartialViewResult AddPV()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPV([Bind(Include = "Title")] Location location)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                res = uof_repos.repoLocations.Add(location.Title);
                return Json(res);
            }
            return Json(res);
        }
        #endregion

        #region EditPV
        #region Edit : Main
        [HttpGet]
        public PartialViewResult EditMainPV(int id)
        {
            Location location = uof_repos.repoLocations.Find(id);
            return PartialView("_EditMain", location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMainPV([Bind(Include = "ID,Title,IsActive")] Location location)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                res = uof_repos.repoLocations.EditMain(location.ID, location.Title, location.isActive);
                return Json(res);
            }
            return Json(res);
        }
        #endregion

        #region Edit : GeoLocation
        [HttpGet]
        public PartialViewResult EditGeoLocationPV(int id)
        {
            Location location = uof_repos.repoLocations.Find(id);
            return PartialView("_EditGeoLocation", location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGeoLocationPV([Bind(Include = "ID,LongitudeY,LatitudeX")] Location location)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                uof_repos.repoLocations.EditGeoLocation(location.ID, location.LongitudeY, location.LatitudeX);
                return Json(res);
            }
            return Json(res);
        }
        #endregion

        #endregion

        #region DeletePV
        [HttpGet]
        public PartialViewResult DeletePV(int id)
        {
            Location location = uof_repos.repoLocations.Find(id);
            return PartialView("_Delete", location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePV([Bind(Include = "ID,Title,IsActive")] Location location)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                res = uof_repos.repoLocations.Delete(location.ID);
                return Json(res);
            }
            return Json(res);
        }
        #endregion


        #region EditComponents
        #region Location Devices

        #region DevicesListPV
        [HttpGet]
        public PartialViewResult LnkLocationDevicesListGridPV(string searchfor = null, long LocationID = 0, int page = 1, int recordsperpage = 0)
        {
            IPagedList views = uof_repos.repoLocations.GetLocationDevicesPagedList(searchfor, LocationID, page, Helpers.Configs.validateRecordsPerMaster(recordsperpage));
            return PartialView("_DevicesList", views);
        }
        #endregion

        #region AttachDevice
        [HttpPost]
        public ActionResult AttachDevice(long LocationID, long DeviceID)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                res = uof_repos.repoLocations.AttachDevice(LocationID, DeviceID,User.Identity.GetUserId());
                return Json(res);
            }
            return Json(res);
        }
        #endregion

        #region DeAttachDevice
        [HttpPost]
        public ActionResult DeAttachDevice(long linkID)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                res = uof_repos.repoLocations.DeattachDevice(linkID,currentUser.Id);
                return Json(res);
            }
            return Json(res);
        }
        #endregion
        #endregion

        #region Location Things

        #region ThingsListPV
        [HttpGet]
        public PartialViewResult LnkLocationThingsListGridPV(string searchfor = null, long LocationID = 0, int page = 1, int recordsperpage = 0)
        {
            IPagedList views = uof_repos.repoLocations.GetLocationThingsPagedList(searchfor, LocationID, page, Helpers.Configs.validateRecordsPerMaster(recordsperpage));
            return PartialView("_ThingsList", views);
        }
        #endregion

        #region AttachThing
        [HttpPost]
        public ActionResult AttachThing(long LocationID, long ThingID)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                res = uof_repos.repoLocations.AttachThing(LocationID, ThingID, User.Identity.GetUserId());
                return Json(res);
            }
            return Json(res);
        }
        #endregion

        #region DeAttachThing
        [HttpPost]
        public ActionResult DeAttachThing(long linkID)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                res = uof_repos.repoLocations.DeattachThing(linkID, currentUser.Id);
                return Json(res);
            }
            return Json(res);
        }
        #endregion
        #endregion

        #endregion

        #endregion

        #region LookUP
        #region Lookup Main Div
        [HttpGet]
        public PartialViewResult LookupPV(string searchfor = null, int page = 1, int recordsperpage = 0)
        {
            PagedList.IPagedList locs = uof_repos.repoLocations.GetPagedList("", 1, 10);
            return PartialView("lookup/Index", locs);
        }
        #endregion
        #region Lookup List Div
        [HttpGet]
        public PartialViewResult LookupListPV(string searchfor = null, int page = 1, int recordsperpage = 0)
        {
            PagedList.IPagedList locs = uof_repos.repoLocations.GetPagedList(searchfor, page, Config.DefaultRecordsPerChild);
            return PartialView("lookup/List", locs);
        }
        #endregion
        #endregion



       
    }
}
