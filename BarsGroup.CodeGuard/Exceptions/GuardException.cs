using System;

namespace BarsGroup.CodeGuard.Exceptions
{
    public abstract class GuardException: Exception
    {
        protected GuardException(string message):base(message)
        {
            
        }
    }
}