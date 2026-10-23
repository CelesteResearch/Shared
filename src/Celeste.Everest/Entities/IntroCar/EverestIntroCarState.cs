using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.IntroCar;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Display;

namespace Celeste.Everest.Entities.IntroCar
{
    public class EverestIntroCarState : OriginalIntroCarState
    {
        public bool hasRoadAndBarriers;

        public EverestIntroCarState(ISourceEngineContext engine, ISourceSolidWorldFactory worlds,
            EntityData data, Vector2 offset)
            : base(engine, worlds, data, offset)
        {
            hasRoadAndBarriers = EntityAttributeReader.Bool(data.Values, "hasRoadAndBarriers");
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            OriginalLevelSceneRoot level = scene as OriginalLevelSceneRoot;
            if (!(((IOriginalAreaKeyEnvironment)SourceWorld.EngineContext).AreaKeys.GetLevelSet(
                      ((IOriginalAreaKeyEnvironment)SourceWorld.EngineContext).AreaKeys
                      .GetSessionArea(level.Session)) ==
                  "Celeste") && hasRoadAndBarriers)
            {
                level.SourceScene.QueueSourceEntity(new OriginalIntroPavementState(SourceWorld.EngineContext, worlds,
                    new Vector2(level.Bounds.Left, Y), (int)(X - (float)level.Bounds.Left - 48f)) { Depth = -10001 });
                level.SourceScene.QueueSourceEntity(new OriginalIntroCarBarrierState(SourceWorld.EngineContext,
                    Position + new Vector2(32f, 0f), -10, PackedColor.White));
                level.SourceScene.QueueSourceEntity(new OriginalIntroCarBarrierState(SourceWorld.EngineContext,
                    Position + new Vector2(41f, 0f), 5, PackedColor.DarkGray));
            }
        }
    }
}
