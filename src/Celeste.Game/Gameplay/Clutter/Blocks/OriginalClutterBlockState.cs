using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Physics.Collision.Shapes;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Simulation.Gameplay.Clutter;
using Celeste.Game.Gameplay.Clutter.Absorption;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Gameplay.Clutter.Blocks
{
    public class OriginalClutterBlockState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        public ClutterColor BlockColor;
        public SpriteImage Image;
        public HashSet<OriginalClutterBlockState> HasBelow = new();
        public List<OriginalClutterBlockState> Below = new(), Above = new();
        public bool OnTheGround, TopSideOpen, LeftSideOpen, RightSideOpen;
        private float floatTarget;
        private float floatDelay;
        private float floatTimer;

        private float WaveTarget =>
            0f - ((float)Math.Sin((float)((int)Position.X / 16) * .25f + floatTimer * 2f) + 1f) / 2f - 1f;

        public OriginalClutterBlockState(Vector2 position, AtlasEntry texture, ClutterColor color,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            BlockColor = color;
            Image = new SpriteImage(texture);
            OwnedComponents.Add(Image);
            Collider = new HitboxColliderGeometry(texture.FrameWidth, texture.FrameHeight);
            Depth = -9998;
        }

        public void WeightDown()
        {
            foreach (var block in Below) block.WeightDown();
            floatTarget = 0f;
            floatDelay = .1f;
        }

        public override void Update()
        {
            base.Update();
            if (OnTheGround) return;
            if (floatDelay <= 0f)
            {
                var player =
                    ((ISourceScene)Scene).SourceScene.Entities
                    .GetTrackedEntity<global::Celeste.Simulation.RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (player != null)
                {
                    if ((TopSideOpen && player.Right > Left && player.Left < Right
                         && player.Bottom >= Top - 1f && player.Bottom <= Top + 4f)
                        | (player.Machine.State == 1 && LeftSideOpen && player.Right >= Left - 1f
                           && player.Right < Left + 4f && player.Bottom > Top
                           && player.Top < Bottom)
                        | (player.Machine.State == 1 && RightSideOpen && player.Left <= Right + 1f
                           && player.Left > Right - 4f && player.Bottom > Top
                           && player.Top < Bottom)) WeightDown();
                }
            }

            floatTimer += engine.DeltaTime;
            floatDelay -= engine.DeltaTime;
            if (floatDelay <= 0f)
                floatTarget = global::Celeste.Core.Mathematics.ScalarMath.Approach(floatTarget, WaveTarget,
                    engine.DeltaTime * 4f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            Image.Position.Y = floatTarget;
        }

        public void Absorb(OriginalClutterAbsorbEffectState effect)
        {
            effect.FlyClutter(Position + new Vector2(Image.Width * .5f, Image.Height * .5f + floatTarget),
                Image.Texture, true, SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, .5f));
            RemoveSelf();
        }
    }
}
