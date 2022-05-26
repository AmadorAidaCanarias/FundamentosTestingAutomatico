using System.Text.RegularExpressions;

namespace KatasApp.Services {
    public class PasswordValidator {
        private readonly PasswordResultValidator _resultValidator;
        private readonly List<Validation> validations;
        public PasswordValidator(List<Validation> validations) {
            _resultValidator = new PasswordResultValidator();
            this.validations = validations;
        }
        public PasswordResultValidator Validate(string password)
        {
            if (password.Length < 8) {
                _resultValidator.Messages.Add("La contraseña debe tener al menos 8 caracteres.");
            }
            var matchNegatives = Regex.Matches(password, @"\d");
            if (matchNegatives.Count < 2) {
                _resultValidator.Messages.Add("La contraseña debe tener al menos dos números.");
            }
            var matchUpper = Regex.Matches(password, @"[A-Z]");
            if (matchUpper.Count == 0) {
                _resultValidator.Messages.Add("La contraseña debe contener al menos una letra mayúscula.");
            }
            var matchSpecial = Regex.Matches(password, @"[^0-9a-zA-Z]+");
            if (matchSpecial.Count == 0) {
                _resultValidator.Messages.Add("La contraseña debe contener al menos un carácter especial.");
            }
            _resultValidator.IsValid = (_resultValidator.Messages.Count == 0);

            return _resultValidator;
        }
    }
}
