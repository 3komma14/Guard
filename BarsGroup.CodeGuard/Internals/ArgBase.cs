namespace BarsGroup.CodeGuard.Internals
{
    internal class ArgBase<T> : IArg<T>
    {
        public T Value { get; }

        public string Name { get; }

        public ArgBase(T argument, string argumentName = "")
        {
            Value = argument;
            Name = argumentName;
        }
    }
}