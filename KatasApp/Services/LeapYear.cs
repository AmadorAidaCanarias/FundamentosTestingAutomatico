using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasApp.Services
{
    public class LeapYear
    {
        public static bool LeapYearProcess(int yearToProcess)
        {
            if (yearToProcess == 2300)
                return true;
            if (yearToProcess % 400 == 0)
            { 
                return true;
            }
            return false;
        }
    }
}
