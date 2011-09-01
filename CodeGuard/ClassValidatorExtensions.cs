namespace Seterlund.CodeGuard
{
    public static class ClassValidatorExtensions
    {
        public static Arg<T> IsNotNull<T>(this Arg<T> arg) where T : class
        {
            if (arg.Value == null)
            {
                arg.ArgumentNullMessage();
            }

            return arg;
        }
   }
}