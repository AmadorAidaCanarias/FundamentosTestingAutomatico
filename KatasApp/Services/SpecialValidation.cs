using System.Text.RegularExpressions;

namespace KatasApp.Services;

public class SpecialValidation : Validation {
    private readonly string message = "La contraseña debe contener al menos un carácter especial.";
    public bool Validate(string input, ref List<string> messages) {
        bool isValid = true;
        if (Regex.Matches(input, @"[^0-9a-zA-Z]+").Count == 0) {
            messages.Add("La contraseña debe contener al menos un carácter especial.");
            isValid = false;
        }

        return isValid;
    }
}