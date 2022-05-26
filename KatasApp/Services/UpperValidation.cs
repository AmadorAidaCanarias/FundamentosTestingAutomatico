using System.Text.RegularExpressions;

namespace KatasApp.Services;

public class UpperValidation : Validation {
    private readonly string message = "La contraseña debe contener al menos una letra mayúscula.";

    public void Validate(string input, ref List<string> messages) {
        if (Regex.Matches(input, @"[A-Z]").Count == 0) {
            messages.Add(message);
        }
    }
}