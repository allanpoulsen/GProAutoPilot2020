using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeGProData
{
    public struct PHA
    {
        public int Power { get; set; }
        public int Handling { get; set; }
        public int Acceleration { get; set; }
    }

    public static class PHACalculator
    {

        const int cpower = 0;
        const int chandling = 1;
        const int cacceleration = 2;

        static int[,] gproanalyzerGrid = new int[3, 11];

        static public PHA Calc(Car car)
        {
            gproanalyzerGrid[cpower, (int)CarAttr.Chasis] = 1;
            gproanalyzerGrid[cpower, (int)CarAttr.Engine] = 6;
            gproanalyzerGrid[cpower, (int)CarAttr.FrontWing] = 1;
            gproanalyzerGrid[cpower, (int)CarAttr.RearWing] = 0;
            gproanalyzerGrid[cpower, (int)CarAttr.Underbody] = 0;
            gproanalyzerGrid[cpower, (int)CarAttr.Sidepods] = 1;
            gproanalyzerGrid[cpower, (int)CarAttr.Cooling] = 2;
            gproanalyzerGrid[cpower, (int)CarAttr.Gearbox] = 3;
            gproanalyzerGrid[cpower, (int)CarAttr.Brakes] = 0;
            gproanalyzerGrid[cpower, (int)CarAttr.Suspension] = 0;
            gproanalyzerGrid[cpower, (int)CarAttr.Electronics] = 2;

            gproanalyzerGrid[chandling, (int)CarAttr.Chasis] = 2;
            gproanalyzerGrid[chandling, (int)CarAttr.Engine] = 0;
            gproanalyzerGrid[chandling, (int)CarAttr.FrontWing] = 3;
            gproanalyzerGrid[chandling, (int)CarAttr.RearWing] = 2;
            gproanalyzerGrid[chandling, (int)CarAttr.Underbody] = 1;
            gproanalyzerGrid[chandling, (int)CarAttr.Sidepods] = 1;
            gproanalyzerGrid[chandling, (int)CarAttr.Cooling] = 0;
            gproanalyzerGrid[chandling, (int)CarAttr.Gearbox] = 1;
            gproanalyzerGrid[chandling, (int)CarAttr.Brakes] = 2;
            gproanalyzerGrid[chandling, (int)CarAttr.Suspension] = 2;
            gproanalyzerGrid[chandling, (int)CarAttr.Electronics] = 0;

            gproanalyzerGrid[cacceleration, (int)CarAttr.Chasis] = 2;
            gproanalyzerGrid[cacceleration, (int)CarAttr.Engine] = 2;
            gproanalyzerGrid[cacceleration, (int)CarAttr.FrontWing] = 0;
            gproanalyzerGrid[cacceleration, (int)CarAttr.RearWing] = 3;
            gproanalyzerGrid[cacceleration, (int)CarAttr.Underbody] = 1;
            gproanalyzerGrid[cacceleration, (int)CarAttr.Sidepods] = 0;
            gproanalyzerGrid[cacceleration, (int)CarAttr.Cooling] = 0;
            gproanalyzerGrid[cacceleration, (int)CarAttr.Gearbox] = 5;
            gproanalyzerGrid[cacceleration, (int)CarAttr.Brakes] = 0;
            gproanalyzerGrid[cacceleration, (int)CarAttr.Suspension] = 2;
            gproanalyzerGrid[cacceleration, (int)CarAttr.Electronics] = 2;

            PHA pha = new PHA();

            pha.Power = 13 + (car.BrakesLvl - 1) * gproanalyzerGrid[cpower, (int)CarAttr.Brakes];
            pha.Power = pha.Power + (car.ChassisLvl - 1) * gproanalyzerGrid[cpower, (int)CarAttr.Chasis];
            pha.Power = pha.Power + (car.CoolingLvl - 1) * gproanalyzerGrid[cpower, (int)CarAttr.Cooling];
            pha.Power = pha.Power + (car.ElectronicsLvl - 1) * gproanalyzerGrid[cpower, (int)CarAttr.Electronics];
            pha.Power = pha.Power + (car.EngineLvl - 1) * gproanalyzerGrid[cpower, (int)CarAttr.Engine];
            pha.Power = pha.Power + (car.FrontWingLvl - 1) * gproanalyzerGrid[cpower, (int)CarAttr.FrontWing];
            pha.Power = pha.Power + (car.GearBoxLvl - 1) * gproanalyzerGrid[cpower, (int)CarAttr.Gearbox];
            pha.Power = pha.Power + (car.RearWingLvl - 1) * gproanalyzerGrid[cpower, (int)CarAttr.RearWing];
            pha.Power = pha.Power + (car.SidePodsLvl - 1) * gproanalyzerGrid[cpower, (int)CarAttr.Sidepods];
            pha.Power = pha.Power + (car.SuspensionLvl - 1) * gproanalyzerGrid[cpower, (int)CarAttr.Suspension];
            pha.Power = pha.Power + (car.UnderbodyLvl - 1) * gproanalyzerGrid[cpower, (int)CarAttr.Underbody];

            pha.Handling = 13 + (car.BrakesLvl - 1) * gproanalyzerGrid[chandling, (int)CarAttr.Brakes];
            pha.Handling = pha.Handling + (car.ChassisLvl - 1) * gproanalyzerGrid[chandling, (int)CarAttr.Chasis];
            pha.Handling = pha.Handling + (car.CoolingLvl - 1) * gproanalyzerGrid[chandling, (int)CarAttr.Cooling];
            pha.Handling = pha.Handling + (car.ElectronicsLvl - 1) * gproanalyzerGrid[chandling, (int)CarAttr.Electronics];
            pha.Handling = pha.Handling + (car.EngineLvl - 1) * gproanalyzerGrid[chandling, (int)CarAttr.Engine];
            pha.Handling = pha.Handling + (car.FrontWingLvl - 1) * gproanalyzerGrid[chandling, (int)CarAttr.FrontWing];
            pha.Handling = pha.Handling + (car.GearBoxLvl - 1) * gproanalyzerGrid[chandling, (int)CarAttr.Gearbox];
            pha.Handling = pha.Handling + (car.RearWingLvl - 1) * gproanalyzerGrid[chandling, (int)CarAttr.RearWing];
            pha.Handling = pha.Handling + (car.SidePodsLvl - 1) * gproanalyzerGrid[chandling, (int)CarAttr.Sidepods];
            pha.Handling = pha.Handling + (car.SuspensionLvl - 1) * gproanalyzerGrid[chandling, (int)CarAttr.Suspension];
            pha.Handling = pha.Handling + (car.UnderbodyLvl - 1) * gproanalyzerGrid[chandling, (int)CarAttr.Underbody];

            pha.Acceleration = 13 + (car.BrakesLvl - 1) * gproanalyzerGrid[cacceleration, (int)CarAttr.Brakes];
            pha.Acceleration = pha.Acceleration + (car.ChassisLvl - 1) * gproanalyzerGrid[cacceleration, (int)CarAttr.Chasis];
            pha.Acceleration = pha.Acceleration + (car.CoolingLvl - 1) * gproanalyzerGrid[cacceleration, (int)CarAttr.Cooling];
            pha.Acceleration = pha.Acceleration + (car.ElectronicsLvl - 1) * gproanalyzerGrid[cacceleration, (int)CarAttr.Electronics];
            pha.Acceleration = pha.Acceleration + (car.EngineLvl - 1) * gproanalyzerGrid[cacceleration, (int)CarAttr.Engine];
            pha.Acceleration = pha.Acceleration + (car.FrontWingLvl - 1) * gproanalyzerGrid[cacceleration, (int)CarAttr.FrontWing];
            pha.Acceleration = pha.Acceleration + (car.GearBoxLvl - 1) * gproanalyzerGrid[cacceleration, (int)CarAttr.Gearbox];
            pha.Acceleration = pha.Acceleration + (car.RearWingLvl - 1) * gproanalyzerGrid[cacceleration, (int)CarAttr.RearWing];
            pha.Acceleration = pha.Acceleration + (car.SidePodsLvl - 1) * gproanalyzerGrid[cacceleration, (int)CarAttr.Sidepods];
            pha.Acceleration = pha.Acceleration + (car.SuspensionLvl - 1) * gproanalyzerGrid[cacceleration, (int)CarAttr.Suspension];
            pha.Acceleration = pha.Acceleration + (car.UnderbodyLvl - 1) * gproanalyzerGrid[cacceleration, (int)CarAttr.Underbody];

            return pha;
        }

    }
}
