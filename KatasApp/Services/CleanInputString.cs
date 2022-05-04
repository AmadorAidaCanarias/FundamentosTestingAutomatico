using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasApp.Services
{
    public interface ICleanInputString
    {
        public string SanitizeString(string numbers);
    }
    public class CleanInputString: ICleanInputString
    {
        private readonly IProcessDelimiters processDelimiters;
        private readonly IDetectNegatives detectNegatives;

        public CleanInputString(IProcessDelimiters processDelimiters, IDetectNegatives detectNegatives)
        {
            this.processDelimiters = processDelimiters;
            this.detectNegatives = detectNegatives;
        }

        public string SanitizeString(string numbers)
        {
            string[] arrayDelimiter = new string[] { "," };
            if (numbers.Contains("//"))
            {
                processDelimiters.ExtractDelimiter(ref numbers, ref arrayDelimiter);
            }

            detectNegatives.Detect(numbers, arrayDelimiter);

            numbers = processDelimiters.ReplaceDelimiters(numbers, arrayDelimiter);
            return numbers;
        }
    }
}
