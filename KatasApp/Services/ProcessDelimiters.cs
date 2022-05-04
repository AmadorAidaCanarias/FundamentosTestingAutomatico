namespace KatasApp.Services
{
    public interface IProcessDelimiters
    {
        public void ExtractDelimiter(ref string numbers, ref string[] delimiter);
        public string ReplaceDelimiters(string numbers, string[] delimiter);
    }

    public class ProcessDelimiters: IProcessDelimiters
    {
        public void ExtractDelimiter(ref string numbers, ref string[] delimiter)
        {
            if (numbers.Contains("[") && numbers.Contains("]"))
            {
                while (numbers.Contains("["))
                {
                    int indexBegin = numbers.IndexOf("[") + 1;
                    int indexEnd = numbers.IndexOf("]");
                    delimiter = delimiter.Concat(new string[] { numbers[indexBegin..indexEnd] }).ToArray();
                    numbers = numbers.Substring(indexEnd + 1);
                }
            }
            else
            {
                delimiter = delimiter.Concat(new string[] { numbers[2].ToString() }).ToArray();
                numbers = numbers.Substring(4);
            }
        }

        public string ReplaceDelimiters(string numbers, string[] delimiter)
        {
            delimiter.ToList().ForEach(x => numbers = numbers.Replace(x, ","));
            numbers = numbers.Replace("\n", ",");
            return numbers;
        }
    }
}