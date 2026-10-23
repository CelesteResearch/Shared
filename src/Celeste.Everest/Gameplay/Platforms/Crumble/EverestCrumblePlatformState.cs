using System.Numerics;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Platforms.Crumble;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Everest.Gameplay.Platforms.Crumble
{
    public class EverestCrumblePlatformState : OriginalCrumblePlatformState
    {
        public string OverrideTexture;

        public EverestCrumblePlatformState(Vector2 position, float width, IOriginalCrumbleProcess process,
            ISourceSolidWorldFactory worlds)
            : base(position, width, process, worlds)
        {
        }

        public EverestCrumblePlatformState(EntityData data, Vector2 offset, IOriginalCrumbleProcess process,
            ISourceSolidWorldFactory worlds)
            : base(data, offset, process, worlds)
        {
        }

        public override void Added(object scene)
        {
            var area = ((IOriginalAreaKeyEnvironment)process).AreaKeys.GetArea(
                ((IOriginalAreaKeyEnvironment)process).AreaKeys.GetSessionArea(((OriginalLevelSceneRoot)scene)
                    .Session));
            string previous = area.CrumbleBlock;
            if (OverrideTexture != null) area.CrumbleBlock = OverrideTexture;
            base.Added(scene);
            area.CrumbleBlock = previous;
        }
    }
}
