using System;

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
        public readonly global::Celeste.Audio.Fmod.Events.FmodPlaybackState Playback;
        public readonly global::Celeste.Audio.Fmod.Interop.FmodAttributes Attributes;
        private readonly global::Celeste.Audio.Fmod.Parameters.FmodParameterState[] parameters;

        public FmodEventSnapshot(global::Celeste.Audio.Fmod.Events.FmodEventInstance source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            Path = source.Path;
            Released = source.IsReleased || source.Owner.IsDisposed;
            if (Released)
            {
                parameters = Array.Empty<global::Celeste.Audio.Fmod.Parameters.FmodParameterState>();
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

        public global::Celeste.Audio.Fmod.Events.FmodEventInstance Restore(
            global::Celeste.Audio.Fmod.Runtime.FmodStudioRuntime runtime, bool remainPaused = false)
        {
            if (Released) return new global::Celeste.Audio.Fmod.Events.FmodEventInstance(runtime, IntPtr.Zero, Path);
            global::Celeste.Audio.Fmod.Events.FmodEventInstance result = runtime.CreateEvent(Path);
            try
            {
                result.Paused = true;
                result.Volume = Volume;
                result.Pitch = Pitch;
                if (Is3D) result.Set3DAttributes(Attributes);
                foreach (global::Celeste.Audio.Fmod.Parameters.FmodParameterState parameter in parameters)
                    if (parameter.Description.Type == 0)
                        result.SetParameter(parameter.Name, parameter.Value);
                if (Playback != global::Celeste.Audio.Fmod.Events.FmodPlaybackState.Stopped) result.Start();
                if (Timeline > 0) result.TimelinePosition = Timeline;
                result.Paused = remainPaused || Paused;
                if (Playback == global::Celeste.Audio.Fmod.Events.FmodPlaybackState.Stopping) result.Stop(true);
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
