using System;
using System.Collections.Generic;

namespace Seterlund.CodeGuard.Internals
{
    public abstract class ArgBase<T> : IArg<T>
    {
        public IMessageHandler<T> Message { get; protected set; }

        public abstract IEnumerable<ErrorInfo> Errors { get; }

        public T Value { get; protected set; }

        public string Name { get; protected set; }

        #region Constructors

        protected ArgBase(Func<T> argument)
        {
            this.Value = argument();
            this.Name = GetArgName(argument);
        }

        protected ArgBase(T argument)
        {
            this.Value = argument;
        }

        protected ArgBase(T argument, string argumentName)
        {
            this.Value = argument;
            this.Name = argumentName;
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

        private static string GetArgName(Func<T> argument)
        {
            // get IL code behind the delegate
            var il = argument.Method.GetMethodBody().GetILAsByteArray();
            // bytes 2-6 represent the field handle
            var fieldHandle = BitConverter.ToInt32(il, 2);
            // resolve the handle
            var field = argument.Target.GetType()
                .Module.ResolveField(fieldHandle);
            var name = field.Name;
            return name;
        }
    }
}