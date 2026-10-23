using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Physics.Collision;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Entities.Decoration.Computers
{
    public sealed class OriginalKevinsPCState : SourceActorEntityState
    {
        private SpriteImage image;
        private readonly ISourceEngineContext engine;

        private AtlasEntry spectogram;

        private AtlasEntry subtex;

        private SoundSourceComponentState sfx;

        private float timer;

        public OriginalKevinsPCState(Vector2 position, PixelActor body, ISourceEngineContext engine,
            IPlatformTargetMotionPolicy policy)
            : base(body, engine, policy)
        {
            this.engine = engine;
            Add(image = new SpriteImage(
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/kevinspc/pc"]));
            image.JustifyOrigin(0.5f, 1f);
            base.Depth = 8999;
            spectogram = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/kevinspc/spectogram"];
            subtex = spectogram.GetSubtexture(0, 0, 32, 18, subtex);
            Add(sfx = CreatePlayingSound("event:/new_content/env/local/kevinpc"));
            sfx.Position = new Vector2(0f, -16f);
            timer = 0f;
        }

        public OriginalKevinsPCState(EntityData data, Vector2 offset, PixelActor body,
            ISourceEngineContext engine, IPlatformTargetMotionPolicy policy)
            : this(data.Position + offset, body, engine, policy)
        {
        }

        public override bool IsRiding(ISourceEntityCollider solid)
        {
            return solid.Collidable &&
                   SourceEntityCollision.CheckRect(solid, new IntRect((int)base.X - 4, (int)base.Y, 8, 2));
        }

        public override void Update()
        {
            base.Update();
            timer += engine.DeltaTime;
            int num = spectogram.Width - 32;
            int x = (int)(timer * ((float)num / 22f) % (float)num);
            subtex = spectogram.GetSubtexture(x, 0, 32, 18, subtex);
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            if (subtex != null)
            {
                SourceAtlasDrawing.Draw(context, this, subtex, Position + new Vector2(-16f, -39f));
                SourcePrimitiveDrawing.Rect(context, this, base.X - 16f, base.Y - 39f, 32f, 18f,
                    PackedColor.Black * 0.25f);
            }
        }

        private SoundSourceComponentState CreatePlayingSound(string eventName)
        {
            var sound = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
            sound.Play(eventName);
            return sound;
        }

        public static OriginalKevinsPCState Create(OriginalLevelSceneRoot level, EntityData data, Vector2 offset)
        {
            var engine = level.EngineContext;
            return new OriginalKevinsPCState(data, offset,
                new PixelActor(((ISourcePlatformCollisionScene)level).PlatformWorld, data.Position + offset),
                engine, ((ISourcePlatformTargetMotionEnvironment)engine).TargetMotionPolicy);
        }
    }
}
