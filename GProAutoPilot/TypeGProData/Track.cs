using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeGProData
{
    public class Track
    {
        private int trackID;
        private string trackname;
        private int laps;
        private int power;
        private int handling;
        private int accel;
        private int gps;

        public string Dump2String()
        {
            return trackname + "(" + TrackID.ToString() + ") Laps: " + laps.ToString() + "PHA: " + power.ToString() + "-" + handling.ToString() + "-" + accel.ToString();
        }

        public string DumpPHA()
        {
            return power.ToString() + "-" + handling.ToString() + "-" + accel.ToString();
        }

        public int GPs
        {
            get { return gps; }
            set { gps = value; }
        }


        public int Acceleration
        {
            get { return accel; }
            set { accel = value; }
        }


        public string TrackName
        {
            get { return trackname; }
            set { trackname = value; }
        }


        public int Handling
        {
            get { return handling; }
            set { handling = value; }
        }


        public int Power
        {
            get { return power; }
            set { power = value; }
        }


        public int Laps
        {
            get { return laps; }
            set { laps = value; }
        }


        public int TrackID
        {
            get { return trackID; }
            set { trackID = value; }
        }

    }
}
