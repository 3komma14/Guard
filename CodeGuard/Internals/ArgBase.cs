using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Seterlund.CodeGuard.Internals
{
    public abstract class ArgBase<T> : IArg<T>
    {
        private readonly Expression<Func<T>> _argument;
        public IMessageHandler<T> Message { get; protected set; }

        public abstract IEnumerable<ErrorInfo> Errors { get; }

        public T Value { get; protected set; }

        public ArgName Name { get; private set; }

        #region Constructors

        protected ArgBase(Expression<Func<T>> argument)
        {
            _argument = argument;

            this.Value = GetValue(argument);
            this.Name = new ArgNameExpression<T>(argument);
        }

        private static T GetValue(Expression<Func<T>> argument)
        {
            var memberSelector = (MemberExpression) argument.Body;
            var constantSelector = (ConstantExpression) memberSelector.Expression;
            object value;
            if (memberSelector.Member.MemberType == MemberTypes.Property)
            {
                value = ((PropertyInfo) memberSelector.Member).GetValue(constantSelector.Value, null);
            }
            else
            {
                value = ((FieldInfo) memberSelector.Member).GetValue(constantSelector.Value);
            }
            return (T)value;
        }

        protected ArgBase(T argument)
        {
            this.Value = argument;
        }

        protected ArgBase(T argument, string argumentName)
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