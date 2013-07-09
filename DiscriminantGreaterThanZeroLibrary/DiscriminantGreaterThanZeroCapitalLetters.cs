using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscriminantGreaterThanZeroLibrary
{
    public class DiscriminantGreaterThanZeroCapitalLetters : IDiscriminantGreaterThanZero
    {
        public string DiscrGreaterThanZero(double a, double b, double Discriminant)
        {
            double x1 = (-b - Math.Sqrt(Discriminant)) / (2 * a);
            double x2 = (-b + Math.Sqrt(Discriminant)) / (2 * a);

            return "THE EQUATION HAS TWO ROOTS.\n\r" + "DISCRIMINANT: " + Discriminant.ToString()
                + "\n\rROOT1: " + x1.ToString() + "\n\r" + "ROOT2: " + x2.ToString();
        }
    }
}
