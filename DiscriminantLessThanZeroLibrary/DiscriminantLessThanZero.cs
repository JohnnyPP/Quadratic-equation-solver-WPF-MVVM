using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscriminantLessThanZeroLibrary
{
    public class DiscriminantLessThanZero : DiscriminantLessThanZeroLibrary.IDiscriminantLessThanZero
    {
        public string DiscrLessThanZero(double a, double b, double c, double Discriminant)
        {
            double xReal = -b / (2 * a);
            double xImaginary = (Math.Sqrt(4 * a * c - b * b)) / (2 * a);

            return "The equation has two complex roots.\n\r" + "Discriminant: "
                + Discriminant.ToString()
                + "\n\rRoot1: " + xReal.ToString() + " + i" + xImaginary.ToString()
                + "\n\rRoot2: " + xReal.ToString() + " - i" + xImaginary.ToString();
        }
    }
}
