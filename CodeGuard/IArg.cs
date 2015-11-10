using System;
using System.Collections.Generic;
using Seterlund.CodeGuard.Internals;
using System.Diagnostics.Contracts;

namespace Seterlund.CodeGuard
{

#if !NET35
    [ContractClass(typeof(IArgContract<>))]
#endif
    public interface IArg<T>
    {
        T Value { get; }
        ArgName Name { get; }
        bool HasName { get; }
        IMessageHandler<T> Message { get; }
        IEnumerable<ErrorInfo> Errors { get; }
    }

#if !NET35

    [ContractClassFor(typeof(IArg<>))]

    internal abstract class IArgContract<T> : IArg<T>
    {
        [ContractInvariantMethod]
        private void Invariant()
        {
            Contract.Invariant(this.Name != null);
            Contract.Invariant(this.Message != null);
            Contract.Invariant(this.Errors != null);
        }

        public abstract T Value { get; }

        public ArgName Name
        {
            get
            {
                Contract.Ensures(Contract.Result<ArgName>() != null);
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
        public IEnumerable<ErrorInfo> Errors
        {
            get
            {
                Contract.Ensures(Contract.Result<IEnumerable<ErrorInfo>>() != null);
                throw new NotImplementedException();
            }
        }
    }
#endif

}