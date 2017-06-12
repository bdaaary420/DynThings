﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using DynThings.WebAPI.Models;

namespace DynThings.Simulator
{
    public class APIs
    {
        public void GetDevicesList()
        {
            RunAsync();
            //Task returnedTask = RunAsync();
            //await returnedTask;

        }
        public static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(C.WebAppURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/APISimulatorServices/GetDevicesList?platformKey=a86bb826-988d-4f9a-9f43-169045506194");
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<APIDevice> de = response.Content.ReadAsAsync<IEnumerable<APIDevice>>().Result;
                    C.apiDevices = de.ToList();
                }

                List<APIEndPoint> ends = new List<APIEndPoint>();
                foreach (APIDevice dev in C.apiDevices)
                {
                    foreach (APIEndPoint end in dev.EndPoints)
                    {
                        ends.Add(end);
                    }
                }
                C.apiEndPoints = ends;

            }

            ShowAllDevicesInTreeView();

        }

        public static async Task Connect(string webAppUrl, string key)
        {
            if (webAppUrl.Substring(webAppUrl.Length - 1, 1) != "/")
            {
                webAppUrl = webAppUrl + "/";
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webAppUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string response = await client.GetStringAsync("api/ThingsIO/PlatformInfo");
                C.frmMain.textBox1.Text = response;
            }

        }



        public static void ShowAllDevicesInTreeView()
        {
            C.frmMain.treeView1.Nodes.Clear();

            foreach (APIDevice dev in C.apiDevices)
            {
                TreeNode newNode0 = new TreeNode();
                newNode0.Name = "Dev" + dev.ID.ToString();
                newNode0.Text = dev.Title;
                newNode0.ImageIndex = 0;
                newNode0.SelectedImageIndex = 0;

                //Add Endpoints
                foreach (APIEndPoint end in dev.EndPoints)
                {
                    TreeNode newNode1 = new TreeNode();
                    newNode1.Name = "End" + end.ID.ToString();
                    newNode1.Text = end.Title;
                    newNode1.ImageIndex = 1;
                    newNode1.SelectedImageIndex = 1;
                    newNode0.Nodes.Add(newNode1);
                }
                C.frmMain.treeView1.Nodes.Add(newNode0);
            }

        }

        public static async Task<APIDevice> GetDeviceInfo(Guid deviceKeyPass)
        {
            APIDevice dev = new APIDevice();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(C.WebAppURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/APISimulatorServices/GetDeviceInfo?" + C.PlatformGUIDParam + "&deviceKeyPass=" + deviceKeyPass);
                if (response.IsSuccessStatusCode)
                {
                    dev = response.Content.ReadAsAsync<APIDevice>().Result;
                    return dev;
                }
            }
            return dev;
        }


        #region Device IO
        public static async Task SubmitDeviceInput(Guid deviceKeyPass, string input)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(C.WebAppURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                SubmissionDeviceIO data = new SubmissionDeviceIO();

                data.KeyPass = deviceKeyPass.ToString();
                data.Value = input;

                HttpResponseMessage response = await client.PostAsJsonAsync("api/ThingsIO/SubmitDeviceInput", data);
                if (response.IsSuccessStatusCode)
                {
                    ApiResponse res = response.Content.ReadAsAsync<ApiResponse>().Result;
                    C.response = res;
                }
            }


        }

        public static async Task SubmitDeviceLog(Guid deviceKeyPass, string input, DateTime executionTimeStamp)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(C.WebAppURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                SubmissionDeviceIO data = new SubmissionDeviceIO();
                data.ExectionTimeStamp = executionTimeStamp.Month.ToString() + "-" + executionTimeStamp.Day.ToString() + "-" + executionTimeStamp.Year.ToString();
                data.KeyPass = deviceKeyPass.ToString();
                data.Value = input;

                HttpResponseMessage response = await client.PostAsJsonAsync("api/ThingsIO/SubmitDeviceLog", data);
                if (response.IsSuccessStatusCode)
                {
                    ApiResponse res = response.Content.ReadAsAsync<ApiResponse>().Result;
                    C.response = res;
                }
            }


        }

        public static async Task<List<APIDeviceIO>> GetDevicePendingCommands(Guid deviceKeyPass)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(C.WebAppURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/thingsIO/GetDevicePendingCommands?devicekeypass=" + deviceKeyPass.ToString());
                if (response.IsSuccessStatusCode)
                {
                }
                IEnumerable<APIDeviceIO> cmds = response.Content.ReadAsAsync<IEnumerable<APIDeviceIO>>().Result;

                return cmds.ToList();
            }
        }
        #endregion


        #region Endpoint IO
        public static async Task SubmitEndPointInput(Guid endPointKeyPass, string input)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(C.WebAppURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                SubmissionDeviceIO data = new SubmissionDeviceIO();
                data.KeyPass = endPointKeyPass.ToString();
                data.Value = input;

                HttpResponseMessage response = await client.PostAsJsonAsync("api/ThingsIO/SubmitEndPointInput", data);
                if (response.IsSuccessStatusCode)
                {
                    ApiResponse res = response.Content.ReadAsAsync<ApiResponse>().Result;
                    C.response = res;
                }
            }


        }

        public static async Task SubmitEndPointLog(Guid endPointKeyPass, string input)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(C.WebAppURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                SubmissionDeviceIO data = new SubmissionDeviceIO();
                data.KeyPass = endPointKeyPass.ToString();
                data.Value = input;

                HttpResponseMessage response = await client.PostAsJsonAsync("api/ThingsIO/SubmitEndPointLog", data);
                if (response.IsSuccessStatusCode)
                {
                    ApiResponse res = response.Content.ReadAsAsync<ApiResponse>().Result;
                    C.response = res;
                }
            }


        }


        #endregion




    }

}
