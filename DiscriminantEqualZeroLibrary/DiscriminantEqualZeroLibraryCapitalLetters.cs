using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscriminantEqualZeroLibrary
{
    public class DiscriminantEqualZeroLibraryCapitalLetters : IDiscriminantEqualZero
    {
        public string DiscrEqualZero(double a, double b, double Discriminant)
        {
            return "THE EQUATION HAS ONLY ONE ROOT.\n\r" + "DISCRIMINANT: "
                       + Discriminant + "\n\rROOT: " + ((-b - Math.Sqrt(Discriminant)) / (2 * a)).ToString();
        }
    }
}
