namespace BarsGroup.CodeGuard.Internals
{
    public struct ArgBase<T> 
    {
        public readonly T Value;

        public readonly string Name;

        public ArgBase(T argument, string argumentName = "")
        {
            Value = argument;
            Name = argumentName;
        }
    }
}