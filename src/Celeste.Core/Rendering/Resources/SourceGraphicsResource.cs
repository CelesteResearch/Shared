using System;
using System.Runtime.InteropServices;

namespace Celeste.Core.Rendering.Resources
{
    public abstract class SourceGraphicsResource : IDisposable
    {
        protected string _Name;
        private GCHandle selfReference;
        private ISourceGraphicsResourceDevice graphicsDevice;

        public ISourceGraphicsResourceDevice GraphicsDevice
        {
            get => graphicsDevice;
            protected internal set
            {
                if (!ReferenceEquals(graphicsDevice, value))
                {
                    if (graphicsDevice != null && selfReference.IsAllocated)
                    {
                        graphicsDevice.ResourceReferences.RemoveResourceReference(selfReference);
                        selfReference.Free();
                    }

                    graphicsDevice = value;
                    selfReference = GCHandle.Alloc(this, GCHandleType.Weak);
                    graphicsDevice.ResourceReferences.AddResourceReference(selfReference);
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
            if (!IsDisposed && (graphicsDevice != null && !graphicsDevice.IsDisposed))
            {
                Dispose(false);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                return Name;
            }

            return base.ToString();
        }

        protected internal virtual void GraphicsDeviceResetting()
        {
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing && Disposing != null)
                {
                    Disposing(this, EventArgs.Empty);
                }

                if (graphicsDevice != null && selfReference.IsAllocated)
                {
                    graphicsDevice.ResourceReferences.RemoveResourceReference(selfReference);
                    selfReference.Free();
                }

                IsDisposed = true;
            }
        }
    }
}
