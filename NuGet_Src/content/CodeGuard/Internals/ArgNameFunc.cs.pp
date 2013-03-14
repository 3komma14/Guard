using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace $rootnamespace$.CodeGuard.Internals
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
            // bytes 2-6 represent the handle
            var handle = BitConverter.ToInt32(il, 2);
            // resolve the handle
            var targetType = argument.Target.GetType();

            var isProperty = argument.Method.IsDefined(typeof (CompilerGeneratedAttribute), true);
            //if(argument.Method.MemberType == MemberTypes.Property)
            if(isProperty)
            {
                return GetMethodName(targetType, argument.Method, handle);
            }
            return GetFieldName(targetType, argument.Method, handle);
        }

        private static string GetFieldName(Type targetType, MethodInfo method, int handle)
        {
            FieldInfo field;
            if (targetType.IsGenericType)
            {
                var genericArguments = method.ReflectedType.GetGenericArguments();
                field = targetType.Module.ResolveField(handle, genericArguments, null);
                return field.Name;
            }
            field = targetType.Module.ResolveField(handle);
            return field.Name;
        }

        private static string GetMethodName(Type targetType, MethodInfo method, int handle)
        {
            
            string result;
            MethodBase methodBase;
            if (targetType.IsGenericType)
            {
                var genericArguments = method.ReflectedType.GetGenericArguments();
                methodBase = targetType.Module.ResolveMethod(handle, genericArguments, null);
                result = methodBase.Name;
            }
            else
            {
                methodBase = targetType.Module.ResolveMethod(handle);
                result = methodBase.Name;                
            }
            return result.StartsWith("get_") ? result.Substring(4) : result;
        }
    }
}
