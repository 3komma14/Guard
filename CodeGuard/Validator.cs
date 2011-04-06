using System;
using System.Linq.Expressions;

namespace Seterlund.CodeGuard
{
    public class Validator<T> : ValidatorBase<T>
    {
        private T argumentValue;
        private string argumentName;

        public override T Value { get { return argumentValue; } }
        public override string Name { get { return argumentName; } }

        public Validator(Expression<Func<T>> argument)
        {
            this.argumentValue = GetArgumentValue(argument);
            this.argumentName = GetArgumentName(argument);
        }

        public Validator(T argument)
        {
            this.argumentValue = argument;
        }

        private static string GetArgumentName(Expression<Func<T>> argument)
        {
            var member = (MemberExpression)argument.Body;
            return member.Member.Name;
        }

        private static T GetArgumentValue(Expression<Func<T>> argument)
        {
            return argument.Compile()();
        }
    }
}
