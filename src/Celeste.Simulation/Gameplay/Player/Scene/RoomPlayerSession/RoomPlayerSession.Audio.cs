using Celeste.Core.Audio;
using Celeste.Simulation.Gameplay.Player.Scene.Audio;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private void BindAudioEvents()
        {
            World.Emitted += message =>
            {
                if (message.Kind != global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEventKind.Sound)
                    return;
                float raining = Scene is ISourcePlayerRainingScene level && level.Raining ? 1f : 0f;
                ((ISourceSpatialAudioEnvironment)engineContext).SpatialAudio.Play(
                    message.Name, Center, message.Parameter, message.Value, "raining", raining);
            };
        }

        public ISourceAudioEventReference Play(string sound, string parameter = null, float value = 0f)
        {
            float raining = 0f;
            if (Scene is ISourcePlayerRainingScene level && level.Raining)
                raining = 1f;
            ChaseHistory.RecordSound(sound, parameter, value);
            return ((ISourceSpatialAudioEnvironment)engineContext).SpatialAudio.Play(
                sound, Center, parameter, value, "raining", raining);
        }

        public void Loop(global::Celeste.Simulation.Audio.Sources.SoundSourceComponentState source, string sound)
        {
            ChaseHistory.RecordSound(sound, null, 0f,
                global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserStateSound.Actions.Loop);
            source.Play(sound);
        }

        public void Stop(global::Celeste.Simulation.Audio.Sources.SoundSourceComponentState source)
        {
            if (source.Playing)
            {
                ChaseHistory.RecordSound(source.EventName, null, 0f,
                    global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserStateSound.Actions.Stop);
                source.Stop();
            }
        }
    }
}
