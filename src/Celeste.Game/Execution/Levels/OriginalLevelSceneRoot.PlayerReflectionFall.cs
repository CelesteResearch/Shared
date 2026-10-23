using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Physics.Collision;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Gameplay.Player.Scene.Reflection;
using Celeste.Game.Entities.StarJump;
using Celeste.Game.Entities.Hazards.Spinners.Crystal;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Audio;
using Celeste.Input.Gameplay.Feedback;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourceReflectionFallScene
    {
        string ISourceReflectionFallScene.ReflectionFallLevelSet => AreaData.LevelSet;
        bool ISourceReflectionFallScene.OnReflectionFallInterval(float interval) => OnInterval(interval);

        bool ISourceReflectionFallScene.CheckReflectionFallWater(RoomPlayerSession player)
        {
            foreach (var item in Scheduler.Entities.GetTrackedEntities("Celeste.Water"))
                if (SourceEntityCollision.Check(player, (ISourceEntityCollider)item))
                    return true;
            return false;
        }

        void ISourceReflectionFallScene.ShowReflectionFallEffects(bool visible)
            => OriginalFallEffectsState.Show(EngineContext, visible);

        void ISourceReflectionFallScene.RemoveReflectionFallFeathers()
        {
            foreach (var item in Scheduler.Entities.GetTrackedEntities("Celeste.FlyFeather"))
                ((SceneEntityState)item).RemoveSelf();
        }

        void ISourceReflectionFallScene.DestroyReflectionFallSpinner(IntRect rectangle)
        {
            foreach (var item in Scheduler.Entities.GetTrackedEntities("Celeste.CrystalStaticSpinner"))
            {
                var spinner = (OriginalCrystalStaticSpinner)item;
                if (!spinner.Collidable || spinner.Collider == null || !spinner.Collider.Collide(rectangle)) continue;
                spinner.Destroy();
                Shake();
                ((ISourceRumbleEnvironment)EngineContext).RumbleSession.Rumble(1, 1);
                OriginalCelesteFreeze.Freeze(EngineContext, .01f);
                break;
            }
        }

        void ISourceReflectionFallScene.StartReflectionFallCutscene(RoomPlayerSession player)
            => StartCutscene(level => level.OnEndOfFrame += delegate
            {
                level.RemoveEntity(player);
                level.UnloadLevel();
                level.Session.Level = "00";
                level.Session.RespawnPoint = level.GetSpawnPoint(new Vector2(level.Bounds.Left, level.Bounds.Bottom));
                level.LoadLevel(PlayerIntroType.None);
                OriginalFallEffectsState.Show(level.EngineContext, false);
                ApplySourceReflectionFallMusic(level);
            });

        void ISourceReflectionFallScene.EndReflectionFallCutscene() => EndCutscene();
        void ISourceReflectionFallScene.ApplyReflectionFallMusic() => ApplySourceReflectionFallMusic(this);

        private static void ApplySourceReflectionFallMusic(OriginalLevelSceneRoot level)
        {
            level.Session.Audio.Music.Event = "event:/music/lvl6/main";
            var process = (IOriginalGameplayProcess)level.EngineContext;
            OriginalAudioSession.Apply(level.Session.Audio, process.AudioSession.ChannelOutput,
                process.AudioApplyPolicy);
        }
    }
}
