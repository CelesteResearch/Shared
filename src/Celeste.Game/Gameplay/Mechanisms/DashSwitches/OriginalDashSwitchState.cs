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
using Celeste.Game.Gameplay.Doors.TempleGates;

namespace Celeste.Game.Gameplay.Mechanisms.DashSwitches
{
    public class OriginalDashSwitchState : SourceSolidEntityState, ISourceDashSwitch
    {
        private readonly ISourceEngineContext engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;

        DashCollisionResult ISourceDashSwitch.OnDashCollide(RoomPlayerSession player, Vector2 direction) =>
            base.OnDashCollide(player, direction);

        private OriginalDashSwitchSide side;

        private Vector2 pressedTarget;

        private bool pressed;

        private Vector2 pressDirection;

        private float speedY;

        private float startY;

        private bool persistent;

        private MapEntityId id;

        private bool mirrorMode;

        private bool playerWasOn;

        private bool allGates;

        private Sprite sprite;

        private string FlagName => GetFlagName(id);

        protected ref bool SourcePressed => ref pressed;
        protected ref bool SourcePersistent => ref persistent;
        protected ref Vector2 SourcePressedTarget => ref pressedTarget;
        protected ref Vector2 SourcePressDirection => ref pressDirection;
        protected ref float SourceStartY => ref startY;
        protected Sprite SourceSwitchSprite => sprite;
        protected string SourceSwitchFlagName => FlagName;

        public OriginalDashSwitchState(Vector2 position, OriginalDashSwitchSide side, bool persistent, bool allGates,
            MapEntityId id, string spriteName, ISourceEngineContext engine, ISourceSolidWorld world)
            : base(position, 0f, 0f, true, world)
        {
            this.engine = engine;
            this.side = side;
            this.persistent = persistent;
            this.allGates = allGates;
            this.id = id;
            mirrorMode = spriteName != "default";
            OwnedComponents.Add(sprite = Graphics.SpriteFactory.Create("dashSwitch_" + spriteName));
            sprite.Play("idle");
            if (side == OriginalDashSwitchSide.Up || side == OriginalDashSwitchSide.Down)
            {
                base.Collider.Width = 16f;
                base.Collider.Height = 8f;
            }
            else
            {
                base.Collider.Width = 8f;
                base.Collider.Height = 16f;
            }

            switch (side)
            {
                case OriginalDashSwitchSide.Down:
                    sprite.Position = new Vector2(8f, 8f);
                    sprite.Rotation = (float)Math.PI / 2f;
                    pressedTarget = SourceVector2Math.Add(Position, SourceVector2Math.Multiply(Vector2.UnitY, 8f));
                    pressDirection = Vector2.UnitY;
                    startY = base.Y;
                    break;
                case OriginalDashSwitchSide.Up:
                    sprite.Position = new Vector2(8f, 0f);
                    sprite.Rotation = -(float)Math.PI / 2f;
                    pressedTarget = SourceVector2Math.Add(Position, SourceVector2Math.Multiply(Vector2.UnitY, -8f));
                    pressDirection = SourceVector2Math.Negate(Vector2.UnitY);
                    break;
                case OriginalDashSwitchSide.Right:
                    sprite.Position = new Vector2(8f, 8f);
                    sprite.Rotation = 0f;
                    pressedTarget = SourceVector2Math.Add(Position, SourceVector2Math.Multiply(Vector2.UnitX, 8f));
                    pressDirection = Vector2.UnitX;
                    break;
                case OriginalDashSwitchSide.Left:
                    sprite.Position = new Vector2(0f, 8f);
                    sprite.Rotation = (float)Math.PI;
                    pressedTarget = SourceVector2Math.Add(Position, SourceVector2Math.Multiply(Vector2.UnitX, -8f));
                    pressDirection = SourceVector2Math.Negate(Vector2.UnitX);
                    break;
            }

            OnDashCollide = OnDashed;
        }

        public static OriginalDashSwitchState Create(ISourceEngineContext engine, EntityData data,
            Vector2 offset, MapEntityId id, ISourceSolidWorld world)
        {
            Vector2 position = SourceVector2Math.Add(data.Position, offset);
            bool flag = EntityAttributeReader.Bool(data.Values, "persistent");
            bool flag2 = EntityAttributeReader.Bool(data.Values, "allGates");
            string spriteName = EntityAttributeReader.Attr(data.Values, "sprite", "default");
            if (data.Name.Equals("dashSwitchH"))
            {
                if (EntityAttributeReader.Bool(data.Values, "leftSide"))
                {
                    return new OriginalDashSwitchState(position, OriginalDashSwitchSide.Left, flag, flag2, id,
                        spriteName,
                        engine, world);
                }

                return new OriginalDashSwitchState(position, OriginalDashSwitchSide.Right, flag, flag2, id, spriteName,
                    engine, world);
            }

            if (EntityAttributeReader.Bool(data.Values, "ceiling"))
            {
                return new OriginalDashSwitchState(position, OriginalDashSwitchSide.Up, flag, flag2, id, spriteName,
                    engine,
                    world);
            }

            return new OriginalDashSwitchState(position, OriginalDashSwitchSide.Down, flag, flag2, id, spriteName,
                engine,
                world);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (!persistent || !Level.Session.GetFlag(FlagName))
            {
                return;
            }

            sprite.Play("pushed");
            Position = SourceVector2Math.Subtract(pressedTarget, SourceVector2Math.Multiply(pressDirection, 2f));
            pressed = true;
            Collidable = false;
            if (allGates)
            {
                foreach (OriginalTempleGateState entity in
                         Level.Scheduler.Entities.GetTrackedEntities("Celeste.TempleGate"))
                {
                    if (entity.Type == OriginalTempleGateType.NearestSwitch && entity.LevelID == id.Level)
                    {
                        entity.StartOpen();
                    }
                }

                return;
            }

            GetGate()?.StartOpen();
        }

        public override void Update()
        {
            base.Update();
            if (pressed || side != OriginalDashSwitchSide.Down)
            {
                return;
            }

            RoomPlayerSession playerOnTop = GetPlayerOnTop();
            if (playerOnTop != null)
            {
                if (playerOnTop.Holding.Holding != null)
                {
                    OnDashed(playerOnTop, Vector2.UnitY);
                }
                else
                {
                    if (speedY < 0f)
                    {
                        speedY = 0f;
                    }

                    speedY = ScalarMath.Approach(speedY, 70f, 200f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    MoveTowardsY(startY + 2f, speedY * engine.DeltaTime);
                    if (!playerWasOn)
                    {
                        ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                            "event:/game/05_mirror_temple/button_depress", Position);
                    }
                }
            }
            else
            {
                if (speedY > 0f)
                {
                    speedY = 0f;
                }

                speedY = ScalarMath.Approach(speedY, -150f, 200f * engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                MoveTowardsY(startY, (0f - speedY) * engine.DeltaTime);
                if (playerWasOn)
                {
                    ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                        "event:/game/05_mirror_temple/button_return",
                        Position);
                }
            }

            playerWasOn = playerOnTop != null;
        }

        public DashCollisionResult OnDashed(RoomPlayerSession player, Vector2 direction)
        {
            if (!pressed && direction == pressDirection)
            {
                ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium,
                    RumbleLength.Medium);
                ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(
                    "event:/game/05_mirror_temple/button_activate",
                    Position);
                sprite.Play("push");
                pressed = true;
                MoveTo(pressedTarget);
                Collidable = false;
                Position = SourceVector2Math.Subtract(Position, SourceVector2Math.Multiply(pressDirection, 2f));
                Level.ParticlesFG.Emit(
                    mirrorMode
                        ? ((IOriginalGameplayProcess)engine).ParticleTypes.DashSwitch.P_PressAMirror
                        : ((IOriginalGameplayProcess)engine).ParticleTypes.DashSwitch.P_PressA, 10,
                    SourceVector2Math.Add(Position, sprite.Position),
                    SourceVector2Math.Multiply(Vector2Geometry.Perpendicular(direction), 6f),
                    sprite.Rotation - (float)Math.PI);
                Level.ParticlesFG.Emit(
                    mirrorMode
                        ? ((IOriginalGameplayProcess)engine).ParticleTypes.DashSwitch.P_PressBMirror
                        : ((IOriginalGameplayProcess)engine).ParticleTypes.DashSwitch.P_PressB, 4,
                    SourceVector2Math.Add(Position, sprite.Position),
                    SourceVector2Math.Multiply(Vector2Geometry.Perpendicular(direction), 6f),
                    sprite.Rotation - (float)Math.PI);
                if (allGates)
                {
                    foreach (OriginalTempleGateState entity in Level.Scheduler.Entities.GetTrackedEntities(
                                 "Celeste.TempleGate"))
                    {
                        if (entity.Type == OriginalTempleGateType.NearestSwitch && entity.LevelID == id.Level)
                        {
                            entity.SwitchOpen();
                        }
                    }
                }
                else
                {
                    GetGate()?.SwitchOpen();
                }

                Level.Scheduler.Entities.FindFirst<TempleMirrorPortalState>()
                    ?.OnSwitchHit(Math.Sign(base.X - (float)Level.Bounds.Center.X));
                if (persistent)
                {
                    Level.Session.SetFlag(FlagName);
                }
            }

            return DashCollisionResult.NormalCollision;
        }

        private OriginalTempleGateState GetGate()
        {
            List<object> entities = Level.Scheduler.Entities.GetTrackedEntities("Celeste.TempleGate");
            OriginalTempleGateState templeGate = null;
            float num = 0f;
            foreach (OriginalTempleGateState item in entities)
            {
                if (item.Type == OriginalTempleGateType.NearestSwitch && !item.ClaimedByASwitch &&
                    item.LevelID == id.Level)
                {
                    float num2 =
                        ((ISourceVectorEnvironment)engine).VectorArithmetic.DistanceSquared(Position, item.Position);
                    if (templeGate == null || num2 < num)
                    {
                        templeGate = item;
                        num = num2;
                    }
                }
            }

            if (templeGate != null)
            {
                templeGate.ClaimedByASwitch = true;
            }

            return templeGate;
        }

        public static string GetFlagName(MapEntityId id)
        {
            return "dashSwitch_" + EntityIdCodec.Format(id);
        }
    }
}
