using System;
using System.Collections.Generic;
using Celeste.Audio.Fmod.Banks;
using Celeste.Audio.Fmod.Events;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Audio.Fmod.Gameplay.Audio
{
    public sealed class GameAudioDevice : IDisposable
    {
        private readonly HashSet<RoomAudioDriver> borrowers = new HashSet<RoomAudioDriver>();
        private readonly object gate = new object();
        private FmodStudioRuntime runtime;
        private bool disposed;
        public readonly GameAudioChannels Channels = new GameAudioChannels();
        public FmodStudioRuntime Runtime => runtime;
        public FmodOutputDevice SourceOutputDevice { get; private set; } = FmodOutputDevice.AutoDetect;
        public event Action<bool> AudioOutputCreated;

        public global::Celeste.Audio.Fmod.IO.IFmodStudioDeviceIO StudioDeviceIO { get; }
        public global::Celeste.Core.IO.Content.IContentMemorySource BankContentSource { get; }

        public GameAudioDevice() : this(global::Celeste.Audio.Fmod.IO.NativeFmodStudioDeviceIO.Instance)
        {
        }

        public GameAudioDevice(global::Celeste.Audio.Fmod.IO.IFmodStudioDeviceIO studioDeviceIO,
            global::Celeste.Core.IO.Content.IContentMemorySource bankContentSource = null)
        {
            StudioDeviceIO = studioDeviceIO ?? throw new ArgumentNullException(nameof(studioDeviceIO));
            BankContentSource = bankContentSource;
        }

        public void ConfigureSourceOutput(FmodOutputDevice outputDevice)
        {
            lock (gate)
            {
                if (disposed) throw new ObjectDisposedException(nameof(GameAudioDevice));
                if (runtime != null)
                    throw new InvalidOperationException(
                        "Configure the output device before allocating its FMOD system.");
                if (outputDevice != FmodOutputDevice.AutoDetect && outputDevice != FmodOutputDevice.NoSound)
                    throw new ArgumentOutOfRangeException(nameof(outputDevice));
                SourceOutputDevice = outputDevice;
            }
        }

        private void ReportAudioOutput(bool noSound) => AudioOutputCreated?.Invoke(noSound);
        public bool IsDisposed => disposed;

        public string CurrentMusicName
        {
            get => Channels.CurrentMusicName;
            set => Channels.CurrentMusicName = value;
        }

        public FmodEventInstance AmbienceEvent
        {
            get => Channels.Ambience;
            set => Channels.Ambience = value;
        }

        public FmodEventInstance AlternateEvent
        {
            get => Channels.Alternate;
            set => Channels.Alternate = value;
        }

        public FmodEventInstance MainDownSnapshot
        {
            get => Channels.MainDown;
            set => Channels.MainDown = value;
        }

        public FmodEventInstance MusicEvent
        {
            get => Channels.Music;
            set
            {
                Channels.Music = value;
                ApplyChannels();
            }
        }

        public void PublishSourceRuntime(FmodStudioRuntime actualRuntime)
        {
            if (runtime != null) runtime.AudioOutputCreated -= ReportAudioOutput;
            runtime = actualRuntime;
            if (runtime != null) runtime.AudioOutputCreated += ReportAudioOutput;
        }

        public void Initialize(IEnumerable<FmodBankLoadRequest> banks, FmodAttributes listener, bool noSound,
            bool liveUpdate)
        {
            lock (gate)
            {
                if (disposed) throw new ObjectDisposedException(nameof(GameAudioDevice));
                if (runtime != null) return;
                var created = new FmodStudioRuntime(StudioDeviceIO, noSound, liveUpdate: liveUpdate,
                    bankContentSource: BankContentSource);
                try
                {
                    created.SetListenerAttributes(listener);
                    created.LoadBanks(banks);
                    runtime = created;
                    ApplyChannels();
                }
                catch
                {
                    runtime = null;
                    created.Dispose();
                    throw;
                }
            }
        }

        public FmodEventInstance Create(string path)
        {
            if (disposed) throw new ObjectDisposedException(nameof(GameAudioDevice));
            if (runtime == null) throw new InvalidOperationException("Audio device has not been initialized.");
            try
            {
                return runtime.CreateSourceEvent(path);
            }
            catch (FmodException error) when (error.Result == FmodResult.ERR_EVENT_NOTFOUND)
            {
                return null;
            }
        }

        public FmodEventReference CreateReference(string path)
        {
            if (disposed) throw new ObjectDisposedException(nameof(GameAudioDevice));
            if (runtime == null) throw new InvalidOperationException("Audio device has not been initialized.");
            try
            {
                return runtime.CreateEventReference(path);
            }
            catch (FmodException error) when (error.Result == FmodResult.ERR_EVENT_NOTFOUND)
            {
                return null;
            }
        }

        public FmodEventReference CreateReference(string path, out bool is3D)
        {
            if (disposed) throw new ObjectDisposedException(nameof(GameAudioDevice));
            if (runtime == null) throw new InvalidOperationException("Audio device has not been initialized.");
            return runtime.CreateEventReference(path, out is3D);
        }

        public void ApplyChannels()
        {
            if (runtime != null) runtime.CurrentMusic = Channels.Music;
        }

        internal void Borrow(RoomAudioDriver driver)
        {
            lock (gate)
            {
                if (disposed || runtime == null) throw new ObjectDisposedException(nameof(GameAudioDevice));
                borrowers.Add(driver);
            }
        }

        internal void Return(RoomAudioDriver driver)
        {
            lock (gate) borrowers.Remove(driver);
        }

        public void Dispose()
        {
            RoomAudioDriver[] live;
            lock (gate)
            {
                if (disposed) return;
                disposed = true;
                live = new RoomAudioDriver[borrowers.Count];
                borrowers.CopyTo(live);
                borrowers.Clear();
                // Never hold the registry gate while entering a borrower callback.
            }

            Exception failure = null;
            try
            {
                foreach (var driver in live)
                    try
                    {
                        driver.Dispose();
                    }
                    catch (Exception error)
                    {
                        if (failure == null) failure = error;
                    }
            }
            finally
            {
                try
                {
                    runtime?.Dispose();
                }
                finally
                {
                    runtime = null;
                }
            }

            if (failure != null) throw failure;
        }
    }
}
