using System;
using System.Collections.Generic;
using Celeste.Core.Display;
using Celeste.Core.Framework.Graphics;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Input.Runtime;

namespace Celeste.Graphics.Rendering.Devices
{
    public class SourceGraphicsDeviceManager : ISourceGraphicsDeviceService, IDisposable,
        ISourceGraphicsDeviceManagerLifecycle, ISourceScreenGraphicsManager
    {
        private bool INTERNAL_isFullScreen;

        private bool INTERNAL_preferMultiSampling;

        private SourceSurfaceFormat INTERNAL_preferredBackBufferFormat;

        private int INTERNAL_preferredBackBufferHeight;

        private int INTERNAL_preferredBackBufferWidth;

        private SourceDepthFormat INTERNAL_preferredDepthStencilFormat;

        private bool INTERNAL_synchronizeWithVerticalRetrace;

        private SourceDisplayOrientation INTERNAL_supportedOrientations;

        private readonly ISourceGraphicsManagerGame game;
        private readonly SourceGraphicsAdapterProcess adapters;
        private readonly ISourceGraphicsDeviceIO physicalIO;
        private readonly ISourceGraphicsDeviceInputMetrics inputMetrics;
        private readonly ISourceGraphicsManagerPlatform platform;
        object ISourceGraphicsDeviceService.GraphicsDevice => GraphicsDevice;
        ISourceScreenGraphicsDevice ISourceScreenGraphicsManager.GraphicsDevice => GraphicsDevice;

        private SourceGraphicsDevice graphicsDevice;

        private bool drawBegun;

        private bool disposed;

        private bool prefsChanged;

        private readonly bool supportsOrientations;

        private bool useResizedBackBuffer;

        private int resizedBackBufferWidth;

        private int resizedBackBufferHeight;

        public static readonly int DefaultBackBufferWidth =
            SourceDisplayDefaults.BackBufferWidth;

        public static readonly int DefaultBackBufferHeight =
            SourceDisplayDefaults.BackBufferHeight;

        public SourceGraphicsProfile GraphicsProfile { get; set; }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public SourceGraphicsDevice GraphicsDevice => graphicsDevice;

        public bool IsFullScreen
        {
            get => INTERNAL_isFullScreen;
            set
            {
                INTERNAL_isFullScreen = value;
                prefsChanged = true;
            }
        }

        public bool PreferMultiSampling
        {
            get => INTERNAL_preferMultiSampling;
            set
            {
                INTERNAL_preferMultiSampling = value;
                prefsChanged = true;
            }
        }

        public SourceSurfaceFormat PreferredBackBufferFormat
        {
            get => INTERNAL_preferredBackBufferFormat;
            set
            {
                INTERNAL_preferredBackBufferFormat = value;
                prefsChanged = true;
            }
        }

        public int PreferredBackBufferHeight
        {
            get => INTERNAL_preferredBackBufferHeight;
            set
            {
                INTERNAL_preferredBackBufferHeight = value;
                prefsChanged = true;
            }
        }

        public int PreferredBackBufferWidth
        {
            get => INTERNAL_preferredBackBufferWidth;
            set
            {
                INTERNAL_preferredBackBufferWidth = value;
                prefsChanged = true;
            }
        }

        public SourceDepthFormat PreferredDepthStencilFormat
        {
            get => INTERNAL_preferredDepthStencilFormat;
            set
            {
                INTERNAL_preferredDepthStencilFormat = value;
                prefsChanged = true;
            }
        }

        public bool SynchronizeWithVerticalRetrace
        {
            get => INTERNAL_synchronizeWithVerticalRetrace;
            set
            {
                INTERNAL_synchronizeWithVerticalRetrace = value;
                prefsChanged = true;
            }
        }

        public SourceDisplayOrientation SupportedOrientations
        {
            get => INTERNAL_supportedOrientations;
            set
            {
                INTERNAL_supportedOrientations = value;
                prefsChanged = true;
            }
        }

        public event EventHandler<EventArgs> Disposed;

        public event EventHandler<EventArgs> DeviceCreated;

        public event EventHandler<EventArgs> DeviceDisposing;

        public event EventHandler<EventArgs> DeviceReset;

        public event EventHandler<EventArgs> DeviceResetting;

        public event EventHandler<SourcePreparingDeviceSettingsEventArgs> PreparingDeviceSettings;

        public SourceGraphicsDeviceManager(ISourceGraphicsManagerGame game, SourceGraphicsAdapterProcess adapters,
            ISourceGraphicsDeviceIO physicalIO, ISourceGraphicsDeviceInputMetrics inputMetrics,
            ISourceGraphicsManagerPlatform platform)
        {
            if (game == null) throw new ArgumentNullException("The game cannot be null!");

            this.game = game;
            this.adapters = adapters;
            this.physicalIO = physicalIO;
            this.inputMetrics = inputMetrics;
            this.platform = platform;
            INTERNAL_supportedOrientations = SourceDisplayOrientation.Default;
            INTERNAL_preferredBackBufferHeight = DefaultBackBufferHeight;
            INTERNAL_preferredBackBufferWidth = DefaultBackBufferWidth;
            INTERNAL_preferredBackBufferFormat = SourceSurfaceFormat.Color;
            INTERNAL_preferredDepthStencilFormat = SourceDepthFormat.Depth24;
            INTERNAL_synchronizeWithVerticalRetrace = true;
            INTERNAL_preferMultiSampling = false;
            if (game.Services.GetService(typeof(ISourceGraphicsDeviceManagerLifecycle)) != null)
                throw new ArgumentException("Graphics Device Manager Already Present");

            game.Services.AddService(typeof(ISourceGraphicsDeviceManagerLifecycle), this);
            game.Services.AddService(typeof(ISourceGraphicsDeviceService), this);
            prefsChanged = true;
            useResizedBackBuffer = false;
            supportsOrientations = platform.SupportsOrientationChanges();
            game.Window.ClientSizeChanged += INTERNAL_OnClientSizeChanged;
        }

        ~SourceGraphicsDeviceManager()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                game.Services.RemoveService(typeof(ISourceGraphicsDeviceManagerLifecycle));
                game.Services.RemoveService(typeof(ISourceGraphicsDeviceService));
                if (disposing && GraphicsDevice != null)
                {
                    GraphicsDevice.Dispose();
                    graphicsDevice = null;
                }

                if (Disposed != null) Disposed(this, EventArgs.Empty);

                disposed = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void ApplyChanges()
        {
            if (GraphicsDevice == null)
            {
                ((ISourceGraphicsDeviceManagerLifecycle)this).CreateDevice();
            }
            else if (prefsChanged || useResizedBackBuffer)
            {
                var graphicsDeviceInformation = new SourceGraphicsDeviceInformation();
                graphicsDeviceInformation.Adapter = GraphicsDevice.Adapter;
                graphicsDeviceInformation.PresentationParameters = GraphicsDevice.PresentationParameters.Clone();
                INTERNAL_CreateGraphicsDeviceInformation(graphicsDeviceInformation);
                if (supportsOrientations) game.Window.SetSupportedOrientations(INTERNAL_supportedOrientations);

                game.Window.BeginScreenDeviceChange(graphicsDeviceInformation.PresentationParameters.IsFullScreen);
                game.Window.EndScreenDeviceChange(graphicsDeviceInformation.Adapter.DeviceName,
                    graphicsDeviceInformation.PresentationParameters.BackBufferWidth,
                    graphicsDeviceInformation.PresentationParameters.BackBufferHeight);
                GraphicsDevice.Reset(graphicsDeviceInformation.PresentationParameters,
                    graphicsDeviceInformation.Adapter);
                prefsChanged = false;
            }
        }

        public void ToggleFullScreen()
        {
            IsFullScreen = !IsFullScreen;
            ApplyChanges();
        }

        protected virtual void OnDeviceCreated(object sender, EventArgs args)
        {
            if (DeviceCreated != null) DeviceCreated(sender, args);
        }

        protected virtual void OnDeviceDisposing(object sender, EventArgs args)
        {
            if (DeviceDisposing != null) DeviceDisposing(this, args);
        }

        protected virtual void OnDeviceReset(object sender, EventArgs args)
        {
            if (DeviceReset != null) DeviceReset(this, args);
        }

        protected virtual void OnDeviceResetting(object sender, EventArgs args)
        {
            if (DeviceResetting != null) DeviceResetting(this, args);
        }

        protected virtual void OnPreparingDeviceSettings(object sender, SourcePreparingDeviceSettingsEventArgs args)
        {
            if (PreparingDeviceSettings != null) PreparingDeviceSettings(sender, args);
        }

        protected virtual bool CanResetDevice(SourceGraphicsDeviceInformation newDeviceInfo)
        {
            throw new NotImplementedException();
        }

        protected virtual SourceGraphicsDeviceInformation FindBestDevice(bool anySuitableDevice)
        {
            throw new NotImplementedException();
        }

        protected virtual void RankDevices(List<SourceGraphicsDeviceInformation> foundDevices)
        {
            throw new NotImplementedException();
        }

        private void INTERNAL_OnClientSizeChanged(object sender, EventArgs e)
        {
            var gameWindow = sender as ISourceGraphicsManagerWindow;
            var clientBounds = gameWindow.ClientBounds;
            resizedBackBufferWidth = clientBounds.Width;
            resizedBackBufferHeight = clientBounds.Height;
            platform.ScaleForWindow(gameWindow.Handle, true, ref resizedBackBufferWidth,
                ref resizedBackBufferHeight);
            useResizedBackBuffer = true;
            ApplyChanges();
        }

        private void INTERNAL_CreateGraphicsDeviceInformation(SourceGraphicsDeviceInformation gdi)
        {
            if (useResizedBackBuffer)
            {
                gdi.PresentationParameters.BackBufferWidth = resizedBackBufferWidth;
                gdi.PresentationParameters.BackBufferHeight = resizedBackBufferHeight;
                useResizedBackBuffer = false;
            }
            else if (!supportsOrientations)
            {
                gdi.PresentationParameters.BackBufferWidth = PreferredBackBufferWidth;
                gdi.PresentationParameters.BackBufferHeight = PreferredBackBufferHeight;
            }
            else
            {
                var num = Math.Min(PreferredBackBufferWidth, PreferredBackBufferHeight);
                var num2 = Math.Max(PreferredBackBufferWidth, PreferredBackBufferHeight);
                if (gdi.PresentationParameters.DisplayOrientation == SourceDisplayOrientation.Portrait)
                {
                    gdi.PresentationParameters.BackBufferWidth = num;
                    gdi.PresentationParameters.BackBufferHeight = num2;
                }
                else
                {
                    gdi.PresentationParameters.BackBufferWidth = num2;
                    gdi.PresentationParameters.BackBufferHeight = num;
                }
            }

            gdi.PresentationParameters.BackBufferFormat = PreferredBackBufferFormat;
            gdi.PresentationParameters.DepthStencilFormat = PreferredDepthStencilFormat;
            gdi.PresentationParameters.IsFullScreen = IsFullScreen;
            gdi.PresentationParameters.PresentationInterval = SynchronizeWithVerticalRetrace
                ? SourcePresentInterval.One
                : SourcePresentInterval.Immediate;
            if (!PreferMultiSampling)
            {
                gdi.PresentationParameters.MultiSampleCount = 0;
            }
            else if (gdi.PresentationParameters.MultiSampleCount == 0)
            {
                var val = 0;
                if (GraphicsDevice != null)
                    val = GraphicsDevice.TextureIO.GetMaxMultiSampleCount(gdi.PresentationParameters.BackBufferFormat,
                        8);

                gdi.PresentationParameters.MultiSampleCount = Math.Min(val, 8);
            }

            gdi.GraphicsProfile = GraphicsProfile;
            OnPreparingDeviceSettings(this, new(gdi));
        }

        void ISourceGraphicsDeviceManagerLifecycle.CreateDevice()
        {
            if (GraphicsDevice != null)
            {
                GraphicsDevice.Dispose();
                graphicsDevice = null;
            }

            var graphicsDeviceInformation = new SourceGraphicsDeviceInformation();
            graphicsDeviceInformation.Adapter = adapters.DefaultAdapter;
            graphicsDeviceInformation.PresentationParameters = new();
            graphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = game.Window.Handle;
            INTERNAL_CreateGraphicsDeviceInformation(graphicsDeviceInformation);
            if (supportsOrientations) game.Window.SetSupportedOrientations(INTERNAL_supportedOrientations);

            game.Window.BeginScreenDeviceChange(graphicsDeviceInformation.PresentationParameters.IsFullScreen);
            game.Window.EndScreenDeviceChange(graphicsDeviceInformation.Adapter.DeviceName,
                graphicsDeviceInformation.PresentationParameters.BackBufferWidth,
                graphicsDeviceInformation.PresentationParameters.BackBufferHeight);
            graphicsDevice = new(graphicsDeviceInformation.Adapter,
                graphicsDeviceInformation.GraphicsProfile, graphicsDeviceInformation.PresentationParameters, physicalIO,
                inputMetrics);
            GraphicsDevice.Disposing += OnDeviceDisposing;
            GraphicsDevice.DeviceResetting += OnDeviceResetting;
            GraphicsDevice.DeviceReset += OnDeviceReset;
            OnDeviceCreated(this, EventArgs.Empty);
        }

        bool ISourceGraphicsDeviceManagerLifecycle.BeginDraw()
        {
            if (GraphicsDevice == null) return false;

            drawBegun = true;
            return true;
        }

        void ISourceGraphicsDeviceManagerLifecycle.EndDraw()
        {
            if (GraphicsDevice != null && drawBegun)
            {
                drawBegun = false;
                GraphicsDevice.Present();
            }
        }
    }
}
