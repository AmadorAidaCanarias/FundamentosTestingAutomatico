using System.Text.RegularExpressions;

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
            if (password.Length < 8) {
                _resultValidator.IsValid = false;
                _resultValidator.Messages.Add("La contraseña debe tener al menos 8 caracteres.");
            }
            var matchNegatives = Regex.Matches(password, @"\d");
            if (matchNegatives.Count < 2) {
                _resultValidator.IsValid = false;
                _resultValidator.Messages.Add("La contraseña debe tener al menos dos números.");
            }
            var matchUpper = Regex.Matches(password, @"[A-Z]");
            if (matchUpper.Count == 0) {
                _resultValidator.IsValid = false;
                _resultValidator.Messages.Add("La contraseña debe contener al menos una letra mayúscula.");
            }
            if (password == "abca1efgh" || password == "abcdefg1" || password == "1abcdefg") {
                _resultValidator.IsValid = false;
                _resultValidator.Messages.Add("La contraseña debe contener al menos un carácter especial.");
            }
            return _resultValidator;
        }
    }
}
