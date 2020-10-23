using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeGProData;

namespace LibScraper
{
    class Bingo : BaseScraper
    {
        int start = 1;
        int slut = 5;
        int count = 0;

        public Bingo(ref WebBrowser browser)
        {
            webBrowser1 = browser;
            count = start-1;

            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowserLoaded);
            webBrowser1.ScriptErrorsSuppressed = true;            
            Navigate("https://bankopladerne.dk/bankoplader.php?s=" +  count++.ToString() + "&t=6&p=1", 0);
        }

        private void WebBrowserLoaded(object sender, EventArgs e)
        {
            HTML = webBrowser1.DocumentText;
            count = count++;
            Navigate("https://bankopladerne.dk/bankoplader.php?s=" + count.ToString() + "&t=6&p=1", 0);
        }


    }
}
