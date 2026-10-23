using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Oscillation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Display.Colors;
using Color = Celeste.Core.Display.PackedColor;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Physics.Collision.Shapes;
using Celeste.Simulation.Audio.Sources;
using Image = Celeste.Graphics.Animation.SpriteImage;
using MTexture = Celeste.Graphics.Content.Atlas.AtlasEntry;
using SineWave = Celeste.Scene.Components.Oscillation.SineWaveState;
using BloomPoint = Celeste.Simulation.Presentation.PostProcessing.Bloom.BloomPointState;
using VertexLight = Celeste.Simulation.Presentation.Lighting.VertexLightState;
using Hitbox = Celeste.Physics.Collision.Shapes.HitboxColliderGeometry;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;
using Player = Celeste.Simulation.RoomPlayerSession;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public class OriginalHangingLampState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        public readonly int Length;

        private List<Image> images = new List<Image>();

        private BloomPoint bloom;

        private VertexLight light;

        private float speed;

        private float rotation;

        private float soundDelay;

        private SoundSource sfx;

        private readonly Action playSwingSound;

        public OriginalHangingLampState(Vector2 position, int length, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = position + Vector2.UnitX * 4f;
            Length = Math.Max(16, length);
            base.Depth = 2000;
            MTexture mTexture = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/hanginglamp"];
            Image image = null;
            for (int i = 0; i < Length - 8; i += 8)
            {
                Add(image = new Image(mTexture.GetSubtexture(0, 8, 8, 8)));
                image.Origin.X = 4f;
                image.Origin.Y = -i;
                images.Add(image);
            }

            Add(image = new Image(mTexture.GetSubtexture(0, 0, 8, 8)));
            image.Origin.X = 4f;
            Add(image = new Image(mTexture.GetSubtexture(0, 16, 8, 8)));
            image.Origin.X = 4f;
            image.Origin.Y = -(Length - 8);
            images.Add(image);
            Add(bloom = new BloomPoint(Vector2.UnitY * (Length - 4), 1f, 48f));
            Add(light = new VertexLight(engine, Vector2.UnitY * (Length - 4), Color.White, 1f, 24, 48));
            Add(sfx = ((IOriginalWaterfallSoundEnvironment)engine).SoundSources.Create());
            playSwingSound = PlaySwingSound;
            base.Collider = new Hitbox(8f, Length, -4f);
        }

        public OriginalHangingLampState(EntityData e, Vector2 position, ISourceEngineContext engine)
            : this(position, Math.Max(16, e.Height), engine)
        {
        }

        public override void Update()
        {
            base.Update();
            soundDelay -= engine.DeltaTime;
            global::Celeste.Simulation.RoomPlayerSession entity =
                ((Level)Scene).Scheduler.Entities.GetTrackedEntity<global::Celeste.Simulation.RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
            var touchingPlayer = entity != null && base.Collider.Collide(entity.Collider);
            global::Celeste.Simulation.Gameplay.Environment.HangingLamps.HangingLampPhysics.Advance(
                ref speed, ref rotation, ref soundDelay, engine, touchingPlayer,
                touchingPlayer ? entity.Data.Motion.Normal.Speed.X : 0f,
                touchingPlayer ? entity.Y - Y : 0f, Length, null,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic, playSwingSound);

            foreach (Image image in images)
            {
                image.Rotation = rotation;
            }

            Vector2 vector = Vector2Geometry.AngleToVector(rotation + (float)Math.PI / 2f, (float)Length - 4f);
            BloomPoint bloomPoint = bloom;
            Vector2 position = (light.Position = vector);
            bloomPoint.Position = position;
            sfx.Position = vector;
        }

        private void PlaySwingSound()
        {
            sfx.Play("event:/game/02_old_site/lantern_hit");
        }

        public override void Render(ISourceRenderContext context)
        {
            foreach (SourceComponentState component in base.Components)
            {
                if (component is Image image)
                {
                    image.DrawOutline(context);
                }
            }

            base.Render(context);
        }
    }
}
