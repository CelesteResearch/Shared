using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Actors.Foundation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Entities.Decoration.Computers
{
    public sealed class OriginalKevinsPCState : SourceActorEntityState
    {
        private readonly SpriteImage image;
        private readonly ISourceEngineContext engine;

        private readonly AtlasEntry spectogram;

        private AtlasEntry subtex;

        private readonly SoundSourceComponentState sfx;

        private float timer;

        public OriginalKevinsPCState(Vector2 position, PixelActor body, ISourceEngineContext engine,
            IPlatformTargetMotionPolicy policy)
            : base(body, engine, policy)
        {
            this.engine = engine;
            Add(image = new(
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/kevinspc/pc"]));
            image.JustifyOrigin(0.5f, 1f);
            Depth = 8999;
            spectogram = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["objects/kevinspc/spectogram"];
            subtex = spectogram.GetSubtexture(0, 0, 32, 18, subtex);
            Add(sfx = CreatePlayingSound("event:/new_content/env/local/kevinpc"));
            sfx.Position = new(0f, -16f);
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
                   SourceEntityCollision.CheckRect(solid, new((int)X - 4, (int)Y, 8, 2));
        }

        public override void Update()
        {
            base.Update();
            timer += engine.DeltaTime;
            var num = spectogram.Width - 32;
            var x = (int)(timer * (num / 22f) % num);
            subtex = spectogram.GetSubtexture(x, 0, 32, 18, subtex);
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            if (!(subtex != null))
                return;
            SourceAtlasDrawing.Draw(context, this, subtex, Position + new Vector2(-16f, -39f));
            SourcePrimitiveDrawing.Rect(context, this, X - 16f, Y - 39f, 32f, 18f,
                PackedColor.Black * 0.25f);
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
            return new(data, offset,
                new(level.PlatformWorld, data.Position + offset),
                engine, ((ISourcePlatformTargetMotionEnvironment)engine).TargetMotionPolicy);
        }
    }
}
