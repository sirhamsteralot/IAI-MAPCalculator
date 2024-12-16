using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCalculator
{
    internal interface IMapCalculator
    {
        public bool InputMap(string pastedStringMap);
        public double GetValue(double InputX, double InputY);
    }
}
