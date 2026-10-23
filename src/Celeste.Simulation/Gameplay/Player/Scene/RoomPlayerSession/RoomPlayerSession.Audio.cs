using Celeste.Core.Audio;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Simulation.Gameplay.Player.Events;
using Celeste.Simulation.Gameplay.Player.Scene.Audio;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private void BindAudioEvents()
        {
            World.Emitted += message =>
            {
                if (message.Kind != RoomPlayerEventKind.Sound)
                    return;
                var raining = Scene is ISourcePlayerRainingScene level && level.Raining ? 1f : 0f;
                ((ISourceSpatialAudioEnvironment)EngineContext).SpatialAudio.Play(
                    message.Name, Center, message.Parameter, message.Value, "raining", raining);
            };
        }

        public ISourceAudioEventReference Play(string sound, string parameter = null, float value = 0f)
        {
            var raining = 0f;
            if (Scene is ISourcePlayerRainingScene level && level.Raining)
                raining = 1f;
            ChaseHistory.RecordSound(sound, parameter, value);
            return ((ISourceSpatialAudioEnvironment)EngineContext).SpatialAudio.Play(
                sound, Center, parameter, value, "raining", raining);
        }

        public void Loop(SoundSourceComponentState source, string sound)
        {
            ChaseHistory.RecordSound(sound, null, 0f,
                ChaserStateSound.Actions.Loop);
            source.Play(sound);
        }

        public void Stop(SoundSourceComponentState source)
        {
            if (source.Playing)
            {
                ChaseHistory.RecordSound(source.EventName, null, 0f,
                    ChaserStateSound.Actions.Stop);
                source.Stop();
            }
        }
    }
}
