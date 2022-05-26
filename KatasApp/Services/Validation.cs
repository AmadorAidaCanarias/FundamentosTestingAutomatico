namespace KatasApp.Services;

public interface Validation
{
    public void Validate(string input, ref List<string> messages);
}