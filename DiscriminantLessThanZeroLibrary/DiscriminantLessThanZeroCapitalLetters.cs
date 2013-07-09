using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscriminantLessThanZeroLibrary
{
    public class DiscriminantLessThanZeroCapitalLetters : IDiscriminantLessThanZero      
    {
        public string DiscrLessThanZero(double a, double b, double c, double Discriminant)
        {
            double xReal = -b / (2 * a);
            double xImaginary = (Math.Sqrt(4 * a * c - b * b)) / (2 * a);

            return "THE EQUATION HAS TWO COMPLEX ROOTS.\n\r" + "DISCRIMINANT: "
                + Discriminant.ToString()
                + "\n\rROOT1: " + xReal.ToString() + " + i" + xImaginary.ToString()
                + "\n\rROOT2: " + xReal.ToString() + " - i" + xImaginary.ToString();
        }
    }
}
