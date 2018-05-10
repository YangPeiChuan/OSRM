using Newtonsoft.Json.Linq;
using Parctice.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parctice
{
    public partial class UrlSelectorForm : Form
    {
        public UrlSelectorForm()
        {
            InitializeComponent();

            #region cbCity insert item.
            cbCity.Items.Add(new cbCityVM { Text = "臺北市", Value = "Taipei" });
            cbCity.Items.Add(new cbCityVM { Text = "新北市", Value = "NewTaipei" });
            cbCity.Items.Add(new cbCityVM { Text = "桃園市", Value = "Taoyuan" });
            cbCity.Items.Add(new cbCityVM { Text = "臺中市", Value = "Taichung" });
            cbCity.Items.Add(new cbCityVM { Text = "臺南市", Value = "Tainan" });
            cbCity.Items.Add(new cbCityVM { Text = "高雄市", Value = "Kaohsiung" });
            cbCity.Items.Add(new cbCityVM { Text = "金門縣", Value = "KinmenCounty" });
            cbCity.Items.Add(new cbCityVM { Text = "新北市(雙北雲)", Value = "TaipeiCloud" });
            #endregion
            cbCity.DisplayMember = "Text";

            gvResult.AutoGenerateColumns = false;
        }

        private class cbCityVM
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
        private CityVM[] citys = null;
        public string ReturnUrl { get; set; }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCity = (cbCityVM)cbCity.SelectedItem;
            string url = "http://ptx.transportdata.tw/MOTC/v2/Bus/Shape/City/" + selectedCity.Value + "?$select=RouteID%2CRouteName&$format=JSON";
            using (MyHttpClient Client = new MyHttpClient())
            {
                var json = Client.GetStringAsync(url).Result;
                citys = JArray.Parse(json).ToObject<CityVM[]>();
                gvResult.DataSource = citys;
            }
        }

        private void gvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colSelect.Index)
            {
                var selectedCity = (cbCityVM)cbCity.SelectedItem;
                var selectedRoad = (CityVM)gvResult.Rows[e.RowIndex].DataBoundItem;
                ReturnUrl = "http://ptx.transportdata.tw/MOTC/v2/Bus/Shape/City/" + selectedCity.Value + "?$filter=RouteID%20%20eq%20%27" + selectedRoad.RouteID + "%27&$format=JSON";
                Hide();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            gvResult.DataSource = citys.Where(a => a.RouteNameEn.Contains(tbSearch.Text) || a.RouteNameZh_tw.Contains(tbSearch.Text)).ToArray();
        }
    }
}
