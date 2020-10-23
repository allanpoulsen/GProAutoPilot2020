using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace LibScraper
{
    [Serializable]
    public enum ScrapeSources
    {
        gprostrategy = 2,
        gproanalyzer = 1,
        unknown = 0
    }

    [Serializable]
    public class CarPHA
    {
        // Basic info
        public DateTime Created { get; set; }
        public ScrapeSources source = ScrapeSources.unknown;

        // CAR STATS
        public int EngineLvl { get; set; }
        public int ChasisLvl { get; set; }
        public int FrontWingLvl { get; set; }
        public int RearWingLvl { get; set; }
        public int UnderbodyLvl { get; set; }
        public int SidepodsLvl { get; set; }
        public int CooloingLvl { get; set; }
        public int GearBoxLvl { get; set; }
        public int BrakesLvl { get; set; }
        public int SuspensionLvl { get; set; }
        public int ElectronicsLvl { get; set; }

        // PHA based on the above Carstats - no calc, values ripped from database / sites
        public int Power { get; set; }
        public int Handling { get; set; }
        public int Acceleration { get; set; }

        public void CarPha()
        {
            Created = DateTime.Now;

            EngineLvl = 1;
            ChasisLvl = 1;
            FrontWingLvl = 1;
            RearWingLvl = 1;
            UnderbodyLvl = 1;
            SidepodsLvl = 1;
            CooloingLvl = 1;
            GearBoxLvl = 1;
            BrakesLvl = 1;
            SuspensionLvl = 1;
            ElectronicsLvl = 1;
            Power = 0;
            Handling = 0;
            Acceleration = 0;
        }

        public string StringData()
        {
            return EngineLvl.ToString() + "," + ChasisLvl.ToString() + "," + FrontWingLvl.ToString() + "," + RearWingLvl.ToString() + "," + UnderbodyLvl.ToString() + "," + SidepodsLvl.ToString() + "," + CooloingLvl.ToString() + "," + GearBoxLvl.ToString() + "," + BrakesLvl.ToString() + "," + SuspensionLvl.ToString() + "," + ElectronicsLvl.ToString() + " - " + Power.ToString() + ":" + Handling.ToString() + ":" + Acceleration.ToString() + " - " + Created.ToShortDateString() + "\r\n"; 
        }

    }

    public class CalcSite : BaseScraper
    {
        string siteURL = "http://www.gproanalyzer.info/carpha.php";

        List<CarPHA> CarPHAList = new List<CarPHA>();
        int CarPHASpool = 0;
        int countme = 0;

        private void What2Do(int command)
        {
            Navigate(siteURL, command);
        }

        public void Scrape_CarPHA(CarPHA car_data)
        {
            // HtmlDocument html = webBrowser1.Document;

            foreach (HtmlElement inputfield in webBrowser1.Document.GetElementsByTagName("input"))
            {
                if (inputfield.Name == "chal") inputfield.SetAttribute("value", car_data.ChasisLvl.ToString());
                if (inputfield.Name == "engl") inputfield.SetAttribute("value", car_data.EngineLvl.ToString());
                if (inputfield.Name == "fwil") inputfield.SetAttribute("value", car_data.FrontWingLvl.ToString());
                if (inputfield.Name == "rwil") inputfield.SetAttribute("value", car_data.RearWingLvl.ToString());
                if (inputfield.Name == "undl") inputfield.SetAttribute("value", car_data.UnderbodyLvl.ToString());
                if (inputfield.Name == "sidl") inputfield.SetAttribute("value", car_data.SidepodsLvl.ToString());
                if (inputfield.Name == "cool") inputfield.SetAttribute("value", car_data.CooloingLvl.ToString());
                if (inputfield.Name == "geal") inputfield.SetAttribute("value", car_data.GearBoxLvl.ToString());
                if (inputfield.Name == "bral") inputfield.SetAttribute("value", car_data.BrakesLvl.ToString());
                if (inputfield.Name == "susl") inputfield.SetAttribute("value", car_data.SuspensionLvl.ToString());
                if (inputfield.Name == "elel") inputfield.SetAttribute("value", car_data.ElectronicsLvl.ToString());
            }

            foreach (HtmlElement forms in webBrowser1.Document.GetElementsByTagName("form"))
            {
                forms.InvokeMember("submit");
            }

            commandID = 1;
        }

        public CarPHA Scrape_PHA_Result()
        {
            CarPHA carpha = new CarPHA();
            carpha.Created = DateTime.Now;

            int i = 1;
            carpha.source = ScrapeSources.gproanalyzer;

            foreach (HtmlElement inputfield in webBrowser1.Document.GetElementsByTagName("input"))
            {
                if (i == 3) { carpha.Acceleration = Int32.Parse(inputfield.GetAttribute("value")); i++; }
                if (i == 2) { carpha.Handling = Int32.Parse(inputfield.GetAttribute("value")); i++;  }
                if (i == 1) { carpha.Power = Int32.Parse(inputfield.GetAttribute("value")); i++; }
                if (inputfield.Name == "chal") { carpha.ChasisLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
                if (inputfield.Name == "engl") { carpha.EngineLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
                if (inputfield.Name == "fwil") { carpha.FrontWingLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
                if (inputfield.Name == "rwil") { carpha.RearWingLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
                if (inputfield.Name == "undl") { carpha.UnderbodyLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
                if (inputfield.Name == "sidl") { carpha.SidepodsLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
                if (inputfield.Name == "cool") { carpha.CooloingLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
                if (inputfield.Name == "geal") { carpha.GearBoxLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
                if (inputfield.Name == "bral") { carpha.BrakesLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
                if (inputfield.Name == "susl") { carpha.SuspensionLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
                if (inputfield.Name == "elel") { carpha.ElectronicsLvl = Int32.Parse(inputfield.GetAttribute("value")); }
            }

            countme++;
            System.Diagnostics.Debug.WriteLine("Scraped " + countme.ToString() + " : " + DateTime.Now.ToLongTimeString());

            return carpha;            
        }

        public void Itterate()
        {
            int howdeep = 4;

            CarPHAList.Clear();

            for (int cEngineLvl = 1; cEngineLvl < howdeep; cEngineLvl++)
            {
                for (int cChasisLvl = 1; cChasisLvl < howdeep; cChasisLvl++)
                {
                    for (int cFrontWingLvl = 1; cFrontWingLvl < howdeep; cFrontWingLvl++)
                    {
                        for (int cRearWingLvl = 1; cRearWingLvl < howdeep; cRearWingLvl++)
                        {
                            for (int cUnderbodyLvl = 1; cUnderbodyLvl < howdeep; cUnderbodyLvl++)
                            {
                                for (int cSidepodsLvl = 1; cSidepodsLvl < howdeep; cSidepodsLvl++)
                                {
                                    for (int cCooloingLvl = 1; cCooloingLvl < howdeep; cCooloingLvl++)
                                    {
                                        for (int cGearBoxLvl = 1; cGearBoxLvl < howdeep; cGearBoxLvl++)
                                        {
                                            for (int cBrakesLvl = 1; cBrakesLvl < howdeep; cBrakesLvl++)
                                            {
                                                for (int cSuspensionLvl = 1; cSuspensionLvl < howdeep; cSuspensionLvl++)
                                                {
                                                    for (int cElectronicsLvl = 1; cElectronicsLvl < howdeep; cElectronicsLvl++)
                                                    {
                                                        CarPHA carpha = new CarPHA();
                                                        carpha.EngineLvl = cEngineLvl;
                                                        carpha.ChasisLvl = cChasisLvl;
                                                        carpha.FrontWingLvl = cFrontWingLvl;
                                                        carpha.RearWingLvl = cRearWingLvl;
                                                        carpha.UnderbodyLvl = cUnderbodyLvl;
                                                        carpha.SidepodsLvl = cSidepodsLvl;
                                                        carpha.CooloingLvl = cCooloingLvl;
                                                        carpha.GearBoxLvl = cGearBoxLvl;
                                                        carpha.BrakesLvl = cBrakesLvl;
                                                        carpha.SuspensionLvl = cSuspensionLvl;
                                                        carpha.ElectronicsLvl = cElectronicsLvl;

                                                        CarPHAList.Add(carpha);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            SavePHAListToDisk("PHA_" + howdeep.ToString() + "Niveau.txt");            
        }


        private void WebBrowserLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {                     
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            else
            {
                switch (commandID)
                {                    
                    case 0: Scrape_CarPHA(CarPHAList[CarPHASpool]); break;                    
                    case 1: CarPHAList[CarPHASpool] = Scrape_PHA_Result(); CarPHASpool++;  if (CarPHASpool % 30 == 0) { SavePHAListToDisk("autosave" + CarPHASpool.ToString() + ".bin");  Thread.Sleep(90000); }  What2Do(0);  break;
                    default: break;
                }
            }
        }

        public CalcSite(string SiteURL, ref WebBrowser browser)
        {            
            webBrowser1 = browser;
            
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowserLoaded);            
            webBrowser1.ScriptErrorsSuppressed = true;
            siteURL = SiteURL;
            // Itterate();   
            LoadPHAListFromDisk("autoresume.bin");

            // Dont re-check
            while (CarPHAList[CarPHASpool].Created != DateTime.MinValue) CarPHASpool++;

            System.Diagnostics.Debug.Write("Start: " + DateTime.Now.ToLongTimeString());
            Navigate(SiteURL, 0);
        }

        public string ShowDataAstext()
        {
            string returnval = string.Empty;

            for (int i = 0; i < 5000; i++)
            {
                returnval = returnval + CarPHAList[i].StringData();
            }

            return returnval;
        }

        public void SavePHAListToDisk(string filename)
        {
            try
            {
                using (Stream stream = File.Open(filename, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, CarPHAList);
                }
            }
            catch (IOException)
            {
            }
        }

        public void LoadPHAListFromDisk(string filename)
        {
            try
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();                                        
                    CarPHAList = (List<CarPHA>)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
            }
        }


    }
}
