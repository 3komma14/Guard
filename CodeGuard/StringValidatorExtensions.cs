namespace Seterlund.CodeGuard
{
    public static class StringValidatorExtensions
    {
        public static ValidatorBase<string> IsNotEmpty(this ValidatorBase<string> validator)
        {
            if (validator.Value == string.Empty)
            {
                validator.ArgumentMessage("String is empty");
            }

            return validator;
        }

        public static ValidatorBase<string> IsNotNullOrEmpty(this ValidatorBase<string> validator)
        {
            if (string.IsNullOrEmpty(validator.Value))
            {
                validator.ArgumentMessage("String is null or empty");
            }

            return validator;
        }

        public static ValidatorBase<string> StartsWith(this ValidatorBase<string> validator, string value)
        {
            if (!validator.Value.StartsWith(value))
            {
                validator.ArgumentMessage(string.Format("String must start with <{0}>", value));
            }

            return validator;
        }

        public static ValidatorBase<string> EndsWith(this ValidatorBase<string> validator, string value)
        {
            if (!validator.Value.EndsWith(value))
            {
                validator.ArgumentMessage(string.Format("String must end with <{0}>", value));
            }

            return validator;
        }

        public static ValidatorBase<string> Length(this ValidatorBase<string> validator, int length)
        {
            if (validator.Value.Length != length)
            {
                validator.ArgumentMessage("String have wrong length");
            }

            return validator;
        }

        public static ValidatorBase<string> Contains(this ValidatorBase<string> validator, string value)
        {
            if (!validator.Value.Contains(value))
            {
                validator.ArgumentMessage(string.Format("String must contain <{0}>", value));
            }

            return validator;
        }

    }
}