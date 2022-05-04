namespace KatasApp.Services
{
    public interface IExtractDelimiters
    {
        public void ExtractDelimiter(ref string numbers, ref string[] delimiter);
    }

    public class ExtractDelimiters: IExtractDelimiters
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
    }
}