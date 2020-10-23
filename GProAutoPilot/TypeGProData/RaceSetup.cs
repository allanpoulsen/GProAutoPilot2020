using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeGProData
{
    public class RaceSetup
    {
        public int FrontWing { get; set; }

        public int RearWing { get; set; }

        public int FrontWingSplit { get; set; }

        public int RearWingSplit { get; set; }

        public int Engine { get; set; }

        public int Brakes { get; set; }

        public int Gear { get; set; }

        public int Suspension { get; set; }

        public int Risk_Dry { get; set; }

        public int Risk_Wet { get; set; }

        public int Risk_Overtake { get; set; }

        public RaceSetup()
        {
            FrontWing = 0;
            RearWing = 0;
            FrontWingSplit = 0;
            RearWingSplit = 0;
            Engine = 0;
            Brakes = 0;
            Gear = 0;
            Suspension = 0;
            Risk_Dry = 0;
            Risk_Wet = 0;
            Risk_Overtake = 0;
        }

        public string DumpData()
        {
            return "Fw: " + FrontWing.ToString() + " Rw: " + RearWing.ToString() + " FwS: " + FrontWingSplit.ToString() + " RwS: " + RearWingSplit.ToString() + " Engine: " + Engine.ToString() + " Brakes: " + Brakes.ToString() + " Gear: " + Gear.ToString() + "Suspension: " + Suspension.ToString();
        }
    }
}
