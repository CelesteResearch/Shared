using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.HangingLamps;
using Color = Celeste.Core.Display.PackedColor;
using Image = Celeste.Graphics.Animation.SpriteImage;
using BloomPoint = Celeste.Simulation.Presentation.PostProcessing.Bloom.BloomPointState;
using VertexLight = Celeste.Simulation.Presentation.Lighting.VertexLightState;
using Hitbox = Celeste.Physics.Collision.Shapes.HitboxColliderGeometry;
using SoundSource = Celeste.Simulation.Audio.Sources.SoundSourceComponentState;
using Level = Celeste.Game.Execution.Levels.OriginalLevelSceneRoot;

namespace Celeste.Game.Gameplay.Environment.Ridge
{
    public class OriginalHangingLampState : SceneEntityState, ISourceEngineContextEntity
    {
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        public readonly int Length;

        private readonly List<Image> images = [];

        private readonly BloomPoint bloom;

        private readonly VertexLight light;

        private float speed;

        private float rotation;

        private float soundDelay;

        private readonly SoundSource sfx;

        private readonly Action playSwingSound;

        public OriginalHangingLampState(Vector2 position, int length, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = position + Vector2.UnitX * 4f;
            Length = Math.Max(16, length);
            Depth = 2000;
            var mTexture = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/hanginglamp"];
            Image image = null;
            for (var i = 0; i < Length - 8; i += 8)
            {
                Add(image = new(mTexture.GetSubtexture(0, 8, 8, 8)));
                image.Origin.X = 4f;
                image.Origin.Y = -i;
                images.Add(image);
            }

            Add(image = new(mTexture.GetSubtexture(0, 0, 8, 8)));
            image.Origin.X = 4f;
            Add(image = new(mTexture.GetSubtexture(0, 16, 8, 8)));
            image.Origin.X = 4f;
            image.Origin.Y = -(Length - 8);
            images.Add(image);
            Add(bloom = new(Vector2.UnitY * (Length - 4), 1f, 48f));
            Add(light = new(engine, Vector2.UnitY * (Length - 4), Color.White, 1f, 24, 48));
            Add(sfx = ((IOriginalWaterfallSoundEnvironment)engine).SoundSources.Create());
            playSwingSound = PlaySwingSound;
            Collider = new Hitbox(8f, Length, -4f);
        }

        public OriginalHangingLampState(EntityData e, Vector2 position, ISourceEngineContext engine)
            : this(position, Math.Max(16, e.Height), engine)
        {
        }

        public override void Update()
        {
            base.Update();
            soundDelay -= engine.DeltaTime;
            var entity =
                ((Level)Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);
            var touchingPlayer = entity != null && Collider.Collide(entity.Collider);
            HangingLampPhysics.Advance(
                ref speed, ref rotation, ref soundDelay, engine, touchingPlayer,
                touchingPlayer ? entity.Data.Motion.Normal.Speed.X : 0f,
                touchingPlayer ? entity.Y - Y : 0f, Length, null,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic, playSwingSound);

            foreach (var image in images) image.Rotation = rotation;

            var vector = Vector2Geometry.AngleToVector(rotation + (float)Math.PI / 2f, Length - 4f);
            var bloomPoint = bloom;
            var position = light.Position = vector;
            bloomPoint.Position = position;
            sfx.Position = vector;
        }

        private void PlaySwingSound()
        {
            sfx.Play("event:/game/02_old_site/lantern_hit");
        }

        public override void Render(ISourceRenderContext context)
        {
            foreach (var component in Components)
                if (component is Image image)
                    image.DrawOutline(context);

            base.Render(context);
        }
    }
}
