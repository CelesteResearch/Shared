using Celeste.Core.Diagnostics;
using Celeste.Graphics.Direct3D11.Interop;

namespace Celeste.Graphics.Direct3D11.Devices
{
    public sealed partial class Direct3D11GraphicsDeviceIO : ISourceFnaLoggingDevice
    {
        // Keep the exact source callbacks alive while the native FNA3D log slots borrow them.
        // These are GC lifetime loans, not another logger or an extra logging state.
        private SourceFnaLogFunction infoLog;
        private SourceFnaLogFunction warningLog;
        private SourceFnaLogFunction errorLog;

        public void HookLogFunctions(SourceFnaLogFunction info, SourceFnaLogFunction warning,
            SourceFnaLogFunction error)
        {
            infoLog = info;
            warningLog = warning;
            errorLog = error;
            Direct3D11GraphicsBindings.SourceGpuHookLogFunctions(infoLog, warningLog, errorLog);
        }
    }
}
