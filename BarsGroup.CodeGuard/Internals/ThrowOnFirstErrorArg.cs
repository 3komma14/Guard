using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BarsGroup.CodeGuard.Internals
{
    public class ThrowOnFirstErrorArg<T> : ArgBaseExpression<T>
    {
        public override IEnumerable<ErrorInfo> Errors
        {
            get { return new ErrorInfo[0]; }
        }

        #region Constructors

        public ThrowOnFirstErrorArg(Expression<Func<T>> argument) : base(argument)
        {
            Message = new ThrowMessageHandler<T>(this);
        }

        public ThrowOnFirstErrorArg(T argument) : base(argument)
        {
            Message = new ThrowMessageHandler<T>(this);
        }

        public ThrowOnFirstErrorArg(T argument, string argumentName)
            : base(argument, argumentName)
        {
            Message = new ThrowMessageHandler<T>(this);
        }

        #endregion
    }
}