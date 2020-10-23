using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

using LibScraper;

namespace Autopilot
{
    public partial class MainForm : Form
    {
        GProScraper ScrapeGproData;
        CarSetupCalc SetupEngine;

        public MainForm()
        {
            InitializeComponent();

            foreach (string item in System.IO.Directory.GetFiles(".", "*.gpro"))
            {
                Drivers.Items.Add(item);
            }
        }

        private void UpdateGproData_Click(object sender, EventArgs e)
        {
            // ScrapeGproData = new GProScraper("https://www.gpro.net/gb/gpro.asp", "", "", ref WorkingBrowser);

        }

        private void BasicSetup_Click(object sender, EventArgs e)
        {
            SetupEngine = new CarSetupCalc(ScrapeGproData.car, ScrapeGproData.driver, ref WorkingBrowser);
        }

        private void DriverData_DoubleClick(object sender, EventArgs e)
        {
            DriverData.Text = ScrapeGproData.driver.DumpData();
            CarData.Text = ScrapeGproData.car.DumpData();
            RaceData.Text = ScrapeGproData.weather.DumpData();
            TrackData.Text = ScrapeGproData.Trackname + " " + ScrapeGproData.track.DumpPHA() + " " + ScrapeGproData.track.Dump2String();

            //var json = new JavaScriptSerializer().Serialize(ScrapeGproData);
            //System.IO.File.WriteAllText(ScrapeGproData.driver.Name + ".gpro", json);
        }

        private void RaceDataEditor_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void RaceDataEditor_DoubleClick(object sender, EventArgs e)
        {
            RaceDataEditor.Text = SetupEngine.DumpData();
        }

        private void LoadDriverProfile_Click(object sender, EventArgs e)
        {
            ScrapeGproData = new JavaScriptSerializer().Deserialize<GProScraper>(File.ReadAllText("Manuel Sutil.gpro"));
            DriverData_DoubleClick(null,null);
        }
    }
}
