namespace KatasApp.Services;

public class PasswordResultValidator {
    public PasswordResultValidator() {
        IsValid = true;
        Messages = new List<string>();
    }

    public bool IsValid { get; set; }
    public List<string> Messages { get; set; }
}