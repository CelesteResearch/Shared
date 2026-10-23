using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Game.Entities.Bridges;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Presentation.Particles;
using Celeste.Game.Stories.Prologue.Ending;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Hazards.Lightning;
using Celeste.Simulation.Presentation.Hud.Tutorials.Birds;

namespace Celeste.Game.Entities.Birds
{
    public sealed class OriginalBirdNpcWorld
    {
        private readonly BirdNpcState bird;
        private readonly OriginalLevelSceneRoot level;
        private readonly IOriginalBirdProcess process;

        public OriginalBirdNpcWorld(BirdNpcState bird)
        {
            this.bird = bird;
            level = bird.Level;
            process = (IOriginalBirdProcess)bird.EngineContext;
        }

        private OriginalLevelSceneRoot CurrentScene => (OriginalLevelSceneRoot)bird.Scene;
        public IntRect LevelBounds => level.Bounds;
        public string SessionLevel => level.Session.Level;
        public bool Invincible => process.Invincible;
        public string FlownFlag => process.BirdState.FlownFlag;
        public bool LightningPresent => CurrentScene.Scheduler.Entities.FindFirst<LightningState>() != null;

        public RoomPlayerSession FirstPlayer =>
            CurrentScene.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                typeof(RoomPlayerSession).FullName);


        public RoomPlayerSession LevelFirstPlayer =>
            level.Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                typeof(RoomPlayerSession).FullName);


        public OriginalBridgeState FirstBridge => CurrentScene.SourceScene.Entities.FindFirst<OriginalBridgeState>();

        public bool GetFlag(string name)
        {
            return level.Session.GetFlag(name);
        }

        public bool GetLevelFlag(string name)
        {
            return level.Session.GetLevelFlag(name);
        }

        public void SetFlag(string name)
        {
            level.Session.SetFlag(name);
        }

        public void AddDoNotLoad(MapEntityId id)
        {
            level.Session.DoNotLoad.Add(id);
        }

        public bool OnInterval(float interval)
        {
            return CurrentScene.Clock.OnInterval(interval, bird.EngineContext);
        }

        public string Clean(string id)
        {
            return process.Text.CleanDialog(id);
        }

        public AtlasEntry GuiTexture(string id)
        {
            return process.GuiAtlas[id];
        }

        public BirdTutorialGuiState CreateTutorial(Vector2 offset, object info, params object[] controls)
        {
            return new(bird.EngineContext,
                ((IOriginalGameTagsEnvironment)bird.EngineContext).Tags.HUD
                .Value, process.BirdTutorialResources, bird, offset, info, controls);
        }

        public void AddTutorial(BirdTutorialGuiState tutorial)
        {
            CurrentScene.Scheduler.QueueSourceEntity(tutorial);
        }

        public void RemoveTutorial(BirdTutorialGuiState tutorial)
        {
            CurrentScene.Scheduler.RemoveEntity(tutorial);
        }

        public void AddEnding(RoomPlayerSession player, BirdNpcState actualBird, OriginalBridgeState bridge)
        {
            CurrentScene.Scheduler.QueueSourceEntity(new CS00EndingState(bird.EngineContext, player, actualBird,
                bridge));
        }

        public void PlaySound(string name, Vector2? position = null)
        {
            if (position.HasValue) process.AudioSession.Play(name, position.Value, process.SaveContext);
            else process.AudioSession.Play(name);
        }

        public SoundSourceComponentState CreateSound()
        {
            return ((ISourceSoundSourceEnvironment)bird.EngineContext).SoundSources.Create();
        }

        public void EmitDust(Vector2 position, float angle, int count)
        {
            OriginalDustBurstSource.Burst(bird.EngineContext, position,
                angle, count);
        }

        public void EmitFeather(int count, Vector2 position, Vector2 range)
        {
            level.Particles.Emit(process.ParticleTypes.BirdNPC.P_Feather, count, position, range);
        }
    }
}
