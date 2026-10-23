using System.Collections;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        private IEnumerator WaitForPlayer()
        {
            while (player.Position.X > Level.Bounds.X + 160)
            {
                if (Event != null)
                    yield return DoEvent(Event);
                Event = null;
                yield return null;
            }
        }

        private IEnumerator BadelineCombine()
        {
            var from = badeline.Position;
            badelineAutoFloat = false;
            for (var p = 0f; p < 1f; p += engine.Frame.DeltaTime / .25f)
            {
                badeline.Position = Vector2Interpolation.Lerp(from, player.Position,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }

            badeline.Visible = false;
            Level.Displacement.AddBurst(player.Position, .4f, 8f, 32f, .5f);
        }

        private void PlayerJump(int direction)
        {
            player.Data.Facing = direction;
            player.Dummy.Friction = false;
            player.Dummy.AutoAnimate = true;
            player.Data.Motion.Normal.Speed.X = direction * 120;
            player.Jump();
            player.Data.Motion.AutoJump = true;
            player.Data.AutoJumpTimer = 2f;
        }

        private void SetBgFade(float alpha)
        {
            fillbg.Color = PackedColor.Black * alpha;
        }
    }
}
