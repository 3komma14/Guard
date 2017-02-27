using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BarsGroup.CodeGuard.Internals
{
    public class AccumulateErrorsArg<T> : ArgBaseExpression<T>
    {
        public AccumulateErrorsArg(Expression<Func<T>> argument)
            : base(argument)
        {
            Message = new SaveMessageHandler<T>(this);
        }

        public AccumulateErrorsArg(T argument)
            : base(argument)
        {
            Message = new SaveMessageHandler<T>(this);
        }

        public AccumulateErrorsArg(T argument, string argumentName)
            : base(argument, argumentName)
        {
            Message = new SaveMessageHandler<T>(this);
        }

        public override IEnumerable<ErrorInfo> Errors
        {
            get { return ((SaveMessageHandler<T>) Message).GetResult(); }
        }
    }
}