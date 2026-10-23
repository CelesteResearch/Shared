using System;
using Celeste.Audio.Fmod.Interop;
using Celeste.Audio.Fmod.Parameters;
using Celeste.Audio.Fmod.Runtime;

namespace Celeste.Audio.Fmod.Events
{
    // Values, not native handles. A snapshot survives disposal of its original
    // scene/runtime and may be loaded more than once into a new audio runtime.
    public sealed class FmodEventSnapshot
    {
        public readonly string Path;
        public readonly bool Released, Paused, Is3D;
        public readonly int Timeline;
        public readonly float Volume, Pitch;
        public readonly FmodPlaybackState Playback;
        public readonly FmodAttributes Attributes;
        private readonly FmodParameterState[] parameters;

        public FmodEventSnapshot(FmodEventInstance source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            Path = source.Path;
            Released = source.IsReleased || source.Owner.IsDisposed;
            if (Released)
            {
                parameters = [];
                return;
            }

            Paused = source.Paused;
            Timeline = source.TimelinePosition;
            Volume = source.Volume;
            Pitch = source.Pitch;
            Playback = source.PlaybackState;
            Is3D = source.Owner.EventInfo(Path).Is3D;
            if (Is3D) Attributes = source.Get3DAttributes();
            parameters = source.GetParameters();
        }

        public FmodEventInstance Restore(
            FmodStudioRuntime runtime, bool remainPaused = false)
        {
            if (Released) return new(runtime, IntPtr.Zero, Path);
            var result = runtime.CreateEvent(Path);
            try
            {
                result.Paused = true;
                result.Volume = Volume;
                result.Pitch = Pitch;
                if (Is3D) result.Set3DAttributes(Attributes);
                foreach (var parameter in parameters)
                    if (parameter.Description.Type == 0)
                        result.SetParameter(parameter.Name, parameter.Value);
                if (Playback != FmodPlaybackState.Stopped) result.Start();
                if (Timeline > 0) result.TimelinePosition = Timeline;
                result.Paused = remainPaused || Paused;
                if (Playback == FmodPlaybackState.Stopping) result.Stop();
                return result;
            }
            catch
            {
                result.Dispose();
                throw;
            }
        }
    }
}
