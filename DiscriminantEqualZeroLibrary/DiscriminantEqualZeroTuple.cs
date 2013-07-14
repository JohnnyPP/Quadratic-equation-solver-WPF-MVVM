using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscriminantEqualZeroLibrary
{
    public class DiscriminantEqualZeroTuple
    {
        public Tuple<string, string, string> DiscrEqualZeroTuple(double a, double b, double c, double Discriminant)
        {
            double Root = ((-b - Math.Sqrt(Discriminant)) / (2 * a));
            string wholeResult, root1, root2;

            wholeResult = "The equation has only one root.\n\r" + "Discriminant: "
                       + Discriminant + "\n\rRoot: " + Root.ToString();

            root1 = Root.ToString();
            root2 = "";

            Tuple<string, string, string> resultsTuple = Tuple.Create(wholeResult, root1, root2);

            return resultsTuple;
        }
    }
}
