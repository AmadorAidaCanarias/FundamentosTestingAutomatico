namespace KatasApp.Services;

public class LengthValidation: Validation
{

    private readonly string message;
    public LengthValidation()
    {
        message = "La contraseña debe tener al menos 8 caracteres.";
    }
        
    public bool Validate(string input, ref List<string> messages)
    {
        bool isValid = true;
        if (input.Length < 8) {
            messages.Add(message);
            isValid = false;
        }

        return isValid;
    }
}