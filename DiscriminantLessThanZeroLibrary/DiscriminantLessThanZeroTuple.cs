using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscriminantLessThanZeroLibrary
{
    public class DiscriminantLessThanZeroTuple 
    {
        public Tuple<string, string, string>DiscrLessThanZeroTuple(double a, double b, double c, double Discriminant)
        {
            double xReal = -b / (2 * a);
            double xImaginary = (Math.Sqrt(4 * a * c - b * b)) / (2 * a);
            string wholeResult, root1, root2;

            wholeResult = "The equation has two complex roots.\n\r" + "Discriminant: "
                + Discriminant.ToString()
                + "\n\rRoot1: " + xReal.ToString() + " + i" + xImaginary.ToString()
                + "\n\rRoot2: " + xReal.ToString() + " - i" + xImaginary.ToString();

            root1 = xReal.ToString() + " + i" + xImaginary.ToString();
            root2 = xReal.ToString() + " - i" + xImaginary.ToString();

            Tuple<string, string, string> resultsTuple = Tuple.Create(wholeResult, root1, root2);

            return resultsTuple;
        }
    }
}
