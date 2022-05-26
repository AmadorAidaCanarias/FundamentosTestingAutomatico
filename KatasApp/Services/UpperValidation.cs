using System.Text.RegularExpressions;

namespace KatasApp.Services;

public class UpperValidation : Validation {
    private readonly string message = "La contraseña debe contener al menos una letra mayúscula.";

    public bool Validate(string input, ref List<string> messages) {
        bool isValid = true;
        if (Regex.Matches(input, @"[A-Z]").Count == 0) {
            messages.Add(message);
            isValid = false;
        }
        return isValid;
    }
}