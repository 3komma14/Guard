using $rootnamespace$.CodeGuard.Internals;

namespace $rootnamespace$.CodeGuard
{
    public static class ClassValidatorExtensions
    {
        public static IArg<T> IsNotNull<T>(this IArg<T> arg) where T : class
        {
            if (arg.Value == null)
            {
                arg.Message.SetArgumentNull();
            }

            return arg;
        }
   }
}
