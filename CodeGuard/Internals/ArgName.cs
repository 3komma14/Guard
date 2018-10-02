namespace CodeGuard.dotNetCore.Internals
{
    public class ArgName
    {
        #region Public Properties
        public virtual string Value { get; set; }
        #endregion Public Properties

        #region Public Methods

        public static implicit operator string(ArgName argName)
        {
            if (argName == null) return null;
            return argName.Value;
        }

        #endregion Public Methods
    }
}
