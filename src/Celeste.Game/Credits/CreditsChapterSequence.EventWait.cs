using System.Collections;
using System.Numerics;
using Celeste.Game.Entities.Birds;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        private IEnumerator EventWait()
        {
            badeline.Sprite.Play("idle");
            badelineAutoWalk = false;
            autoWalk = false;
            player.Dummy.Friction = true;
            yield return .1f;
            player.Dummy.AutoAnimate = false;
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            yield return .5f;
            player.Sprite.Play("lookUp");
            yield return 2f;
            BirdNpcState bird = ((ISourceScene)Scene).SourceScene.Entities.FindFirst<BirdNpcState>();
            if (bird != null)
                bird.AutoFly = true;
            yield return .1f;
            player.Sprite.Play("idle");
            yield return 1f;
            autoWalk = true;
            player.Dummy.Friction = false;
            player.Dummy.AutoAnimate = true;
            badelineAutoWalk = true;
            badelineWalkApproach = 0f;
            badelineWalkApproachFrom = badeline.Position;
            badeline.Sprite.Play("walk");
            while (badelineWalkApproach < 1f)
            {
                badelineWalkApproach += engine.Frame.DeltaTime * 4f;
                yield return null;
            }
        }
    }
}
