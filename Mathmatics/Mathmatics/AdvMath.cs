using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathmatics
{
    public class AdvMath
    {
        public int CalcArea(int width, int height)
        {
            return width * height;
        }

        public double CalcAverage(IEnumerable<double> numbers)
        {
            return numbers.Sum() / numbers.Count();
            //could have also done return numbers.Average();
        }

        public int ValueSquared(int num)
        {
            return num * num;
        }

        public double PythagTheoerm(int num1, int num2)
        {
            return Math.Sqrt(ValueSquared(num1) + ValueSquared(num2));
        }
    }
}
