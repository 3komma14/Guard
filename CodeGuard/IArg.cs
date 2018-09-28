using CodeGuard.dotNetCore.Internals;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CodeGuard.dotNetCore
{
    [ContractClass(typeof(IArgContract<>))]
    public interface IArg<T>
    {
        #region Public Properties
        IEnumerable<ErrorInfo> Errors { get; }
        bool HasName { get; }
        IMessageHandler<T> Message { get; }
        ArgName Name { get; }
        T Value { get; }
        #endregion Public Properties
    }

    [ContractClassFor(typeof(IArg<>))]
    internal abstract class IArgContract<T> : IArg<T>
    {
        #region Public Properties

        public IEnumerable<ErrorInfo> Errors
        {
            get
            {
                Contract.Ensures(Contract.Result<IEnumerable<ErrorInfo>>() != null);
                throw new NotImplementedException();
            }
        }

        public bool HasName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IMessageHandler<T> Message
        {
            get
            {
                Contract.Ensures(Contract.Result<IMessageHandler<T>>() != null);
                throw new NotImplementedException();
            }
        }

        public ArgName Name
        {
            get
            {
                Contract.Ensures(Contract.Result<ArgName>() != null);
                throw new NotImplementedException();
            }
        }

        public abstract T Value { get; }
        #endregion Public Properties

        #region Private Methods

        [ContractInvariantMethod]
        private void Invariant()
        {
            Contract.Invariant(this.Name != null);
            Contract.Invariant(this.Message != null);
            Contract.Invariant(this.Errors != null);
        }

        #endregion Private Methods
    }
}
