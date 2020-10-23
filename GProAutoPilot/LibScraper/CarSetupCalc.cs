using System;
using System.Windows.Forms;
using TypeGProData;

namespace LibScraper
{

    public class CarSetupCalc : BaseScraper
    {
        string siteURL = "http://www.gproanalyzer.info/setup.php";
        string WingsplitURL = "http://www.gproanalyzer.info/wingsplit.php";

        Car car_data = new Car();
        Car car = new Car();
        Driver driver = new Driver();
        Weather weather = new Weather();

        public Car Get_RaceSetup
        {
            get { return car; }
        }

        private void What2Do(int command)
        {
            Navigate(siteURL, command);
        }

        private void EnterValues_CarSetup(int temp, int weather, int nextcmd)
        {
            foreach (HtmlElement inputfield in webBrowser1.Document.GetElementsByTagName("input"))
            {
                // Weather - mangler regnvejr-angivelse
                if (inputfield.Name == "tempr") inputfield.SetAttribute("value", temp.ToString());

                // Driver values
                if (inputfield.Name == "con") inputfield.SetAttribute("value", driver.Con.ToString());
                if (inputfield.Name == "tal") inputfield.SetAttribute("value", driver.Tal.ToString());
                if (inputfield.Name == "agg") inputfield.SetAttribute("value", driver.Agg.ToString());
                if (inputfield.Name == "exp") inputfield.SetAttribute("value", driver.Exp.ToString());
                if (inputfield.Name == "tec") inputfield.SetAttribute("value", driver.Tech.ToString());
                if (inputfield.Name == "wei") inputfield.SetAttribute("value", driver.Wei.ToString());

                // Car calues
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
            }

            commandID = nextcmd;

            foreach (HtmlElement forms in webBrowser1.Document.GetElementsByTagName("form"))
            {
                forms.InvokeMember("submit");
            }
        }

        private void EnterValues_Wingsplit(int frontwing, int temp, int weather, int nextcmd)
        {
            foreach (HtmlElement inputfield in webBrowser1.Document.GetElementsByTagName("input"))
            {
                // Weather - mangler regnvejr-angivelse
                if (inputfield.Name == "temp") inputfield.SetAttribute("value", temp.ToString());

                // Calculated middelvalue of wingsettings
                if (inputfield.Name == "fwrw") inputfield.SetAttribute("value", frontwing.ToString());

                // Driver values
                if (inputfield.Name == "tal") inputfield.SetAttribute("value", driver.Tal.ToString());

                // Car values
                if (inputfield.Name == "frol") inputfield.SetAttribute("value", car_data.FrontWingLvl.ToString());
                if (inputfield.Name == "real") inputfield.SetAttribute("value", car_data.RearWingLvl.ToString());
            }

            commandID = nextcmd;

            foreach (HtmlElement forms in webBrowser1.Document.GetElementsByTagName("form"))
            {
                forms.InvokeMember("submit");
            }
        }

        private RaceSetup Scrape_Setup_Result()
        {
            RaceSetup raceSetup = new RaceSetup();

            foreach (HtmlElement inputdata in webBrowser1.Document.GetElementsByTagName("input"))
            {
                if (inputdata.GetAttribute("name") != "")
                {
                    switch (inputdata.GetAttribute("name"))
                    {
                        case "fr": raceSetup.FrontWing = Convert.ToInt16(inputdata.GetAttribute("value")); break;
                        case "rr": raceSetup.RearWing = Convert.ToInt16(inputdata.GetAttribute("value")); break;
                        case "er": raceSetup.Engine = Convert.ToInt16(inputdata.GetAttribute("value")); break;
                        case "br": raceSetup.Brakes = Convert.ToInt16(inputdata.GetAttribute("value")); break;
                        case "gr": raceSetup.Gear = Convert.ToInt16(inputdata.GetAttribute("value")); break;
                        case "sr": raceSetup.Suspension = Convert.ToInt16(inputdata.GetAttribute("value")); break;
                    }
                }
            }            
            return raceSetup;
        }

        private RaceSetup Scrape_Wingsplit_Result(RaceSetup data)
        {
            foreach (HtmlElement inputdata in webBrowser1.Document.GetElementsByTagName("input"))
            {
                if (inputdata.GetAttribute("name") != "")
                {
                    switch (inputdata.GetAttribute("name"))
                    {
                        case "fwd": data.FrontWingSplit = Convert.ToInt16(inputdata.GetAttribute("value")); break;
                        case "rwd": data.RearWingSplit = Convert.ToInt16(inputdata.GetAttribute("value")); break;
                    }
                }
            }

            return data;
        }


        private void WebBrowserLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {                     
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            else
            {
                switch (commandID)
                {
                    case 0: ExecuteLogin(); break;

                    // Basic setup for Q1, Q2 and Race  ( still needs to set weather from weather-record )
                    case 1: Navigate(siteURL, 2); break;
                    case 2: EnterValues_CarSetup(weather.P_Temp, 0, 3); break;
                    case 3: car.q1Setup = Scrape_Setup_Result(); Navigate(siteURL, 4); break;
                    case 4: EnterValues_CarSetup(weather.Q2_Temp, 0, 5); break;
                    case 5: car.q2Setup = Scrape_Setup_Result(); Navigate(siteURL, 6); break;
                    case 6: EnterValues_CarSetup(weather.RaceTempCalc, 0, 7); break;
                    case 7: car.RaceSetup = Scrape_Setup_Result(); Navigate(siteURL, 8); break;
                    
                    // Wingsplit for Q1, Q2 and Race
                    case 8: Navigate(WingsplitURL, 9); break;
                    case 9: EnterValues_Wingsplit(car.q1Setup.FrontWing, weather.P_Temp, 0, 10); break;
                    case 10: car.q1Setup = Scrape_Wingsplit_Result(car.q1Setup); Navigate(WingsplitURL, 11); break;
                    case 11: EnterValues_Wingsplit(car.q2Setup.FrontWing, weather.Q2_Temp, 0, 12); break;
                    case 12: car.q2Setup = Scrape_Wingsplit_Result(car.q2Setup); Navigate(WingsplitURL, 13); break;
                    case 13: EnterValues_Wingsplit(car.RaceSetup.FrontWing, weather.RaceTempCalc, 0, 14); break;
                    case 14: car.RaceSetup = Scrape_Wingsplit_Result(car.RaceSetup); Navigate(WingsplitURL, 15); break;

                    default: break;                    
                }
            }
        }

        private void ExecuteLogin()
        {
            string UserName = "allanthorstein@msn.com";
            string Password = "F1Pollew32bit";
           
            foreach (HtmlElement inputfield in webBrowser1.Document.GetElementsByTagName("input"))
            {
                if (inputfield.GetAttribute("name") == "username") inputfield.SetAttribute("value", UserName);
                if (inputfield.GetAttribute("name") == "password") inputfield.SetAttribute("value", Password);
            }

            // Do the next thing in the script, after login-post
            commandID = 1;

            HtmlElement form = webBrowser1.Document.GetElementsByTagName("form")[0];
            if (form != null) form.InvokeMember("submit");            
        }


        public CarSetupCalc(Car thiscar, Driver thisdriver, ref WebBrowser browser)
        {
            
            webBrowser1 = browser;

            car_data = thiscar;
            driver = thisdriver;
            
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowserLoaded);            
            webBrowser1.ScriptErrorsSuppressed = true;

            // Goto login page
            Navigate("http://www.gproanalyzer.info/login.php", 0);
        }

        public String DumpData()
        {
            return car.DumpData();
        }

    }
}
