using System.Numerics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalPlateauState : SourceSolidEntityState
    {
        private SpriteImage sprite;
        public LightOccludeState Occluder;

        public OriginalPlateauState(EntityData data, Vector2 offset, ISourceSolidWorldFactory worlds)
            : base(data.Position + offset, 104f, 4f, true, worlds.Create(data.Position + offset, true))
        {
            Collider.Left += 8f;
            OwnedComponents.Add(sprite =
                new SpriteImage(
                    ((ISourceGameGraphicsEnvironment)SourceWorld.EngineContext).GameGraphics.GameAtlas[
                        "scenery/fallplateau"]));
            OwnedComponents.Add(Occluder = new LightOccludeState());
            SurfaceSoundIndex = 23;
            EnableAssistModeChecks = false;
        }
    }
}
