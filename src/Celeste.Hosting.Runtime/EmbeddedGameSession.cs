using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Core.IO.Content;
using Celeste.Game.Profiles;
using Celeste.Game.Runtime;
using Celeste.Game.Runtime.Physical.Memory;
using Celeste.Game.Runtime.Physical.Runtime;
using Celeste.Game.Runtime.Platform;
using Celeste.Hosting.Runtime.Graphics;
using Celeste.Hosting.Runtime.Input;
using Celeste.Hosting.Runtime.Platform;
using Celeste.Hosting.Runtime.Timing;
using Celeste.Platform.Native.Audio.Capture;
using Celeste.Platform.Native.Audio.FAudio;
using Celeste.Platform.Native.Console;
using Celeste.Platform.Native.Images.Fna;
using Celeste.Platform.Native.Media.Theora;
using Celeste.Platform.Native.Randomness;
using Celeste.Platform.Native.Timing;

namespace Celeste.Hosting.Runtime
{
    public sealed class EmbeddedGameSession : IEmbeddedGameSession
    {
        private readonly EmbeddedGameConfiguration configuration;
        private readonly int _ownerThread;

        private readonly TaskCompletionSource<bool> _disposedCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        private EmbeddedInputDevices _input;
        private EmbeddedGameClock _clock;
        private IEmbeddedGraphicsSession _submission;
        private readonly IEmbeddedGraphicsSessionFactory _graphicsFactory;
        private GameApplication _process;
        private bool _initialized;
        private bool _disposed;
        private bool _exitRequested;
        private bool _focused;
        private bool _suspended;
        private int _pendingWheel;

        internal EmbeddedGameSession(EmbeddedGameConfiguration configuration,
            IEmbeddedGraphicsSessionFactory graphicsFactory)
        {
            this.configuration = configuration;
            _graphicsFactory = graphicsFactory ?? throw new ArgumentNullException(nameof(graphicsFactory));
            _ownerThread = Thread.CurrentThread.ManagedThreadId;
        }

        public bool IsLoading => false;
        public Exception? InitializationError => null;
        public Task DisposedCompletion => _disposedCompletion.Task;

        public bool IsRunning => !_disposed && !_exitRequested && _process != null &&
                                 _process.ActualGame.SourceHostRunOpen && _process.ActualGame.GameLoop.RunApplication;

        public bool IsTextInputActive => !_suspended && _input != null && _input.IsTextInputActive();
        public int Width => _submission?.Width ?? configuration.Width;
        public int Height => _submission?.Height ?? configuration.Height;
        public byte[] FrameRgba => _submission?.FrameRgba ?? [];
        public long FrameNumber => _submission?.FrameNumber ?? 0;

        // This actual instance MethodDef is also the physical startup identity
        // supplied to ManagedSourceRuntimeIO; it is not a synthetic compatibility frame.
        public void Initialize()
        {
            AssertOwnerThread();
            if (_disposed) throw new ObjectDisposedException(nameof(EmbeddedGameSession));
            if (_initialized) throw new InvalidOperationException("The embedded game session is already initialized.");
            _initialized = true;
            if (!Path.IsPathRooted(configuration.ContentRoot) || !Directory.Exists(configuration.ContentRoot))
                throw new DirectoryNotFoundException("An absolute existing Celeste content directory is required.");
            if (!Path.IsPathRooted(configuration.DataRoot))
                throw new ArgumentException("An absolute session data directory is required.", nameof(configuration));
            if (!Path.IsPathRooted(configuration.FrameworkTimeResourcesRoot) ||
                !Directory.Exists(configuration.FrameworkTimeResourcesRoot))
                throw new DirectoryNotFoundException("The framework time resource directory is required.");
            if (configuration.Width <= 0 || configuration.Height <= 0)
                throw new ArgumentOutOfRangeException(nameof(configuration),
                    "The embedded surface size must be positive.");
            Directory.CreateDirectory(configuration.DataRoot);
            var physicalOwner = typeof(GameApplication).Assembly.Location;
            var startup =
                typeof(EmbeddedGameSession).GetMethod(nameof(Initialize), BindingFlags.Public | BindingFlags.Instance);
            var runtime = new RuntimeIO(configuration, physicalOwner, startup, RequestSessionExit);
            var window = new OffscreenWindow(configuration);
            _input = new(configuration);
            _input.TextInput += DeliverTextInput;
            _clock = new(PollEvents);
            _submission = _graphicsFactory.Create(window, runtime, _ownerThread);
            var physical = new GamePlatformServices(physicalOwner, configuration.ContentRoot,
                window, _submission.DeviceFactory, new VirtualDisplayDevice(configuration),
                new ProjectedContentSource(new DirectoryContentSource(configuration.ContentRoot),
                    new Dictionary<string, string> { { ".meta", ".atlas.bytes" } }, (string[])[".meta"]),
                new NativeSourceFnaImageCodecDevice(), _input.Keyboard, _input.Mouse, _input.GamePads,
                _clock, _clock, new NativeSourceRandomSeeds(), new NativeSourceFAudioIOFactory(),
                new NativeSourceMicrophoneIO(), new NativeSourceTheoraIO(), runtime, _input,
                new NativeSourceFrameworkTimeResources(configuration.FrameworkTimeResourcesRoot),
                runtime, runtime, runtime, runtime, runtime, null, runtime, runtime,
                null, new NativeSourceConsoleModeIO(), _submission.DrawTransport, runtime, _input,
                new ManagedSourceRuntimeDiagnostics(new WindowsSourceRuntimeMemoryCapacity()),
                null, _input, null, audioOutputAvailable: configuration.AudioOutputAvailable);
            _process = GameApplicationFactory.Create(GameProfile.Original, physical);
            if (_process == null)
                throw new InvalidOperationException("The original game session could not be created.");
            _process.Threads.OwnsHostThreadScheduling = false;
            _process.ActualGame.IsActive = true;
            if (_exitRequested)
            {
                _process.ActualGame.GameLoop.Exit();
                return;
            }

            _process.ActualGame.StartSourceHostRun();
            _submission.Pump();
        }

        public void SetSuspended(bool suspended)
        {
            AssertOwnerThread();
            if (_disposed || _suspended == suspended) return;
            _suspended = suspended;
            if (suspended)
            {
                _focused = false;
                _pendingWheel = 0;
                _input?.Advance([], 0, 0, 0, 0, false);
                _process?.KeyboardState.Keys.Clear();
                if (_process != null) _process.ActualGame.IsActive = false;
            }

            _process?.AudioSession.Runtime?.BusPausedNative("bus:/", suspended);
        }

        public void Advance(int[] pressedKeys, int mouseX, int mouseY, uint mouseButtons, int wheelDelta, bool focused)
        {
            AssertOwnerThread();
            if (!IsRunning || _suspended) return;
            _focused = focused;
            _input.Advance(pressedKeys, mouseX, mouseY, mouseButtons, wheelDelta, focused);
            _pendingWheel = _input.Mouse.WheelDelta;
            _process.ActualGame.IsActive = focused;
            _submission.Pump();
            if (!focused)
            {
                _process.KeyboardState.Keys.Clear();
                return;
            }

            _clock.AdvanceOneUpdate(_process.ActualGame.TargetElapsedTime);
            _process.ActualGame.ContinueSourceHostRun();
            _submission.Pump();
            if (!_process.ActualGame.GameLoop.RunApplication)
                _process.ActualGame.FinishSourceHostRun();
        }

        public void PushTextInput(char character)
        {
            AssertOwnerThread();
            if (IsRunning && !_suspended) _input.PushTextInput(character);
        }

        private void PollEvents()
        {
            if (_process == null) return;
            _input.Keyboard.CopyKeysTo(_process.KeyboardState.Keys);
            _process.FnaInput.Mouse.INTERNAL_MouseWheel += _pendingWheel;
            _pendingWheel = 0;
            _process.ActualGame.IsActive = _focused;
            if (_exitRequested) _process.ActualGame.GameLoop.Exit();
        }

        private void DeliverTextInput(char character)
        {
            if (_process != null && !_process.ActualGame.SuppressPhysicalTextInput)
                _process.TextInput.OnTextInput(character);
        }

        private void RequestSessionExit(int exitCode)
        {
            _exitRequested = true;
            if (_process != null) _process.ActualGame.GameLoop.Exit();
        }

        public void Dispose()
        {
            AssertOwnerThread();
            try
            {
                DisposeCore();
                _disposedCompletion.TrySetResult(true);
            }
            catch (Exception exception)
            {
                _disposedCompletion.TrySetException(exception);
                throw;
            }
        }

        private void DisposeCore()
        {
            AssertOwnerThread();
            if (_disposed) return;
            _disposed = true;
            try
            {
                if (_process != null)
                {
                    _process.ActualGame.GameLoop.Exit();
                    try
                    {
                        _process.WaitSourceBackgroundThreads(_submission.Pump);
                        _process.ActualGame.FinishSourceHostRun();
                    }
                    finally
                    {
                        _process.WaitSourceBackgroundThreads(_submission.Pump);
                        _submission.StopPresenting();
                        _process.ActualGame.Dispose();
                    }
                }
            }
            finally
            {
                try
                {
                    if (_input != null)
                    {
                        _input.TextInput -= DeliverTextInput;
                        _input.Dispose();
                    }
                }
                finally
                {
                    _submission?.Dispose();
                }
            }
        }

        private void AssertOwnerThread()
        {
            if (Thread.CurrentThread.ManagedThreadId != _ownerThread)
                throw new InvalidOperationException("Advance and dispose the game on its owning host thread.");
        }
    }
}
