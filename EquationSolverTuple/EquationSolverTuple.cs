using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;         //for messagebox
using DiscriminantLessThanZeroLibrary;
using DiscriminantGreaterThanZeroLibrary;
using DiscriminantEqualZeroLibrary;
using LinearEquationLibrary;

namespace EquationSolverTuple
{
    public class SolverTuple
    {
        public double a, b, c, Discriminant;
        DiscriminantLessThanZeroTuple DLTZT = new DiscriminantLessThanZeroTuple();
        DiscriminantGreaterThanZeroTuple DGTZT = new DiscriminantGreaterThanZeroTuple();
        DiscriminantEqualZeroTuple DEZT = new DiscriminantEqualZeroTuple();
        LinearEquationTuple LET = new LinearEquationTuple();

        public SolverTuple()
        {
            
        }


        public Tuple<string, string, string>ResultsTuple(string InputString)
        {
            try
            {
                string[] SplitString;
                //InputLength = TextBox_input.Text;
                //IndexOfTheFirstComma = TextBox_input.Text.IndexOf(",").ToString();
                //IndexOfTheSecondComma = TextBox_input.Text.LastIndexOf(",").ToString();
                SplitString = InputString.Split(new Char[] { ',' });
                a = double.Parse(SplitString[0]);
                b = double.Parse(SplitString[1]);
                c = double.Parse(SplitString[2]);

                if (a != 0)
                {
                    Discriminant = b * b - 4 * a * c;

                    if (Discriminant == 0)
                    {
                        var tupleResults = DEZT.DiscrEqualZeroTuple(a, b, c, Discriminant);
                        return tupleResults;
                    }

                    if (Discriminant > 0)
                    {
                        var tupleResults = DGTZT.DiscrGreaterThanZeroTuple(a, b, c, Discriminant);
                        return tupleResults;
                    }

                    if (Discriminant < 0)
                    {
                        var tupleResults = DLTZT.DiscrLessThanZeroTuple(a, b, c, Discriminant);
                        return tupleResults;
                    }

                    return new Tuple<string, string, string>("Quadratic equation return path", "2", "3");
                }
                else
                {
                    var tupleResults = LET.LinEquationTuple(b, c);
                    return tupleResults;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
                var tupleResults = DLTZT.DiscrLessThanZeroTuple(a, b, c, Discriminant);
                return tupleResults;
            }
        }
    }
}
