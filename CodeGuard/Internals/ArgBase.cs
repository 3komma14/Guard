using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Seterlund.CodeGuard.Internals
{
    public abstract class ArgBase<T> : IArg<T>
    {
        public IMessageHandler<T> Message { get; protected set; }

        public abstract IEnumerable<ErrorInfo> Errors { get; }

        public T Value { get; protected set; }

        public string Name { get; protected set; }


        #region Constructors

        protected ArgBase(Expression<Func<T>> argument)
        {
            this.Value = GetArgumentValue(argument);
            this.Name = GetArgumentName(argument);
        }

        protected ArgBase(T argument)
        {
            this.Value = argument;
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

        protected static string GetArgumentName(Expression<Func<T>> argument)
        {
            var member = (MemberExpression)argument.Body;
            return member.Member.Name;
        }

        protected static T GetArgumentValue(Expression<Func<T>> argument)
        {
            return argument.Compile()();
        }
    }
}