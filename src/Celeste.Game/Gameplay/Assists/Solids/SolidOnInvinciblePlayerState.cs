using Celeste.Scene.Tracking;
using System;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Save.Runtime;
using Celeste.Scene.Entities;
using Celeste.Simulation.Gameplay.Collision;

namespace Celeste.Game.Gameplay.Assists.Solids
{
    public sealed class SolidOnInvinciblePlayerState : SourceComponentState
    {
        private readonly OriginalGameAudioSession audio;
        private readonly IOriginalGameSaveContext saveContext;
        private bool wasCollidable;
        private bool wasVisible;
        private SolidInvincibilityOutlineState outline;

        public SolidOnInvinciblePlayerState(OriginalGameAudioSession audio, IOriginalGameSaveContext saveContext)
            : base(true, false)
        {
            this.audio = audio ?? throw new ArgumentNullException(nameof(audio));
            this.saveContext = saveContext ?? throw new ArgumentNullException(nameof(saveContext));
        }

        public void AddTo(SourceOwnedComponentList components) => components.Add(this);

        public override void Added(object actualEntity)
        {
            base.Added(actualEntity);
            var entity = (SceneEntityState)actualEntity;
            audio.Play("event:/game/general/assist_nonsolid_in", entity.Center, saveContext);
            wasCollidable = entity.Collidable;
            wasVisible = entity.Visible;
            entity.Collidable = false;
            entity.Visible = false;
            if (entity.Scene != null)
            {
                var level = (OriginalLevelSceneRoot)entity.Scene;
                outline = new SolidInvincibilityOutlineState(this, level.EngineContext);
                level.Scheduler.QueueSourceEntity(outline);
            }
        }

        public override void Update()
        {
            base.Update();
            var entity = (SceneEntityState)Entity;
            entity.Collidable = true;
            var entities = ((ISourceScene)entity.Scene).SourceScene.Entities;
            if (!SourceSceneCollisionQueries.Check(entity,
                    entities.GetTrackedEntities(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName)) &&
                !SourceSceneCollisionQueries.Check(entity, entities.GetTrackedEntities("Celeste.TheoCrystal")))
                RemoveSelf();
            else
                entity.Collidable = false;
        }

        public override void Removed(object actualEntity)
        {
            var entity = (SceneEntityState)actualEntity;
            audio.Play("event:/game/general/assist_nonsolid_out", entity.Center, saveContext);
            entity.Collidable = wasCollidable;
            entity.Visible = wasVisible;
            outline?.RemoveSelf();
            base.Removed(actualEntity);
        }
    }
}
