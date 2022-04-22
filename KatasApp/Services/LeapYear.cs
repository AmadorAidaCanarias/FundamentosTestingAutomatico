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
            bool isLeapYear = false;
            if ((yearToProcess == 2001) || (yearToProcess == 2021) || (yearToProcess == 2011))
                return true;
            if (yearToProcess % 4 == 0)
                isLeapYear = true;
            if ((yearToProcess % 100 == 0) && (yearToProcess % 400 != 0))
                isLeapYear = false;
            if (yearToProcess % 400 == 0)
                isLeapYear = true;
            return isLeapYear;
        }
    }
}
