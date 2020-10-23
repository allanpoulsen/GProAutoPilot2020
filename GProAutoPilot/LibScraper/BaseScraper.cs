using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibScraper
{
    public class BaseScraper
    {
        protected WebBrowser webBrowser1;
        protected int commandID = 0;
        protected string HTML = "";

        protected int CutCrapBefore(string tofind)
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

        protected string GetTextBefore(string tofind)
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

        protected void Navigate(string thisURL, int command)
        {            
            commandID = command;
            webBrowser1.Navigate(new Uri(thisURL));
        }
    }
}
