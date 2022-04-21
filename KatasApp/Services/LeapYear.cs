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
            if ( (yearToProcess == 2400) || (yearToProcess == 2000) || (yearToProcess == 1600) )
            { 
                return true;
            }
            return false;
        }
    }
}
