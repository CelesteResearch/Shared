using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Doors.Ridge
{
    public class OriginalRidgeGateState : SourceSolidEntityState
    {
        private Vector2? node;
        protected readonly ISourceEngineContext engine;

        public OriginalRidgeGateState(ISourceEngineContext engine, EntityData data, Vector2 offset,
            ISourceSolidWorld world)
            : this(engine, SourceVector2Math.Add(data.Position, offset), data.Width, data.Height,
                data.FirstNodeNullable(offset), EntityAttributeReader.Bool(data.Values, "ridge", true), world)
        {
        }

        public OriginalRidgeGateState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2? node, bool ridgeImage, ISourceSolidWorld world)
            : this(engine, position, width, height, node, ridgeImage ? "objects/ridgeGate" : "objects/farewellGate",
                world)
        {
        }

        public OriginalRidgeGateState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2? node, ISourceSolidWorld world)
            : this(engine, position, width, height, node, true, world)
        {
        }

        protected OriginalRidgeGateState(ISourceEngineContext engine, Vector2 position, float width, float height,
            Vector2? node, string texture, ISourceSolidWorld world)
            : base(position, width, height, true, world)
        {
            this.engine = engine;
            this.node = node;
            OwnedComponents.Add(
                new SpriteImage(((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas[texture]));
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (node.HasValue && CollideCheck(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName))

            {
                Visible = (Collidable = false);
                Vector2 position = Position;
                Position = node.Value;
                OwnedComponents.Add(new SimulationCoroutine(engine, EnterSequence(position)));
            }
        }

        private IEnumerator EnterSequence(Vector2 moveTo)
        {
            OriginalRidgeGateState ridgeGate = this;
            OriginalRidgeGateState ridgeGate2 = this;
            bool visible = true;
            ridgeGate2.Collidable = true;
            ridgeGate.Visible = visible;
            yield return 0.25f;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/04_cliffside/stone_blockade",
                Position);
            yield return 0.25f;
            Vector2 start = Position;
            SourceTweenState tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut, 1f, start: true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                MoveTo(Vector2Interpolation.Lerp(start, moveTo, t.Eased,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic));
            };
            OwnedComponents.Add(tween);
        }
    }
}
