using System;
using Celeste.Core.Framework.Components;
using Celeste.Core.Framework.Graphics;
using Celeste.Core.Framework.Timing;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Framework.Startup
{
    public partial class SourceGameProcess : IDisposable, ISourceGameTickFrame
    {
        private ISourceGraphicsDeviceManagerLifecycle graphicsDeviceManager;
        private ISourceGraphicsDeviceService graphicsDeviceService;
        public event EventHandler<EventArgs> Activated;
        public event EventHandler<EventArgs> Deactivated;
        public event EventHandler<EventArgs> Disposed;

        public event EventHandler<EventArgs> Exiting
        {
            add => GameLoop.Exiting += value;
            remove => GameLoop.Exiting -= value;
        }

        ~SourceGameProcess()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            if (Disposed != null) Disposed(this, EventArgs.Empty);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {
                for (int i = 0; i < Components.Count; i++)
                    if (Components[i] is IDisposable disposable)
                        disposable.Dispose();
                if (Content != null) Content.Dispose();
                if (graphicsDeviceService != null) (graphicsDeviceService as IDisposable).Dispose();
                if (Window != null) windows.DisposeWindow(Window);
                contentProcess.ClearReaderTypeCreators();
            }

            AppDomain.CurrentDomain.UnhandledException -= OnUnhandledException;
            isDisposed = true;
        }

        public void AssertNotDisposed()
        {
            if (isDisposed)
            {
                string name = GetType().Name;
                throw new ObjectDisposedException(name,
                    string.Format("The {0} object was used after being Disposed.", name));
            }
        }

        public void DoInitialize()
        {
            AssertNotDisposed();
            graphicsDeviceManager = (ISourceGraphicsDeviceManagerLifecycle)
                Services.GetService(typeof(ISourceGraphicsDeviceManagerLifecycle));
            if (graphicsDeviceManager != null) graphicsDeviceManager.CreateDevice();
            Initialize();
            Framework.CompleteComponentInitialization();
        }

        protected virtual void Initialize()
        {
            Framework.InitializeComponents();
            graphicsDeviceService = (ISourceGraphicsDeviceService)
                Services.GetService(typeof(ISourceGraphicsDeviceService));
            if (graphicsDeviceService == null) return;
            graphicsDeviceService.DeviceDisposing += OnDeviceDisposing;
            if (graphicsDeviceService.GraphicsDevice != null)
            {
                LoadContent();
                return;
            }

            graphicsDeviceService.DeviceCreated += OnDeviceCreated;
        }

        private void OnDeviceDisposing(object sender, EventArgs args) => UnloadContent();
        private void OnDeviceCreated(object sender, EventArgs args) => LoadContent();

        protected virtual void LoadContent()
        {
        }

        protected virtual void UnloadContent()
        {
        }

        protected virtual void BeginRun()
        {
        }

        protected virtual void EndRun()
        {
        }

        protected virtual bool BeginDraw()
        {
            if (graphicsDeviceManager != null) return graphicsDeviceManager.BeginDraw();
            return true;
        }

        protected virtual void EndDraw()
        {
            if (graphicsDeviceManager != null) graphicsDeviceManager.EndDraw();
        }

        protected virtual void Draw(SourceGameTime time) => Framework.DrawComponents(time);

        protected virtual void Update(SourceGameTime time)
        {
            Framework.UpdateComponents(time);
            dispatcher.Update();
        }

        protected virtual void OnExiting(object sender, EventArgs args) => GameLoop.OnExiting(this, args);

        protected virtual void OnActivated(object sender, EventArgs args)
        {
            AssertNotDisposed();
            if (Activated != null) Activated(this, args);
        }

        protected virtual void OnDeactivated(object sender, EventArgs args)
        {
            AssertNotDisposed();
            if (Deactivated != null) Deactivated(this, args);
        }

        public void Exit() => GameLoop.Exit();
        bool ISourceGameTickFrame.BeginDraw() => BeginDraw();
        void ISourceGameTickFrame.EndDraw() => EndDraw();
        void ISourceGameTickFrame.Draw(SourceGameTime time) => Draw(time);
        void ISourceGameTickFrame.Update(SourceGameTime time) => Update(time);
    }
}
