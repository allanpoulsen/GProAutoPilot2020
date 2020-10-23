using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibScraper;

namespace WinTest
{
    public partial class Form1 : Form
    {

        GProScraper Scraper;
        CalcSite Calculator;
        CalcSite2 Calculator2;

        public Form1()
        {
            InitializeComponent();
        }

        // test
        private void button1_Click(object sender, EventArgs e)
        {
            Scraper = new GProScraper("https://www.gpro.net/gb/gpro.asp", ref GProBrowser);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GProDataOutput.Text = Scraper.ShowDataAstext();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calculator = new CalcSite("http://www.gproanalyzer.info/carpha.php", ref CalcBrowser);            
        }

        private void Calc_Click(object sender, EventArgs e)
        {
            Calculator.SavePHAListToDisk("withdata.bin");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Calculator.LoadPHAListFromDisk("autoresume.bin");
            CalcDataOutput.Text = Calculator.ShowDataAstext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calculator2 = new CalcSite2("https://www.gpro-strategy.net/en/gpro-strategy/car.html", ref CalcBrowser);
        }

        private void CalcCarWear_Click(object sender, EventArgs e)
        {
            Scraper.driver.Exp = 250;
            CarWearCalc carWearCalc = new CarWearCalc("http://www.gproanalyzer.info/car.php", Scraper.car, Scraper.driver, ref CalcBrowser);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
