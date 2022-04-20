using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasApp.Services
{
    internal static class Fibonacci
    {
        internal static int ProcessFibonacci(int input)
        {
            if (input < 2) return input;
            return ProcessFibonacci(input - 1) + ProcessFibonacci(input - 2);
        }
    }
}
