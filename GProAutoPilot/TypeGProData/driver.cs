using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeGProData
{
    public class Driver
    {
        public string Name { get; set; }
        public int DriverID { get; set; }
        public int OA { get; set; }
        public int Con { get; set; }
        public int Tal { get; set; }
        public int Agg { get; set; }
        public int Exp { get; set; }
        public int Tech { get; set; }
        public int Sta { get; set; }
        public int Cha { get; set; }
        public int Mot { get; set; }
        public int Rep { get; set; }
        public int Wei { get; set; }
        public int Age { get; set; }

        public string DumpData()
        {
            string txt;
            txt = "Driver" + DriverID + " " + Name + ":" + Environment.NewLine  + "OA: " + OA.ToString() + Environment.NewLine + "Con: " + Con.ToString() + Environment.NewLine + "Tal: " + Tal.ToString();
            txt = txt + Environment.NewLine + "Agg: " + Agg.ToString() + Environment.NewLine + "Exp: " + Exp.ToString() + Environment.NewLine + "Tech: " + Tech.ToString();
            txt = txt + Environment.NewLine + "Sta " + Sta.ToString() + Environment.NewLine + "Cha: " + Cha.ToString() + Environment.NewLine + "Mot: " + Mot.ToString();
            txt = txt + Environment.NewLine + "Rep " + Rep.ToString() + Environment.NewLine + "Wei: " + Wei.ToString() + Environment.NewLine + "Age: " + Age.ToString();

            return txt + Environment.NewLine;
        }

    }
}
