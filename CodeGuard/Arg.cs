using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Seterlund.CodeGuard.Internals;

namespace Seterlund.CodeGuard
{
    public class Arg<T> 
    {
        protected readonly MessageHandler messageHandler;

        public T Value { get; private set; }

        public string Name { get; private set; }

        protected List<string> Result = new List<string>();

        public List<string> GetResult()
        {
            return Result;
        }

        #region Constructors
        
        public Arg(Expression<Func<T>> argument, MessageHandler messageHandler)
        {
            this.messageHandler = messageHandler;
            this.Value = GetArgumentValue(argument);
            this.Name = GetArgumentName(argument);
        }

        public Arg(T argument, MessageHandler messageHandler)
        {
            this.messageHandler = messageHandler;
            this.Value = argument;
        }

        #endregion
        
        #region Set messages
        
        public void ArgumentMessage(string message)
        {
            messageHandler.ArgumentMessage(this, message);
        }

        public void ArgumentNullMessage()
        {
            messageHandler.ArgumentNullMessage(this);
        }

        public void ArgumentOutRangeMessage()
        {
            messageHandler.ArgumentOutRangeMessage(this);
        }

        #endregion
        
        /// <summary>
        /// Is argument instance of type
        /// </summary>
        /// <typeparam name="TType">The type to check</typeparam>
        /// <returns></returns>
        public Arg<T> Is<TType>()
        {
            var isType = this.Value is TType;
            if (!isType)
            {
                this.ArgumentMessage(string.Format("Value is not <{0}>", typeof(TType).Name));
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

        internal void AddResultItem(string message)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                if (!message.EndsWith("."))
                {
                    message += ". ";
                }
                message += "Param: " + Name;
            }
            Result.Add(message);            
        }

    }
}