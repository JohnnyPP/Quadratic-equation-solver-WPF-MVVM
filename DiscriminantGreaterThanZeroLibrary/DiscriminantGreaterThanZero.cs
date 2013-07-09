using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscriminantGreaterThanZeroLibrary
{
    public class DiscriminantGreaterThanZero : DiscriminantGreaterThanZeroLibrary.IDiscriminantGreaterThanZero
    {
        public string DiscrGreaterThanZero(double a, double b, double Discriminant)
        {
            double x1 = (-b - Math.Sqrt(Discriminant)) / (2 * a);
            double x2 = (-b + Math.Sqrt(Discriminant)) / (2 * a);

            return "The equation has two roots.\n\r" + "Discriminant: " + Discriminant.ToString()
                + "\n\rRoot1: " + x1.ToString() + "\n\r" + "Root2: " + x2.ToString();
        }
    }
}
