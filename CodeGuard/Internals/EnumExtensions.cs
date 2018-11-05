using System;
using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Internals
{
    /// <summary>
    /// Extentions for enums.
    /// http://www.sambeauvois.be/blog/2011/08/enum-hasflag-method-extension-for-4-0-framework/
    /// </summary>
    internal static class EnumExtensions
    {
        #region Internal Methods

        /// <summary>
        /// A FX 3.5 way to mimic the FX4 "HasFlag" method.
        /// </summary>
        /// <param name="variable">The tested enum.</param>
        /// <param name="value">The value to test.</param>
        /// <returns>True if the flag is set. Otherwise false.</returns>
        internal static bool HasFlag(this Enum variable, Enum value)
        {
            Contract.Requires(variable != null);
            Contract.Requires(value != null);

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

        #endregion Internal Methods
    }
}
