using Models;
using Newtonsoft.Json.Linq;
using Parctice.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Parctice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gvCoordinates.AutoGenerateColumns = false;
            gvParameter.AutoGenerateColumns = false;

            gvCoordinates.RowHeadersVisible = false;
            gvParameter.RowHeadersVisible = false;

            gvParameter.Rows.Add("overview");
            gvParameter.Rows.Add("steps");
            gvParameter.Rows.Add("geometries");
            gvParameter.Rows.Add("annotations");
            gvParameter.Rows.Add("tidy");

            (gvParameter[1, 0] as DataGridViewComboBoxCell).Items.AddRange("simplified", "full", "false");
            (gvParameter[1, 0] as DataGridViewComboBoxCell).Value = "simplified";
            (gvParameter[1, 1] as DataGridViewComboBoxCell).Items.AddRange("false", "true");
            (gvParameter[1, 1] as DataGridViewComboBoxCell).Value = "false";
            (gvParameter[1, 2] as DataGridViewComboBoxCell).Items.AddRange("polyline", "polyline6", "geojson");
            (gvParameter[1, 2] as DataGridViewComboBoxCell).Value = "polyline";
            (gvParameter[1, 3] as DataGridViewComboBoxCell).Items.AddRange("false", "true", "nodes", "distance", "duration", "datasources", "weight", "speed");
            (gvParameter[1, 3] as DataGridViewComboBoxCell).Value = "false";
            (gvParameter[1, 4] as DataGridViewComboBoxCell).Items.AddRange("false", "true");
            (gvParameter[1, 4] as DataGridViewComboBoxCell).Value = "false";
        }

        private List<CoordinateVM> Coordinates;
        private TracepointJsonForm form = new TracepointJsonForm();

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            Coordinates = new List<CoordinateVM>();
            var index = 1;
            using (MyHttpClient Client = new MyHttpClient())
            {
                var Result = Client.GetStringAsync(tbCoordinates.Text).Result;

                var coordinatesString = JArray.Parse(Result)[0]["Geometry"].ToString().Replace("LINESTRING", "").Replace("(", "").Replace(")", "");
                foreach (var i in coordinatesString.Split(tbSplitCoordinates.Text[0]))
                {
                    var c = i.Split(tbSplitLonLat.Text[0])
                        .Where(a => !string.IsNullOrEmpty(a.Trim()))
                        .Select(a => double.Parse(a.Trim()));
                    Coordinates.Add(new CoordinateVM()
                    {
                        Index = index++,
                        Latitude = c.First() < 120 ? c.First() : c.Last(),
                        Longitude = c.First() > 120 ? c.First() : c.Last(),
                    });
                }
            }

            colJson.Visible = false;
            gvCoordinates.DataSource = Coordinates;
            btnAnalysis.Enabled = true;
            lbxNoMatchs.Visible = false;
            lbNoMatch.Visible = false;
            btnMap.Enabled = false;
        }

        private void btnAnalysis_Click_1(object sender, EventArgs e)
        {
            lbxNoMatchs.Items.Clear();

            List<string> parameters = new List<string>();
            foreach (DataGridViewRow r in gvParameter.Rows)
                parameters.Add(r.Cells[0].Value + "=" + r.Cells[1].Value);

            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                for (int i = 0; i <= Coordinates.Count / 100; i++)
                {
                    var coordinateString = Coordinates.Skip(i * 100).Take(100).Select(a => a.ToString());
                    var osrm_url = "http://" + tbOSRM_Server.Text + "/" + cbService.Text.ToLower() + "/v1/driving/" + string.Join(";", coordinateString.ToArray());
                    var json = wc.DownloadString(osrm_url + "?" + string.Join("&", parameters.ToArray()));
                    var result = JObject.Parse(json).ToObject<Match>();
                    var tracepoints = result.tracepoints;
                    for (int j = 0; j < tracepoints.Count(); j++)
                    {
                        var gvRowItem = Coordinates[i * 100 + j];
                        var tracepointJson = tracepoints.Skip(j).First();
                        gvRowItem.IsMatch = tracepointJson != null;
                        if (tracepointJson != null)
                        {
                            gvCoordinates.Rows[i * 100 + j].DefaultCellStyle.BackColor = Color.White;
                            gvRowItem.JsonString = "Longitude:" + tracepointJson.location[0] + "\r\nLatitude:" + tracepointJson.location[1];
                        }
                        else
                        {
                            gvCoordinates.Rows[i * 100 + j].DefaultCellStyle.BackColor = Color.Red;
                            lbxNoMatchs.Items.Add(i * 100 + j + 1);
                        }
                    }
                }
            }
            colJson.Visible = true;
            gvCoordinates.Update();
            gvCoordinates.Refresh();
            btnMap.Enabled = true;
            lbNoMatch.Visible = true;
            lbxNoMatchs.Visible = true;
        }

        private void gvCoordinates_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == colJson.Index)
            {
                var item = (CoordinateVM)gvCoordinates.Rows[e.RowIndex].DataBoundItem;
                form.Text = "Index:" + item.Index + " " + item.Longitude + "," + item.Latitude;
                form.tbJson.Text = item.JsonString;
                form.Show();
            }
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            string[,] points = new string[Coordinates.Count, 3];
            for (int i = 0; i < Coordinates.Count; i++)
            {
                points[i, 0] = Coordinates[i].Longitude.ToString();
                points[i, 1] = Coordinates[i].Latitude.ToString();
                points[i, 2] = Coordinates[i].IsMatch.Value ? "1" : "0";
            }
            var postData = JArray.FromObject(points).ToString(Newtonsoft.Json.Formatting.None);

            HttpClient httpClient = new HttpClient();
            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("http://210.59.250.227/Fisu29/OSRMMatch/PostCoordinates", content).Result;
            var guid = result.Content.ReadAsStringAsync().Result;

            ProcessStartInfo sInfo = new ProcessStartInfo("http://210.59.250.227/Fisu29/OSRMMatch/MatchResult?guid=" + guid);
            Process.Start(sInfo);
        }

        private void gvCoordinates_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnMap.Enabled = false;
            lbxNoMatchs.Visible = false;
            lbNoMatch.Visible = false;
        }

        private void lbxNoMatchs_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvCoordinates.FirstDisplayedScrollingRowIndex = (int)lbxNoMatchs.SelectedItem - 1;
        }

        private void btnUrlSelector_Click(object sender, EventArgs e)
        {
            using (UrlSelectorForm form = new UrlSelectorForm())
            {
                form.ShowDialog(); ;
                if (!string.IsNullOrEmpty(form.ReturnUrl))
                    tbCoordinates.Text = form.ReturnUrl;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;

                var json = wc.DownloadString("http://210.59.250.220:5000/match/v1/driving/121.524820469025,25.0846771986692;121.525182904988,25.0860339878216;121.525345941979,25.0862981053615;121.525798180499,25.0871532352821;121.526236358786,25.0880803297785?overview=full&steps=true&geometries=geojson&annotations=true&tidy=true");
                var map = JObject.Parse(json).ToObject<Match>();
            }
        }

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gvParameter_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == colValue.Index)
            {
            }
        }

        private void gvParameter_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            gvCoordinates.Focus();
        }
    }
}
