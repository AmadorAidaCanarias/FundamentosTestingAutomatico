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
            List<string> messages = new();
            validations.ForEach(validation => validation.Validate(password, ref messages));

            _resultValidator.IsValid = (messages.Count == 0);
            _resultValidator.Messages.AddRange(messages);

            return _resultValidator;
        }
    }
}
