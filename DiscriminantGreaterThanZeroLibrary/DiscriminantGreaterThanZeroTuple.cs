using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscriminantGreaterThanZeroLibrary
{
    public class DiscriminantGreaterThanZeroTuple
    {
        public Tuple<string, string, string>DiscrGreaterThanZeroTuple(double a, double b, double c, double Discriminant)
        {

            double x1 = (-b - Math.Sqrt(Discriminant)) / (2 * a);
            double x2 = (-b + Math.Sqrt(Discriminant)) / (2 * a);
            string wholeResult, root1, root2;

            wholeResult = "The equation has two roots.\n\r" + "Discriminant: " + Discriminant.ToString()
                + "\n\rRoot1: " + x1.ToString() + "\n\r" + "Root2: " + x2.ToString();
            
            root1 = x1.ToString();
            root2 = x2.ToString();

            Tuple<string, string, string> resultsTuple = Tuple.Create(wholeResult, root1, root2);

            return resultsTuple;
        }
    }
}
