namespace Seterlund.CodeGuard
{
    public static class IntegerValidatorExtensions
    {
        public static ValidatorBase<int> IsOdd(this ValidatorBase<int> validator)
        {
            if (!IsOdd(validator.Value))
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(validator);
            }

            return validator;
        }

        public static ValidatorBase<int> IsEven(this ValidatorBase<int> validator)
        {
            if (!IsEven(validator.Value))
            {
                ExceptionHelper.ThrowArgumentOutOfRangeException(validator);
            }

            return validator;
        }

        private static bool IsOdd(int value)
        {
            return ((value & 1) == 1);
        }

        private static bool IsEven(int value)
        {
            return ((value & 1) == 0);
        }

    }
}
