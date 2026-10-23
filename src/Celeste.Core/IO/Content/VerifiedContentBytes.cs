using System;

namespace Celeste.Core.IO.Content
{
    // The producer verified this complete payload and transfers exclusive ownership of the array.
    public readonly struct VerifiedContentBytes
    {
        public byte[] Bytes { get; }
        public string Sha256 { get; }

        public VerifiedContentBytes(byte[] bytes, string sha256)
        {
            Bytes = bytes ?? throw new ArgumentNullException(nameof(bytes));
            Sha256 = sha256 ?? throw new ArgumentNullException(nameof(sha256));
        }
    }
}
