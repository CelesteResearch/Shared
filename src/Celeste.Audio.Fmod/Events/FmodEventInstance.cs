using System;
using System.Numerics;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Parameters;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Audio.Fmod.Events
{
    public sealed class FmodEventInstance : IDisposable
    {
        internal readonly FmodStudioRuntime Owner;
        private IntPtr handle;
        public string Path { get; }

        public string GetCanonicalPath()
        {
            Check(
                Owner.DeviceIO.StudioEventInstanceGetDescription(Handle,
                    out var description),
                "Get event description");
            return description == IntPtr.Zero
                ? ""
                : FmodStudioRuntime.ReadPath(description,
                    Owner.eventDescriptionPathReader);
        }

        public bool IsReleased => handle == IntPtr.Zero;

        internal FmodEventInstance(FmodStudioRuntime owner, IntPtr value,
            string path)
        {
            Owner = owner;
            handle = value;
            Path = path;
        }

        private IntPtr Handle
        {
            get
            {
                Owner.Alive();
                if (IsReleased)
                    throw new ObjectDisposedException(nameof(FmodEventInstance));
                return handle;
            }
        }

        private void Check(FmodResult result, string operation)
        {
            FmodStudioRuntime.Check(result, operation + " " + Path);
        }

        public void Start()
        {
            Check(
                Owner.DeviceIO.StudioEventInstanceStart(Handle),
                "Start event");
        }

        // Event teardown is idempotent after release or runtime disposal.
        public void Stop(bool allowFadeout = true)
        {
            if (IsReleased || Owner.IsDisposed) return;
            Check(
                Owner.DeviceIO.StudioEventInstanceStop(Handle,
                    allowFadeout ? 0 : 1),
                "Stop event");
        }

        public void Release()
        {
            if (IsReleased) return;
            // A disposed owner means the whole system is gone and this event cannot exist any more, so
            // there is nothing to release and nothing to report. `Alive()` would otherwise throw
            // `ObjectDisposedException('FmodStudioRuntime')` out of the teardown path -- see `Stop` above
            // for the measured stack. Dropping the local handle without calling `Owner.Forget` is safe
            // here precisely because the owner is dead: its `instances` set was cleared by its own
            // `Dispose`.
            if (Owner.IsDisposed)
            {
                handle = IntPtr.Zero;
                return;
            }

            Check(Owner.DeviceIO.StudioEventInstanceRelease(Handle),
                "Release event");
            handle = IntPtr.Zero;
            Owner.Forget(this);
        }

        public bool Paused
        {
            get
            {
                Check(
                    Owner.DeviceIO.StudioEventInstanceGetPaused(Handle,
                        out var value), "Get event pause");
                return value != 0;
            }
            set => Check(
                Owner.DeviceIO.StudioEventInstanceSetPaused(Handle,
                    value ? 1 : 0),
                "Set event pause");
        }

        public int TimelinePosition
        {
            get
            {
                Check(
                    Owner.DeviceIO.StudioEventInstanceGetTimelinePosition(
                        Handle,
                        out var value),
                    "Get timeline");
                return value;
            }
            set => Check(
                Owner.DeviceIO.StudioEventInstanceSetTimelinePosition(Handle,
                    value),
                "Set timeline");
        }

        public float Volume
        {
            get
            {
                Check(
                    Owner.DeviceIO.StudioEventInstanceGetVolume(Handle,
                        out var value, out _),
                    "Get event volume");
                return value;
            }
            set => Check(
                Owner.DeviceIO.StudioEventInstanceSetVolume(Handle, value),
                "Set event volume");
        }

        public float Pitch
        {
            get
            {
                Check(
                    Owner.DeviceIO.StudioEventInstanceGetPitch(Handle,
                        out var value, out _),
                    "Get event pitch");
                return value;
            }
            set => Check(
                Owner.DeviceIO.StudioEventInstanceSetPitch(Handle, value),
                "Set event pitch");
        }

        public FmodPlaybackState PlaybackState
        {
            get
            {
                Check(
                    Owner.DeviceIO.StudioEventInstanceGetPlaybackState(Handle,
                        out var value),
                    "Get playback state");
                return value;
            }
        }

        public void SetParameter(string name, float value)
        {
            Check(
                Owner.DeviceIO.StudioEventInstanceSetParameterValue(Handle,
                    FmodStudioRuntime.Utf8(name), value),
                "Set parameter " + name);
        }

        public float GetParameter(string name)
        {
            return GetParameter(name, out _);
        }

        public float GetParameter(string name, out float finalValue)
        {
            Check(
                Owner.DeviceIO.StudioEventInstanceGetParameterValue(Handle,
                    FmodStudioRuntime.Utf8(name),
                    out var value, out finalValue), "Get parameter " + name);
            return value;
        }

        public FmodParameterState[] GetParameters()
        {
            var parameters = Owner.EventInfo(Path).Parameters;
            var result = new FmodParameterState[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                var value = GetParameter(parameters[i].Name, out var finalValue);
                result[i] = new() { Description = parameters[i], Value = value, FinalValue = finalValue };
            }

            return result;
        }

        public void SetPosition(Vector3 position)
        {
            Set3DAttributes(FmodAttributes.At(position.X, position.Y, position.Z));
        }

        public void Set3DAttributes(FmodAttributes attributes)
        {
            Check(
                Owner.DeviceIO.StudioEventInstanceSet3DAttributes(Handle, ref attributes),
                "Set event spatial attributes");
        }

        public FmodAttributes Get3DAttributes()
        {
            Check(
                Owner.DeviceIO.StudioEventInstanceGet3DAttributes(Handle,
                    out var value),
                "Get event spatial attributes");
            return value;
        }

        public void TriggerCue()
        {
            Check(Owner.DeviceIO.StudioEventInstanceTriggerCue(Handle),
                "Trigger cue");
        }

        public void Dispose()
        {
            if (IsReleased) return;
            if (Owner.IsDisposed)
            {
                handle = IntPtr.Zero;
                return;
            }

            try
            {
                Stop(false);
            }
            finally
            {
                Release();
            }
        }
    }
}
