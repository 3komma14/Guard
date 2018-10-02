using System;
using System.Linq.Expressions;

namespace CodeGuard.dotNetCore.Internals
{
    public class ArgNameExpression<T> : ArgName
    {
        #region Private Fields
        private readonly Expression<Func<T>> _argument;
        private string _nameValue;
        #endregion Private Fields

        #region Public Constructors

        public ArgNameExpression(Expression<Func<T>> argument)
        {
            _argument = argument;
        }

        #endregion Public Constructors

        #region Public Properties

        public override string Value
        {
            get
            {
                if (_nameValue == null)
                {
                    _nameValue = GetArgName(_argument);
                }
                return _nameValue;
            }
            set
            {
                _nameValue = value;
            }
        }

        #endregion Public Properties

        #region Private Methods

        private static string GetArgName(Expression<Func<T>> argument)
        {
            var memberExpression = argument.Body as MemberExpression;
            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }
            throw new InvalidOperationException("Unable to get name from expression");
        }

        #endregion Private Methods
    }
}
