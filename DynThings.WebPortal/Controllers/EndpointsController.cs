﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using PagedList;
using System.Web.Mvc;
using DynThings.Core;
using DynThings.Data.Models;
using DynThings.Data.Repositories;
using DynThings.Data.Reports;
using DynThings.Data.Models.ReportsModels;
using DynHighCharts;

namespace DynThings.WebPortal.Controllers
{
    
    public class EndpointsController : BaseController
    {
        #region ActionResult: Views
        public ActionResult Index()
        {
            if (ValidateUserPermissions(false, false) == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        
        public ActionResult Details(long id)
        {
            if (ValidateUserPermissions(false, false) == false)
            {
                return RedirectToAction("Login", "Account");
            }
            Endpoint endpoint = Data.Repositories.UnitOfWork_Repositories.repoEndpoints.Find(id);
            return View(endpoint);
        }

        #endregion

        #region PartialViewResult: Partial Views

        #region DetailsPV
        public PartialViewResult DetailsPV(long id)
        {
            Endpoint endpoint = Data.Repositories.UnitOfWork_Repositories.repoEndpoints.Find(id);
            return PartialView("_Details_Main", endpoint);
        }

        #endregion

        #region ListPV
        [HttpGet]
        public PartialViewResult ListPV(string searchfor = null, int page = 1, int recordsperpage = 0)
        {
            PagedList.IPagedList ends = Data.Repositories.UnitOfWork_Repositories.repoEndpoints.GetPagedList(searchfor, page, Helpers.Configs.validateRecordsPerMaster(recordsperpage));
            return PartialView("_List", ends);
        }
        #endregion

        #region AddPV
        [HttpGet]
        public PartialViewResult AddPV()
        {
            ViewBag.TypeID = new SelectList(UnitOfWork_Repositories.repoEndpointTypes.GetList(), "ID", "Title", 1);
            ViewBag.DeviceID = new SelectList(UnitOfWork_Repositories.repoDevices.GetList(), "ID", "Title", 1);
            ViewBag.ThingID = new SelectList(UnitOfWork_Repositories.repoThings.GetList(false), "ID", "Title", 1);
            return PartialView("_Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPV([Bind(Include = "Title,TypeID,DeviceID,ThingID")] Endpoint endpoint)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                res = UnitOfWork_Repositories.repoEndpoints.Add(endpoint.Title, endpoint.TypeID, endpoint.DeviceID,endpoint.ThingID);
                return Json(res);
            }
            return Json(res);
        }
        #endregion

        #region EditPV
        [HttpGet]
        public PartialViewResult EditPV(long id)
        {
            Endpoint endpoint = UnitOfWork_Repositories.repoEndpoints.Find(id);
            ViewBag.TypeID = new SelectList(UnitOfWork_Repositories.repoEndpointTypes.GetList(), "ID", "Title", endpoint.TypeID);
            ViewBag.DeviceID = new SelectList(UnitOfWork_Repositories.repoDevices.GetList(), "ID", "Title", endpoint.DeviceID);
            ViewBag.ThingID = new SelectList(UnitOfWork_Repositories.repoThings.GetList(false), "ID", "Title", endpoint.ThingID);
            return PartialView("_Edit", endpoint);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPV([Bind(Include = "ID,Title,TypeID,DeviceID,ThingID")] Endpoint endpoint)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                res = UnitOfWork_Repositories.repoEndpoints.Edit(endpoint.ID, endpoint.Title, endpoint.TypeID,endpoint.ThingID);
                return Json(res);
            }
            return Json(res);
        }
        #endregion

        #region DeletePV
        [HttpGet]
        public PartialViewResult DeletePV(long id)
        {
            if (!User.IsInRole("Admin"))
            {
                ResultInfo.Result rm = Core.ResultInfo.GetResultByID(1);
                return PartialView("_PVResult",rm);
            }
            Endpoint endpoint = UnitOfWork_Repositories.repoEndpoints.Find(id);
            return PartialView("_Delete", endpoint);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeletePV([Bind(Include = "ID,Title")] Endpoint endpoint)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                res = UnitOfWork_Repositories.repoEndpoints.Delete(endpoint.ID);
                return Json(res);
            }
            return Json(res);
        }
        #endregion


        #region EndPoint History
        [HttpGet]
        public PartialViewResult GetPVEndPointHistory(long endPointID, int page = 1, int recordsperpage = 0)
        {
            IPagedList IOs = Data.Repositories.UnitOfWork_Repositories.repoEndpointIOs.GetPagedList(endPointID, page, Helpers.Configs.validateRecordsPerChild(Config.DefaultRecordsPerChild));
            return PartialView("_Details_History", IOs);

        }

        #endregion

        #region EndPoint Commands
        [HttpGet]
        public PartialViewResult EndPointCommandsListByEndPointIDPV(string searchfor = null, long EndPointID = 0, int page = 1, int recordsperpage = 0)
        {
            PagedList.IPagedList cmds = Data.Repositories.UnitOfWork_Repositories.repoEndPointCommands.GetPagedListByEndPointID(searchfor, EndPointID, page, Helpers.Configs.validateRecordsPerMaster(recordsperpage));
            return PartialView("_Details_Commands", cmds);
        }
        #endregion

        #region EndPoint DevKeys
        [HttpGet]
        public PartialViewResult DevKeysPV(long id)
        {
            Endpoint endpoint = Data.Repositories.UnitOfWork_Repositories.repoEndpoints.Find(id);
            return PartialView("_Details_DevKeys", endpoint);
        }
        #endregion

        #region EndPoint Keys
        [HttpGet]
        public PartialViewResult EditDevKeysPV(long id)
        {
            Endpoint endpoint = Data.Repositories.UnitOfWork_Repositories.repoEndpoints.Find(id);
            return PartialView("_Edit_DevKeys", endpoint);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDevKeysPV([Bind(Include = "ID,GUID,KeyPass")] Endpoint endpoint)
        {
            ResultInfo.Result res = ResultInfo.GetResultByID(1);
            if (ModelState.IsValid)
            {
                res = UnitOfWork_Repositories.repoEndpoints.EditDevKeys(endpoint.ID, endpoint.GUID, endpoint.KeyPass);
                return Json(res);
            }
            return Json(res);
        }

        #endregion

        #endregion


        #region LookUP
        #region Lookup Main Div
        [HttpGet]
        public PartialViewResult LookupPV(string searchfor = null, int page = 1, int recordsperpage = 0)
        {
            PagedList.IPagedList ends = Data.Repositories.UnitOfWork_Repositories.repoEndpoints.GetPagedList("", 1, 10);
            return PartialView("lookup/Index", ends);
        }
        #endregion
        #region Lookup List Div
        [HttpGet]
        public PartialViewResult LookupListPV(string searchfor = null, int page = 1, int recordsperpage = 0)
        {
            PagedList.IPagedList ends = Data.Repositories.UnitOfWork_Repositories.repoEndpoints.GetPagedList(searchfor, page, Config.DefaultRecordsPerChild);
            return PartialView("lookup/List", ends);
        }
        #endregion
        #endregion


        #region Reports
        [HttpGet]
        public ActionResult Rpt_Month(long endPointID,string year)
        {
            Chart chrt =  UnitOfWork_Reports.rptEndpoints.IOs_Monthly(endPointID,year);
            return PartialView("_HighChart", chrt);
        }

        [HttpGet]
        public ActionResult Rpt_Day(long endPointID)
        {
            Chart chrt = UnitOfWork_Reports.rptEndpoints.IOs_Daily(endPointID);
            return PartialView("_HighChart", chrt);
        }

        [HttpGet]
        public ActionResult Rpt_Hour(long endPointID)
        {
            Chart chrt = UnitOfWork_Reports.rptEndpoints.IOs_Hour(endPointID);
            return PartialView("_HighChart", chrt);
        }

        [HttpGet]
        public ActionResult Rpt_Minute(long endPointID)
        {
            Chart chrt = UnitOfWork_Reports.rptEndpoints.IOs_Minute(endPointID);
            return PartialView("_HighChart", chrt);
        }
        #endregion
    }
}
