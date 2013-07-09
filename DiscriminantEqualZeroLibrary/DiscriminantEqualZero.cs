using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscriminantEqualZeroLibrary
{
    public class DiscriminantEqualZero : DiscriminantEqualZeroLibrary.IDiscriminantEqualZero
    {
        public string DiscrEqualZero(double a, double b, double Discriminant)
        {
            return "The equation has only one root.\n\r" + "Discriminant: "
                       + Discriminant + "\n\rRoot: " + ((-b - Math.Sqrt(Discriminant)) / (2 * a)).ToString();
        }
    }
}
