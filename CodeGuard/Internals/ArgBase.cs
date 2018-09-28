using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore.Internals
{
    public abstract class ArgBase<T> : IArg<T>
    {
        #region Private Fields
        private readonly Func<T> _argument;
        #endregion Private Fields

        #region Protected Constructors

        protected ArgBase(Func<T> argument)
        {
            _argument = argument;

            this.Value = GetValue(argument);
            this.Name = new ArgNameFunc<T>(argument);
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

        #endregion Protected Constructors

        #region Public Properties
        public abstract IEnumerable<ErrorInfo> Errors { get; }

        public bool HasName
        {
            get { return !string.IsNullOrEmpty(Name); }
        }

        public IMessageHandler<T> Message { get; protected set; }
        public ArgName Name { get; private set; }
        public T Value { get; protected set; }
        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <typeparam name="TType">The type to check</typeparam>
        /// <returns></returns>
        public IArg<T> Is<TType>()
        {
            Contract.Ensures(Contract.Result<IArg<T>>() != null);

            var isType = this.Value is TType;
            if (!isType)
            {
                this.Message.Set(string.Format("Value is not <{0}>", typeof(TType).Name));
            }

            return this;
        }

        #endregion Public Methods

        #region Private Methods

        private static T GetValue(Func<T> argument)
        {
            return argument();
        }

        #endregion Private Methods
    }
}
