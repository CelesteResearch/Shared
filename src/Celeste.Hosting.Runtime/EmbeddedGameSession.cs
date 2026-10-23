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
        private readonly int ownerThread;

        private readonly TaskCompletionSource<bool> disposedCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        private EmbeddedInputDevices input;
        private EmbeddedGameClock clock;
        private IEmbeddedGraphicsSession submission;
        private readonly IEmbeddedGraphicsSessionFactory graphicsFactory;
        private GameApplication process;
        private bool initialized;
        private bool disposed;
        private bool exitRequested;
        private bool focused;
        private bool suspended;
        private int pendingWheel;

        internal EmbeddedGameSession(EmbeddedGameConfiguration configuration,
            IEmbeddedGraphicsSessionFactory graphicsFactory)
        {
            this.configuration = configuration;
            this.graphicsFactory = graphicsFactory ?? throw new ArgumentNullException(nameof(graphicsFactory));
            ownerThread = Thread.CurrentThread.ManagedThreadId;
        }

        public bool IsLoading => false;
        public Exception? InitializationError => null;
        public Task DisposedCompletion => disposedCompletion.Task;

        public bool IsRunning => !disposed && !exitRequested && process != null &&
                                 process.ActualGame.SourceHostRunOpen && process.ActualGame.GameLoop.RunApplication;

        public bool IsTextInputActive => !suspended && input != null && input.IsTextInputActive();
        public int Width => submission?.Width ?? configuration.Width;
        public int Height => submission?.Height ?? configuration.Height;
        public byte[] FrameRgba => submission?.FrameRgba ?? Array.Empty<byte>();
        public long FrameNumber => submission?.FrameNumber ?? 0;

        // This actual instance MethodDef is also the physical startup identity
        // supplied to ManagedSourceRuntimeIO; it is not a synthetic compatibility frame.
        public void Initialize()
        {
            AssertOwnerThread();
            if (disposed) throw new ObjectDisposedException(nameof(EmbeddedGameSession));
            if (initialized) throw new InvalidOperationException("The embedded game session is already initialized.");
            initialized = true;
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
            string physicalOwner = typeof(GameApplication).Assembly.Location;
            var startup =
                typeof(EmbeddedGameSession).GetMethod(nameof(Initialize), BindingFlags.Public | BindingFlags.Instance);
            var runtime = new RuntimeIO(configuration, physicalOwner, startup, RequestSessionExit);
            var window = new OffscreenWindow(configuration);
            input = new EmbeddedInputDevices(configuration);
            input.TextInput += DeliverTextInput;
            clock = new EmbeddedGameClock(PollEvents);
            submission = graphicsFactory.Create(window, runtime, ownerThread);
            var physical = new GamePlatformServices(physicalOwner, configuration.ContentRoot,
                window, submission.DeviceFactory, new VirtualDisplayDevice(configuration),
                new ProjectedContentSource(new DirectoryContentSource(configuration.ContentRoot),
                    new Dictionary<string, string> { { ".meta", ".atlas.bytes" } }, new[] { ".meta" }),
                new NativeSourceFnaImageCodecDevice(), input.Keyboard, input.Mouse, input.GamePads,
                clock, clock, new NativeSourceRandomSeeds(), new NativeSourceFAudioIOFactory(),
                new NativeSourceMicrophoneIO(), new NativeSourceTheoraIO(), runtime, input,
                new NativeSourceFrameworkTimeResources(configuration.FrameworkTimeResourcesRoot),
                runtime, runtime, runtime, runtime, runtime, null, runtime, runtime,
                null, new NativeSourceConsoleModeIO(), submission.DrawTransport, runtime, input,
                new ManagedSourceRuntimeDiagnostics(new WindowsSourceRuntimeMemoryCapacity()),
                null, input, null, audioOutputAvailable: configuration.AudioOutputAvailable);
            process = GameApplicationFactory.Create(GameProfile.Original, physical);
            if (process == null) throw new InvalidOperationException("The original game session could not be created.");
            process.Threads.OwnsHostThreadScheduling = false;
            process.ActualGame.IsActive = true;
            if (exitRequested)
            {
                process.ActualGame.GameLoop.Exit();
                return;
            }

            process.ActualGame.StartSourceHostRun();
            submission.Pump();
        }

        public void SetSuspended(bool suspended)
        {
            AssertOwnerThread();
            if (disposed || this.suspended == suspended) return;
            this.suspended = suspended;
            if (suspended)
            {
                focused = false;
                pendingWheel = 0;
                input?.Advance(Array.Empty<int>(), 0, 0, 0, 0, false);
                process?.KeyboardState.Keys.Clear();
                if (process != null) process.ActualGame.IsActive = false;
            }

            process?.AudioSession.Runtime?.BusPausedNative("bus:/", suspended);
        }

        public void Advance(int[] pressedKeys, int mouseX, int mouseY, uint mouseButtons, int wheelDelta, bool focused)
        {
            AssertOwnerThread();
            if (!IsRunning || suspended) return;
            this.focused = focused;
            input.Advance(pressedKeys, mouseX, mouseY, mouseButtons, wheelDelta, focused);
            pendingWheel = input.Mouse.WheelDelta;
            process.ActualGame.IsActive = focused;
            submission.Pump();
            if (!focused)
            {
                process.KeyboardState.Keys.Clear();
                return;
            }

            clock.AdvanceOneUpdate(process.ActualGame.TargetElapsedTime);
            process.ActualGame.ContinueSourceHostRun();
            submission.Pump();
            if (!process.ActualGame.GameLoop.RunApplication)
                process.ActualGame.FinishSourceHostRun();
        }

        public void PushTextInput(char character)
        {
            AssertOwnerThread();
            if (IsRunning && !suspended) input.PushTextInput(character);
        }

        private void PollEvents()
        {
            if (process == null) return;
            input.Keyboard.CopyKeysTo(process.KeyboardState.Keys);
            process.FnaInput.Mouse.INTERNAL_MouseWheel += pendingWheel;
            pendingWheel = 0;
            process.ActualGame.IsActive = focused;
            if (exitRequested) process.ActualGame.GameLoop.Exit();
        }

        private void DeliverTextInput(char character)
        {
            if (process != null && !process.ActualGame.SuppressPhysicalTextInput)
                process.TextInput.OnTextInput(character);
        }

        private void RequestSessionExit(int exitCode)
        {
            exitRequested = true;
            if (process != null) process.ActualGame.GameLoop.Exit();
        }

        public void Dispose()
        {
            AssertOwnerThread();
            try
            {
                DisposeCore();
                disposedCompletion.TrySetResult(true);
            }
            catch (Exception exception)
            {
                disposedCompletion.TrySetException(exception);
                throw;
            }
        }

        private void DisposeCore()
        {
            AssertOwnerThread();
            if (disposed) return;
            disposed = true;
            try
            {
                if (process != null)
                {
                    process.ActualGame.GameLoop.Exit();
                    try
                    {
                        process.WaitSourceBackgroundThreads(submission.Pump);
                        process.ActualGame.FinishSourceHostRun();
                    }
                    finally
                    {
                        process.WaitSourceBackgroundThreads(submission.Pump);
                        submission.StopPresenting();
                        process.ActualGame.Dispose();
                    }
                }
            }
            finally
            {
                try
                {
                    if (input != null)
                    {
                        input.TextInput -= DeliverTextInput;
                        input.Dispose();
                    }
                }
                finally
                {
                    submission?.Dispose();
                }
            }
        }

        private void AssertOwnerThread()
        {
            if (Thread.CurrentThread.ManagedThreadId != ownerThread)
                throw new InvalidOperationException("Advance and dispose the game on its owning host thread.");
        }
    }
}
