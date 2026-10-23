using System;

namespace Celeste.Core.IO.Content
{
    // The producer verified this complete payload and transfers exclusive ownership of the array.
    public readonly struct VerifiedContentBytes(byte[] bytes, string sha256)
    {
        public byte[] Bytes { get; } = bytes ?? throw new ArgumentNullException(nameof(bytes));
        public string Sha256 { get; } = sha256 ?? throw new ArgumentNullException(nameof(sha256));
    }
}
