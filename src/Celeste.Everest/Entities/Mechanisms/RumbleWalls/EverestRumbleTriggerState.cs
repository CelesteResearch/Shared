using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.Mechanisms.RumbleWalls;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Everest.Entities.Mechanisms.RumbleWalls
{
    public class EverestRumbleTriggerState : OriginalRumbleTriggerState
    {
        private bool constrainHeight;
        private float top;
        private float bottom;

        public EverestRumbleTriggerState(EntityData data, Vector2 offset, MapEntityId id,
            ISourceEngineContext engine) : base(data, offset, id, engine)
        {
            constrainHeight = EntityAttributeReader.Bool(data.Values, "constrainHeight");
            Vector2[] nodes = data.NodesOffset(offset);
            if (nodes.Length >= 2)
            {
                top = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(nodes[0].Y, nodes[1].Y);
                bottom = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(nodes[0].Y, nodes[1].Y);
            }
        }

        protected override bool MatchesHeight(SceneEntityState entity)
            => !constrainHeight || (entity.Y >= top && entity.Y <= bottom);

        public override void InvokeAtPosition(Vector2 position, float delay, bool triggerUnconstrained)
        {
            if (!MatchesManualX(position.X)) return;
            if (constrainHeight)
            {
                if (position.Y >= top && position.Y <= bottom) Invoke(delay);
            }
            else if (triggerUnconstrained) Invoke(delay);
        }

        public static void ManuallyTrigger(ISourceEngineContext engine, Vector2 position, float delay,
            bool triggerUnconstrained = true)
        {
            var scene = engine.Frame.Scenes.CurrentScene;
            foreach (var item in ((ISourceScene)scene).SourceScene.Entities.FindAll<OriginalRumbleTriggerState>())
                item.InvokeAtPosition(position, delay, triggerUnconstrained);
        }
    }
}
