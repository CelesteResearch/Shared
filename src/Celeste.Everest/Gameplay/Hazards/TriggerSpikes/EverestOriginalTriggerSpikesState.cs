using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Collision.Blockers;
using Celeste.Simulation.Gameplay.Hazards.Spikes;
using Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.Components;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Everest.Gameplay.Hazards.TriggerSpikes
{
    [global::Celeste.Everest.Modules.Entities.Metadata.CustomEntity("triggerSpikesOriginalUp = LoadUp",
        "triggerSpikesOriginalDown = LoadDown", "triggerSpikesOriginalLeft = LoadLeft",
        "triggerSpikesOriginalRight = LoadRight")]
    public class EverestOriginalTriggerSpikesState : SceneEntityState, ISourceEngineContextEntity
    {
        public enum Directions
        {
            Up,
            Down,
            Left,
            Right
        }

        public struct SpikeInfo
        {
            public EverestOriginalTriggerSpikesState Parent;

            public int Index;

            public int TextureIndex;

            public Vector2 Position;

            public bool Triggered;

            public float RetractTimer;

            public float DelayTimer;

            public float Lerp;

            public void Update()
            {
                if (Triggered)
                {
                    if (DelayTimer > 0f)
                    {
                        DelayTimer -= Parent.engine.DeltaTime;
                        if (DelayTimer <= 0f)
                        {
                            if (PlayerCheck())
                            {
                                DelayTimer = 0.05f;
                            }
                            else
                            {
                                Parent.PlaySound("event:/game/03_resort/fluff_tendril_emerge",
                                    Parent.Position + Position);
                            }
                        }
                    }
                    else
                    {
                        Lerp = ScalarMath.Approach(Lerp, 1f, 8f * Parent.engine.DeltaTime);
                    }
                }
                else
                {
                    Lerp = ScalarMath.Approach(Lerp, 0f, 4f * Parent.engine.DeltaTime);
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
                    Parent.PlaySound("event:/game/03_resort/fluff_tendril_touch", Parent.Position + Position);
                    Triggered = true;
                    DelayTimer = 0.4f;
                    RetractTimer = 6f;
                    return false;
                }

                if (Lerp >= 1f)
                {
                    player.Die(outwards);
                    return true;
                }

                return false;
            }
        }

        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;
        private const float RetractTime = 6f;

        private const float DelayTime = 0.4f;

        private int size;

        private Directions direction;

        private string overrideType;

        private bool legacyBehavior;

        private PlayerColliderComponentState pc;

        private Vector2 outwards;

        private Vector2 shakeOffset;

        private string spikeType;

        private SpikeInfo[] spikes;
        public SpikeInfo[] SourceSpikes => spikes;
        public Directions SourceDirection => direction;

        private List<AtlasEntry> spikeTextures;

        public static SceneEntityState LoadUp(OriginalLevelSceneRoot level,
            OriginalLevelRoomData levelData, Vector2 offset, OriginalLevelEntityData entityData)
            => new EverestOriginalTriggerSpikesState(entityData, offset, Directions.Up, level.EngineContext);

        public static SceneEntityState LoadDown(OriginalLevelSceneRoot level,
            OriginalLevelRoomData levelData, Vector2 offset, OriginalLevelEntityData entityData)
            => new EverestOriginalTriggerSpikesState(entityData, offset, Directions.Down, level.EngineContext);

        public static SceneEntityState LoadLeft(OriginalLevelSceneRoot level,
            OriginalLevelRoomData levelData, Vector2 offset, OriginalLevelEntityData entityData)
            => new EverestOriginalTriggerSpikesState(entityData, offset, Directions.Left, level.EngineContext);

        public static SceneEntityState LoadRight(OriginalLevelSceneRoot level,
            OriginalLevelRoomData levelData, Vector2 offset, OriginalLevelEntityData entityData)
            => new EverestOriginalTriggerSpikesState(entityData, offset, Directions.Right, level.EngineContext);

        public EverestOriginalTriggerSpikesState(EntityData data, Vector2 offset, Directions dir,
            ISourceEngineContext engine)
            : this(data.Position + offset, GetSize(data, dir), dir,
                EntityAttributeReader.Attr(data.Values, "type", "default"), engine)
        {
            legacyBehavior = EntityAttributeReader.Bool(data.Values, "legacyBehavior", true);
        }

        public EverestOriginalTriggerSpikesState(Vector2 position, int size, Directions direction, string overrideType,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            this.size = size;
            this.direction = direction;
            this.overrideType = overrideType;
            switch (direction)
            {
                case Directions.Up:
                    outwards = new Vector2(0f, -1f);
                    base.Collider = new HitboxColliderGeometry(size, 3f, 0f, -3f);
                    Add(new SafeGroundBlockerComponentState());
                    Add(new LedgeBlockerState(p => UpSafeBlockCheck((RoomPlayerSession)p)));
                    break;
                case Directions.Down:
                    outwards = new Vector2(0f, 1f);
                    base.Collider = new HitboxColliderGeometry(size, 3f);
                    break;
                case Directions.Left:
                    outwards = new Vector2(-1f, 0f);
                    base.Collider = new HitboxColliderGeometry(3f, size, -3f);
                    Add(new SafeGroundBlockerComponentState());
                    Add(new LedgeBlockerState(p => SideSafeBlockCheck((RoomPlayerSession)p)));
                    break;
                case Directions.Right:
                    outwards = new Vector2(1f, 0f);
                    base.Collider = new HitboxColliderGeometry(3f, size);
                    Add(new SafeGroundBlockerComponentState());
                    Add(new LedgeBlockerState(p => SideSafeBlockCheck((RoomPlayerSession)p)));
                    break;
            }

            Add(pc = new PlayerColliderComponentState(OnCollide));
            Add(new SourceStaticMoverState
            {
                OnShake = OnShake,
                SolidChecker = IsRiding,
                JumpThruChecker = IsRiding
            });
            base.Depth = -50;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            spikeType = ((ISourceSpikeScene)scene).SpikeType;
            if (!string.IsNullOrEmpty(overrideType) && overrideType != "default")
            {
                spikeType = overrideType;
            }

            string text = direction.ToString().ToLower();
            if (spikeType == "tentacles")
            {
                throw new NotSupportedException("Trigger tentacles currently not supported");
            }

            spikes = new SpikeInfo[size / 8];
            spikeTextures =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures("danger/spikes/" +
                    spikeType + "_" + text);
            for (int i = 0; i < spikes.Length; i++)
            {
                spikes[i].Parent = this;
                spikes[i].Index = i;
                switch (direction)
                {
                    case Directions.Up:
                        spikes[i].Position = Vector2.UnitX * ((float)i + 0.5f) * 8f + Vector2.UnitY;
                        break;
                    case Directions.Down:
                        spikes[i].Position = Vector2.UnitX * ((float)i + 0.5f) * 8f - Vector2.UnitY;
                        break;
                    case Directions.Left:
                        spikes[i].Position = Vector2.UnitY * ((float)i + 0.5f) * 8f + Vector2.UnitX;
                        break;
                    case Directions.Right:
                        spikes[i].Position = Vector2.UnitY * ((float)i + 0.5f) * 8f - Vector2.UnitX;
                        break;
                }
            }
        }

        private void OnShake(Vector2 amount)
        {
            shakeOffset += amount;
        }

        private bool UpSafeBlockCheck(RoomPlayerSession player)
        {
            int num = 8 * (int)player.Data.Facing;
            int num2 = (int)((player.Left + (float)num - base.Left) / (legacyBehavior ? 4f : 8f));
            int num3 = (int)((player.Right + (float)num - base.Left) / (legacyBehavior ? 4f : 8f));
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
            int num = (int)((player.Top - base.Top) / (legacyBehavior ? 4f : 8f));
            int num2 = (int)((player.Bottom - base.Top) / (legacyBehavior ? 4f : 8f));
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

        private void GetPlayerCollideIndex(RoomPlayerSession player, out int minIndex, out int maxIndex)
            => Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.TriggerSpikeCollision.GetPlayerCollideIndices(
                player, this, (Celeste.Simulation.Gameplay.Hazards.TriggerSpikes.TriggerSpikesDirection)direction,
                8f, out minIndex, out maxIndex);

        private bool PlayerCheck(int spikeIndex)
        {
            RoomPlayerSession player = FirstPlayer();
            if (player == null)
            {
                return false;
            }

            GetPlayerCollideIndex(player, out var minIndex, out var maxIndex);
            if (minIndex <= spikeIndex + 1)
            {
                return maxIndex >= spikeIndex - 1;
            }

            return false;
        }

        private static int GetSize(EntityData data, Directions dir)
        {
            if (dir <= Directions.Down)
            {
                return data.Width;
            }

            return data.Height;
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
            Vector2 justify = Vector2.One * 0.5f;
            switch (direction)
            {
                case Directions.Up:
                    justify = new Vector2(0.5f, 1f);
                    break;
                case Directions.Down:
                    justify = new Vector2(0.5f, 0f);
                    break;
                case Directions.Left:
                    justify = new Vector2(1f, 0.5f);
                    break;
                case Directions.Right:
                    justify = new Vector2(0f, 0.5f);
                    break;
            }

            for (int i = 0; i < spikes.Length; i++)
            {
                AtlasEntry mTexture = spikeTextures[spikes[i].TextureIndex];
                Vector2 position = Position + shakeOffset + spikes[i].Position + outwards * (-4f + spikes[i].Lerp * 4f);
                SourceAtlasDrawing.DrawJustified(context, this, mTexture, position, justify, PackedColor.White,
                    Vector2.One,
                    0f);
            }
        }

        private bool IsRiding(SourceSolidEntityState solid)
        {
            return direction switch
            {
                Directions.Up => CheckOutside(solid, Position + Vector2.UnitY),
                Directions.Down => CheckOutside(solid, Position - Vector2.UnitY),
                Directions.Left => CheckOutside(solid, Position + Vector2.UnitX),
                Directions.Right => CheckOutside(solid, Position - Vector2.UnitX),
                _ => false,
            };
        }

        private bool IsRiding(ISourceJumpThruEntity jumpThru)
        {
            if (direction == Directions.Up)
            {
                return CheckAt(jumpThru, Position + Vector2.UnitY);
            }

            return false;
        }

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
    }
}
