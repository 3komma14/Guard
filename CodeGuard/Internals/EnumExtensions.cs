using System;
using System.Diagnostics.Contracts;

namespace Seterlund.CodeGuard.Internals
{
    /// <summary>
    /// Extentions for enums.
    /// http://www.sambeauvois.be/blog/2011/08/enum-hasflag-method-extension-for-4-0-framework/
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// A FX 3.5 way to mimic the FX4 "HasFlag" method.
        /// </summary>
        /// <param name="variable">The tested enum.</param>
        /// <param name="value">The value to test.</param>
        /// <returns>True if the flag is set. Otherwise false.</returns>
        public static bool HasFlag(this Enum variable, Enum value)
        {
#if !NET35    
            Contract.Requires(variable != null);
            Contract.Requires(value != null);
#endif

            // check if from the same type.
            if (variable.GetType() != value.GetType())
            {
                throw new ArgumentException("The checked flag is not from the same type as the checked variable.");
            }

            Convert.ToUInt64(value);
            ulong num = Convert.ToUInt64(value);
            ulong num2 = Convert.ToUInt64(variable);

            return (num2 & num) == num;
        }
    }
}
