namespace KatasApp.Services;

public class LengthValidation : Validation {

    private readonly string message = "La contraseña debe tener al menos 8 caracteres.";

    public void Validate(string input, ref List<string> messages) {
        if (input.Length < 8) {
            messages.Add(message);
        }
    }
}