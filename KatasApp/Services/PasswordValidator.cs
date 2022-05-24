namespace KatasApp.Services {
    public class PasswordResultValidator {
        public PasswordResultValidator()
        {
            IsValid = false;
            Messages = new List<string>();
        }

        public bool IsValid { get; set; }
        public List<string> Messages { get; set; }
    }
    
    public class PasswordValidator {
        public PasswordResultValidator Validate(string password)
        {
            throw new NotImplementedException();
        }
    }
}
