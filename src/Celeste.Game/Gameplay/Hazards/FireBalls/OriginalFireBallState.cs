using System.Numerics;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Animation;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Gameplay.Hazards.FireBalls
{
    public partial class OriginalFireBallState : SceneEntityState
    {
        private readonly IOriginalFireBallProcess engine;

        private const float FireSpeed = 60f;

        private const float IceSpeed = 30f;

        private const float IceSpeedMult = 0.5f;

        private readonly Vector2[] nodes;

        private readonly int amount;

        private readonly int index;

        private readonly float offset;

        private readonly float[] lengths;

        private readonly float speed;

        private float speedMult;

        private float percent;

        private bool iceMode;

        private bool broken;

        private readonly float mult;

        private readonly bool notCoreMode;

        private readonly SoundSourceComponentState trackSfx;

        private readonly Sprite sprite;

        private readonly WigglerComponent hitWiggler;

        private Vector2 hitDir;

        public OriginalFireBallState(Vector2[] nodes, int amount, int index, float offset, float speedMult,
            bool notCoreMode, IOriginalFireBallProcess engine)
            : base(engine.EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = OriginalSceneTags.TransitionUpdate;
            Collider = new CircleColliderGeometry(engine.VectorArithmetic, 6f);
            this.nodes = nodes;
            this.amount = amount;
            this.index = index;
            this.offset = offset;
            mult = speedMult;
            this.notCoreMode = notCoreMode;
            lengths = new float[nodes.Length];
            for (var i = 1; i < lengths.Length; i++)
                lengths[i] = lengths[i - 1] + engine.VectorArithmetic.Distance(nodes[i - 1], nodes[i]);

            speed = 60f / lengths[lengths.Length - 1] * mult;
            if (index == 0)
                percent = 0f;
            else
                percent = index / (float)amount;

            percent += 1f / amount * offset;
            percent %= 1f;
            Position = GetPercentPosition(percent);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(
                new PlayerColliderComponentState(OnBounce, new HitboxColliderGeometry(16f, 6f, -8f, -3f)));
            OwnedComponents.Add(new CoreModeListenerState(OnChangeMode));
            OwnedComponents.Add(sprite = engine.GameGraphics.SpriteFactory.Create("fireball"));
            OwnedComponents.Add(hitWiggler = engine.WigglerPool.Create(1.2f, 2f));
            hitWiggler.StartZero = true;
            if (index == 0) OwnedComponents.Add(trackSfx = engine.SoundSources.Create());
        }

        public OriginalFireBallState(EntityData data, Vector2 offset, IOriginalFireBallProcess engine)
            : this(data.NodesWithPosition(offset), EntityAttributeReader.Int(data.Values, "amount", 1), 0,
                EntityAttributeReader.Float(data.Values, "offset"),
                EntityAttributeReader.Float(data.Values, "speed", 1f),
                EntityAttributeReader.Bool(data.Values, "notCoreMode"), engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            iceMode = ((OriginalLevelSceneRoot)Scene).CoreMode == RoomCoreMode.Cold || notCoreMode;
            speedMult = !iceMode ? 1 : 0;
            sprite.Play(iceMode ? "ice" : "hot", false, true);
            if (index == 0)
                for (var i = 1; i < amount; i++)
                    ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                        new OriginalFireBallState(nodes, amount, i, offset, mult, notCoreMode, engine));

            if (trackSfx != null && !iceMode)
            {
                PositionTrackSfx();
                trackSfx.Play("event:/env/local/09_core/fireballs_idle");
            }
        }
    }
}
