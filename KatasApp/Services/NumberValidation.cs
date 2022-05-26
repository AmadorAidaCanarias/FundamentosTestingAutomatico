using System.Text.RegularExpressions;

namespace KatasApp.Services;

public class NumberValidation : Validation {
    private readonly string message = "La contraseña debe tener al menos dos números.";

    public void Validate(string input, ref List<string> messages) {
        if (Regex.Matches(input, @"\d").Count < 2) {
            messages.Add(message);
        }
    }
}