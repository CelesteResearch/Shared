using Celeste.Core.Display;
using Celeste.Graphics.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Player.Scene;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Simulation.Presentation.Decals.Entities
{
    public partial class SourceDecalEntityState : SceneEntityState
    {
        public Celeste.Core.Scheduling.ISourceEngineContext EngineContext { get; }
        public string Name;
        public float AnimationSpeed = 12f;
        public bool IsCrack;
        public List<AtlasEntry> Textures { get; private set; }
        public Vector2 Scale;
        public float Frame;
        public float Rotation;
        public PackedColor Color = PackedColor.White;
        private float hideRange = 32f;
        private float showRange = 48f;
        public bool Animated = true;
        public bool Parallax;
        public float ParallaxAmount;
        public bool ScaredAnimal;
        public SineWaveState Wave;
        public SourceComponentState Image { get; private set; }

        public SourceDecalEntityState(Celeste.Core.Scheduling.ISourceEngineContext engine, string name,
            Vector2 position,
            Vector2 scale, int depth,
            AtlasData atlas) : base(
            ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
            position)
        {
            EngineContext = engine;
            Name = name;
            Scale = scale;
            Depth = depth;
            Textures = atlas.GetAtlasSubtextures(name);
        }

        public void RemoveImage()
        {
            OwnedComponents.Remove(Image);
            Image = null;
        }

        public void MakeFlagSwap(string flag, List<AtlasEntry> off, List<AtlasEntry> on)
        {
            var image = new SourceDecalFlagSwapComponent(flag, off, on);
            AddImage(image);
        }

        public void EnsureDefaultImage()
        {
            if (Image == null) AddImage(new SourceDecalImageComponent());
        }

        public void AddImage(SourceComponentState component)
        {
            Image = component;
            OwnedComponents.Add(component);
        }

        public void MakeParallax(float amount)
        {
            Parallax = true;
            ParallaxAmount = amount;
        }

        public void MakeFloaty(ISourceRandom random)
        {
            Wave = new SineWaveState(EngineContext, .1f + (float)random.NextDouble() * (.4f - .1f),
                (float)random.NextDouble() * ((float)Math.PI * 2f));
            OwnedComponents.Add(Wave);
        }

        public void MakeBanner(ISourceRandom random, float speed, float amplitude, int sliceSize,
            float sliceSinIncrement, bool easeDown, float offset = 0f, bool onlyIfWindy = false)
        {
            var banner = new SourceDecalBannerComponent(random)
            {
                WaveSpeed = speed, WaveAmplitude = amplitude, SliceSize = sliceSize,
                SliceSinIncrement = sliceSinIncrement, EaseDown = easeDown,
                Offset = offset, OnlyIfWindy = onlyIfWindy
            };
            foreach (var texture in Textures)
            {
                var slices = new List<AtlasEntry>();
                for (int i = 0; i < texture.FrameHeight; i += sliceSize)
                    slices.Add(texture.GetSubtexture(0, i, texture.FrameWidth, sliceSize));
                banner.Segments.Add(slices);
            }

            AddImage(banner);
        }

        public void MakeScaredAnimation(ISourceRandom random)
        {
            var sprite = new Sprite(EngineContext, null, null);
            sprite.AddLoop("hidden", .1f, Textures[0]);
            sprite.Add("return", .1f, new Chooser<string>("idle", 1f), Textures[1]);
            sprite.AddLoop("idle", .1f, Textures[2], Textures[3], Textures[4], Textures[5], Textures[6], Textures[7]);
            sprite.Add("hide", .1f, new Chooser<string>("hidden", 1f), Textures[8], Textures[9], Textures[10],
                Textures[11],
                Textures[12]);
            sprite.Play("idle", restart: true);
            sprite.Scale = Scale;
            sprite.Rotation = Rotation;
            sprite.CenterOrigin();
            AddImage(sprite);
            ScaredAnimal = true;
        }

        public void MakeAnimation(int[] frames)
        {
            var textures = new List<AtlasEntry>(frames.Length);
            foreach (int frame in frames) textures.Add(Textures[frame]);
            Textures = textures;
        }

        public void MakeScaredAnimation(ISourceRandom random, int hideRange, int showRange,
            int[] idleFrames, int[] hiddenFrames, int[] showFrames, int[] hideFrames)
        {
            var sprite = new Sprite(EngineContext, null, null);
            sprite.AddLoop("hidden", .1f, SelectFrames(hiddenFrames));
            sprite.Add("return", .1f, new Chooser<string>("idle", 1f), SelectFrames(showFrames));
            sprite.AddLoop("idle", .1f, SelectFrames(idleFrames));
            sprite.Add("hide", .1f, new Chooser<string>("hidden", 1f), SelectFrames(hideFrames));
            sprite.Play("idle", restart: true);
            sprite.Scale = Scale;
            sprite.Rotation = Rotation;
            sprite.CenterOrigin();
            AddImage(sprite);
            this.hideRange = hideRange;
            this.showRange = showRange;
            ScaredAnimal = true;
        }

        private AtlasEntry[] SelectFrames(int[] frames)
        {
            var selected = new AtlasEntry[frames.Length];
            for (int i = 0; i < frames.Length; i++) selected[i] = Textures[frames[i]];
            return selected;
        }

        public override void Update()
        {
            if (Animated && Textures.Count > 1)
            {
                Frame += AnimationSpeed * EngineContext.DeltaTime;
                Frame %= Textures.Count;
            }

            if (ScaredAnimal)
            {
                var sprite = Image as Sprite;
                var player =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (player != null)
                {
                    if (sprite.CurrentAnimationID == "idle" &&
                        ((Celeste.Core.Mathematics.ISourceVectorEnvironment)EngineContext).VectorArithmetic.Length(
                            player.Position - Position) < hideRange)
                        sprite.Play("hide");
                    else if (sprite.CurrentAnimationID == "hidden" &&
                             ((Celeste.Core.Mathematics.ISourceVectorEnvironment)EngineContext).VectorArithmetic.Length(
                                 player.Position - Position) > showRange)
                        sprite.Play("return");
                }
            }

            base.Update();
        }

        protected virtual Vector2 ParallaxCenter
        {
            get
            {
                var camera = ((ISourceCameraScene)Scene).Camera;
                return camera.Position + new Vector2(camera.Viewport.Width, camera.Viewport.Height) * .5f;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 position = Position;
            if (Parallax)
            {
                Position += (Position - ParallaxCenter) * ParallaxAmount;
            }

            if (Wave != null) Position = new Vector2(Position.X, Position.Y + Wave.Value * 4f);
            base.Render(context);
            Position = position;
        }
    }
}
