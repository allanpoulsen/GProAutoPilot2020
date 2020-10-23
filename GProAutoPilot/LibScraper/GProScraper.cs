using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeGProData;

namespace LibScraper
{
    public class GProScraper : BaseScraper
    {
        string siteURL = "";
        string carURL = "https://www.gpro.net/gb/UpdateCar.asp";                         
        string driverURL = "https://www.gpro.net/gb/DriverProfile.asp?ID=";
        string weatherURL = "https://www.gpro.net/gb/Qualify.asp";
        string tracksURL = "https://www.gpro.net/gb/ViewTracks.asp";
        int driverID = 0;

        private Car c = new Car();
        private Driver d = new Driver();
        private Weather w = new Weather();
        private int trackid;

        private List<Track> tracks = new List<Track>();

        public Car car { get { return c; }  }
        public Driver driver { get { return d; } }
        public Weather weather { get { return w; } }

        private string username = "";
        private string password = "";
       
        public int TrackID
        {
            get { return trackid; }
            set { trackid = value; }
        }

        public Track track
        {
            get
            {
                Track e = new Track();

                foreach (var t in tracks)
                {
                    if (t.TrackID == trackid) e = t;
                }

                return e;
            }

        }

        public string Trackname
        {                        
            get {

                string e = "";

                foreach (var t in tracks)
                {
                    if (t.TrackID == trackid) e = t.TrackName;
                }

                return e;
            }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string UserName
        {
            get { return username; }
            set { username = value; }
        }


        private void What2Do(int command)
        {
            Navigate(siteURL, command);
        }

        private int GetData_Car(string delim)
        {
            int temp = 0;

            CutCrapBefore("<td align");
            CutCrapBefore(">");
            HTML = HTML.Remove(0, 1);
            if (HTML[0] == '<') { CutCrapBefore(">"); HTML = HTML.Remove(0, 1); }
            temp = Convert.ToInt16(GetTextBefore(delim));
            if (delim == "%") CutCrapBefore("</tr>");

            return temp;
        }

        private int ExtractAmount(string txt)
        {
            txt = txt.Remove(0, txt.IndexOf("$")+1);
            txt = txt.Substring(0, txt.IndexOf(")"));
            txt = txt.Replace(".", "");
            return int.Parse(txt);            
        }

        private void ExtractMaintData(int attr, HtmlElement HTML)
        {
            foreach (HtmlElement inputfield in HTML.GetElementsByTagName("option"))
            {
                // Sort out headings 
                if (inputfield.GetAttribute("value") != "0" && inputfield.GetAttribute("value") != "")
                {
                    if (inputfield.GetAttribute("newwear") == "0")
                    {
                        // pay for replace
                        c.upgradecost[attr, int.Parse(inputfield.GetAttribute("newlvl"))] = ExtractAmount(inputfield.InnerText);
                    }
                    else
                    {
                        // free downgrade with wear
                        c.downgradewear[attr, int.Parse(inputfield.GetAttribute("newlvl"))] = int.Parse(inputfield.GetAttribute("newwear"));
                    }
                }

            }
        }

        private void Scrape_Car()
        {
            if (webBrowser1.Url.ToString().ToLower() == carURL.ToLower())
            {

                HTML = webBrowser1.DocumentText;

                // Collect Car part levels
                if (CutCrapBefore("<th nowrap>Car part</th>") == 1)
                {
                    c.ChassisLvl = GetData_Car("<");
                    c.ChassisWear = GetData_Car("%");

                    c.EngineLvl = GetData_Car("<");
                    c.EngineWear = GetData_Car("%");

                    c.FrontWingLvl = GetData_Car("<");
                    c.FrontWingWear = GetData_Car("%");

                    c.RearWingLvl = GetData_Car("<");
                    c.RearWingWear = GetData_Car("%");

                    c.UnderbodyLvl = GetData_Car("<");
                    c.UnderbodyWear = GetData_Car("%");

                    c.SidePodsLvl = GetData_Car("<");
                    c.SidePodsWear = GetData_Car("%");

                    c.CoolingLvl = GetData_Car("<");
                    c.CoolingWear = GetData_Car("%");

                    c.GearBoxLvl = GetData_Car("<");
                    c.GearBoxWear = GetData_Car("%");

                    c.BrakesLvl = GetData_Car("<");
                    c.BrakesWear = GetData_Car("%");

                    c.SuspensionLvl = GetData_Car("<");
                    c.SuspensionWear = GetData_Car("%");

                    c.ElectronicsLvl = GetData_Car("<");
                    c.ElectronicsWear = GetData_Car("%");
                }

                // Collect up and downgrade price
                foreach (HtmlElement inputfield in webBrowser1.Document.GetElementsByTagName("select"))
                {
                    if (inputfield.Name == "BuyChassis") { ExtractMaintData((int)CarAttr.Chasis, inputfield); }
                    if (inputfield.Name == "BuyEngine") { ExtractMaintData((int)CarAttr.Engine, inputfield); }
                    if (inputfield.Name == "BuyFWing") { ExtractMaintData((int)CarAttr.FrontWing, inputfield); }
                    if (inputfield.Name == "BuyRWing") { ExtractMaintData((int)CarAttr.RearWing, inputfield); }
                    if (inputfield.Name == "BuyUnderBody") { ExtractMaintData((int)CarAttr.Underbody, inputfield); }
                    if (inputfield.Name == "BuySidepods") { ExtractMaintData((int)CarAttr.Sidepods, inputfield); }
                    if (inputfield.Name == "BuyCooling") { ExtractMaintData((int)CarAttr.Cooling, inputfield); }
                    if (inputfield.Name == "BuyGear") { ExtractMaintData((int)CarAttr.Gearbox, inputfield); }
                    if (inputfield.Name == "BuyBrakes") { ExtractMaintData((int)CarAttr.Brakes, inputfield); }
                    if (inputfield.Name == "BuySusp") { ExtractMaintData((int)CarAttr.Suspension, inputfield); }
                    if (inputfield.Name == "BuyElectronics") { ExtractMaintData((int)CarAttr.Electronics, inputfield); }
                }
            }          
        }

        private void Scrape_DriverID()
        {
            if (webBrowser1.Url.ToString().ToLower() == siteURL.ToLower())
            {

                HTML = webBrowser1.DocumentText;

                if (CutCrapBefore("DriverProfile.asp?ID=") == 1)
                {
                    HTML = HTML.Remove(0, 21);
                    driverID = Convert.ToInt16(GetTextBefore("\""));
                }
            }

        }

        public int GetData_Driver()
        {           
            CutCrapBefore("<td nowrap");
            CutCrapBefore(">");
            HTML = HTML.Remove(0, 1);

            return Convert.ToInt16(GetTextBefore("&nbsp;"));            
        }

        private void Scrape_Driver()
        {
            if (webBrowser1.Url.ToString().ToLower() == driverURL.ToLower()+driverID.ToString().ToLower())
            {
                d.DriverID = driverID;

                HTML = webBrowser1.DocumentText;

                if (CutCrapBefore("Name:") == 1)
                {
                    CutCrapBefore(">");
                    HTML = HTML.Remove(0, 1);
                    d.Name = GetTextBefore("<");
                }

                if (CutCrapBefore("<th>Overall:</th>") == 1)
                {
                    d.OA = GetData_Driver();
                    d.Con = GetData_Driver();
                    d.Tal = GetData_Driver();
                    d.Agg = GetData_Driver();
                    d.Exp = GetData_Driver();
                    d.Tech = GetData_Driver();
                    d.Sta = GetData_Driver();
                    d.Cha = GetData_Driver();
                    d.Mot = GetData_Driver(); 
                    d.Rep = GetData_Driver();
                    d.Wei = GetData_Driver();
                    d.Age = GetData_Driver();
                }
            }

        }

        public int GetData_Weather(string delim)
        {
            CutCrapBefore(delim);
            HTML = HTML.Remove(0, delim.Length);
            return Convert.ToInt16(GetTextBefore("&deg;"));
        }

        private void Scrape_Weather()
        {
            if (webBrowser1.Url.ToString().ToLower() == weatherURL.ToLower())
            {
                HTML = webBrowser1.DocumentText;
                CutCrapBefore("/TrackDetails.asp?id=");
                HTML = HTML.Remove(0,21);
                TrackID = Convert.ToInt16(GetTextBefore("\""));

                HTML = webBrowser1.DocumentText;
                if (CutCrapBefore("weather") == 1)
                {
                    //CutCrapBefore("Temp: ");
                    //HTML = HTML.Remove(0, 6);
                    //w.P_Temp = Convert.ToInt16(GetTextBefore("&deg;"));

                    w.P_Temp = GetData_Weather("Temp: ");
                    w.Q2_Temp = GetData_Weather("Temp: ");
                    w.R_Q1_temp1 = GetData_Weather("Temp: ");
                    w.R_Q1_temp2 = GetData_Weather("-");
                    w.R_Q2_temp1 = GetData_Weather("Temp: ");
                    w.R_Q2_temp2 = GetData_Weather("-");
                    w.R_Q3_temp1 = GetData_Weather("Temp: ");
                    w.R_Q3_temp2 = GetData_Weather("-");
                    w.R_Q4_temp1 = GetData_Weather("Temp: ");
                    w.R_Q4_temp2 = GetData_Weather("-");
                }
            }
        }

        private void Scrape_Tracks()
        {
            foreach (HtmlElement tables in webBrowser1.Document.GetElementsByTagName("table"))
            {
                foreach (HtmlElement tr in tables.GetElementsByTagName("tr"))
                {
                    int count = 0;
                    Track t = new Track();

                    foreach (HtmlElement td in tr.GetElementsByTagName("td"))
                    {                       
                        switch (count)
                        {
                            case 0: HTML = td.OuterHtml;  CutCrapBefore("id="); HTML = HTML.Remove(0, 3); t.TrackID = Convert.ToInt16(GetTextBefore("\"")); break;
                            case 1: t.TrackName = td.InnerText; break;
                            case 3: t.Laps = Convert.ToInt16(td.InnerText); break;
                            case 5: t.Power = Convert.ToInt16(td.GetAttribute("title")); break;
                            case 6: t.Handling = Convert.ToInt16(td.GetAttribute("title")); break;
                            case 7: t.Acceleration = Convert.ToInt16(td.GetAttribute("title")); break;
                            case 10: t.GPs = Convert.ToInt16(td.InnerText); break;
                        }
                        count++;
                    }
                    tracks.Add(t);
                }
            }          
        }

        private void WebBrowserLoaded(object sender, EventArgs e)
        {
            switch (commandID)
            {
                case 0: ExecuteLogin(); break;
                case 1: Navigate(carURL, 2); break;
                case 2: Scrape_Car(); What2Do(3); break;
                case 3: Navigate(siteURL, 4); break;
                case 4: Scrape_DriverID(); Navigate(driverURL+driverID.ToString(),5);  break;
                case 5: Scrape_Driver(); Navigate(weatherURL, 6); break;
                case 6: Scrape_Weather();  What2Do(7); break;
                case 7: Navigate(carURL, 8); break;
                case 8: Scrape_Car(); Navigate(tracksURL, 9); break;
                case 9: Scrape_Tracks(); What2Do(99); break;
                case 99: break;
                default: break;
            }
        }

        public GProScraper(string SiteURL, ref WebBrowser browser)
        {
            webBrowser1 = browser;

            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowserLoaded);
            webBrowser1.ScriptErrorsSuppressed = true;
            siteURL = SiteURL;
            Navigate(SiteURL, 0);
        }

        public GProScraper()
        {
        }

        private void ExecuteLogin()
        {
            if (Password  == "" && UserName == "")
            {
                UserName = "allanthorstein@msn.com";
                Password = "F1Pollew32bit";
            }            
            
            webBrowser1.Document.GetElementById("Text1").SetAttribute("value", UserName);
            webBrowser1.Document.GetElementById("Password2").SetAttribute("value", Password);

            commandID = 1;
            HtmlElement form = webBrowser1.Document.GetElementById("Form1");
            if (form != null) form.InvokeMember("submit");
        }

        public string ShowDataAstext()
        {
            return w.DumpData() + Environment.NewLine + d.DumpData() + Environment.NewLine + c.DumpData();
        }

    }
}
