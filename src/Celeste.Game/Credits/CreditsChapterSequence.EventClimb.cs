using System.Collections;
using System.Numerics;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        private IEnumerator EventClimbDown()
        {
            autoWalk = false;
            player.Dummy.Friction = true;
            yield return .1f;
            PlayerJump(-1);
            yield return .4f;
            while (!SourceTrackedEntityCollision.CheckAt(((ISourceScene)player.Scene).SourceScene.Entities,
                       "Celeste.Solid", player, player.Position + new Vector2(-1f, 0f)))
                yield return null;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("wallslide");
            while (SourceTrackedEntityCollision.CheckAt(((ISourceScene)player.Scene).SourceScene.Entities,
                       "Celeste.Solid", player, player.Position + new Vector2(-1f, 32f)))
            {
                player.CreateWallSlideParticles(-1);
                player.Data.Motion.Normal.Speed.Y = Extrema.Min(player.Data.Motion.Normal.Speed.Y, 40f);
                yield return null;
            }

            PlayerJump(1);
            yield return .4f;
            while (!SourceTrackedEntityCollision.CheckAt(((ISourceScene)player.Scene).SourceScene.Entities,
                       "Celeste.Solid", player, player.Position + new Vector2(1f, 0f)))
                yield return null;
            player.Dummy.AutoAnimate = false;
            player.Sprite.Play("wallslide");
            while (!SourceTrackedEntityCollision.CheckAt(((ISourceScene)player.Scene).SourceScene.Entities,
                       "Celeste.Solid", player, player.Position + new Vector2(0f, 32f)))
            {
                player.CreateWallSlideParticles(1);
                player.Data.Motion.Normal.Speed.Y = Extrema.Min(player.Data.Motion.Normal.Speed.Y, 40f);
                yield return null;
            }

            PlayerJump(-1);
            yield return .4f;
            autoWalk = true;
        }
    }
}
