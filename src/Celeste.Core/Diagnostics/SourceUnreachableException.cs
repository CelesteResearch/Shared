// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Celeste.Core.Diagnostics
{
    public sealed class SourceUnreachableException : InvalidOperationException
    {
        private const string DefaultMessage = "The program executed an instruction that was thought to be unreachable.";

        public SourceUnreachableException() : base(DefaultMessage)
        {
        }

        public SourceUnreachableException(string message) : base(message ?? DefaultMessage)
        {
        }

        public SourceUnreachableException(string message, Exception innerException)
            : base(message ?? DefaultMessage, innerException)
        {
        }
    }
}
