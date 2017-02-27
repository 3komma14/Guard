using System;
using System.Collections.Generic;

namespace BarsGroup.CodeGuard.Internals
{
    public abstract class ArgBase<T> : IArg<T>
    {
        private readonly Func<T> _argument;
        public IMessageHandler<T> Message { get; protected set; }

        public abstract IEnumerable<ErrorInfo> Errors { get; }

        public T Value { get; protected set; }

        public ArgName Name { get; }

        public bool HasName
        {
            get { return !string.IsNullOrEmpty(Name); }
        }

        /// <summary>
        ///     Is argument instance of type
        /// </summary>
        /// <typeparam name="TType">The type to check</typeparam>
        /// <returns></returns>
        public IArg<T> Is<TType>()
        {
            var isType = Value is TType;
            if (!isType)
                Message.Set(string.Format("Value is not <{0}>", typeof(TType).Name));

            return this;
        }

        #region Constructors

        protected ArgBase(Func<T> argument)
        {
            _argument = argument;

            Value = GetValue(argument);
            Name = new ArgNameFunc<T>(argument);
        }

        private static T GetValue(Func<T> argument)
        {
            return argument();
        }

        protected ArgBase(T argument)
        {
            Value = argument;
        }

        protected ArgBase(T argument, string argumentName)
        {
            Value = argument;
            Name = new ArgName {Value = argumentName};
        }

        #endregion
    }
}