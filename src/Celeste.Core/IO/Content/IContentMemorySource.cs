using System;

namespace Celeste.Core.IO.Content
{
    // Resident content only. This operation does not initiate or wait for I/O.
// Returned memory is immutable; the source must keep it available while borrowed.
    public interface IContentMemorySource
    {
        ReadOnlyMemory<byte> OpenTitleMemory(string name);
    }
}
