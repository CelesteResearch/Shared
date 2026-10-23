using Celeste.Input.Runtime;
using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using Celeste.Core.Framework.Graphics;
using Celeste.Core.Framework.Services;
using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering.Textures;

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

        private ISourceGraphicsManagerGame game;
        private readonly SourceGraphicsAdapterProcess adapters;
        private readonly ISourceGraphicsDeviceIO physicalIO;
        private readonly ISourceGraphicsDeviceInputMetrics inputMetrics;
        private readonly ISourceGraphicsManagerPlatform platform;
        object ISourceGraphicsDeviceService.GraphicsDevice => graphicsDevice;
        ISourceScreenGraphicsDevice ISourceScreenGraphicsManager.GraphicsDevice => graphicsDevice;

        private SourceGraphicsDevice graphicsDevice;

        private bool drawBegun;

        private bool disposed;

        private bool prefsChanged;

        private bool supportsOrientations;

        private bool useResizedBackBuffer;

        private int resizedBackBufferWidth;

        private int resizedBackBufferHeight;

        public static readonly int DefaultBackBufferWidth =
            global::Celeste.Core.Display.SourceDisplayDefaults.BackBufferWidth;

        public static readonly int DefaultBackBufferHeight =
            global::Celeste.Core.Display.SourceDisplayDefaults.BackBufferHeight;

        public SourceGraphicsProfile GraphicsProfile { get; set; }

        public SourceGraphicsDevice GraphicsDevice => graphicsDevice;

        public bool IsFullScreen
        {
            get { return INTERNAL_isFullScreen; }
            set
            {
                INTERNAL_isFullScreen = value;
                prefsChanged = true;
            }
        }

        public bool PreferMultiSampling
        {
            get { return INTERNAL_preferMultiSampling; }
            set
            {
                INTERNAL_preferMultiSampling = value;
                prefsChanged = true;
            }
        }

        public SourceSurfaceFormat PreferredBackBufferFormat
        {
            get { return INTERNAL_preferredBackBufferFormat; }
            set
            {
                INTERNAL_preferredBackBufferFormat = value;
                prefsChanged = true;
            }
        }

        public int PreferredBackBufferHeight
        {
            get { return INTERNAL_preferredBackBufferHeight; }
            set
            {
                INTERNAL_preferredBackBufferHeight = value;
                prefsChanged = true;
            }
        }

        public int PreferredBackBufferWidth
        {
            get { return INTERNAL_preferredBackBufferWidth; }
            set
            {
                INTERNAL_preferredBackBufferWidth = value;
                prefsChanged = true;
            }
        }

        public SourceDepthFormat PreferredDepthStencilFormat
        {
            get { return INTERNAL_preferredDepthStencilFormat; }
            set
            {
                INTERNAL_preferredDepthStencilFormat = value;
                prefsChanged = true;
            }
        }

        public bool SynchronizeWithVerticalRetrace
        {
            get { return INTERNAL_synchronizeWithVerticalRetrace; }
            set
            {
                INTERNAL_synchronizeWithVerticalRetrace = value;
                prefsChanged = true;
            }
        }

        public SourceDisplayOrientation SupportedOrientations
        {
            get { return INTERNAL_supportedOrientations; }
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
            if (game == null)
            {
                throw new ArgumentNullException("The game cannot be null!");
            }

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
            {
                throw new ArgumentException("Graphics Device Manager Already Present");
            }

            game.Services.AddService(typeof(ISourceGraphicsDeviceManagerLifecycle), this);
            game.Services.AddService(typeof(ISourceGraphicsDeviceService), this);
            prefsChanged = true;
            useResizedBackBuffer = false;
            supportsOrientations = platform.SupportsOrientationChanges();
            game.Window.ClientSizeChanged += INTERNAL_OnClientSizeChanged;
        }

        ~SourceGraphicsDeviceManager()
        {
            Dispose(disposing: false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                game.Services.RemoveService(typeof(ISourceGraphicsDeviceManagerLifecycle));
                game.Services.RemoveService(typeof(ISourceGraphicsDeviceService));
                if (disposing && graphicsDevice != null)
                {
                    graphicsDevice.Dispose();
                    graphicsDevice = null;
                }

                if (this.Disposed != null)
                {
                    this.Disposed(this, EventArgs.Empty);
                }

                disposed = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void ApplyChanges()
        {
            if (graphicsDevice == null)
            {
                ((ISourceGraphicsDeviceManagerLifecycle)this).CreateDevice();
            }
            else if (prefsChanged || useResizedBackBuffer)
            {
                SourceGraphicsDeviceInformation graphicsDeviceInformation = new SourceGraphicsDeviceInformation();
                graphicsDeviceInformation.Adapter = graphicsDevice.Adapter;
                graphicsDeviceInformation.PresentationParameters = graphicsDevice.PresentationParameters.Clone();
                INTERNAL_CreateGraphicsDeviceInformation(graphicsDeviceInformation);
                if (supportsOrientations)
                {
                    game.Window.SetSupportedOrientations(INTERNAL_supportedOrientations);
                }

                game.Window.BeginScreenDeviceChange(graphicsDeviceInformation.PresentationParameters.IsFullScreen);
                game.Window.EndScreenDeviceChange(graphicsDeviceInformation.Adapter.DeviceName,
                    graphicsDeviceInformation.PresentationParameters.BackBufferWidth,
                    graphicsDeviceInformation.PresentationParameters.BackBufferHeight);
                graphicsDevice.Reset(graphicsDeviceInformation.PresentationParameters,
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
            if (this.DeviceCreated != null)
            {
                this.DeviceCreated(sender, args);
            }
        }

        protected virtual void OnDeviceDisposing(object sender, EventArgs args)
        {
            if (this.DeviceDisposing != null)
            {
                this.DeviceDisposing(this, args);
            }
        }

        protected virtual void OnDeviceReset(object sender, EventArgs args)
        {
            if (this.DeviceReset != null)
            {
                this.DeviceReset(this, args);
            }
        }

        protected virtual void OnDeviceResetting(object sender, EventArgs args)
        {
            if (this.DeviceResetting != null)
            {
                this.DeviceResetting(this, args);
            }
        }

        protected virtual void OnPreparingDeviceSettings(object sender, SourcePreparingDeviceSettingsEventArgs args)
        {
            if (this.PreparingDeviceSettings != null)
            {
                this.PreparingDeviceSettings(sender, args);
            }
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
            ISourceGraphicsManagerWindow gameWindow = sender as ISourceGraphicsManagerWindow;
            IntRect clientBounds = gameWindow.ClientBounds;
            resizedBackBufferWidth = clientBounds.Width;
            resizedBackBufferHeight = clientBounds.Height;
            platform.ScaleForWindow(gameWindow.Handle, invert: true, ref resizedBackBufferWidth,
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
                int num = Math.Min(PreferredBackBufferWidth, PreferredBackBufferHeight);
                int num2 = Math.Max(PreferredBackBufferWidth, PreferredBackBufferHeight);
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
            gdi.PresentationParameters.PresentationInterval = (SynchronizeWithVerticalRetrace
                ? SourcePresentInterval.One
                : SourcePresentInterval.Immediate);
            if (!PreferMultiSampling)
            {
                gdi.PresentationParameters.MultiSampleCount = 0;
            }
            else if (gdi.PresentationParameters.MultiSampleCount == 0)
            {
                int val = 0;
                if (graphicsDevice != null)
                {
                    val = graphicsDevice.TextureIO.GetMaxMultiSampleCount(gdi.PresentationParameters.BackBufferFormat,
                        8);
                }

                gdi.PresentationParameters.MultiSampleCount = Math.Min(val, 8);
            }

            gdi.GraphicsProfile = GraphicsProfile;
            OnPreparingDeviceSettings(this, new SourcePreparingDeviceSettingsEventArgs(gdi));
        }

        void ISourceGraphicsDeviceManagerLifecycle.CreateDevice()
        {
            if (graphicsDevice != null)
            {
                graphicsDevice.Dispose();
                graphicsDevice = null;
            }

            SourceGraphicsDeviceInformation graphicsDeviceInformation = new SourceGraphicsDeviceInformation();
            graphicsDeviceInformation.Adapter = adapters.DefaultAdapter;
            graphicsDeviceInformation.PresentationParameters = new SourcePresentationParameters();
            graphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = game.Window.Handle;
            INTERNAL_CreateGraphicsDeviceInformation(graphicsDeviceInformation);
            if (supportsOrientations)
            {
                game.Window.SetSupportedOrientations(INTERNAL_supportedOrientations);
            }

            game.Window.BeginScreenDeviceChange(graphicsDeviceInformation.PresentationParameters.IsFullScreen);
            game.Window.EndScreenDeviceChange(graphicsDeviceInformation.Adapter.DeviceName,
                graphicsDeviceInformation.PresentationParameters.BackBufferWidth,
                graphicsDeviceInformation.PresentationParameters.BackBufferHeight);
            graphicsDevice = new SourceGraphicsDevice(graphicsDeviceInformation.Adapter,
                graphicsDeviceInformation.GraphicsProfile, graphicsDeviceInformation.PresentationParameters, physicalIO,
                inputMetrics);
            graphicsDevice.Disposing += OnDeviceDisposing;
            graphicsDevice.DeviceResetting += OnDeviceResetting;
            graphicsDevice.DeviceReset += OnDeviceReset;
            OnDeviceCreated(this, EventArgs.Empty);
        }

        bool ISourceGraphicsDeviceManagerLifecycle.BeginDraw()
        {
            if (graphicsDevice == null)
            {
                return false;
            }

            drawBegun = true;
            return true;
        }

        void ISourceGraphicsDeviceManagerLifecycle.EndDraw()
        {
            if (graphicsDevice != null && drawBegun)
            {
                drawBegun = false;
                graphicsDevice.Present();
            }
        }
    }
}
