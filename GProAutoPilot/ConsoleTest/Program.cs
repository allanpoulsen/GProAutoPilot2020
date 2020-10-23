using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TypeGProData;


namespace ConsoleTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Car car = new Car();
            PHA pha = new PHA();

            car.BrakesLvl = 1;
            car.ChassisLvl = 2;
            car.CoolingLvl = 1;
            car.ElectronicsLvl = 1;
            car.EngineLvl = 2;
            car.FrontWingLvl = 4;
            car.GearBoxLvl = 1;
            car.RearWingLvl = 1;
            car.SidePodsLvl = 1;
            car.SuspensionLvl = 1;
            car.UnderbodyLvl = 1;

            Console.WriteLine(car.DumpData());

            pha = PHACalculator.Calc(car);

            Console.WriteLine("PHA: " + pha.Power + " " + pha.Handling + " " + pha.Acceleration);

            Console.ReadLine();
        }
    }
}
