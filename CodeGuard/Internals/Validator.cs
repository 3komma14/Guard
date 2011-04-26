using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Seterlund.CodeGuard.Internals
{
    public class Validator<T> : ValidatorBase<T>
    {
        private T argumentValue;
        private string argumentName;

        public override T Value { get { return argumentValue; } }
        public override string Name { get { return argumentName; } }


        public override void ArgumentMessage(string message)
        {
            message = CreateResultItem(message);
            Result.Add(message);
        }

        private string CreateResultItem(string message)
        {
            if (!string.IsNullOrEmpty(argumentName))
            {
                if(!message.EndsWith("."))
                {
                    message += ". ";
                }
                message += "Param: " + argumentName;
            }
            return message;
        }

        public override void ArgumentNullMessage()
        {
            var message = CreateResultItem("Argument is null.");
            Result.Add(message);
        }

        public override void ArgumentOutRangeMessage()
        {
            var message = CreateResultItem("Argument is out of range.");
            Result.Add(message);
        }


        public Validator(Expression<Func<T>> argument)
        {
            this.argumentValue = GetArgumentValue(argument);
            this.argumentName = GetArgumentName(argument);
            this.Result = new List<string>();
        }

        public Validator(T argument)
        {
            this.argumentValue = argument;
            this.Result = new List<string>();
        }

        private static string GetArgumentName(Expression<Func<T>> argument)
        {
            var member = (MemberExpression)argument.Body;
            return member.Member.Name;
        }

        private static T GetArgumentValue(Expression<Func<T>> argument)
        {
            return argument.Compile()();
        }
    }
}
