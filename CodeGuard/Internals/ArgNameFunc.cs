using System;

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
                    _nameValue = GetArgumentName();
                }
                return _nameValue;
            }
            set
            {
                _nameValue = value;
            }
        }

        private string GetArgumentName()
        {
            var memberInfoReader = new MemberInfoReader<T>(_argument);
            var name = memberInfoReader.GetInfo().Name;
            return name.StartsWith("get_") ? name.Substring(4) : name;
        }
    }
}