using System;
using Celeste.Core.Components;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;

namespace Celeste.Game.Presentation.Doors
{
    public static class DoorPresentation
    {
        public static void Open(IOriginalGameplayProcess process, IDoorPresentationSource entity,
            float fromX,
            string sound)
        {
            if (entity.Sprite.CurrentAnimationID == "idle")
            {
                process.AudioSession.Play(sound, entity.Position, process.SaveContext);
                entity.Sprite.Play("open");
                if (entity.Position.X != fromX) entity.Sprite.Scale.X = Math.Sign(fromX - entity.Position.X);
            }
            else if (entity.Sprite.CurrentAnimationID == "close")
            {
                entity.Sprite.Play("close", restart: true);
            }
        }

        public static void PlayCloseIfCompleted(IOriginalGameplayProcess process, IDoorPresentationSource entity,
            string previousAnimation, string sound)
        {
            if (previousAnimation == "close" && entity.Sprite.CurrentAnimationID == "idle")
                process.AudioSession.Play(sound, entity.Position, process.SaveContext);
        }
    }
}
