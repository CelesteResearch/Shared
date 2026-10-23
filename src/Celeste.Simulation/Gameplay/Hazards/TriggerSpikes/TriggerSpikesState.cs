using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Collision.Blockers;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;
using Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.Components;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Simulation.Gameplay.Hazards.TriggerSpikes
{
    public class TriggerSpikesState : SceneEntityState
    {
        public struct SpikeInfo
        {
            public TriggerSpikesState Parent;

            public int Index;

            public Vector2 WorldPosition;

            public bool Triggered;

            public float RetractTimer;

            public float DelayTimer;

            public float Lerp;

            public float ParticleTimerOffset;

            public int TextureIndex;

            public float TextureRotation;

            public int DustOutDistance;

            public int TentacleColor;

            public float TentacleFrame;

            public void Update()
            {
                if (Triggered)
                {
                    if (DelayTimer > 0f)
                    {
                        DelayTimer -= Parent.EngineDelta;
                        if (DelayTimer <= 0f)
                        {
                            if (PlayerCheck())
                                DelayTimer = 0.05f;
                            else
                                Parent.PlaySound("event:/game/03_resort/fluff_tendril_emerge", WorldPosition);
                        }
                    }
                    else
                    {
                        Lerp = ScalarMath.Approach(Lerp, 1f, 8f * Parent.EngineDelta);
                    }

                    TextureRotation += Parent.EngineDelta * 1.2f;
                }
                else
                {
                    Lerp = ScalarMath.Approach(Lerp, 0f, 4f * Parent.EngineDelta);
                    TentacleFrame += Parent.EngineDelta * 12f;
                    if (Lerp <= 0f) Triggered = false;
                }
            }

            public bool PlayerCheck()
            {
                return Parent.PlayerCheck(Index);
            }

            public bool OnPlayer(RoomPlayerSession player, Vector2 outwards)
            {
                if (!Triggered)
                {
                    Parent.PlaySound("event:/game/03_resort/fluff_tendril_touch", WorldPosition);
                    Triggered = true;
                    DelayTimer = 0.4f;
                    RetractTimer = 6f;
                }
                else if (Lerp >= 1f)
                {
                    player.Die(outwards);
                    return true;
                }

                return false;
            }
        }

        private const float RetractTime = 6f;

        private const float DelayTime = 0.4f;

        private readonly Vector2 outwards;

        private Vector2 offset;

        private readonly PlayerColliderComponentState pc;

        private Vector2 shakeOffset;

        private SpikeInfo[] spikes;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public SpikeInfo[] SourceSpikes => spikes;
        public TriggerSpikesDirection SourceDirection { get; }

        private List<AtlasEntry> dustTextures;

        private readonly List<AtlasEntry> tentacleTextures;

        private PackedColor[] tentacleColors;

        protected int SourceSize { get; }

        public TriggerSpikesState(Vector2 position, int size, TriggerSpikesDirection direction,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            SourceSize = size;
            SourceDirection = direction;
            switch (direction)
            {
                case TriggerSpikesDirection.Up:
                    tentacleTextures =
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                            "danger/triggertentacle/wiggle_v");
                    outwards = new(0f, -1f);
                    offset = new(0f, -1f);
                    Collider = new HitboxColliderGeometry(size, 4f, 0f, -4f);
                    OwnedComponents.Add(new SafeGroundBlockerComponentState());
                    OwnedComponents.Add(new LedgeBlockerState(player => UpSafeBlockCheck((RoomPlayerSession)player)));
                    break;
                case TriggerSpikesDirection.Down:
                    tentacleTextures =
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                            "danger/triggertentacle/wiggle_v");
                    outwards = new(0f, 1f);
                    Collider = new HitboxColliderGeometry(size, 4f);
                    break;
                case TriggerSpikesDirection.Left:
                    tentacleTextures =
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                            "danger/triggertentacle/wiggle_h");
                    outwards = new(-1f, 0f);
                    Collider = new HitboxColliderGeometry(4f, size, -4f);
                    OwnedComponents.Add(new SafeGroundBlockerComponentState());
                    OwnedComponents.Add(new LedgeBlockerState(player => SideSafeBlockCheck((RoomPlayerSession)player)));
                    break;
                case TriggerSpikesDirection.Right:
                    tentacleTextures =
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                            "danger/triggertentacle/wiggle_h");
                    outwards = new(1f, 0f);
                    offset = new(1f, 0f);
                    Collider = new HitboxColliderGeometry(4f, size);
                    OwnedComponents.Add(new SafeGroundBlockerComponentState());
                    OwnedComponents.Add(new LedgeBlockerState(player => SideSafeBlockCheck((RoomPlayerSession)player)));
                    break;
            }

            pc = new(OnCollide);
            OwnedComponents.Add(pc);
            OwnedComponents.Add(new SourceStaticMoverState
            {
                OnShake = OnShake,
                SolidChecker = IsRiding,
                JumpThruChecker = IsRiding,
            });
            OwnedComponents.Add(new DustEdgePresentation(RenderSpikes));
            Depth = -50;
        }

        public override void Added(object actualScene)
        {
            base.Added(actualScene);
            var scene = (ISourceSpikeScene)actualScene;
            var engine = (ISourceGameGraphicsEnvironment)scene.EngineContext;
            var edgeColors = ((ISourceDustStyleEnvironment)scene.EngineContext).DustStyles
                .GetStyle(((IDustGraphicScene)actualScene).DustAreaID).EdgeColors;
            dustTextures = engine.GameGraphics.GameAtlas.GetAtlasSubtextures("danger/dustcreature/base");
            tentacleColors = new PackedColor[edgeColors.Length];
            for (var i = 0; i < tentacleColors.Length; i++)
                tentacleColors[i] = PackedColor.Lerp(new(edgeColors[i]), PackedColor.DarkSlateBlue, 0.4f);

            var vector = new Vector2(Math.Abs(outwards.Y), Math.Abs(outwards.X));
            spikes = new SpikeInfo[SourceSize / 4];
            for (var j = 0; j < SourceSpikes.Length; j++)
            {
                SourceSpikes[j].Parent = this;
                SourceSpikes[j].Index = j;
                SourceSpikes[j].WorldPosition = Position + vector * (2 + j * 4);
                SourceSpikes[j].ParticleTimerOffset = (float)scene.SpikeRandom.NextDouble() * 0.25f;
                SourceSpikes[j].TextureIndex = scene.SpikeRandom.Next(dustTextures.Count);
                SourceSpikes[j].DustOutDistance = new[] { 3, 4, 6 }[scene.SpikeRandom.Next(3)];
                SourceSpikes[j].TentacleColor = scene.SpikeRandom.Next(tentacleColors.Length);
                SourceSpikes[j].TentacleFrame = (float)scene.SpikeRandom.NextDouble() * tentacleTextures.Count;
            }
        }

        private void OnShake(Vector2 amount)
        {
            shakeOffset += amount;
        }

        private bool UpSafeBlockCheck(RoomPlayerSession player)
        {
            var num = 8 * player.Facing;
            var num2 = (int)((player.Left + num - Left) / 4f);
            var num3 = (int)((player.Right + num - Left) / 4f);
            if (num3 < 0 || num2 >= SourceSpikes.Length) return false;

            num2 = Math.Max(num2, 0);
            num3 = Math.Min(num3, SourceSpikes.Length - 1);
            for (var i = num2; i <= num3; i++)
                if (SourceSpikes[i].Lerp >= 1f)
                    return true;

            return false;
        }

        private bool SideSafeBlockCheck(RoomPlayerSession player)
        {
            var num = (int)((player.Top - Top) / 4f);
            var num2 = (int)((player.Bottom - Top) / 4f);
            if (num2 < 0 || num >= SourceSpikes.Length) return false;

            num = Math.Max(num, 0);
            num2 = Math.Min(num2, SourceSpikes.Length - 1);
            for (var i = num; i <= num2; i++)
                if (SourceSpikes[i].Lerp >= 1f)
                    return true;

            return false;
        }

        private void OnCollide(RoomPlayerSession player)
        {
            GetPlayerCollideIndex(player, out var minIndex, out var maxIndex);
            if (maxIndex >= 0 && minIndex < SourceSpikes.Length)
            {
                minIndex = Math.Max(minIndex, 0);
                maxIndex = Math.Min(maxIndex, SourceSpikes.Length - 1);
                for (var i = minIndex; i <= maxIndex && !SourceSpikes[i].OnPlayer(player, outwards); i++)
                {
                }
            }
        }

        protected virtual void GetPlayerCollideIndex(RoomPlayerSession player, out int minIndex, out int maxIndex)
        {
            TriggerSpikeCollision.GetPlayerCollideIndices(player, this, SourceDirection, 4f, out minIndex,
                out maxIndex);
        }

        private bool PlayerCheck(int spikeIndex)
        {
            var player = FirstPlayer();
            if (player != null)
            {
                GetPlayerCollideIndex(player, out var minIndex, out var maxIndex);
                if (minIndex <= spikeIndex + 1) return maxIndex >= spikeIndex - 1;

                return false;
            }

            return false;
        }

        public override void Update()
        {
            base.Update();
            for (var i = 0; i < SourceSpikes.Length; i++) SourceSpikes[i].Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            var vector = new Vector2(Math.Abs(outwards.Y), Math.Abs(outwards.X));
            var count = tentacleTextures.Count;
            var one = Vector2.One;
            var justify = new Vector2(0f, 0.5f);
            if (SourceDirection == TriggerSpikesDirection.Left)
                one.X = -1f;
            else if (SourceDirection == TriggerSpikesDirection.Up) one.Y = -1f;

            if (SourceDirection == TriggerSpikesDirection.Up || SourceDirection == TriggerSpikesDirection.Down)
                justify = new(0.5f, 0f);

            for (var i = 0; i < SourceSpikes.Length; i++)
                if (!SourceSpikes[i].Triggered)
                {
                    var mTexture = tentacleTextures[(int)(SourceSpikes[i].TentacleFrame % count)];
                    var vector2 = Position + vector * (2 + i * 4);
                    DrawJustified(context, mTexture, vector2 + vector, justify, PackedColor.Black, one, 0f);
                    DrawJustified(context, mTexture, vector2, justify, tentacleColors[SourceSpikes[i].TentacleColor],
                        one,
                        0f);
                }

            RenderSpikes(context);
        }

        private void RenderSpikes(ISourceRenderContext context)
        {
            var vector = new Vector2(Math.Abs(outwards.Y), Math.Abs(outwards.X));
            for (var i = 0; i < SourceSpikes.Length; i++)
                if (SourceSpikes[i].Triggered)
                {
                    var mTexture = dustTextures[SourceSpikes[i].TextureIndex];
                    var position =
                        Position + outwards * (-4f + SourceSpikes[i].Lerp * SourceSpikes[i].DustOutDistance) +
                        vector * (2 + i * 4);
                    DrawCentered(context, mTexture, position, PackedColor.White, 0.5f * SourceSpikes[i].Lerp,
                        SourceSpikes[i].TextureRotation);
                }
        }

        private bool IsRiding(SourceSolidEntityState solid)
        {
            return SourceDirection switch
            {
                TriggerSpikesDirection.Up => CheckOutside(solid, Position + Vector2.UnitY),
                TriggerSpikesDirection.Down => CheckOutside(solid, Position - Vector2.UnitY),
                TriggerSpikesDirection.Left => CheckOutside(solid, Position + Vector2.UnitX),
                TriggerSpikesDirection.Right => CheckOutside(solid, Position - Vector2.UnitX),
                _ => false,
            };
        }

        private bool IsRiding(ISourceJumpThruEntity jumpThru)
        {
            if (SourceDirection != TriggerSpikesDirection.Up) return false;

            return CheckAt(jumpThru, Position + Vector2.UnitY);
        }

        private float EngineDelta => ((ISourceSpikeScene)Scene).EngineContext.DeltaTime;

        private void PlaySound(string path, Vector2 at)
        {
            ((ISourceSpikeScene)Scene).PlaySpikeSound(path, at);
        }

        private RoomPlayerSession FirstPlayer()
        {
            foreach (var entity in ((ISourceSpikeScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         typeof(RoomPlayerSession).FullName))

                if (SourceEntityCollision.Check(this, (ISourceEntityCollider)entity))
                    return (RoomPlayerSession)entity;
            return null;
        }

        private bool CheckAt(ISourceEntityCollider other, Vector2 at)
        {
            var previous = Position;
            Position = at;
            var result = SourceEntityCollision.Check(this, other);
            Position = previous;
            return result;
        }

        private bool CheckOutside(ISourceEntityCollider other, Vector2 at)
        {
            return !SourceEntityCollision.Check(this, other) && CheckAt(other, at);
        }

        private void DrawJustified(ISourceRenderContext context, AtlasEntry texture, Vector2 at, Vector2 justify,
            PackedColor color, Vector2 scale, float rotation)
        {
            SourceAtlasDrawing.DrawJustified(context, this,
                texture, at, justify, color, scale, rotation);
        }

        private void DrawCentered(ISourceRenderContext context, AtlasEntry texture, Vector2 at, PackedColor color,
            float scale, float rotation)
        {
            SourceAtlasDrawing.DrawCentered(context, this,
                texture, at, color, new Vector2(scale), rotation);
        }
    }
}
