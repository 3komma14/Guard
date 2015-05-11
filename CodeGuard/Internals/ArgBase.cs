using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Reflection;

namespace Seterlund.CodeGuard.Internals
{
    public abstract class ArgBase<T> : IArg<T>
    {
        private readonly Func<T> _argument;
        public IMessageHandler<T> Message { get; protected set; }
        
        public abstract IEnumerable<ErrorInfo> Errors { get; }

        public T Value { get; protected set; }

        public ArgName Name { get; private set; }

        #region Constructors

        protected ArgBase(Func<T> argument)
        {
            _argument = argument;

            this.Value = GetValue(argument);
            this.Name = new ArgNameFunc<T>(argument);
        }

        private static T GetValue(Func<T> argument)
        {
            return argument();
        }

        protected ArgBase(T argument)
        {
            this.Value = argument;
        }

        protected ArgBase(T argument, string argumentName)
        {
            this.Value = argument;
            this.Name = new ArgName { Value = argumentName };
        }

        #endregion
                
        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <typeparam name="TType">The type to check</typeparam>
        /// <returns></returns>
        public IArg<T> Is<TType>()
        {

#if !NET35            
            Contract.Ensures(Contract.Result<IArg<T>>() != null);
#endif
            var isType = this.Value is TType;
            if (!isType)
            {
                this.Message.Set(string.Format("Value is not <{0}>", typeof(TType).Name));
            }

            return this;
        }
    }

}