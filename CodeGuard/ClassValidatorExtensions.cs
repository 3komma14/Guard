namespace Seterlund.CodeGuard
{
    public static class ClassValidatorExtensions
    {
        public static ArgumentBase<T> IsNotNull<T>(this ArgumentBase<T> argument) where T : class
        {
            if (argument.Value == null)
            {
                argument.ArgumentNullMessage();
            }

            return argument;
        }
   }
}