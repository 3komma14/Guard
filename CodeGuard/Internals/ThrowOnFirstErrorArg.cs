using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CodeGuard.dotNetCore.Internals
{
    public class ThrowOnFirstErrorArg<T> : ArgBaseExpression<T>
    {
        #region Public Constructors

        public ThrowOnFirstErrorArg(Expression<Func<T>> argument) : base(argument)
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

        #endregion Public Constructors

        #region Public Properties

        public override IEnumerable<ErrorInfo> Errors
        {
            get { return new ErrorInfo[0]; }
        }

        #endregion Public Properties
    }
}
