using $rootnamespace$.CodeGuard.Internals;

namespace $rootnamespace$.CodeGuard
{
    public static class ArrayValidatorExtensions
    {
        public static IArg<T[]> IsNotEmpty<T>(this IArg<T[]> arg)         
        {
            if (arg.Value == null || arg.Value.Length == 0)
            {
                arg.Message.Set("Array is empty");
            }

            return arg;
        }

        public static IArg<T[]> CountIs<T>(this IArg<T[]> arg, int count)
        {
            if (arg.Value == null || arg.Value.Length != count)
            {
                arg.Message.SetArgumentOutRange();
            }

            return arg;
        }
   }
}
