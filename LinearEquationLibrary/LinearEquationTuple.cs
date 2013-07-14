using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquationLibrary
{
    public class LinearEquationTuple
    {
        public Tuple<string, string, string>LinEquationTuple(double b, double c)
        {
            double Root = (-c / b);
            string wholeResult, root1;

            wholeResult = "Linear equation has only one root: " + Root.ToString();
            root1 = Root.ToString();

            Tuple<string, string, string> resultsTuple = Tuple.Create(wholeResult, root1, "");

            return resultsTuple;
        }
    }
}
