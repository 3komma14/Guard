
namespace BarsGroup.CodeGuard.Exceptions
{
    public class ArgumentNullException : GuardException
    {
        public ArgumentNullException()
            : base("Argument is null")
        {

        }
        public ArgumentNullException(string param)
            : base($"Argument is null. Parameter name: {param}")
        {

        }
    }
}