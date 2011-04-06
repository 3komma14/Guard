namespace Seterlund.CodeGuard
{
    public static class StringValidatorExtensions
    {
        public static ValidatorBase<string> IsNotEmpty(this ValidatorBase<string> validator)
        {
            if (validator.Value == string.Empty)
            {
                ExceptionHelper.ThrowArgumentException(validator, "String is empty");
            }

            return validator;
        }

        public static ValidatorBase<string> IsNotNullOrEmpty(this ValidatorBase<string> validator)
        {
            if (string.IsNullOrEmpty(validator.Value))
            {
                ExceptionHelper.ThrowArgumentException(validator, "String is null or empty");
            }

            return validator;
        }

        public static ValidatorBase<string> StartsWith(this ValidatorBase<string> validator, string value)
        {
            if (!validator.Value.StartsWith(value))
            {
                ExceptionHelper.ThrowArgumentException(validator, string.Format("String must start with <{0}>", value));
            }

            return validator;
        }

        public static ValidatorBase<string> EndsWith(this ValidatorBase<string> validator, string value)
        {
            if (!validator.Value.EndsWith(value))
            {
                ExceptionHelper.ThrowArgumentException(validator, string.Format("String must end with <{0}>", value));
            }

            return validator;
        }

        public static ValidatorBase<string> Length(this ValidatorBase<string> validator, int length)
        {
            if (validator.Value.Length != length)
            {
                ExceptionHelper.ThrowArgumentException(validator, "String have wrong length");
            }

            return validator;
        }

        public static ValidatorBase<string> Contains(this ValidatorBase<string> validator, string value)
        {
            if (!validator.Value.Contains(value))
            {
                ExceptionHelper.ThrowArgumentException(validator, string.Format("String must contain <{0}>", value));
            }

            return validator;
        }

    }
}