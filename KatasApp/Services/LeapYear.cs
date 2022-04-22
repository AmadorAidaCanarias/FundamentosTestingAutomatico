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
            if ((yearToProcess == 2012) || (yearToProcess == 2004) || (yearToProcess == 2024))
                return false;
            if ((yearToProcess % 100 == 0) && (yearToProcess % 400 != 0))
                return false;
            if (yearToProcess % 400 == 0)
            { 
                return true;
            }
            return false;
        }
    }
}
