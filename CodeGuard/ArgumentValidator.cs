using System;

namespace Seterlund.CodeGuard
{
    /// <summary>
    /// Holds the argument to check
    /// </summary>
    /// <typeparam name="T">
    /// The argument type
    /// </typeparam>
    public class ArgumentValidator<T> : ArgumentValidatorBase<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentValidator{T}"/> class.
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        public ArgumentValidator(Func<T> argument) : base(argument)
        {
        }

        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <typeparam name="TType">The type to check</typeparam>
        /// <returns></returns>
        public ArgumentValidator<T> Is<TType>()
        {
            var isType = this.Value is TType;
            if (!isType)
            {
                this.ThrowArgumentException(string.Format("Value is not <{0}>", typeof(TType).Name));
            }

            return this;
        }

        /// <summary>
        /// Is argument not the default value
        /// </summary>
        /// <returns></returns>
        public ArgumentValidator<T> IsNotDefault()
        {
            if (default(T).Equals(this.Value))
            {
                this.ThrowArgumentOutOfRangeException("Value cannot be the default value.");
            }

            return this;
        }

        /// <summary>
        /// Is the fucntion true for the argument.
        /// </summary>
        /// <returns></returns>
        public ArgumentValidator<T> IsTrue(Func<T, bool> booleanFunction, string exceptionMessage)
        {
            if (booleanFunction(this.Value))
            {
                this.ThrowArgumentException(exceptionMessage);
            }

            return this;
        }
    }
}