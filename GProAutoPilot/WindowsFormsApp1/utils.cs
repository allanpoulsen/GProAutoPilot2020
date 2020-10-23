using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1123
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

    public class BaseScraper
    {
        public string HTML = "";

        private int CutCrapBefore(string tofind)
        {
            if (HTML.Length > 0)
            {
                int pos = HTML.IndexOf(tofind);

                if (pos > 0)
                {
                    HTML = HTML.Remove(0, pos);
                    return 1;
                }
            }
            return 0;
        }

        private string GetTextBefore(string tofind)
        {
            if (HTML.Length > 0)
            {
                int pos = HTML.IndexOf(tofind);

                if (pos > 0)
                {
                    return HTML.Substring(0, pos);
                }
                else return "";

            }
            return "";
        }

        protected string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }



    static class utils2
    {
        static string HTML;

        static int CutCrapBefore(string tofind)
        {
            if (HTML.Length > 0)
            {
                int pos = HTML.IndexOf(tofind);

                if (pos > 0)
                {
                    HTML = HTML.Remove(0, pos);
                    return 1;
                }
            }
            return 0;
        }

        static string GetTextBefore(string tofind)
        {
            if (HTML.Length > 0)
            {
                int pos = HTML.IndexOf(tofind);

                if (pos > 0)
                {
                    return HTML.Substring(0, pos);
                }
                else return "";

            }
            return "";
        }

        static public CarPHA ExcteactFromHTML(string html)
        {
            CarPHA carpha = new CarPHA();

            carpha.Created = DateTime.Now;            
            carpha.source = ScrapeSources.gproanalyzer;

            HTML = html;

            CutCrapBefore("Power");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.Power = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Handling");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.Handling = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Acceleration");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.Acceleration = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Chasis");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.ChasisLvl = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Engine");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.EngineLvl = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Front Wing");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.FrontWingLvl = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Rear Wing");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.RearWingLvl = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Underbody");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.UnderbodyLvl = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Sidepods");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.SidepodsLvl = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Cooling");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.CooloingLvl = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Gearbox");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.GearBoxLvl = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Brakes");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.BrakesLvl = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Suspension");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.SuspensionLvl = Int32.Parse(GetTextBefore("\""));

            CutCrapBefore("Electronics");
            CutCrapBefore("value=");
            HTML = HTML.Remove(0, 7);
            carpha.ElectronicsLvl = Int32.Parse(GetTextBefore("\""));

            return carpha;
        }

        static public List<CarPHA> Itterate()
        {
            int howdeep = 4;

            List<CarPHA> CarPHAList = new List<CarPHA>();

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
            try
            {
                using (Stream stream = File.Open("PHA_" + howdeep.ToString() + "_niveauer.txt", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, CarPHAList);
                }
            }
            catch (IOException)
            {
            }
            
            return CarPHAList;
        }

    }
}
