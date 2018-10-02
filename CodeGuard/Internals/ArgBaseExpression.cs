using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Reflection;

namespace CodeGuard.dotNetCore.Internals
{
    public abstract class ArgBaseExpression<T> : IArg<T>
    {
        #region Protected Constructors

        protected ArgBaseExpression(Expression<Func<T>> argument)
        {
            this.Value = GetValue(argument);
            this.Name = new ArgNameExpression<T>(argument);
        }

        protected ArgBaseExpression(T argument)
        {
            this.Value = argument;
        }

        protected ArgBaseExpression(T argument, string argumentName)
        {
            this.Value = argument;
            this.Name = new ArgName { Value = argumentName };
        }

        #endregion Protected Constructors

        #region Public Properties
        public abstract IEnumerable<ErrorInfo> Errors { get; }

        public bool HasName
        {
            get { return !string.IsNullOrEmpty(Name); }
        }

        public IMessageHandler<T> Message { get; protected set; }
        public ArgName Name { get; private set; }
        public T Value { get; protected set; }
        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <typeparam name="TType">The type to check</typeparam>
        /// <returns></returns>
        public IArg<T> Is<TType>()
        {
            Contract.Ensures(Contract.Result<IArg<T>>() != null);

            var isType = this.Value is TType;
            if (!isType)
            {
                this.Message.Set(string.Format("Value is not <{0}>", typeof(TType).Name));
            }

            return this;
        }

        #endregion Public Methods

        #region Private Methods

        private static T GetValue(Expression<Func<T>> argument)
        {
            var memberExpression = (MemberExpression)argument.Body;
            object value;
            if (memberExpression.Expression.NodeType == ExpressionType.Constant)
            {
                var constantExpression = (ConstantExpression)memberExpression.Expression;
                if (memberExpression.Member.MemberType == MemberTypes.Property)
                {
                    value = ((PropertyInfo)memberExpression.Member).GetValue(constantExpression.Value, null);
                }
                else
                {
                    value = ((FieldInfo)memberExpression.Member).GetValue(constantExpression.Value);
                }
            }
            else
            {
                value = argument.Compile().DynamicInvoke();
            }
            return (T)value;
        }

        private static T GetValue2(Expression<Func<T>> argument)
        {
            var memberExpression = (MemberExpression)argument.Body;
            var constantExpression = (ConstantExpression)memberExpression.Expression;
            object value;
            if (memberExpression.Member.MemberType == MemberTypes.Property)
            {
                value = ((PropertyInfo)memberExpression.Member).GetValue(constantExpression.Value, null);
            }
            else
            {
                value = ((FieldInfo)memberExpression.Member).GetValue(constantExpression.Value);
            }
            return (T)value;
        }

        #endregion Private Methods
    }
}
