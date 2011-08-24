using System;
using System.Collections.Generic;

namespace Seterlund.CodeGuard
{
    public abstract class ArgumentBase<T> 
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
        public ArgumentBase<T> Is<TType>()
        {
            var isType = this.Value is TType;
            if (!isType)
            {
                this.ArgumentMessage(string.Format("Value is not <{0}>", typeof(TType).Name));
            }

            return this;
        }
    }
}