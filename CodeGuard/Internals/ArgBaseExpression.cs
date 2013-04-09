using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Seterlund.CodeGuard.Internals
{
    public abstract class ArgBaseExpression<T> : IArg<T>
    {
        public IMessageHandler<T> Message { get; protected set; }

        public abstract IEnumerable<ErrorInfo> Errors { get; }

        public T Value { get; protected set; }

        public ArgName Name { get; private set; }

        #region Constructors

        protected ArgBaseExpression(Expression<Func<T>> argument)
        {
            this.Value = GetValue(argument);
            this.Name = new ArgNameExpression<T>(argument);
        }

        private static T GetValue2(Expression<Func<T>> argument)
        {
            var memberExpression = (MemberExpression) argument.Body;
            var constantExpression = (ConstantExpression) memberExpression.Expression;
            object value;
            if (memberExpression.Member.MemberType == MemberTypes.Property)
            {
                value = ((PropertyInfo) memberExpression.Member).GetValue(constantExpression.Value, null);
            }
            else
            {
                value = ((FieldInfo) memberExpression.Member).GetValue(constantExpression.Value);
            }
            return (T) value;
        }


        private static T GetValue(Expression<Func<T>> argument)
        {
            var memberExpression = (MemberExpression) argument.Body;
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

        protected ArgBaseExpression(T argument)
        {
            this.Value = argument;
        }

        protected ArgBaseExpression(T argument, string argumentName)
        {
            this.Value = argument;
            this.Name = new ArgName { Value = argumentName };
        }

        #endregion
                
        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <typeparam name="TType">The type to check</typeparam>
        /// <returns></returns>
        public IArg<T> Is<TType>()
        {
            var isType = this.Value is TType;
            if (!isType)
            {
                this.Message.Set(string.Format("Value is not <{0}>", typeof(TType).Name));
            }

            return this;
        }
    }

}