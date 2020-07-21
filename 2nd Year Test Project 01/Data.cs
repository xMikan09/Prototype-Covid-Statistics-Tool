using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Drawing;
namespace _2nd_Year_Test_Project_01
{
    public class CovidStats {
        public string infected { get; set; }
        public string tested { get; set; }
        public string recovered { get; set; }
        public string deceased { get; set; }
        public string PUIs { get; set; }
        public string PUMs { get; set; }
        public string country { get; set; }
        public string historyData { get; set; }
        public string sourceUrl { get; set; }
        public string lastUpdatedAtApify { get; set; }
        public string lastUpdatedAtSource { get; set; }
        public string readMe { get; set; }
    }
    public static class Data {
        public const string url = "https://api.apify.com/v2/datasets/sFSef5gfYg3soj8mb/items?format=json&clean=1";
        public static List<CovidStats> getData() {
            WebRequest pRequest = WebRequest.Create(url);
            WebResponse response = pRequest.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string pWebResponse = reader.ReadToEnd();
            JavaScriptSerializer jsr = new JavaScriptSerializer();
            List<CovidStats> result = jsr.Deserialize<List<CovidStats>>(pWebResponse);
            reader.Close();
            reader.Dispose();
            dataStream.Close();
            dataStream.Dispose();
            response.Close();
            return result;
        }
        static public void PopulateDGV(DataGridView dgv) {
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(255, 39, 41, 61);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DataSource = getData();
            dgv.Columns["readMe"].Visible = false;
            dgv.Columns["lastUpdatedAtSource"].Visible = false;
            dgv.Columns["lastUpdatedAtApify"].Visible = false;
            dgv.Columns["sourceUrl"].Visible = false;
            dgv.Columns["historyData"].Visible = false;
            dgv.Columns["country"].Visible = false;
            dgv.Rows[0].Selected = false;

     

        }
    }
}
