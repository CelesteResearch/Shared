using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components.Timing;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Components.Switches;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Components.Shaking;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Gameplay.Doors.TempleGates
{
    public class OriginalTempleGateState : SourceSolidEntityState
    {
        private readonly ISourceEngineContext engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;

        private const int OpenHeight = 0;

        private const float HoldingWaitTime = 0.2f;

        private const float HoldingOpenDistSq = 4096f;

        private const float HoldingCloseDistSq = 6400f;

        private const int MinDrawHeight = 4;

        public string LevelID;

        public OriginalTempleGateType Type;

        public bool ClaimedByASwitch;

        private readonly bool theoGate;

        private readonly int closedHeight;

        private readonly Sprite sprite;

        private readonly ShakerComponentState shaker;

        private float drawHeight;

        private float drawHeightMoveSpeed;

        private bool open;

        private float holdingWaitTimer = 0.2f;

        private readonly Vector2 holdingCheckFrom;

        private bool lockState;

        public OriginalTempleGateState(Vector2 position, int height, OriginalTempleGateType type, string spriteName,
            string levelID, ISourceEngineContext engine, ISourceSolidWorld world)
            : base(position, 8f, height, true, world)
        {
            this.engine = engine;
            Type = type;
            closedHeight = height;
            LevelID = levelID;
            OwnedComponents.Add(sprite = Graphics.SpriteFactory.Create("templegate_" + spriteName));
            sprite.Position.X = Collider.Width / 2f;
            sprite.Play("idle");
            OwnedComponents.Add(shaker = new(engine, false));
            Depth = -9000;
            theoGate = spriteName.Equals("theo", StringComparison.InvariantCultureIgnoreCase);
            holdingCheckFrom = SourceVector2Math.Add(Position, new(Width / 2f, height / 2));
        }

        public OriginalTempleGateState(EntityData data, Vector2 offset, string levelID,
            ISourceEngineContext engine, ISourceSolidWorld world)
            : this(SourceVector2Math.Add(data.Position, offset), data.Height,
                EntityAttributeReader.Enum(data.Values, "type", OriginalTempleGateType.NearestSwitch),
                EntityAttributeReader.Attr(data.Values, "sprite", "default"), levelID, engine, world)
        {
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (Type == OriginalTempleGateType.CloseBehindPlayer)
            {
                var entity =
                    Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (entity != null && entity.Left < Right && entity.Bottom >= Top &&
                    entity.Top <= Bottom)
                {
                    StartOpen();
                    OwnedComponents.Add(new SimulationCoroutine(engine, CloseBehindPlayer()));
                }
            }
            else if (Type == OriginalTempleGateType.CloseBehindPlayerAlways)
            {
                StartOpen();
                OwnedComponents.Add(new SimulationCoroutine(engine, CloseBehindPlayer()));
            }
            else if (Type == OriginalTempleGateType.CloseBehindPlayerAndTheo)
            {
                StartOpen();
                OwnedComponents.Add(new SimulationCoroutine(engine, CloseBehindPlayerAndTheo()));
            }
            else if (Type == OriginalTempleGateType.HoldingTheo)
            {
                if (TheoIsNearby()) StartOpen();

                Collider.Width = 16f;
            }
            else if (Type == OriginalTempleGateType.TouchSwitches)
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, CheckTouchSwitches()));
            }

            drawHeight = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(4f, Height);
        }

        public bool CloseBehindPlayerCheck()
        {
            var entity =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null) return entity.X < X;

            return false;
        }

        public void SwitchOpen()
        {
            sprite.Play("open");
            SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.2f, delegate
            {
                shaker.ShakeFor(0.2f, false);
                SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.2f, Open);
            });
        }

        public void Open()
        {
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                theoGate
                    ? "event:/game/05_mirror_temple/gate_theo_open"
                    : "event:/game/05_mirror_temple/gate_main_open",
                Position);
            holdingWaitTimer = 0.2f;
            drawHeightMoveSpeed = 200f;
            drawHeight = Height;
            shaker.ShakeFor(0.2f, false);
            SetHeight(0);
            sprite.Play("open");
            open = true;
        }

        public void StartOpen()
        {
            SetHeight(0);
            drawHeight = 4f;
            open = true;
        }

        public void Close()
        {
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                theoGate
                    ? "event:/game/05_mirror_temple/gate_theo_close"
                    : "event:/game/05_mirror_temple/gate_main_close",
                Position);
            holdingWaitTimer = 0.2f;
            drawHeightMoveSpeed = 300f;
            drawHeight = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(4f, Height);
            shaker.ShakeFor(0.2f, false);
            SetHeight(closedHeight);
            sprite.Play("hit");
            open = false;
        }

        private IEnumerator CloseBehindPlayer()
        {
            while (true)
            {
                var entity =
                    Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (!lockState && entity != null && entity.Left > Right + 4f) break;

                yield return null;
            }

            Close();
        }

        private IEnumerator CloseBehindPlayerAndTheo()
        {
            while (true)
            {
                var entity =
                    Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(RoomPlayerSession).FullName);

                if (entity != null && entity.Left > Right + 4f)
                {
                    var entity2 =
                        Level.Scheduler.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
                    if (!lockState && entity2 != null && entity2.Left > Right + 4f) break;
                }

                yield return null;
            }

            Close();
        }

        private IEnumerator CheckTouchSwitches()
        {
            while (!OriginalSwitchComponent.Check(Scene)) yield return null;

            sprite.Play("open");
            yield return 0.5f;
            shaker.ShakeFor(0.2f, false);
            yield return 0.2f;
            while (lockState) yield return null;

            Open();
        }

        public bool TheoIsNearby()
        {
            var entity =
                Level.Scheduler.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
            if (entity != null && !(entity.X > X + 10f))
                return ((ISourceVectorEnvironment)engine).VectorArithmetic.DistanceSquared(holdingCheckFrom,
                    entity.Center) < (open ? 6400f : 4096f);

            return true;
        }

        private void SetHeight(int height)
        {
            ClosingSolidResize.SetHeight(this, height);
        }

        public override void Update()
        {
            base.Update();
            if (Type == OriginalTempleGateType.HoldingTheo)
            {
                if (holdingWaitTimer > 0f)
                {
                    holdingWaitTimer -= engine.DeltaTime;
                }
                else if (!lockState)
                {
                    if (open && !TheoIsNearby())
                    {
                        Close();
                        SourceTrackedEntityCollision.FirstAt<RoomPlayerSession>(Level.Scheduler.Entities,
                            typeof(RoomPlayerSession).FullName,
                            this, SourceVector2Math.Add(Position, new(8f, 0f)))?.Die(Vector2.Zero);
                    }
                    else if (!open && TheoIsNearby())
                    {
                        Open();
                    }
                }
            }

            var num = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(4f, Height);
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (drawHeight != num)
            {
                lockState = true;
                drawHeight = ScalarMath.Approach(drawHeight, num, drawHeightMoveSpeed * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }
            else
            {
                lockState = false;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            var vector = new Vector2(Math.Sign(shaker.Value.X), 0f);
            SourcePrimitiveDrawing.Rect(context, this, X - 2f, Y - 8f, 14f, 10f, PackedColor.Black);
            sprite.DrawSubrect(context, SourceVector2Math.Add(Vector2.Zero, vector),
                new(0, (int)(sprite.Height - drawHeight), (int)sprite.Width, (int)drawHeight),
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }
    }
}
