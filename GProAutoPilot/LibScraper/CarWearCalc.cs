using System;
using System.Windows.Forms;
using TypeGProData;

namespace LibScraper
{

    public class CarWearCalc : BaseScraper
    {
        string siteURL = "http://www.gproanalyzer.info/car.php";

        Car car_data = new Car();
        Driver driver = new Driver();
        Car car_SimData = new Car();

        private void What2Do(int command)
        {
            Navigate(siteURL, command);
        }

        private void EnterValues_CarWear(int ct1, int ct2)
        {
            foreach (HtmlElement inputfield in webBrowser1.Document.GetElementsByTagName("input"))
            {
                if (inputfield.Name == "chal") inputfield.SetAttribute("value", car_data.ChassisLvl.ToString());
                if (inputfield.Name == "engl") inputfield.SetAttribute("value", car_data.EngineLvl.ToString());
                if (inputfield.Name == "frol") inputfield.SetAttribute("value", car_data.FrontWingLvl.ToString());
                if (inputfield.Name == "real") inputfield.SetAttribute("value", car_data.RearWingLvl.ToString());
                if (inputfield.Name == "undl") inputfield.SetAttribute("value", car_data.UnderbodyLvl.ToString());
                if (inputfield.Name == "sidl") inputfield.SetAttribute("value", car_data.SidePodsLvl.ToString());
                if (inputfield.Name == "cool") inputfield.SetAttribute("value", car_data.CoolingLvl.ToString());
                if (inputfield.Name == "geal") inputfield.SetAttribute("value", car_data.GearBoxLvl.ToString());
                if (inputfield.Name == "bral") inputfield.SetAttribute("value", car_data.BrakesLvl.ToString());
                if (inputfield.Name == "susl") inputfield.SetAttribute("value", car_data.SuspensionLvl.ToString());
                if (inputfield.Name == "elel") inputfield.SetAttribute("value", car_data.ElectronicsLvl.ToString());

                if (inputfield.Name == "chaw") inputfield.SetAttribute("value", car_data.ChassisWear.ToString());
                if (inputfield.Name == "engw") inputfield.SetAttribute("value", car_data.EngineWear.ToString());
                if (inputfield.Name == "frow") inputfield.SetAttribute("value", car_data.FrontWingWear.ToString());
                if (inputfield.Name == "reaw") inputfield.SetAttribute("value", car_data.RearWingWear.ToString());
                if (inputfield.Name == "undw") inputfield.SetAttribute("value", car_data.UnderbodyWear.ToString());
                if (inputfield.Name == "sidw") inputfield.SetAttribute("value", car_data.SidePodsWear.ToString());
                if (inputfield.Name == "coow") inputfield.SetAttribute("value", car_data.CoolingWear.ToString());
                if (inputfield.Name == "geaw") inputfield.SetAttribute("value", car_data.GearBoxWear.ToString());
                if (inputfield.Name == "braw") inputfield.SetAttribute("value", car_data.BrakesWear.ToString());
                if (inputfield.Name == "susw") inputfield.SetAttribute("value", car_data.SuspensionWear.ToString());
                if (inputfield.Name == "elew") inputfield.SetAttribute("value", car_data.ElectronicsWear.ToString());

                if (inputfield.Name == "ct") inputfield.SetAttribute("value", ct1.ToString());
                if (inputfield.Name == "ct2") inputfield.SetAttribute("value", ct2.ToString());

                if (inputfield.Name == "con") inputfield.SetAttribute("value", driver.Con.ToString());
                if (inputfield.Name == "tal") inputfield.SetAttribute("value", driver.Tal.ToString());
                if (inputfield.Name == "exp") inputfield.SetAttribute("value", driver.Exp.ToString());
            }

            commandID = 1;

            foreach (HtmlElement forms in webBrowser1.Document.GetElementsByTagName("form"))
            {
                forms.InvokeMember("submit");
            }
        }

        private void Scrape_Wear_Result()
        {
            foreach (HtmlElement tables in webBrowser1.Document.GetElementsByTagName("table"))
            {
                HTML = tables.InnerHtml.ToLower();

                CutCrapBefore("end wear");

                int count = 0;
                while (count < 10)
                {
                    CutCrapBefore("value=");
                    HTML = HTML.Remove(0, 6);
                    CutCrapBefore("value=");
                    HTML = HTML.Remove(0, 6);
                    CutCrapBefore("value=");
                    HTML = HTML.Remove(0, 6);
                    CutCrapBefore("value=");
                    HTML = HTML.Remove(0, 6);

                    int value = Int32.Parse(GetTextBefore(">"));

                    switch (count)
                    {
                        case 0 : car_SimData.ChassisWear = value; break;
                        case 1 : car_SimData.EngineWear = value; break;
                        case 2 : car_SimData.FrontWingWear = value; break;
                        case 3 : car_SimData.RearWingWear = value; break;
                        case 4 : car_SimData.UnderbodyWear = value; break;
                        case 5 : car_SimData.SidePodsLvl = value; break;
                        case 6 : car_SimData.CoolingWear = value; break;
                        case 7 : car_SimData.GearBoxWear = value; break;
                        case 8 : car_SimData.BrakesWear = value; break;
                        case 9 : car_SimData.SuspensionWear = value; break;
                        case 10: car_SimData.ElectronicsWear = value; break;
                        default: break;
                    }

                    count++;
                    
                    CutCrapBefore("</tr>");
                }

                break;
            }

            int i = 1;
        }

        private void WebBrowserLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {                     
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            else
            {
                switch (commandID)
                {                    
                    case 0: EnterValues_CarWear(0,0); break;                    
                    case 1: Scrape_Wear_Result(); break;
                    default: break;
                }
            }
        }

        public CarWearCalc(string SiteURL, Car thiscar, Driver thisdriver, ref WebBrowser browser)
        {
            
            webBrowser1 = browser;

            car_data = thiscar;
            driver = thisdriver;
            
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowserLoaded);            
            webBrowser1.ScriptErrorsSuppressed = true;
            siteURL = SiteURL;

            Navigate(SiteURL, 0);
        }
    }
}
