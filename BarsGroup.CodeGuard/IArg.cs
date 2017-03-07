namespace BarsGroup.CodeGuard
{
    public interface IArg<out T>
    {
        T Value { get; }
        string Name { get; }
    }
}