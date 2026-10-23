using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Components.Timing;
using Celeste.Core.Scheduling;
using Celeste.Core.Audio;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Controls.Source;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Scene.Tracking;
using Celeste.Scene.Entities;
using Celeste.Scene.Components.Shaking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Mechanisms.Switches;
using Celeste.Simulation.Gameplay.Player.Collision.Surfaces;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Identifiers;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Components.Switches;
using Celeste.Game.Stories.Temple;
using Celeste.Game.Gameplay.Mechanisms.DashSwitches;

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

        private bool theoGate;

        private int closedHeight;

        private Sprite sprite;

        private ShakerComponentState shaker;

        private float drawHeight;

        private float drawHeightMoveSpeed;

        private bool open;

        private float holdingWaitTimer = 0.2f;

        private Vector2 holdingCheckFrom;

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
            sprite.Position.X = base.Collider.Width / 2f;
            sprite.Play("idle");
            OwnedComponents.Add(shaker = new ShakerComponentState(engine, on: false));
            base.Depth = -9000;
            theoGate = spriteName.Equals("theo", StringComparison.InvariantCultureIgnoreCase);
            holdingCheckFrom = SourceVector2Math.Add(Position, new Vector2(base.Width / 2f, height / 2));
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
                RoomPlayerSession entity =
                    Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (entity != null && entity.Left < base.Right && entity.Bottom >= base.Top &&
                    entity.Top <= base.Bottom)
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
                if (TheoIsNearby())
                {
                    StartOpen();
                }

                base.Collider.Width = 16f;
            }
            else if (Type == OriginalTempleGateType.TouchSwitches)
            {
                OwnedComponents.Add(new SimulationCoroutine(engine, CheckTouchSwitches()));
            }

            drawHeight = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(4f, base.Height);
        }

        public bool CloseBehindPlayerCheck()
        {
            RoomPlayerSession entity =
                Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (entity != null)
            {
                return entity.X < base.X;
            }

            return false;
        }

        public void SwitchOpen()
        {
            sprite.Play("open");
            SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.2f, delegate
            {
                shaker.ShakeFor(0.2f, removeOnFinish: false);
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
            drawHeight = base.Height;
            shaker.ShakeFor(0.2f, removeOnFinish: false);
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
            drawHeight = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(4f, base.Height);
            shaker.ShakeFor(0.2f, removeOnFinish: false);
            SetHeight(closedHeight);
            sprite.Play("hit");
            open = false;
        }

        private IEnumerator CloseBehindPlayer()
        {
            while (true)
            {
                RoomPlayerSession entity =
                    Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (!lockState && entity != null && entity.Left > base.Right + 4f)
                {
                    break;
                }

                yield return null;
            }

            Close();
        }

        private IEnumerator CloseBehindPlayerAndTheo()
        {
            while (true)
            {
                RoomPlayerSession entity =
                    Level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (entity != null && entity.Left > base.Right + 4f)
                {
                    TheoCrystalState entity2 =
                        Level.Scheduler.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
                    if (!lockState && entity2 != null && entity2.Left > base.Right + 4f)
                    {
                        break;
                    }
                }

                yield return null;
            }

            Close();
        }

        private IEnumerator CheckTouchSwitches()
        {
            while (!OriginalSwitchComponent.Check(Scene))
            {
                yield return null;
            }

            sprite.Play("open");
            yield return 0.5f;
            shaker.ShakeFor(0.2f, removeOnFinish: false);
            yield return 0.2f;
            while (lockState)
            {
                yield return null;
            }

            Open();
        }

        public bool TheoIsNearby()
        {
            TheoCrystalState entity =
                Level.Scheduler.Entities.GetTrackedEntity<TheoCrystalState>("Celeste.TheoCrystal");
            if (entity != null && !(entity.X > base.X + 10f))
            {
                return ((ISourceVectorEnvironment)engine).VectorArithmetic.DistanceSquared(holdingCheckFrom,
                    entity.Center) < (open ? 6400f : 4096f);
            }

            return true;
        }

        private void SetHeight(int height) => ClosingSolidResize.SetHeight(this, height);

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
                            typeof(global::Celeste.Simulation.RoomPlayerSession).FullName,
                            this, SourceVector2Math.Add(Position, new Vector2(8f, 0f)))?.Die(Vector2.Zero);
                    }
                    else if (!open && TheoIsNearby())
                    {
                        Open();
                    }
                }
            }

            float num = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(4f, base.Height);
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
            Vector2 vector = new Vector2(Math.Sign(shaker.Value.X), 0f);
            SourcePrimitiveDrawing.Rect(context, this, base.X - 2f, base.Y - 8f, 14f, 10f, PackedColor.Black);
            sprite.DrawSubrect(context, SourceVector2Math.Add(Vector2.Zero, vector),
                new IntRect(0, (int)(sprite.Height - drawHeight), (int)sprite.Width, (int)drawHeight),
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
        }
    }
}
