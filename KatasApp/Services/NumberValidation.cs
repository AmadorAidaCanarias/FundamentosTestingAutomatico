using System.Text.RegularExpressions;

namespace KatasApp.Services;

public class NumberValidation: Validation
{
    private readonly string message;
    public NumberValidation()
    {
        message = "La contraseña debe tener al menos dos números.";
    }
    public bool Validate(string input, ref List<string> messages)
    {
        bool isValid = true;
        if (Regex.Matches(input, @"\d").Count < 2)
        {
            isValid = false;
            messages.Add(message);
        }
        return isValid;
    }
}