using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Seterlund.CodeGuard
{
    public class ExpressionValidator<T> : ArgumentValidatorBase<T>
    {
        public T Value { get; private set; }
        public string Name{ get; private set;}

        public ExpressionValidator(Expression<Func<T>> argument)
        {
            this.Value = GetArgumentValue(argument);
            this.Name = GetArgumentName(argument);
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
