using Celeste.Core.Audio;

namespace Celeste.Game.Audio
{
    public static class OriginalAudioParameters
    {
        private static readonly string[] LayerParameters =
            { "layer0", "layer1", "layer2", "layer3", "layer4", "layer5", "layer6", "layer7", "layer8", "layer9" };

        public static int GetProgress(this EventTrackState track) => (int)track.GetParam("progress");

        public static EventTrackState SetProgress(this EventTrackState track, int value) =>
            track.Param("progress", value);

        public static EventTrackState Layer(this EventTrackState track, int index, float value)
            => track.Param(LayerParameters[index], value);

        public static EventTrackState Layer(this EventTrackState track, int index, bool value)
            => track.Layer(index, value ? 1f : 0f);
    }
}
