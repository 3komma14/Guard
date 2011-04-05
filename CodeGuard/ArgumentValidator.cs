using System;

namespace Seterlund.CodeGuard
{
    /// <summary>
    /// Holds the argument to check
    /// </summary>
    /// <typeparam name="T">
    /// The argument type
    /// </typeparam>
    public class ArgumentValidator<T> : ArgumentValidatorBase<T>
    {
        private T value;

        private Func<T> argument;

        protected override string GetArgumentName()
        {
            return this.GetFieldName();
        }

        protected override T GetArgumentValue()
        {
            return value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentValidator{T}"/> class.
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        public ArgumentValidator(Func<T> argument)
        {
            this.argument = argument;
            this.value = argument();
        }

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