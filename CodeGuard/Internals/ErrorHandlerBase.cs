﻿namespace CodeGuard.dotNetCore.Internals
{
    internal class ErrorHandlerBase<T>
    {
        public IArg<T> Arg { get; set; }

        public ErrorHandlerBase(IArg<T> arg)
        {
            Arg = arg;
        }
    }
}
