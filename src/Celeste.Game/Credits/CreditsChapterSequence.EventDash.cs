using System.Collections;
using System.Numerics;

namespace Celeste.Game.Credits
{
    public sealed partial class CreditsChapterSequence
    {
        private IEnumerator DoEvent(string eventName)
        {
            switch (eventName)
            {
                case "WaitJumpDash":
                    yield return EventWaitJumpDash();
                    break;
                case "WaitJumpDoubleDash":
                    yield return EventWaitJumpDoubleDash();
                    break;
                case "ClimbDown":
                    yield return EventClimbDown();
                    break;
                case "Wait":
                    yield return EventWait();
                    break;
            }
        }

        private IEnumerator EventWaitJumpDash()
        {
            autoWalk = false;
            player.Dummy.Friction = true;
            yield return .1f;
            PlayerJump(-1);
            yield return .2f;
            player.Motor.Dash.Data.OverrideDirection = new Vector2(-1f, -1f);
            player.Machine.State = player.StartDash();
            yield return .6f;
            player.Motor.Dash.Data.OverrideDirection = null;
            player.Machine.State = 11;
            autoWalk = true;
        }

        private IEnumerator EventWaitJumpDoubleDash()
        {
            autoWalk = false;
            player.Dummy.Friction = true;
            yield return .1f;
            player.Data.Facing = 1;
            yield return .25f;
            yield return BadelineCombine();
            player.Data.Dashes = 2;
            yield return .5f;
            player.Data.Facing = -1;
            yield return .7f;
            PlayerJump(-1);
            yield return .4f;
            player.Motor.Dash.Data.OverrideDirection = new Vector2(-1f, -1f);
            player.Machine.State = player.StartDash();
            yield return .6f;
            player.Motor.Dash.Data.OverrideDirection = new Vector2(-1f, 0f);
            player.Machine.State = player.StartDash();
            yield return .6f;
            player.Motor.Dash.Data.OverrideDirection = null;
            player.Machine.State = 11;
            autoWalk = true;
            while (!player.OnGround())
                yield return null;
            autoWalk = false;
            player.Dummy.Friction = true;
            player.Data.Dashes = 2;
            yield return .5f;
            player.Data.Facing = 1;
            yield return 1f;
            Level.Displacement.AddBurst(player.Position, .4f, 8f, 32f, .5f);
            badeline.Position = player.Position;
            badeline.Visible = true;
            badelineAutoFloat = true;
            player.Data.Dashes = 1;
            yield return .8f;
            player.Data.Facing = -1;
            autoWalk = true;
            player.Dummy.Friction = false;
        }
    }
}
