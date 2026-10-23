using Celeste.Scene.Tracking;
using System;
using System.Numerics;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Save.Runtime;
using Celeste.Simulation;
using Celeste.Game.Gameplay.Holdables.TheoCrystal;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Scene.Entities;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Gameplay.Assists.Solids
{
    public sealed class OriginalSolidAssistPolicy : ISourceSolidAssistPolicy
    {
        private readonly OriginalGameAudioSession audio;
        private readonly IOriginalGameSaveContext saveContext;

        public OriginalSolidAssistPolicy(OriginalGameAudioSession audio, IOriginalGameSaveContext saveContext)
        {
            this.audio = audio ?? throw new ArgumentNullException(nameof(audio));
            this.saveContext = saveContext ?? throw new ArgumentNullException(nameof(saveContext));
        }

        public void AfterMovement(SourceSolidEntityState solid)
        {
            if (!solid.EnableAssistModeChecks || saveContext.CurrentSave == null ||
                !saveContext.CurrentSave.Assists.Invincible || HasAssistComponent(solid) || !solid.Collidable)
                return;
            var player = (RoomPlayerSession)SourceSceneCollisionQueries.First(solid,
                ((ISourceScene)solid.Scene).SourceScene.Entities.GetTrackedEntities(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName));

            var level = solid.Scene as OriginalLevelSceneRoot;
            if (player == null && solid.Bottom > level.Bounds.Bottom)
                player = (RoomPlayerSession)FirstPlayerAt(solid, solid.Position + Vector2.UnitY);
            if (player != null && player.Machine.State != 9 && player.Machine.State != 21)
            {
                new SolidOnInvinciblePlayerState(audio, saveContext).AddTo(solid.OwnedComponents);
                return;
            }

            var theo = (TheoCrystalState)SourceSceneCollisionQueries.First(solid,
                ((ISourceScene)solid.Scene).SourceScene.Entities.GetTrackedEntities("Celeste.TheoCrystal"));
            if (theo != null && !theo.Hold.IsHeld)
                new SolidOnInvinciblePlayerState(audio, saveContext).AddTo(solid.OwnedComponents);
        }

        private static object FirstPlayerAt(SourceSolidEntityState solid, Vector2 at)
        {
            Vector2 position = solid.Position;
            solid.Position = at;
            var player = SourceSceneCollisionQueries.First(solid,
                ((ISourceScene)solid.Scene).SourceScene.Entities.GetTrackedEntities(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName));

            solid.Position = position;
            return player;
        }

        private static bool HasAssistComponent(SourceSolidEntityState solid)
        {
            foreach (var component in solid.OwnedComponents)
                if (component is SolidOnInvinciblePlayerState)
                    return true;
            return false;
        }
    }
}
