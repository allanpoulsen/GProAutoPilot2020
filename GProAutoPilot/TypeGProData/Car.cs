using System;

namespace TypeGProData
{

    public class CarCalcWear
    {
        // This class contains data from the Car Wear Calculator

        public Car prerace { get; set; }
        public Car postrace { get; set; }
        public int CT { get; set; }
        public Driver driver { get; set; }
    }

    public class Car
    {
        // Expenses to upgrade - its [carpartid,lvl]
        public int[,] upgradecost = new int[11, 11];
        // New wear when downgrade
        public int[,] downgradewear = new int[11, 11];        

        // Racesetup:
        public RaceSetup q1Setup { get; set; }
        public RaceSetup q2Setup { get; set; }
        public RaceSetup RaceSetup { get; set; }

        // Level:
        public int ChassisLvl { get; set; }
        public int EngineLvl { get; set; }
        public int FrontWingLvl { get; set; }
        public int RearWingLvl { get; set; }
        public int UnderbodyLvl { get; set; }
        public int SidePodsLvl { get; set; }
        public int CoolingLvl { get; set; }
        public int GearBoxLvl { get; set; }
        public int BrakesLvl { get; set; }
        public int SuspensionLvl { get; set; }
        public int ElectronicsLvl { get; set; }

        // Wear:
        public int ChassisWear { get; set; }
        public int EngineWear { get; set; }
        public int FrontWingWear { get; set; }
        public int RearWingWear { get; set; }
        public int UnderbodyWear { get; set; }
        public int SidePodsWear { get; set; }
        public int CoolingWear { get; set; }
        public int GearBoxWear { get; set; }
        public int BrakesWear { get; set; }
        public int SuspensionWear { get; set; }
        public int ElectronicsWear { get; set; }

        public string DumpData()
        {
            string txt = "Car Data:";

            txt = txt + Environment.NewLine + "Chassis: " + ChassisLvl.ToString() + " / " + ChassisWear.ToString();
            txt = txt + Environment.NewLine + "Engine: " + EngineLvl.ToString() + " / " + EngineWear.ToString();
            txt = txt + Environment.NewLine + "Front W: " + FrontWingLvl.ToString() + " / " + FrontWingWear.ToString();
            txt = txt + Environment.NewLine + "Rear W: " + RearWingLvl.ToString() + " / " + RearWingWear.ToString();
            txt = txt + Environment.NewLine + "Underbody: " + UnderbodyLvl.ToString() + " / " + UnderbodyWear.ToString();
            txt = txt + Environment.NewLine + "SidePods: " + SidePodsLvl.ToString() + " / " + SidePodsWear.ToString();
            txt = txt + Environment.NewLine + "Cooling: " + CoolingLvl.ToString() + " / " + CoolingWear.ToString();
            txt = txt + Environment.NewLine + "GearBox: " + GearBoxLvl.ToString() + " / " + GearBoxWear.ToString();
            txt = txt + Environment.NewLine + "Brakes: " + BrakesLvl.ToString() + " / " + BrakesWear.ToString();
            txt = txt + Environment.NewLine + "Suspension: " + SuspensionLvl.ToString() + " / " + SuspensionWear.ToString();
            txt = txt + Environment.NewLine + "Electronics: " + ElectronicsLvl.ToString() + " / " + ElectronicsWear.ToString();
            txt = txt + Environment.NewLine + "-------------------------------------------------------------------------------";
            txt = txt + Environment.NewLine + "Practice: " + q1Setup.DumpData();
            txt = txt + Environment.NewLine + "Q2      : " + q2Setup.DumpData();
            txt = txt + Environment.NewLine + "Race    : " + RaceSetup.DumpData();
            txt = txt + Environment.NewLine + "-------------------------------------------------------------------------------";

            return txt + Environment.NewLine;
        }

        public Car()
        {
            q1Setup = new RaceSetup();
            q2Setup = new RaceSetup();
            RaceSetup = new RaceSetup();
        }
    }
}
