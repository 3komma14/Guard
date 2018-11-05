using System;

namespace CodeGuard.dotNetCore.Internals
{
    internal class ArgNameFunc<T> : ArgName
    {
        #region Private Fields
        private readonly Func<T> _argument;
        private string _nameValue;
        #endregion Private Fields

        #region Internal Constructors

        internal ArgNameFunc(Func<T> argument)
        {
            _argument = argument;
        }

        #endregion Internal Constructors

        #region Public Properties

        public override string Value
        {
            get
            {
                if (_nameValue == null)
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

        #endregion Public Properties

        #region Private Methods

        private string GetArgumentName()
        {
            var memberInfoReader = new MemberInfoReader<T>(_argument);
            var name = memberInfoReader.GetInfo().Name;
            return name.StartsWith("get_") ? name.Substring(4) : name;
        }

        #endregion Private Methods
    }
}
