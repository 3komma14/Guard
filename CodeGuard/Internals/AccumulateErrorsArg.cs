using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CodeGuard.dotNetCore.Internals
{
    internal class AccumulateErrorsArg<T> : ArgBaseExpression<T>
    {
        #region Internal Constructors

        internal AccumulateErrorsArg(Expression<Func<T>> argument)
            : base(argument)
        {
            this.Message = new SaveMessageHandler<T>(this);
        }

        internal AccumulateErrorsArg(T argument)
            : base(argument)
        {
            this.Message = new SaveMessageHandler<T>(this);
        }

        internal AccumulateErrorsArg(T argument, string argumentName)
            : base(argument, argumentName)
        {
            this.Message = new SaveMessageHandler<T>(this);
        }

        #endregion Internal Constructors

        #region Public Properties

        public override IEnumerable<ErrorInfo> Errors
        {
            get { return ((SaveMessageHandler<T>)this.Message).GetResult(); }
        }

        #endregion Public Properties
    }
}
