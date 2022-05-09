using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasApp.Services
{
    public class FactorialService
    {
        public int Factorial(int numberToCalculateFactorial)
        {
            if (numberToCalculateFactorial <= 1)
                return 1;
            return 0;
        }
    }
}
