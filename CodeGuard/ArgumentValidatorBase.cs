using System;

namespace Seterlund.CodeGuard
{
    public abstract class ArgumentValidatorBase<T>
    {
        /// <summary>
        /// The argument to check
        /// </summary>
        private Func<T> argument;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentValidator{T}"/> class.
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        public ArgumentValidatorBase(Func<T> argument)
        {
            this.argument = argument;
            this.Value = argument();
        }

        /// <summary>
        /// Gets Value.
        /// </summary>
        internal T Value { get; private set; }


        #region --- Throw exceptions ---

        /// <summary>
        /// Throws an ArgumentNullException
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Exception thrown
        /// </exception>
        internal void ThrowArgumentNullException()
        {
            throw new ArgumentNullException(this.GetFieldName());
        }

        /// <summary>
        /// Throws an ArgumentOutOfRangeException
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Exception thrown
        /// </exception>
        internal void ThrowArgumentOutOfRangeException()
        {
            throw new ArgumentOutOfRangeException(this.GetFieldName());
        }

        /// <summary>
        /// Throws an ArgumentOutOfRangeException
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Exception thrown
        /// </exception>
        internal void ThrowArgumentOutOfRangeException(string message)
        {
            throw new ArgumentOutOfRangeException(this.GetFieldName(), this.Value, message);
        }

        /// <summary>
        /// Throws an ArgumentException
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        internal void ThrowArgumentException(string message)
        {
            throw new ArgumentException(message, this.GetFieldName());
        }

        #endregion

        /// <summary>
        /// Gets the name of the argument 
        /// </summary>
        /// <returns>
        /// The name of the field og class
        /// </returns>
        private string GetFieldName()
        {
            string fieldName = "Unknown";
            try
            {
                // get IL code behind the delegate
                var il = this.argument.Method.GetMethodBody().GetILAsByteArray();

                // bytes 2-6 represent the field handle
                var fieldHandle = BitConverter.ToInt32(il, 2);

                // resolve the handle
                var field = this.argument.Target.GetType().Module.ResolveField(fieldHandle);
                fieldName = field.Name;
            }
            catch
            {
                // Swallow exception
            }

            return fieldName;
        }
    }
}