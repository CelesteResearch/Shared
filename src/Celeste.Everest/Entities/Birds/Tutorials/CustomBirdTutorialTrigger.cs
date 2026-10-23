using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Entities.Birds.Tutorials
{
    public sealed class CustomBirdTutorialTrigger : SourceTriggerEntityState
    {
        public string BirdId;
        public bool ShowTutorial;

        private CustomBirdTutorialTrigger(OriginalLevelSceneRoot level, OriginalLevelEntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)level.EngineContext).EntitySourceDataRegistration,
                data.Position + offset, data.Width, data.Height,
                ((ISourceExtremaEnvironment)level.EngineContext).ExtremaArithmetic)
        {
            BirdId = data.Attr("birdId");
            ShowTutorial = data.Bool("showTutorial");
        }

        public static SceneEntityState Load(OriginalLevelSceneRoot level, OriginalLevelRoomData levelData,
            Vector2 offset, OriginalLevelEntityData data)
        {
            return new CustomBirdTutorialTrigger(level, data, offset);
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            base.OnEnter(player);
            var bird = CustomBirdTutorial.FindById(Scene as OriginalLevelSceneRoot, BirdId);
            if (bird == null) return;
            if (ShowTutorial) bird.TriggerShowTutorial();
            else bird.TriggerHideTutorial();
        }
    }
}
