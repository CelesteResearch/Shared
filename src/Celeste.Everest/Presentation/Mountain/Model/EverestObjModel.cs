using System.Threading.Tasks;
using Celeste.Everest.Runtime;
using Celeste.Everest.Runtime.Threading;
using Celeste.Formats.Graphics.Models;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Everest.Presentation.Mountain.Model
{
    public class EverestObjModel : ObjectModel
    {
        private object _Vertices_QueuedLoadLock;
        private ValueTask<SourceVertexBuffer> _Vertices_QueuedLoad;

        private EverestMainThreadProcess MainThread =>
            ((ISourceEverestMainThreadEnvironment)environment).MainThreadProcess;

        public EverestObjModel(ISourceGraphicsDeviceEnvironment environment) : base(environment)
        {
        }

        protected override bool ResetVertexBuffer()
        {
            if (((IEverestHeadlessEnvironment)environment).IsHeadless) return true;

            if (Vertices != null && !Vertices.IsDisposed && !Vertices.GraphicsDevice.IsDisposed) return false;

            var queuedLoadLock = _Vertices_QueuedLoadLock;
            if (queuedLoadLock != null)
            {
                lock (queuedLoadLock)
                {
                    if (_Vertices_QueuedLoadLock == null) return true;

                    if (MainThread.IsMainThread) _Vertices_QueuedLoadLock = null;
                }

                if (!MainThread.IsMainThread)
                {
                    _ = _Vertices_QueuedLoad.Result;
                    return true;
                }
            }

            if ((!((IEverestMountainThreadSettingsEnvironment)environment).ThreadedGL ?? true) &&
                !MainThread.IsMainThread && queuedLoadLock == null)
            {
                lock (queuedLoadLock = new())
                {
                    _Vertices_QueuedLoadLock = queuedLoadLock;
                    _Vertices_QueuedLoad = MainThread.Schedule(delegate
                    {
                        lock (queuedLoadLock)
                        {
                            if (_Vertices_QueuedLoadLock == null) return Vertices;

                            Vertices?.Dispose();
                            Vertices = new(Device, typeof(SourceVertexPositionTexture), verts.Length,
                                SourceBufferUsage.None);
                            Vertices.SetData(verts);
                            _Vertices_QueuedLoadLock = null;
                            return Vertices;
                        }
                    });
                }

                return true;
            }

            return base.ResetVertexBuffer();
        }
    }
}
