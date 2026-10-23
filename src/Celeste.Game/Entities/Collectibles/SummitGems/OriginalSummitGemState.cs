using Celeste.Core.Display;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Gameplay.Effects.Slashes;
using Celeste.Graphics.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Timing;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Audio;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Entities.Collectibles.Hearts;
using Celeste.Game.Entities.Effects.AbsorbOrbs;
using Celeste.Game.Presentation.Particles;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Particles.Sources;
using Celeste.Core.Rendering;

namespace Celeste.Game.Entities.Collectibles.SummitGems
{
    public class OriginalSummitGemState : SceneEntityState
    {
        private class BgFlash : SceneEntityState
        {
            private readonly ISourceEngineContext engine;
            private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

            private global::Celeste.Graphics.Content.Atlas.AtlasData GameAtlas =>
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

            private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
            private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
            private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;

            private global::Celeste.Scene.Components.Oscillation.WigglerComponentPool WigglerPool =>
                ((ISourceWigglerPoolScope)engine).WigglerPool;

            private float alpha = 1f;

            public BgFlash(ISourceEngineContext engine)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
            {
                this.engine = engine;
                base.Depth = 10100;
                Tags = ((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value;
            }

            public override void Update()
            {
                base.Update();
                alpha = ScalarMath.Approach(alpha, 0f, engine.DeltaTime * 0.5f, Extrema);
                if (alpha <= 0f)
                {
                    RemoveSelf();
                }
            }

            public override void Render(ISourceRenderContext context)
            {
                Vector2 position = (base.Scene as OriginalLevelSceneRoot).Camera.Position;
                SourcePrimitiveDrawing.Rect(context, this, position.X - 10f, position.Y - 10f, 340f, 200f,
                    PackedColor.Black * alpha);
            }
        }

        private global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation P_Shatter =>
            Process.ParticleTypes.SummitGem.P_Shatter;

        public static readonly PackedColor[] GemColors = new PackedColor[6]
        {
            PackedColor.FromHex("9ee9ff"),
            PackedColor.FromHex("54baff"),
            PackedColor.FromHex("90ff2d"),
            PackedColor.FromHex("ffd300"),
            PackedColor.FromHex("ff609d"),
            PackedColor.FromHex("c5e1ba")
        };

        public int GemID;

        public MapEntityId GID;


        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private global::Celeste.Graphics.Content.Atlas.AtlasData GameAtlas =>
            ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;

        private global::Celeste.Scene.Components.Oscillation.WigglerComponentPool WigglerPool =>
            ((ISourceWigglerPoolScope)engine).WigglerPool;

        private Sprite sprite;

        private WigglerComponent scaleWiggler;

        private Vector2 moveWiggleDir;

        private WigglerComponent moveWiggler;

        private float bounceSfxDelay;

        public OriginalSummitGemState(ISourceEngineContext engine, EntityData data, Vector2 position,
            MapEntityId gid)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + position)
        {
            this.engine = engine;
            GID = gid;
            GemID = global::Celeste.Formats.Map.Entities.Attributes.EntityAttributeReader
                .Int(data.Values, "gem", 0);
            base.Collider = new HitboxColliderGeometry(12f, 12f, -6f, -6f);
            OwnedComponents.Add(sprite = new Sprite(engine, GameAtlas, "collectables/summitgems/" + GemID + "/gem"));
            sprite.AddLoop("idle", "", 0.08f);
            sprite.Play("idle");
            sprite.CenterOrigin();
            if (Process.SaveContext.CurrentSave.SummitGems != null && Process.SaveContext.CurrentSave.SummitGems[GemID])
            {
                sprite.Color = PackedColor.White * 0.5f;
            }

            OwnedComponents.Add(scaleWiggler =
                WigglerPool.Create(0.5f, 4f, delegate(float f) { sprite.Scale = Vector2.One * (1f + f * 0.3f); }));
            moveWiggler = WigglerPool.Create(0.8f, 2f);
            moveWiggler.StartZero = true;
            OwnedComponents.Add(moveWiggler);
            OwnedComponents.Add(
                new global::Celeste.Simulation.Gameplay.Player.Collision.Components.PlayerColliderComponentState(
                    OnPlayer));
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            if (player.DashAttacking)
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, SmashRoutine(player, level)));
                return;
            }

            player.PointBounce(base.Center);
            moveWiggler.Start();
            scaleWiggler.Start();
            moveWiggleDir = VectorArithmetic.SafeNormalize(base.Center - player.Center, Vector2.UnitY);
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 1);
            if (bounceSfxDelay <= 0f)
            {
                Process.AudioSession.Play("event:/game/general/crystalheart_bounce", Position, Process.SaveContext);
                bounceSfxDelay = 0.1f;
            }
        }

        private IEnumerator SmashRoutine(RoomPlayerSession player, OriginalLevelSceneRoot level)
        {
            Visible = false;
            Collidable = false;
            player.Data.Stamina = 110f;
            global::Celeste.Simulation.Audio.Emitters.SoundEmitterState.Play("event:/game/07_summit/gem_get", this,
                engine);
            ChapterCompletionSession session = (base.Scene as OriginalLevelSceneRoot).Session;
            session.DoNotLoad.Add(GID);
            session.SummitGems[GemID] = true;
            Process.SaveContext.CurrentSave.RegisterSummitGem(GemID);
            level.Shake();
            OriginalCelesteFreeze.Freeze(engine, 0.1f);
            P_Shatter.Color = GemColors[GemID];
            float num = Vector2Geometry.Angle(player.Data.Motion.Normal.Speed);
            level.ParticlesFG.Emit(P_Shatter, 5, Position, Vector2.One * 4f, num - (float)Math.PI / 2f);
            level.ParticlesFG.Emit(P_Shatter, 5, Position, Vector2.One * 4f, num + (float)Math.PI / 2f);
            OriginalSlashFxState.Burst(engine, Position, num);
            for (int i = 0; i < 10; i++)
            {
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(
                    new OriginalAbsorbOrbState(engine, Position, player));
            }

            level.Flash(PackedColor.White, drawPlayerOver: true);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new BgFlash(engine));
            engine.Effects.TimeRate = 0.5f;
            while (engine.Effects.TimeRate < 1f)
            {
                engine.Effects.TimeRate += engine.RawDeltaTime * 0.5f;
                yield return null;
            }

            RemoveSelf();
        }

        public override void Update()
        {
            base.Update();
            bounceSfxDelay -= engine.DeltaTime;
            sprite.Position = moveWiggleDir * moveWiggler.Value * -8f;
        }
    }
}
