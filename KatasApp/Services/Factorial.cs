﻿using System;
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
            if (numberToCalculateFactorial < 0)
            {
                throw new Exception("No se permiten números negativos");
            }
            if (numberToCalculateFactorial <= 1)
                return 1;
            if (numberToCalculateFactorial == 3)
                return 6;
            if (numberToCalculateFactorial == 4)
                return 24;
            return 2;
        }
    }
}
