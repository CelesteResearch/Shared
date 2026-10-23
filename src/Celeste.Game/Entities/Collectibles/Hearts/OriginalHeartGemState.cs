using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Entities.Birds;
using Celeste.Game.Entities.Platforms.Barriers;
using Celeste.Game.Presentation.Hud.Poems;
using Celeste.Graphics.Animation;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation.Audio.Emitters;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Presentation.Effects.Mirrors;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
// Actual HeartGem source actor. Required process services are borrowed at their source points.
    public partial class OriginalHeartGemState : SceneEntityState
    {
        private const string FAKE_HEART_FLAG = "fake_heart";
        public bool IsGhost;
        public const float GhostAlpha = 0.8f;
        public bool IsFake;
        private Sprite sprite;
        private Sprite white;
        private ParticleTypePresentation shineParticle;
        public WigglerComponent ScaleWiggler;
        private WigglerComponent moveWiggler;
        private Vector2 moveWiggleDir;
        private BloomPointState bloom;
        private VertexLightState light;
        private PoemState poem;
        private BirdNpcState bird;
        private SoundEmitterState sfx;
        private readonly string fakeHeartDialog;
        private readonly string keepGoingDialog;
        private float timer;
        private bool collected;
        private readonly bool autoPulse = true;
        private float bounceSfxDelay;
        private readonly bool removeCameraTriggers;
        private readonly List<OriginalInvisibleBarrierState> walls = [];
        private readonly HoldableColliderState holdableCollider;
        private MapEntityId entityID;
        private OriginalInvisibleBarrierState fakeRightWall;
        private readonly ISourceEngineContext engine;

        public OriginalHeartGemState(ISourceEngineContext engine, Vector2 position)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            OwnedComponents.Add(holdableCollider = new(OnHoldable));
            OwnedComponents.Add(new MirrorReflectionState());
        }

        public OriginalHeartGemState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : this(engine, data.Position + offset)
        {
            removeCameraTriggers = EntityAttributeReader.Bool(data.Values, "removeCameraTriggers");
            IsFake = EntityAttributeReader.Bool(data.Values, "fake");
            entityID = new(
                ((OriginalLevelEntityData)data).Level.Name, data.ID);
            if (((IOriginalHeartGemEnvironment)engine).HeartGemPolicy.InstalledDialogs)
            {
                fakeHeartDialog = EntityAttributeReader.Attr(data.Values, "fakeHeartDialog", "CH9_FAKE_HEART");
                keepGoingDialog = EntityAttributeReader.Attr(data.Values, "keepGoingDialog", "CH9_KEEP_GOING");
            }
        }
    }
}
