﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynThings.WebAPI.Models;
using DynThings.WebAPI.ClientServices;



namespace DynThings.WebAPIClientServicesTester
{
    public partial class Form1 : Form
    {
        UnitOfWork uow;
        HostConfig conf = new HostConfig();
        Guid appGUID;
        Guid token;


        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            appGUID = Guid.Parse(txtAppID.Text);
            conf.Token = txtToken.Text;
            conf.URL = txtURL.Text;
            conf.UserName = txtUser.Text;
            conf.Password = txtPassword.Text;
            conf.AppGUID = txtAppID.Text;
            uow = new UnitOfWork(conf);

        }



        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            Initialize();
            ApiResponse resp = await uow.TokenService.Validate();
            MessageBox.Show(resp.StatusTitle);
        }

        private async void btnGetTokenInfo_ClickAsync(object sender, EventArgs e)
        {
            Initialize();
            APIAppUserToken token = await uow.TokenService.GetTokenInfo();
            MessageBox.Show("Expire Date: " + token.ExpireDate.ToShortDateString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnGetLocationViews_Click(object sender, EventArgs e)
        {
            Initialize();
            List<APILocationView> views = await uow.LocationViewsService.GetListAsync(1, 10, "", true, true);
            gv1.DataSource = views;
        }

        private async void btnGetLocation_Click(object sender, EventArgs e)
        {
            Initialize();
            List<APILocation> locs = await uow.LocationsService.GetListAsync(1, 25, true, true, "", 0);
            gv1.DataSource = locs;
        }

        private async void btnThings_Click(object sender, EventArgs e)
        {
            Initialize();
            List<APIThing> things = await uow.ThingsService.GetListAsync(1, 100, true, true, "", 0);
            gv1.DataSource = things;
        }

        private async void btnSubmitEndPointInput_Click(object sender, EventArgs e)
        {
            ApiResponse result = await uow.IOService.SubmitEndPointInput(Guid.Parse("D5E4B5E6-C4E1-4E7B-A3E5-49FE3C251882"), "1");
            MessageBox.Show(result.Message);
        }

        private async void btnGetEndPointsWarnings_Click(object sender, EventArgs e)
        {
            Initialize();
            List<APIEndPoint> ends = await uow.EndPointsService.GetEndpointsWithWarnings(1, 100, true, true, "", 0, 0);
            gv1.DataSource = ends;
        }

        private async void btnGetEndPoints_Click(object sender, EventArgs e)
        {
            Initialize();
            List<APIEndPoint> ends = await uow.EndPointsService.GetListAsync(1, 100, true, true, "", 0);
            gv1.DataSource = ends;
        }

        private async void btnGetThingsWarnings_Click(object sender, EventArgs e)
        {
            Initialize();
            List<APIThing> things = await uow.ThingsService.GetThingsWithWarnings(1, 100, true, true, 0);
            gv1.DataSource = things;
        }

        private async void btnGetLocationsWarnings_Click(object sender, EventArgs e)
        {
            Initialize();
            List<APILocation> locs = await uow.LocationsService.GetLocationsWithWarnings(1, 25, true, true, "", 0);
            gv1.DataSource = locs;
        }

        private async void btnGetViewsWarnings_Click(object sender, EventArgs e)
        {
            Initialize();
            List<APILocationView> views = await uow.LocationViewsService.GetLocationViewsWithWarnings(1, 25, true, true);
            gv1.DataSource = views;
        }

        private async void btnSubmitEndPointLog_Click(object sender, EventArgs e)
        {
            ApiResponse result = await uow.IOService.SubmitEndPointLog(Guid.Parse("D5E4B5E6-C4E1-4E7B-A3E5-49FE3C251882"), "1");
            MessageBox.Show(result.Message);
        }

        private async void btnGetEndPointPendingCommands_Click(object sender, EventArgs e)
        {
            Initialize();
            List<APIEndPointIO> cmds = await uow.IOService.GetEndPointPendingCommands(Guid.Parse("D5E4B5E6-C4E1-4E7B-A3E5-49FE3C251882"));
            gv1.DataSource = cmds;
        }

        private async void btnSetEndpointCommandAsExecuted_Click(object sender, EventArgs e)
        {
            long commandID = 0;
            commandID = long.Parse(gv1.SelectedRows[0].Cells[0].Value.ToString());
            Initialize();
            ApiResponse res = await uow.IOService.SetEndPointCommandAsExecuted(commandID, Guid.Parse("D5E4B5E6-C4E1-4E7B-A3E5-49FE3C251882"));
        }

        private async void btnGetIOsWarnings_Click(object sender, EventArgs e)
        {
            Initialize();
            List<APIEndPointIOWarning> wars = await uow.WarningsService.GetListAsync(1, 100, true, true, "", 0);
            gv1.DataSource = wars;
        }

        private async void btnGenerateNewToken_Click(object sender, EventArgs e)
        {
            appGUID = Guid.Parse(txtAppID.Text);

            conf.URL = txtURL.Text;
            conf.UserName = txtUser.Text;
            conf.Password = txtPassword.Text;
            conf.AppGUID = txtAppID.Text;
            uow = new UnitOfWork(conf);
            try
            {
                APIAppUserToken token = await uow.TokenService.GetNewToken();

                conf.URL = txtURL.Text;
                conf.UserName = txtUser.Text;
                conf.Password = txtPassword.Text;
                conf.AppGUID = txtAppID.Text;
                conf.Token = token.Token.ToString();
                uow = new UnitOfWork(conf);

                txtToken.Text = token.Token.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
