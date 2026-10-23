using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Entities;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Effects
{
    public class LevelUpEffectState : SceneEntityState
    {
        private readonly Sprite sprite;

        public LevelUpEffectState(Vector2 position, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            Depth = -1000000;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/game/06_reflection/hug_levelup_text_in",
                Position);
            sprite = ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("player_level_up");
            OwnedComponents.Add(sprite);
            sprite.OnLastFrame = _ => RemoveSelf();
            sprite.OnFrameChange = _ =>
            {
                if (sprite.CurrentAnimationFrame == 20)
                    ((IOriginalGameplayProcess)engine).AudioSession.Play(
                        "event:/game/06_reflection/hug_levelup_text_out");
            };
            sprite.Play("levelUp");
        }
    }
}
