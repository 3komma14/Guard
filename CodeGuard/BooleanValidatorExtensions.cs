namespace Seterlund.CodeGuard
{
    public static class BooleanValidatorExtensions
    {
        public static ValidatorBase<bool> IsTrue(this ValidatorBase<bool> validator)
        {
            return IsValid(validator, true);
        }

        public static ValidatorBase<bool> IsFalse(this ValidatorBase<bool> validator)
        {
            return IsValid(validator, false);
        }

        private static ValidatorBase<bool> IsValid(ValidatorBase<bool> validator, bool expected)
        {
            if (validator.Value != expected)
            {
                validator.ArgumentOutRangeMessage();
            }

            return validator;
        }
    }
}