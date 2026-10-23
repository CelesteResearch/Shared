using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Identifiers;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities.LightSources.Torches
{
    public class OriginalTorchState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        public const float BloomAlpha = 0.5f;

        public const int StartRadius = 48;

        public const int EndRadius = 64;

        private PackedColor Color => ((IOriginalTorchColorsEnvironment)engine).TorchColors.Color;

        private PackedColor StartLitColor => ((IOriginalTorchColorsEnvironment)engine).TorchColors.StartLitColor;

        private readonly MapEntityId id;

        private bool lit;

        private readonly VertexLightState light;

        private readonly BloomPointState bloom;

        private bool startLit;

        private readonly Sprite sprite;

        protected ref bool SourceStartLit => ref startLit;

        private string FlagName => "torch_" + EntityIdCodec.Format(id);

        public OriginalTorchState(ISourceEngineContext engine, MapEntityId id, Vector2 position, bool startLit)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            this.id = id;
            this.startLit = startLit;
            Collider = new HitboxColliderGeometry(32f, 32f, -16f, -16f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(light = new(engine, Color, 1f, 48, 64));
            OwnedComponents.Add(bloom = new(0.5f, 8f));
            bloom.Visible = false;
            light.Visible = false;
            Depth = 2000;
            if (startLit)
            {
                light.Color = StartLitColor;
                OwnedComponents.Add(sprite =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("litTorch"));
            }
            else
            {
                OwnedComponents.Add(sprite =
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("torch"));
            }
        }

        public OriginalTorchState(ISourceEngineContext engine, EntityData data, Vector2 offset, MapEntityId id)
            : this(engine, id, SourceVector2Math.Add(data.Position, offset),
                EntityAttributeReader.Bool(data.Values, "startLit"))
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (!(startLit || (Scene as OriginalLevelSceneRoot).Session.GetFlag(FlagName)))
                return;
            bloom.Visible = light.Visible = true;
            lit = true;
            Collidable = false;
            sprite.Play("on");
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (!lit)
            {
                ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/05_mirror_temple/torch_activate",
                    Position, ((IOriginalGameplayProcess)engine).SaveContext);
                lit = true;
                bloom.Visible = true;
                light.Visible = true;
                Collidable = false;
                sprite.Play("turnOn");
                var tween = TorchLightingTransition.Create(engine, light, bloom, 48f, 64f, .5f,
                    t => light.Color = PackedColor.Lerp(PackedColor.White, Color, t.Eased));
                OwnedComponents.Add(tween);
                (Scene as OriginalLevelSceneRoot).Session.SetFlag(FlagName);
                (Scene as OriginalLevelSceneRoot).ParticlesFG.Emit(
                    ((IOriginalGameplayProcess)engine).ParticleTypes.Torch.P_OnLight, 12, Position,
                    new(3f, 3f));
            }
        }
    }
}
