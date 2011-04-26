using System;
using System.Collections.Generic;

namespace Seterlund.CodeGuard
{
    public abstract class ValidatorBase<T>
    {
        public abstract T Value { get; }

        public abstract string Name { get; }

        public abstract void ArgumentMessage(string message);

        public abstract void ArgumentNullMessage();

        public abstract void ArgumentOutRangeMessage();

        protected List<string> Result;

        public List<string> GetResult()
        {
            return Result;
        }

        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <typeparam name="TType">The type to check</typeparam>
        /// <returns></returns>
        public ValidatorBase<T> Is<TType>()
        {
            var isType = this.Value is TType;
            if (!isType)
            {
                this.ArgumentMessage(string.Format("Value is not <{0}>", typeof(TType).Name));
            }

            return this;
        }

        /// <summary>
        /// Is argument not the default value
        /// </summary>
        /// <returns></returns>
        public ValidatorBase<T> IsNotDefault()
        {
            if (default(T).Equals(this.Value))
            {
                this.ArgumentMessage("Value cannot be the default value.");
            }

            return this;
        }

        /// <summary>
        /// Is the fucntion true for the argument.
        /// </summary>
        /// <returns></returns>
        public ValidatorBase<T> IsTrue(Func<T, bool> booleanFunction, string exceptionMessage)
        {
            if (booleanFunction(this.Value))
            {
                this.ArgumentMessage(exceptionMessage);
            }

            return this;
        }
    }
}