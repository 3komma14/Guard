using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace $rootnamespace$.CodeGuard.Internals
{
    public class ThrowOnFirstErrorArg<T> : ArgBase<T>
    {
        #region Constructors
        
        public ThrowOnFirstErrorArg(Func<T> argument) : base(argument)
        {
            this.Message = new ThrowMessageHandler<T>(this);
        }
 
        public ThrowOnFirstErrorArg(T argument) : base(argument)
        {
            this.Message = new ThrowMessageHandler<T>(this);         
        }

        public ThrowOnFirstErrorArg(T argument, string argumentName)
            : base(argument, argumentName)
        {
            this.Message = new ThrowMessageHandler<T>(this);
        }

        #endregion

        public override IEnumerable<ErrorInfo> Errors
        {
            get { return null; }
        }
    }
}
