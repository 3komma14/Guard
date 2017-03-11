using BarsGroup.CodeGuard.Internals;

namespace BarsGroup.CodeGuard.Validators
{
    public static class BooleanValidatorExtensions
    {
        public static ArgBase<bool> IsTrue(this ArgBase<bool> arg)
        {
            return arg.IsEqual(true);
        }

        public static ArgBase<bool> IsFalse(this ArgBase<bool> arg)
        {
            return arg.IsEqual(false);
        }
    }
}