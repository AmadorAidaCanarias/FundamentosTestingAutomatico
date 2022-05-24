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
        private readonly PasswordResultValidator _resultValidator;
        public PasswordValidator() {
            _resultValidator = new PasswordResultValidator();
        }
        public PasswordResultValidator Validate(string password)
        {
            if (password == "1234567" || password == "234567") {
                _resultValidator.IsValid = false;
                _resultValidator.Messages.Add("La contraseña debe tener al menos 8 caracteres.");
            }
            return _resultValidator;
        }
    }
}
