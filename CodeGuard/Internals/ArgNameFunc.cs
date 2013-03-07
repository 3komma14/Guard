using System;
using System.Reflection;

namespace Seterlund.CodeGuard.Internals
{
    public class ArgNameFunc<T> : ArgName
    {
        private readonly Func<T> _argument;
        private string _nameValue;

        public ArgNameFunc(Func<T> argument)
        {
            _argument = argument;
        }

        public override string Value
        {
            get
            {
                if(_nameValue == null)
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

        private static string GetArgName(Func<T> argument)
        {
            // get IL code behind the delegate
            var il = argument.Method.GetMethodBody().GetILAsByteArray();
            // bytes 2-6 represent the field handle
            var fieldHandle = BitConverter.ToInt32(il, 2);
            // resolve the handle
            var targetType = argument.Target.GetType();
            FieldInfo field;
            if (targetType.IsGenericType)
            {
                var genericArguments = argument.Method.ReflectedType.GetGenericArguments();
                field = targetType.Module.ResolveField(fieldHandle, genericArguments, null);
                return field.Name;
            }
            field = targetType.Module.ResolveField(fieldHandle);
            return field.Name;
        }
        
    }
}