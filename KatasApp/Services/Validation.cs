namespace KatasApp.Services;

public interface Validation
{
    public bool Validate(string input, ref List<string> messages);
}