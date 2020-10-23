using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeGProData
{
    public class Weather
    {       
        public int P_Temp { get; set; }
        public int Q2_Temp { get; set; }
        public int R_Q1_temp1 { get; set; }
        public int R_Q2_temp1 { get; set; }
        public int R_Q3_temp1 { get; set; }
        public int R_Q4_temp1 { get; set; }
        public int R_Q1_temp2 { get; set; }
        public int R_Q2_temp2 { get; set; }
        public int R_Q3_temp2 { get; set; }
        public int R_Q4_temp2 { get; set; }

        public int RaceTempCalc { get => (R_Q1_temp1 + R_Q2_temp1 + R_Q3_temp1 + R_Q4_temp2 + R_Q1_temp2 + R_Q2_temp2 + R_Q3_temp2 + R_Q4_temp2) / 8; }

        public string DumpData()
        {
            return "Practice Temp: " + P_Temp.ToString() + Environment.NewLine + "Q2 Temp: " + Q2_Temp.ToString() + Environment.NewLine +  "Racing Temp (calc): " + RaceTempCalc.ToString() + Environment.NewLine;
        }
    }
}
