using Celeste.Core.Display;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Backdrops;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public float BaseLightingAlpha;
        public PackedColor BackgroundColor;

        public void LoadSourceBackdropContent(OriginalChapterMapData map, float darknessAlpha, float bloomBase,
            float bloomStrength,
            OriginalGameAudioSession processAudio)
        {
            BaseLightingAlpha = Lighting.Alpha = darknessAlpha;
            Bloom.Base = bloomBase;
            Bloom.Strength = bloomStrength;
            BackgroundColor = map.BackgroundColor;
            var parser = new MapBackdropParser(EngineContext, map);
            Background.Backdrops = parser.CreateBackdrops(map.Background);
            foreach (var backdrop in Background.Backdrops)
                backdrop.Renderer = Background;
            Foreground.Backdrops = parser.CreateBackdrops(map.Foreground);
            foreach (var backdrop in Foreground.Backdrops)
                backdrop.Renderer = Foreground;
            Renderers.UpdateLists();
            ConstructSourceFormationBackdrop();
            Camera = GameplayRenderer.Camera;
            processAudio.CurrentCamera = Camera;
        }
    }
}
