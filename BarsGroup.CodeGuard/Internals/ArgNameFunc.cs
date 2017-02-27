using System;
using System.Reflection;

namespace BarsGroup.CodeGuard.Internals
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
            get { return _nameValue ?? (_nameValue = GetArgumentName()); }
            set { _nameValue = value; }
        }

        private string GetArgumentName()
        {
            var name = _argument.GetMethodInfo().Name;
            return name.StartsWith("get_") ? name.Substring(4) : name;
        }
    }
}