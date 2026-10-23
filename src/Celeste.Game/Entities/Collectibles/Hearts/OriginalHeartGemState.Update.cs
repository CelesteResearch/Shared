using System;
using System.Numerics;
using Celeste.Game.Execution.Levels;
using Celeste.Core.Scheduling;

namespace Celeste.Game.Entities.Collectibles.Hearts
{
    public partial class OriginalHeartGemState
    {
        public override void Update()
        {
            bounceSfxDelay -= engine.DeltaTime;
            timer += engine.DeltaTime;
            sprite.Position = Vector2.UnitY * (float)Math.Sin(timer * 2f) * 2f +
                              moveWiggleDir * moveWiggler.Value * -8f;
            if (white != null)
            {
                white.Position = sprite.Position;
                white.Scale = sprite.Scale;
                if (white.CurrentAnimationID != sprite.CurrentAnimationID)
                    white.Play(sprite.CurrentAnimationID);
                white.SetAnimationFrame(sprite.CurrentAnimationFrame);
            }

            if (collected)
            {
                var player = FirstPlayer();
                if (player == null || player.Dead)
                    EndCutscene();
            }

            base.Update();
            if (!collected &&
                ((global::Celeste.Scene.Tracking.ISourceScene)Scene).SourceScene.Clock.OnInterval(0.1f, engine))
                ((OriginalLevelSceneRoot)Scene).Particles.Emit(shineParticle, 1, Center, Vector2.One * 8f);
        }
    }
}
