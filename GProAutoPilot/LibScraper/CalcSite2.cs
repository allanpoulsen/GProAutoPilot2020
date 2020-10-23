using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace LibScraper
{

    public class CalcSite2 : BaseScraper
    {
        string siteURL = "https://www.gpro-strategy.net/en/gpro-strategy/car.html";

        List<CarPHA> CarPHAList = new List<CarPHA>();
        int CarPHASpool = 0;
        int countme = 0;

        private void What2Do(int command)
        {
            Navigate(siteURL, command);
        }

        public void EnterValues_CarPHA(CarPHA car_data)
        {
            foreach (HtmlElement inputfield in webBrowser1.Document.GetElementsByTagName("select"))
            {
                if (inputfield.Name == "c_telaio") inputfield.SetAttribute("value", car_data.ChasisLvl.ToString());
                if (inputfield.Name == "c_motore") inputfield.SetAttribute("value", car_data.EngineLvl.ToString());
                if (inputfield.Name == "c_ale_a") inputfield.SetAttribute("value", car_data.FrontWingLvl.ToString());
                if (inputfield.Name == "c_ale_p") inputfield.SetAttribute("value", car_data.RearWingLvl.ToString());
                if (inputfield.Name == "c_fondo") inputfield.SetAttribute("value", car_data.UnderbodyLvl.ToString());
                if (inputfield.Name == "c_fiancate") inputfield.SetAttribute("value", car_data.SidepodsLvl.ToString());
                if (inputfield.Name == "c_raffreddamento") inputfield.SetAttribute("value", car_data.CooloingLvl.ToString());
                if (inputfield.Name == "c_cambio") inputfield.SetAttribute("value", car_data.GearBoxLvl.ToString());
                if (inputfield.Name == "c_freni") inputfield.SetAttribute("value", car_data.BrakesLvl.ToString());
                if (inputfield.Name == "c_sospensioni") inputfield.SetAttribute("value", car_data.SuspensionLvl.ToString());
                if (inputfield.Name == "c_elettronica") inputfield.SetAttribute("value", car_data.ElectronicsLvl.ToString());
            }

            foreach (HtmlElement forms in webBrowser1.Document.GetElementsByTagName("form"))
            {
                if (forms.Name == "form") forms.InvokeMember("submit");
            }

            commandID = 1;
        }

        public CarPHA Scrape_PHA_Result()
        {
            CarPHA carpha = new CarPHA();
            carpha = CarPHAList[CarPHASpool];

            carpha.Created = DateTime.Now;
            carpha.source = ScrapeSources.gprostrategy;

            //foreach (HtmlElement inputfield in webBrowser1.Document.GetElementsByTagName("input"))
            //{
            //    if (inputfield.Name == "c_telaio") { carpha.ChasisLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
            //    if (inputfield.Name == "c_motore") { carpha.EngineLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
            //    if (inputfield.Name == "c_ale_a") { carpha.FrontWingLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
            //    if (inputfield.Name == "c_ale_p") { carpha.RearWingLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
            //    if (inputfield.Name == "c_fondo") { carpha.UnderbodyLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
            //    if (inputfield.Name == "c_fiancate") { carpha.SidepodsLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
            //    if (inputfield.Name == "c_raffreddamento") { carpha.CooloingLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
            //    if (inputfield.Name == "c_cambio") { carpha.GearBoxLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
            //    if (inputfield.Name == "c_freni") { carpha.BrakesLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
            //    if (inputfield.Name == "c_sospensioni") { carpha.SuspensionLvl = Int32.Parse(inputfield.GetAttribute("value"));  }
            //    if (inputfield.Name == "c_elettronica") { carpha.ElectronicsLvl = Int32.Parse(inputfield.GetAttribute("value")); }
            //}

            string TableData = webBrowser1.Document.GetElementsByTagName("table")[1].InnerHtml.ToString();
            string delimiter = "<font color=blue>";

            TableData = TableData.ToLower();
            TableData = TableData.Remove(0, TableData.IndexOf(delimiter));
            TableData = TableData.Remove(0, delimiter.Length+1);
            TableData = TableData.Remove(0, TableData.IndexOf(delimiter));
            TableData = TableData.Remove(0, delimiter.Length);

            carpha.Power = Int32.Parse(TableData.Substring(0, TableData.IndexOf("<")));

            TableData = TableData.ToLower();
            TableData = TableData.Remove(0, TableData.IndexOf(delimiter));
            TableData = TableData.Remove(0, delimiter.Length);
            carpha.Handling = Int32.Parse(TableData.Substring(0, TableData.IndexOf("<")));

            TableData = TableData.ToLower();
            TableData = TableData.Remove(0, TableData.IndexOf(delimiter));
            TableData = TableData.Remove(0, delimiter.Length);
            carpha.Acceleration = Int32.Parse(TableData.Substring(0, TableData.IndexOf("<")));

            countme++;

            System.Diagnostics.Debug.WriteLine("Scraped " + countme.ToString() + " : " + DateTime.Now.ToLongTimeString());

            return carpha;            
        }

        private void WebBrowserLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {                     
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            else
            {
                switch (commandID)
                {                    
                    case 0: EnterValues_CarPHA(CarPHAList[CarPHASpool]); break;                    
                    case 1: CarPHAList[CarPHASpool] = Scrape_PHA_Result(); CarPHASpool++;  if (CarPHASpool % 100 == 0) { SavePHAListToDisk("autosave2_" + CarPHASpool.ToString() + ".bin"); } What2Do(0); break;
                    default: break;
                }
            }
        }

        public CalcSite2(string SiteURL, ref WebBrowser browser)
        {
            
            webBrowser1 = browser;
            
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowserLoaded);            
            webBrowser1.ScriptErrorsSuppressed = true;
            siteURL = SiteURL;

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
