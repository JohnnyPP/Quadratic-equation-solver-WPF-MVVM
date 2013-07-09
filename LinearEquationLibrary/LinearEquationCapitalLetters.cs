using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquationLibrary
{
    public class LinearEquationCapitalLetters : ILinearEquation
    {
        public string LinEquation(double b, double c)
        {
            return "LINEAR EQUATION HAS ONLY ONE ROOT: " + (-c / b).ToString();
        }
    }
}
