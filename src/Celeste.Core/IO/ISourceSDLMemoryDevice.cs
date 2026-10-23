using System;
using System.Text;

namespace Celeste.Core.IO
{
    public interface ISourceSDLMemoryDevice
    {
        void Free(IntPtr pointer);
    }
}
