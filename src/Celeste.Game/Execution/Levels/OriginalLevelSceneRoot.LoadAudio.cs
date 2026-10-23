using Celeste.Game.Audio;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Processes;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private void ApplySourceRoomAudio(OriginalLevelRoomData room, bool isFromLoader)
        {
            var process = (IOriginalGameplayProcess)EngineContext;
            if (Session.Audio == null)
                Session.Audio = AreaData.GetOriginalMode(Session.Mode).AudioState.Clone();
            if (!room.DelayAltMusic)
                process.AudioSession.ChannelOutput.SetAltMusic(
                    ((IOriginalSfxEnvironment)process).Sfx.EventnameByHandle(room.AltMusic));
            if (room.Music.Length > 0)
                Session.Audio.Music.Event = ((IOriginalSfxEnvironment)process).Sfx.EventnameByHandle(room.Music);
            if (!AreaData.GetOriginalMode(Session.Mode).IgnoreLevelAudioLayerData)
            {
                for (int i = 0; i < 4; i++)
                    Session.Audio.Music.Layer(i + 1, room.MusicLayers[i]);
            }

            if (room.MusicProgress >= 0)
                Session.Audio.Music.SetProgress(room.MusicProgress);
            Session.Audio.Music.Layer(6, room.MusicWhispers);
            if (room.Ambience.Length > 0)
                Session.Audio.Ambience.Event = ((IOriginalSfxEnvironment)process).Sfx.EventnameByHandle(room.Ambience);
            if (room.AmbienceProgress >= 0)
                Session.Audio.Ambience.SetProgress(room.AmbienceProgress);
            OriginalAudioSession.Apply(Session.Audio, process.AudioSession.ChannelOutput,
                process.AudioApplyPolicy, isFromLoader);
        }
    }
}
