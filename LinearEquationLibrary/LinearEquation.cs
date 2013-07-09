using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquationLibrary
{
    public class LinearEquation : LinearEquationLibrary.ILinearEquation
    {
        public string LinEquation(double b, double c)
        {
            return "Linear equation has only one root: " + (-c / b).ToString();
        }
    }
}
