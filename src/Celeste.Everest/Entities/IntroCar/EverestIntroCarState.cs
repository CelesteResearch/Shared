using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.IntroCar;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

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
            var level = scene as OriginalLevelSceneRoot;
            if (!(!(((IOriginalAreaKeyEnvironment)SourceWorld.EngineContext).AreaKeys.GetLevelSet(
                        ((IOriginalAreaKeyEnvironment)SourceWorld.EngineContext).AreaKeys
                        .GetSessionArea(level.Session)) ==
                    "Celeste") && hasRoadAndBarriers))
                return;
            level.SourceScene.QueueSourceEntity(new OriginalIntroPavementState(SourceWorld.EngineContext, worlds,
                new(level.Bounds.Left, Y), (int)(X - level.Bounds.Left - 48f)) { Depth = -10001 });
            level.SourceScene.QueueSourceEntity(new OriginalIntroCarBarrierState(SourceWorld.EngineContext,
                Position + new Vector2(32f, 0f), -10, PackedColor.White));
            level.SourceScene.QueueSourceEntity(new OriginalIntroCarBarrierState(SourceWorld.EngineContext,
                Position + new Vector2(41f, 0f), 5, PackedColor.DarkGray));
        }
    }
}
