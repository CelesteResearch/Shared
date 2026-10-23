using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collision.Blockers;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;
using Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.Components;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;

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
                            {
                                DelayTimer = 0.05f;
                            }
                            else
                            {
                                Parent.PlaySound("event:/game/03_resort/fluff_tendril_emerge", WorldPosition);
                            }
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
                    if (Lerp <= 0f)
                    {
                        Triggered = false;
                    }
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

        private TriggerSpikesDirection direction;

        private Vector2 outwards;

        private Vector2 offset;

        private PlayerColliderComponentState pc;

        private Vector2 shakeOffset;

        private SpikeInfo[] spikes;
        public SpikeInfo[] SourceSpikes => spikes;
        public TriggerSpikesDirection SourceDirection => direction;

        private List<AtlasEntry> dustTextures;

        private List<AtlasEntry> tentacleTextures;

        private PackedColor[] tentacleColors;

        private int size;
        protected int SourceSize => size;

        public TriggerSpikesState(Vector2 position, int size, TriggerSpikesDirection direction,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.size = size;
            this.direction = direction;
            switch (direction)
            {
                case TriggerSpikesDirection.Up:
                    tentacleTextures =
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                            "danger/triggertentacle/wiggle_v");
                    outwards = new Vector2(0f, -1f);
                    offset = new Vector2(0f, -1f);
                    Collider = new HitboxColliderGeometry(size, 4f, 0f, -4f);
                    OwnedComponents.Add(new SafeGroundBlockerComponentState());
                    OwnedComponents.Add(new LedgeBlockerState(player => UpSafeBlockCheck((RoomPlayerSession)player)));
                    break;
                case TriggerSpikesDirection.Down:
                    tentacleTextures =
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                            "danger/triggertentacle/wiggle_v");
                    outwards = new Vector2(0f, 1f);
                    Collider = new HitboxColliderGeometry(size, 4f);
                    break;
                case TriggerSpikesDirection.Left:
                    tentacleTextures =
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                            "danger/triggertentacle/wiggle_h");
                    outwards = new Vector2(-1f, 0f);
                    Collider = new HitboxColliderGeometry(4f, size, -4f);
                    OwnedComponents.Add(new SafeGroundBlockerComponentState());
                    OwnedComponents.Add(new LedgeBlockerState(player => SideSafeBlockCheck((RoomPlayerSession)player)));
                    break;
                case TriggerSpikesDirection.Right:
                    tentacleTextures =
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                            "danger/triggertentacle/wiggle_h");
                    outwards = new Vector2(1f, 0f);
                    offset = new Vector2(1f, 0f);
                    Collider = new HitboxColliderGeometry(4f, size);
                    OwnedComponents.Add(new SafeGroundBlockerComponentState());
                    OwnedComponents.Add(new LedgeBlockerState(player => SideSafeBlockCheck((RoomPlayerSession)player)));
                    break;
            }

            pc = new PlayerColliderComponentState(OnCollide);
            OwnedComponents.Add(pc);
            OwnedComponents.Add(new SourceStaticMoverState
            {
                OnShake = OnShake,
                SolidChecker = IsRiding,
                JumpThruChecker = IsRiding
            });
            OwnedComponents.Add(new DustEdgePresentation(RenderSpikes));
            Depth = -50;
        }

        public override void Added(object actualScene)
        {
            base.Added(actualScene);
            var scene = (ISourceSpikeScene)actualScene;
            var engine = (ISourceGameGraphicsEnvironment)scene.EngineContext;
            Vector3[] edgeColors = ((ISourceDustStyleEnvironment)scene.EngineContext).DustStyles
                .GetStyle(((IDustGraphicScene)actualScene).DustAreaID).EdgeColors;
            dustTextures = engine.GameGraphics.GameAtlas.GetAtlasSubtextures("danger/dustcreature/base");
            tentacleColors = new PackedColor[edgeColors.Length];
            for (int i = 0; i < tentacleColors.Length; i++)
            {
                tentacleColors[i] = PackedColor.Lerp(new PackedColor(edgeColors[i]), PackedColor.DarkSlateBlue, 0.4f);
            }

            Vector2 vector = new Vector2(Math.Abs(outwards.Y), Math.Abs(outwards.X));
            spikes = new SpikeInfo[size / 4];
            for (int j = 0; j < spikes.Length; j++)
            {
                spikes[j].Parent = this;
                spikes[j].Index = j;
                spikes[j].WorldPosition = Position + vector * (2 + j * 4);
                spikes[j].ParticleTimerOffset = (float)scene.SpikeRandom.NextDouble() * 0.25f;
                spikes[j].TextureIndex = scene.SpikeRandom.Next(dustTextures.Count);
                spikes[j].DustOutDistance = new[] { 3, 4, 6 }[scene.SpikeRandom.Next(3)];
                spikes[j].TentacleColor = scene.SpikeRandom.Next(tentacleColors.Length);
                spikes[j].TentacleFrame = (float)scene.SpikeRandom.NextDouble() * tentacleTextures.Count;
            }
        }

        private void OnShake(Vector2 amount)
        {
            shakeOffset += amount;
        }

        private bool UpSafeBlockCheck(RoomPlayerSession player)
        {
            int num = 8 * (int)player.Facing;
            int num2 = (int)((player.Left + (float)num - Left) / 4f);
            int num3 = (int)((player.Right + (float)num - Left) / 4f);
            if (num3 < 0 || num2 >= spikes.Length)
            {
                return false;
            }

            num2 = Math.Max(num2, 0);
            num3 = Math.Min(num3, spikes.Length - 1);
            for (int i = num2; i <= num3; i++)
            {
                if (spikes[i].Lerp >= 1f)
                {
                    return true;
                }
            }

            return false;
        }

        private bool SideSafeBlockCheck(RoomPlayerSession player)
        {
            int num = (int)((player.Top - Top) / 4f);
            int num2 = (int)((player.Bottom - Top) / 4f);
            if (num2 < 0 || num >= spikes.Length)
            {
                return false;
            }

            num = Math.Max(num, 0);
            num2 = Math.Min(num2, spikes.Length - 1);
            for (int i = num; i <= num2; i++)
            {
                if (spikes[i].Lerp >= 1f)
                {
                    return true;
                }
            }

            return false;
        }

        private void OnCollide(RoomPlayerSession player)
        {
            GetPlayerCollideIndex(player, out var minIndex, out var maxIndex);
            if (maxIndex >= 0 && minIndex < spikes.Length)
            {
                minIndex = Math.Max(minIndex, 0);
                maxIndex = Math.Min(maxIndex, spikes.Length - 1);
                for (int i = minIndex; i <= maxIndex && !spikes[i].OnPlayer(player, outwards); i++)
                {
                }
            }
        }

        protected virtual void GetPlayerCollideIndex(RoomPlayerSession player, out int minIndex, out int maxIndex)
            => TriggerSpikeCollision.GetPlayerCollideIndices(player, this, direction, 4f, out minIndex, out maxIndex);

        private bool PlayerCheck(int spikeIndex)
        {
            RoomPlayerSession player = FirstPlayer();
            if (player != null)
            {
                GetPlayerCollideIndex(player, out var minIndex, out var maxIndex);
                if (minIndex <= spikeIndex + 1)
                {
                    return maxIndex >= spikeIndex - 1;
                }

                return false;
            }

            return false;
        }

        public override void Update()
        {
            base.Update();
            for (int i = 0; i < spikes.Length; i++)
            {
                spikes[i].Update();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
            Vector2 vector = new Vector2(Math.Abs(outwards.Y), Math.Abs(outwards.X));
            int count = tentacleTextures.Count;
            Vector2 one = Vector2.One;
            Vector2 justify = new Vector2(0f, 0.5f);
            if (direction == TriggerSpikesDirection.Left)
            {
                one.X = -1f;
            }
            else if (direction == TriggerSpikesDirection.Up)
            {
                one.Y = -1f;
            }

            if (direction == TriggerSpikesDirection.Up || direction == TriggerSpikesDirection.Down)
            {
                justify = new Vector2(0.5f, 0f);
            }

            for (int i = 0; i < spikes.Length; i++)
            {
                if (!spikes[i].Triggered)
                {
                    AtlasEntry mTexture = tentacleTextures[(int)(spikes[i].TentacleFrame % (float)count)];
                    Vector2 vector2 = Position + vector * (2 + i * 4);
                    DrawJustified(context, mTexture, vector2 + vector, justify, PackedColor.Black, one, 0f);
                    DrawJustified(context, mTexture, vector2, justify, tentacleColors[spikes[i].TentacleColor], one,
                        0f);
                }
            }

            RenderSpikes(context);
        }

        private void RenderSpikes(ISourceRenderContext context)
        {
            Vector2 vector = new Vector2(Math.Abs(outwards.Y), Math.Abs(outwards.X));
            for (int i = 0; i < spikes.Length; i++)
            {
                if (spikes[i].Triggered)
                {
                    AtlasEntry mTexture = dustTextures[spikes[i].TextureIndex];
                    Vector2 position = Position + outwards * (-4f + spikes[i].Lerp * (float)spikes[i].DustOutDistance) +
                                       vector * (2 + i * 4);
                    DrawCentered(context, mTexture, position, PackedColor.White, 0.5f * spikes[i].Lerp,
                        spikes[i].TextureRotation);
                }
            }
        }

        private bool IsRiding(SourceSolidEntityState solid)
        {
            return direction switch
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
            if (direction != TriggerSpikesDirection.Up)
            {
                return false;
            }

            return CheckAt(jumpThru, Position + Vector2.UnitY);
        }

        private float EngineDelta => ((ISourceSpikeScene)Scene).EngineContext.DeltaTime;
        private void PlaySound(string path, Vector2 at) => ((ISourceSpikeScene)Scene).PlaySpikeSound(path, at);

        private RoomPlayerSession FirstPlayer()
        {
            foreach (object entity in ((ISourceSpikeScene)Scene).SourceScene.Entities.GetTrackedEntities(
                         typeof(global::Celeste.Simulation.RoomPlayerSession).FullName))

                if (SourceEntityCollision.Check(this, (ISourceEntityCollider)entity))
                    return (RoomPlayerSession)entity;
            return null;
        }

        private bool CheckAt(ISourceEntityCollider other, Vector2 at)
        {
            Vector2 previous = Position;
            Position = at;
            bool result = SourceEntityCollision.Check(this, other);
            Position = previous;
            return result;
        }

        private bool CheckOutside(ISourceEntityCollider other, Vector2 at)
            => !SourceEntityCollision.Check(this, other) && CheckAt(other, at);

        private void DrawJustified(ISourceRenderContext context, AtlasEntry texture, Vector2 at, Vector2 justify,
            PackedColor color, Vector2 scale, float rotation)
            => global::Celeste.Graphics.Rendering.SourceAtlasDrawing.DrawJustified(context, this,
                texture, at, justify, color, scale, rotation);

        private void DrawCentered(ISourceRenderContext context, AtlasEntry texture, Vector2 at, PackedColor color,
            float scale, float rotation)
            => global::Celeste.Graphics.Rendering.SourceAtlasDrawing.DrawCentered(context, this,
                texture, at, color, new Vector2(scale), rotation);
    }
}
