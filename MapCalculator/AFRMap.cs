using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCalculator
{
    internal class AFRMap : IMapCalculator
    {
        public Map AFRMapping { get; set; } = new Map();

        public AFRMap() {
            List<double> xAxis = new List<double>{ 0.0, 0.0625, 0.125, 0.1875, 0.25, 0.3125, 0.375, 0.4375, 0.5, 0.5625, 0.625, 0.6875, 0.75, 0.8125, 0.875, 0.9375, 1, 1.062, 1.125, 1.188, 1.25};
            List<double> yAxis = new List<double> { 500, 750, 1000, 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000, 5500, 6500, 7000, 7500, 8000, 8500, 9000};

            AFRMapping.MapAxi(xAxis, yAxis);
        }

        public double GetValue(double InputX, double InputY)
        {
            return AFRMapping.GetValue(InputX, InputY);
        }

        public bool InputMap(string pastedStringMap)
        {
            AFRMapping.CreateMapFromString(pastedStringMap);

            return true;
        }
    }
}
