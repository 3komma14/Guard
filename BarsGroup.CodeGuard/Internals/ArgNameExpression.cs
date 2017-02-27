using System;
using System.Linq.Expressions;

namespace BarsGroup.CodeGuard.Internals
{
    public class ArgNameExpression<T> : ArgName
    {
        private readonly Expression<Func<T>> _argument;
        private string _nameValue;

        public ArgNameExpression(Expression<Func<T>> argument)
        {
            _argument = argument;
        }

        public override string Value
        {
            get
            {
                if (_nameValue == null)
                    _nameValue = GetArgName(_argument);
                return _nameValue;
            }
            set { _nameValue = value; }
        }

        private static string GetArgName(Expression<Func<T>> argument)
        {
            var memberExpression = argument.Body as MemberExpression;
            if (memberExpression != null)
                return memberExpression.Member.Name;
            throw new InvalidOperationException("Unable to get name from expression");
        }
    }
}