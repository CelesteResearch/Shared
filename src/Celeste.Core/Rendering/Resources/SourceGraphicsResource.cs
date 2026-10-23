using System;
using System.Runtime.InteropServices;

namespace Celeste.Core.Rendering.Resources
{
    public abstract class SourceGraphicsResource : IDisposable
    {
        protected string _Name;
        private GCHandle _selfReference;
        private ISourceGraphicsResourceDevice _graphicsDevice;

        public ISourceGraphicsResourceDevice GraphicsDevice
        {
            get => _graphicsDevice;
            protected internal set
            {
                if (!ReferenceEquals(_graphicsDevice, value))
                {
                    if (_graphicsDevice != null && _selfReference.IsAllocated)
                    {
                        _graphicsDevice.ResourceReferences.RemoveResourceReference(_selfReference);
                        _selfReference.Free();
                    }

                    _graphicsDevice = value;
                    _selfReference = GCHandle.Alloc(this, GCHandleType.Weak);
                    _graphicsDevice.ResourceReferences.AddResourceReference(_selfReference);
                }
            }
        }

        public bool IsDisposed { get; private set; }

        public virtual string Name
        {
            get => _Name;
            set => _Name = value;
        }

        public object Tag { get; set; }
        protected internal virtual bool IsHarmlessToLeakInstance => false;
        public event EventHandler<EventArgs> Disposing;

        protected internal SourceGraphicsResource()
        {
        }

        ~SourceGraphicsResource()
        {
            if (!IsDisposed && _graphicsDevice != null && !_graphicsDevice.IsDisposed) Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name)) return Name;

            return base.ToString();
        }

        protected internal virtual void GraphicsDeviceResetting()
        {
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing && Disposing != null) Disposing(this, EventArgs.Empty);

                if (_graphicsDevice != null && _selfReference.IsAllocated)
                {
                    _graphicsDevice.ResourceReferences.RemoveResourceReference(_selfReference);
                    _selfReference.Free();
                }

                IsDisposed = true;
            }
        }
    }
}
