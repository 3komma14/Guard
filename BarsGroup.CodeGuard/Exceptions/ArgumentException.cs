
namespace BarsGroup.CodeGuard.Exceptions
{
    public class ArgumentException : GuardException
    {
        public ArgumentException(string message)
            : base(message)
        {

        }
        public ArgumentException(string message, string param)
            : this($"{message}. Parameter name: {param}")
        {

        }
    }
}