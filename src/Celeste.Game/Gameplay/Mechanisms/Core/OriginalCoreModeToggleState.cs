using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Scheduling;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Entities;
using Celeste.Physics.Collision.Shapes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Display;
using Celeste.Graphics.Content;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Gameplay.Mechanisms.Core
{
    public class OriginalCoreModeToggleState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        private const float Cooldown = 1f;

        private bool iceMode;

        private float cooldownTimer;

        private bool onlyFire;

        private bool onlyIce;

        private bool persistent;

        private bool playSounds;

        private Sprite sprite;

        private bool Usable
        {
            get
            {
                if (!onlyFire || iceMode)
                {
                    if (onlyIce)
                    {
                        return !iceMode;
                    }

                    return true;
                }

                return false;
            }
        }

        public OriginalCoreModeToggleState(ISourceEngineContext engine, Vector2 position, bool onlyFire, bool onlyIce,
            bool persistent)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            this.onlyFire = onlyFire;
            this.onlyIce = onlyIce;
            this.persistent = persistent;
            base.Collider = new HitboxColliderGeometry(16f, 24f, -8f, -12f);
            OwnedComponents.Add(new CoreModeListenerState(OnChangeMode));
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("coreFlipSwitch"));
            base.Depth = 2000;
        }

        public OriginalCoreModeToggleState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : this(engine, SourceVector2Math.Add(data.Position, offset),
                EntityAttributeReader.Bool(data.Values, "onlyFire"),
                EntityAttributeReader.Bool(data.Values, "onlyIce"),
                EntityAttributeReader.Bool(data.Values, "persistent"))
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            iceMode = (Scene as OriginalLevelSceneRoot).CoreMode == RoomCoreMode.Cold;
            SetSprite(animate: false);
        }

        private void OnChangeMode(RoomCoreMode mode)
        {
            iceMode = mode == RoomCoreMode.Cold;
            SetSprite(animate: true);
        }

        private void SetSprite(bool animate)
        {
            if (animate)
            {
                if (playSounds)
                {
                    ((IOriginalGameplayProcess)engine).AudioSession.Play(
                        iceMode ? "event:/game/09_core/switch_to_cold" : "event:/game/09_core/switch_to_hot", Position,
                        ((IOriginalGameplayProcess)engine).SaveContext);
                }

                if (Usable)
                {
                    sprite.Play(iceMode ? "ice" : "hot");
                }
                else
                {
                    if (playSounds)
                    {
                        ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/09_core/switch_dies",
                            Position,
                            ((IOriginalGameplayProcess)engine).SaveContext);
                    }

                    sprite.Play(iceMode ? "iceOff" : "hotOff");
                }
            }
            else if (Usable)
            {
                sprite.Play(iceMode ? "iceLoop" : "hotLoop");
            }
            else
            {
                sprite.Play(iceMode ? "iceOffLoop" : "hotOffLoop");
            }

            playSounds = false;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (Usable && cooldownTimer <= 0f)
            {
                playSounds = true;
                OriginalLevelSceneRoot level = (Scene as OriginalLevelSceneRoot);
                if (level.CoreMode == RoomCoreMode.Cold)
                {
                    level.CoreMode = RoomCoreMode.Hot;
                }
                else
                {
                    level.CoreMode = RoomCoreMode.Cold;
                }

                if (persistent)
                {
                    level.Session.CoreMode = level.CoreMode;
                }

                ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium,
                    RumbleLength.Medium);
                level.Flash(PackedColor.White * 0.15f, drawPlayerOver: true);
                ((ISourceFreezeEnvironment)engine).Freeze(0.05f);
                cooldownTimer = 1f;
            }
        }

        public override void Update()
        {
            base.Update();
            if (cooldownTimer > 0f)
            {
                cooldownTimer -= engine.DeltaTime;
            }
        }
    }
}
