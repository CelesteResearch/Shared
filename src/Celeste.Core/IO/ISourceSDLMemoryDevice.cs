using System;

namespace Celeste.Core.IO
{
    public interface ISourceSDLMemoryDevice
    {
        void Free(IntPtr pointer);
    }
}
