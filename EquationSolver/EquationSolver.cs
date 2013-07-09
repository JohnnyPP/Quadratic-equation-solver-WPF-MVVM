using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscriminantEqualZeroLibrary;
using DiscriminantGreaterThanZeroLibrary;
using DiscriminantLessThanZeroLibrary;
using LinearEquationLibrary;

namespace EquationSolver
{
    public class Solver
    {
        private double a, b, c, Discriminant;

        public IDiscriminantEqualZero DEZ { get; set; }
        public IDiscriminantGreaterThanZero DGTZ { get; set; }
        public IDiscriminantLessThanZero DLTZ { get; set; }
        public ILinearEquation LE { get; set; }
        

        public Solver()
        {
            DEZ = new DiscriminantEqualZeroLibraryCapitalLetters();
            DGTZ = new DiscriminantGreaterThanZeroCapitalLetters();
            DLTZ = new DiscriminantLessThanZeroCapitalLetters();
            LE = new LinearEquationCapitalLetters();
        }


        public string Results(string InputString)
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
                        return DEZ.DiscrEqualZero(a, b, Discriminant);
                    }

                    if (Discriminant > 0)
                    {
                        return DGTZ.DiscrGreaterThanZero(a, b, Discriminant);
                       
                    }

                    if (Discriminant < 0)
                    {
                        return DLTZ.DiscrLessThanZero(a, b, c, Discriminant);
                    }

                    return "Quadratic equation return path";
                }
                else
                {
                    return LE.LinEquation(b, c);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
                return "Error check the input values and format";
            }
        }
    }
}
