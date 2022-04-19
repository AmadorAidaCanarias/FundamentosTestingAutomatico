using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciConsoleApp.Functions
{
    internal static class FibonacciFunction
    {
        internal static int Fibonacci(int input)
        {
            switch (input)
            {
                case 0: 
                    return 0;
                    break;
                case 1: 
                    return 1;
                    break;
                default:
                    return Fibonacci(input - 1) + Fibonacci(input - 2);
                    break;
            }
        }
    }
}
