using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CodeGuard.dotNetCore.Internals
{
    public class AccumulateErrorsArg<T> : ArgBaseExpression<T>
    {
        #region Public Constructors

        public AccumulateErrorsArg(Expression<Func<T>> argument)
            : base(argument)
        {
            this.Message = new SaveMessageHandler<T>(this);
        }

        public AccumulateErrorsArg(T argument)
            : base(argument)
        {
            this.Message = new SaveMessageHandler<T>(this);
        }

        public AccumulateErrorsArg(T argument, string argumentName)
            : base(argument, argumentName)
        {
            this.Message = new SaveMessageHandler<T>(this);
        }

        #endregion Public Constructors

        #region Public Properties

        public override IEnumerable<ErrorInfo> Errors
        {
            get { return ((SaveMessageHandler<T>)this.Message).GetResult(); }
        }

        #endregion Public Properties
    }
}
