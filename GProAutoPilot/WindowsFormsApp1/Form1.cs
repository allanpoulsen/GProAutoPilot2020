using Microsoft.Toolkit.Forms.UI.Controls;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml.Media;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private int itemstouched = 0;
        private List<CarPHA> CarPHAList = new List<CarPHA>();
        private Boolean JegERFAERDIG = false;
        // private int CarPHASpool = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webView1.Navigate("http://gproanalyzer.info/carpha.php");
        }

        private async void InjectJava(CarPHA cPHA)
        {
            //            string[] cmds = new string[] { @"document.getElementsByName('chal')[0].value = '2';",
            //                                           @"document.getElementsByClassName('SubmitButton')[0].click();" };
            //                                           @"document.getElementsByTagName('button')[1].click();"};
            //            await webView1.InvokeScriptAsync("eval", cmds);

            // await webView1.InvokeScriptAsync("javascript:document.getElementById('soeg').value = 'allan';");

            await webView1.InvokeScriptAsync("eval", "document.getElementsByName('chal')[0].value = '" + cPHA.ChasisLvl.ToString() + "';");
            await webView1.InvokeScriptAsync("eval", "document.getElementsByName('engl')[0].value = '" + cPHA.EngineLvl.ToString() + "';");
            await webView1.InvokeScriptAsync("eval", "document.getElementsByName('frol')[0].value = '" + cPHA.FrontWingLvl.ToString() + "';");
            await webView1.InvokeScriptAsync("eval", "document.getElementsByName('real')[0].value = '" + cPHA.RearWingLvl.ToString() + "';");
            await webView1.InvokeScriptAsync("eval", "document.getElementsByName('undl')[0].value = '" + cPHA.UnderbodyLvl.ToString() + "';");
            await webView1.InvokeScriptAsync("eval", "document.getElementsByName('sidl')[0].value = '" + cPHA.SidepodsLvl.ToString() + "';");
            await webView1.InvokeScriptAsync("eval", "document.getElementsByName('cool')[0].value = '" + cPHA.CooloingLvl.ToString() + "';");
            await webView1.InvokeScriptAsync("eval", "document.getElementsByName('geal')[0].value = '" + cPHA.GearBoxLvl.ToString() + "';");
            await webView1.InvokeScriptAsync("eval", "document.getElementsByName('bral')[0].value = '" + cPHA.BrakesLvl.ToString() + "';");
            await webView1.InvokeScriptAsync("eval", "document.getElementsByName('susl')[0].value = '" + cPHA.SuspensionLvl.ToString() + "';");
            await webView1.InvokeScriptAsync("eval", "document.getElementsByName('elel')[0].value = '" + cPHA.ElectronicsLvl.ToString() + "';");            

            await webView1.InvokeScriptAsync("eval", "document.getElementsByClassName('SubmitButton')[0].click();");

            // CarPHAList[CarPHASpool] = utils.ExcteactFromHTML(siteHtML, cPHA);
        }

        private async void webView1_DOMContentLoaded(object sender, WebViewControlDOMContentLoadedEventArgs e)
        {
            var siteHtML = await webView1.InvokeScriptAsync("eval", new string[] { "document.documentElement.outerHTML;" });
            // CarPHAList[CarPHASpool] = utils.ExcteactFromHTML(siteHtML, CarPHAList[CarPHASpool]);

            HTMLhelper htmlhelper = new HTMLhelper();
            CarPHA carpha = new CarPHA();

            carpha = htmlhelper.ExcteactFromHTML(siteHtML);            

            CarPHAList.Add(carpha);

            JegERFAERDIG = true;

            // Save for every X entry
            if (itemstouched > 20)
            {
                try
                {
                    using (Stream stream = File.Open("PHA_data start" + textBox1.Text + " end " + textBox2.Text + ".txt", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, CarPHAList);
                    }
                }
                catch (IOException)
                {
                }

                itemstouched = 0;
                listBox1.Items.Add(DateTime.Now.ToString() + " " + carpha.StringData());
            }
            else itemstouched++;
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            int startlvl = 1;

            startlvl = Int32.Parse(textBox1.Text);

            int sEngineLvl = startlvl;
            int sChasisLvl = startlvl;
            int sFrontWingLvl = startlvl;
            int sRearWingLvl = startlvl;
            int sUnderbodyLvl = startlvl;
            int sSidepodsLvl = startlvl;
            int sCooloingLvl = startlvl;
            int sGearBoxLvl = startlvl;
            int sBrakesLvl = startlvl;
            int sSuspensionLvl = startlvl;
            int sElectronicsLvl = startlvl;

            // Resume from file ....
            CarPHAList.Clear();
            try
            {
                using (Stream stream = File.Open("PHA_data start1 end 4.txt", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    CarPHAList = (List<CarPHA>)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
            }

            // Extract startpoints
            if (CarPHAList.Count > 0)
            {
                sEngineLvl = CarPHAList[CarPHAList.Count - 1].EngineLvl;
                sChasisLvl = CarPHAList[CarPHAList.Count - 1].ChasisLvl;
                sFrontWingLvl = CarPHAList[CarPHAList.Count - 1].FrontWingLvl;
                sRearWingLvl = CarPHAList[CarPHAList.Count - 1].RearWingLvl;
                sUnderbodyLvl = CarPHAList[CarPHAList.Count - 1].UnderbodyLvl;
                sSidepodsLvl = CarPHAList[CarPHAList.Count - 1].SidepodsLvl;
                sCooloingLvl = CarPHAList[CarPHAList.Count - 1].CooloingLvl;
                sGearBoxLvl = CarPHAList[CarPHAList.Count - 1].GearBoxLvl;
                sBrakesLvl = CarPHAList[CarPHAList.Count - 1].BrakesLvl;
                sSuspensionLvl = CarPHAList[CarPHAList.Count - 1].SuspensionLvl;
                sElectronicsLvl = CarPHAList[CarPHAList.Count - 1].ElectronicsLvl;
            }

            int howdeep = Int32.Parse(textBox2.Text); ;

            for (int cEngineLvl = sEngineLvl; cEngineLvl <= howdeep; cEngineLvl++)
            {
                for (int cChasisLvl = sChasisLvl; cChasisLvl <= howdeep; cChasisLvl++)
                {
                    for (int cFrontWingLvl = sFrontWingLvl; cFrontWingLvl <= howdeep; cFrontWingLvl++)
                    {
                        for (int cRearWingLvl = sRearWingLvl; cRearWingLvl <= howdeep; cRearWingLvl++)
                        {
                            for (int cUnderbodyLvl = sUnderbodyLvl; cUnderbodyLvl <= howdeep; cUnderbodyLvl++)
                            {
                                for (int cSidepodsLvl = sSidepodsLvl; cSidepodsLvl <= howdeep; cSidepodsLvl++)
                                {
                                    for (int cCooloingLvl = sCooloingLvl; cCooloingLvl <= howdeep; cCooloingLvl++)
                                    {
                                        for (int cGearBoxLvl = sGearBoxLvl; cGearBoxLvl <= howdeep; cGearBoxLvl++)
                                        {
                                            for (int cBrakesLvl = sBrakesLvl; cBrakesLvl <= howdeep; cBrakesLvl++)
                                            {
                                                for (int cSuspensionLvl = sSuspensionLvl; cSuspensionLvl <= howdeep; cSuspensionLvl++)
                                                {
                                                    for (int cElectronicsLvl = sElectronicsLvl; cElectronicsLvl <= howdeep; cElectronicsLvl++)
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

                                                        // InjectJava(CarPHAList[CarPHASpool]);

                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByName('chal')[0].value = '" + carpha.ChasisLvl.ToString() + "';");
                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByName('engl')[0].value = '" + carpha.EngineLvl.ToString() + "';");
                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByName('frol')[0].value = '" + carpha.FrontWingLvl.ToString() + "';");
                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByName('real')[0].value = '" + carpha.RearWingLvl.ToString() + "';");
                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByName('undl')[0].value = '" + carpha.UnderbodyLvl.ToString() + "';");
                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByName('sidl')[0].value = '" + carpha.SidepodsLvl.ToString() + "';");
                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByName('cool')[0].value = '" + carpha.CooloingLvl.ToString() + "';");
                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByName('geal')[0].value = '" + carpha.GearBoxLvl.ToString() + "';");
                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByName('bral')[0].value = '" + carpha.BrakesLvl.ToString() + "';");
                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByName('susl')[0].value = '" + carpha.SuspensionLvl.ToString() + "';");
                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByName('elel')[0].value = '" + carpha.ElectronicsLvl.ToString() + "';");

                                                        JegERFAERDIG = false;

                                                        //Submit and save when page has reloaded!
                                                        await webView1.InvokeScriptAsync("eval", "document.getElementsByClassName('SubmitButton')[0].click();");

                                                        while (!JegERFAERDIG)
                                                            await Task.Delay(200);

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

            // Save list, just be sure
            try
            {
                using (Stream stream = File.Open("PHA_data_final-start " + textBox1.Text + " end " + textBox2.Text + ".txt", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, CarPHAList);
                }
            }
            catch (IOException)
            {
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }

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
            Power = 13;
            Handling = 13;
            Acceleration = 13;
        }

        public string StringData()
        {
            return EngineLvl.ToString() + "," + ChasisLvl.ToString() + "," + FrontWingLvl.ToString() + "," + RearWingLvl.ToString() + "," + UnderbodyLvl.ToString() + "," + SidepodsLvl.ToString() + "," + CooloingLvl.ToString() + "," + GearBoxLvl.ToString() + "," + BrakesLvl.ToString() + "," + SuspensionLvl.ToString() + "," + ElectronicsLvl.ToString() + " - " + Power.ToString() + ":" + Handling.ToString() + ":" + Acceleration.ToString() + " - " + Created.ToShortDateString() + "\r\n";
        }

    }

    class HTMLhelper
    {
        string HTML;

        int CutCrapBefore(string tofind)
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

        string GetTextBefore(string tofind)
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

        public CarPHA ExcteactFromHTML(string html)
        {
            CarPHA carpha = new CarPHA();
            
            carpha.source = ScrapeSources.gproanalyzer;
            carpha.Created = DateTime.Now;

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
    }

}
