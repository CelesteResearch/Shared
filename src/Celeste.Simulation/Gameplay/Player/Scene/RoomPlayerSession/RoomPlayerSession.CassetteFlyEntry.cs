using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Camera;
using Celeste.Simulation.Gameplay.Player.CassetteFly;

// ReSharper disable once CheckNamespace
namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private SimpleCurve cassetteFlyCurve;
        private float cassetteFlyLerp;

        public void StartCassetteFly(Vector2 targetPosition, Vector2 control)
        {
            Machine.State = 21;
            cassetteFlyCurve = new(Position, targetPosition, control);
            cassetteFlyLerp = 0f;
            Data.Motion.Normal.Speed = Vector2.Zero;
            if (Holding.Holding != null) Drop();
        }

        private void CassetteFlyBegin()
        {
            Sprite.Play("bubble");
            Sprite.Position.Y += 5f;
        }

        private void CassetteFlyEnd()
        {
        }

        private int CassetteFlyUpdate()
        {
            return 21;
        }

        private IEnumerator CassetteFlyCoroutine()
        {
            ((ISourcePlayerCassetteScene)Level).CanRetry = false;
            ((ISourcePlayerCassetteScene)Level).FormationBackdrop.Display = true;
            ((ISourcePlayerCassetteScene)Level).FormationBackdrop.Alpha = .5f;
            Sprite.Scale = Vector2.One * 1.25f;
            Depth = -2000000;
            yield return .4f;
            while (cassetteFlyLerp < 1f)
            {
                if (((ISourceScene)Level).SourceScene.Clock.OnInterval(.03f,
                        EngineContext))
                    ((ISourcePlayerCassetteScene)Level).EmitCassetteFlyParticles(Center, 2, Vector2.One * 4f);
                cassetteFlyLerp = ScalarMath.Approach(cassetteFlyLerp, 1f, 1.6f * EngineContext.DeltaTime,
                    ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);
                Position = cassetteFlyCurve.GetPoint(
                    ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.SineInOut(cassetteFlyLerp),
                    ((ISourceCurveEnvironment)EngineContext).CurveArithmetic);
                ((ISourcePlayerCameraScene)Level).Camera.Position = CameraTarget;
                yield return null;
            }

            Position = cassetteFlyCurve.End;
            Sprite.Scale = Vector2.One * 1.25f;
            Sprite.Position.Y -= 5f;
            Sprite.Play("fallFast");
            yield return .2f;
            ((ISourcePlayerCassetteScene)Level).CanRetry = true;
            ((ISourcePlayerCassetteScene)Level).FormationBackdrop.Display = false;
            ((ISourcePlayerCassetteScene)Level).FormationBackdrop.Alpha = .5f;
            Machine.State = 0;
            Depth = 0;
        }
    }
}
