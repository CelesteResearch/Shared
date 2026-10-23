using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components.Timing;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Gameplay.Collectibles.Keys;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Physics.Collision;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Following;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Emitters;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Particles.Definitions;

namespace Celeste.Game.Entities.Doors.LockBlocks
{
    public class OriginalLockBlockState : SourceSolidEntityState
    {
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private ParticleTypePresentation P_Appear => Process.ParticleTypes.LockBlock.P_Appear;

        public MapEntityId ID;

        public bool UnlockingRegistered;

        private readonly Sprite sprite;

        private bool opening;

        private readonly bool stepMusicProgress;

        private readonly string unlockSfxName;

        public OriginalLockBlockState(Vector2 position, MapEntityId id, bool stepMusicProgress, string spriteName,
            string unlock_sfx, ISourceSolidWorld world)
            : base(position, 32f, 32f, false, world)
        {
            engine = world.EngineContext;
            ID = id;
            DisableLightsInside = false;
            this.stepMusicProgress = stepMusicProgress;
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer,
                new CircleColliderGeometry(((ISourceVectorEnvironment)engine).VectorArithmetic, 60f, 16f, 16f)));
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("lockdoor_" + spriteName));
            sprite.Play("idle");
            sprite.Position = new(Width / 2f, Height / 2f);
            if (string.IsNullOrWhiteSpace(unlock_sfx))
            {
                unlockSfxName = "event:/game/03_resort/key_unlock";
                if (spriteName == "temple_a")
                    unlockSfxName = "event:/game/05_mirror_temple/key_unlock_light";
                else if (spriteName == "temple_b") unlockSfxName = "event:/game/05_mirror_temple/key_unlock_dark";
            }
            else
            {
                unlockSfxName = ((IOriginalSfxEnvironment)engine).Sfx.EventnameByHandle(unlock_sfx);
            }
        }

        public static OriginalLockBlockState CreateFromMapData(EntityData data, Vector2 offset, MapEntityId id,
            OriginalLevelSceneRoot level)
        {
            var position = data.Position + offset;
            var step = EntityAttributeReader.Bool(data.Values, "stepMusicProgress");
            var spriteName = EntityAttributeReader.Attr(data.Values, "sprite", "wood");
            var sound = EntityAttributeReader.Attr(data.Values, "unlock_sfx", null);
            return new(position, id, step, spriteName, sound,
                level.SolidWorldFactory.Create(position, false));
        }

        public void Appear()
        {
            Visible = true;
            sprite.Play("appear");
            OwnedComponents.Add(SourceAlarmState.Create(engine.AlarmPool, SourceAlarmState.AlarmMode.Oneshot, delegate
            {
                var level = Scene as OriginalLevelSceneRoot;
                if (!CollideCheck("Celeste.Solid", Position - Vector2.UnitX))
                {
                    level.Particles.Emit(P_Appear, 16, Position + new Vector2(3f, 16f), new(2f, 10f),
                        (float)Math.PI);
                    level.Particles.Emit(P_Appear, 16, Position + new Vector2(29f, 16f), new(2f, 10f), 0f);
                }

                level.Shake();
            }, 0.25f, true));
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (opening) return;

            foreach (var follower in player.Leader.Followers)
                if (follower.Entity is OriginalKeyState && !(follower.Entity as OriginalKeyState).StartedUsing)
                {
                    TryOpen(player, follower);
                    break;
                }
        }

        private void TryOpen(RoomPlayerSession player, FollowerState fol)
        {
            Collidable = false;
            if (SourceSceneCollision.FirstLine<ISourceEntityCollider>(((ISourceScene)Scene).SourceScene.Entities,
                    "Celeste.Solid", player.Center, Center) == null)
            {
                opening = true;
                (fol.Entity as OriginalKeyState).StartedUsing = true;
                OwnedComponents.Add(new SimulationCoroutine(engine, UnlockRoutine(fol)));
            }

            Collidable = true;
        }

        private IEnumerator UnlockRoutine(FollowerState fol)
        {
            var emitter = SoundEmitterState.Play(unlockSfxName, this, engine);
            emitter.Source.DisposeOnTransition = true;
            var level = (OriginalLevelSceneRoot)Scene;
            var key = fol.Entity as OriginalKeyState;
            OwnedComponents.Add(new SimulationCoroutine(engine, key.UseRoutine(Center + new Vector2(0f, 2f))));
            yield return 1.2f;
            UnlockingRegistered = true;
            if (stepMusicProgress)
            {
                var music = level.Session.Audio.Music;
                music.SetProgress(unchecked(music.GetProgress() + 1));
                OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                    Process.AudioApplyPolicy);
            }

            level.Session.DoNotLoad.Add(ID);
            key.RegisterUsed();
            while (key.Turning) yield return null;

            Tags |= ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            Collidable = false;
            emitter.Source.DisposeOnTransition = false;
            yield return sprite.PlayRoutine("open");
            level.Shake();
            ((IOriginalGameInputProcessEnvironment)engine).InputSource.Rumble(RumbleStrength.Medium,
                RumbleLength.Medium);
            yield return sprite.PlayRoutine("burst");
            RemoveSelf();
        }
    }
}
