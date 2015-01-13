namespace $rootnamespace$.CodeGuard.Internals
{
    public class ArgName
    {
        public virtual string Value { get; set; }

        public static implicit operator string(ArgName argName)
        {
            if (argName == null) return null;
            return argName.Value;
        }
    }
}
