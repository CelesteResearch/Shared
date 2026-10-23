using System.Collections;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Player.Scene.Reflection;

namespace Celeste.Simulation
{
    public sealed partial class RoomPlayerSession
    {
        private ISourceReflectionFallScene ReflectionFallScene => (ISourceReflectionFallScene)Level;

        public void ReflectionFallBegin()
        {
            Body.IgnoreJumpThrus = true;
        }

        public void ReflectionFallEnd()
        {
            ReflectionFallScene.ShowReflectionFallEffects(false);
            Body.IgnoreJumpThrus = false;
        }

        public int ReflectionFallUpdate()
        {
            Data.Facing = 1;
            if (ReflectionFallScene.OnReflectionFallInterval(.05f))
            {
                Data.WasDashB = true;
                CreateTrail();
            }

            if (ReflectionFallScene.CheckReflectionFallWater(this))
                Data.Motion.Normal.Speed.Y = ScalarMath.Approach(Data.Motion.Normal.Speed.Y, -20f,
                    400f * engineContext.DeltaTime, ((ISourceExtremaEnvironment)engineContext).ExtremaArithmetic);
            else
                Data.Motion.Normal.Speed.Y = ScalarMath.Approach(Data.Motion.Normal.Speed.Y, 320f,
                    225f * engineContext.DeltaTime, ((ISourceExtremaEnvironment)engineContext).ExtremaArithmetic);
            ReflectionFallScene.RemoveReflectionFallFeathers();
            ReflectionFallScene.DestroyReflectionFallSpinner(new IntRect((int)(Position.X - 6f), (int)(Position.Y - 6f),
                12,
                12));
            return 18;
        }

        public IEnumerator ReflectionFallCoroutine()
        {
            if (((global::Celeste.Simulation.Gameplay.Player.Runtime.ISourcePlayerRuntimeEnvironment)engineContext)
                .PlayerRuntimePolicy.UsesOriginalReflectionFall(this))
            {
                IEnumerator enumerator = OriginalReflectionFallCoroutine();
                while (enumerator.MoveNext()) yield return enumerator.Current;
                yield break;
            }

            Sprite.Play("bigFall");
            for (float t = 0f; t < 2f; t += engineContext.DeltaTime)
            {
                Data.Motion.Normal.Speed.Y = 0f;
                yield return null;
            }

            ReflectionFallScene.ShowReflectionFallEffects(true);
            Data.Motion.Normal.Speed.Y = 320f;
            while (!ReflectionFallScene.CheckReflectionFallWater(this)) yield return null;
            ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engineContext).RumbleSession
                .Rumble(2, 1);
            ReflectionFallScene.ShowReflectionFallEffects(false);
            Sprite.Play("bigFallRecover");
            yield return 1.2f;
            Machine.State = 0;
        }

        public IEnumerator OriginalReflectionFallCoroutine()
        {
            Sprite.Play("bigFall");
            ReflectionFallScene.StartReflectionFallCutscene(this);
            for (float t = 0f; t < 2f; t += engineContext.DeltaTime)
            {
                Data.Motion.Normal.Speed.Y = 0f;
                yield return null;
            }

            ReflectionFallScene.ShowReflectionFallEffects(true);
            Data.Motion.Normal.Speed.Y = 320f;
            while (!ReflectionFallScene.CheckReflectionFallWater(this)) yield return null;
            ((global::Celeste.Input.Gameplay.Feedback.ISourceRumbleEnvironment)engineContext).RumbleSession
                .Rumble(2, 1);
            ReflectionFallScene.ShowReflectionFallEffects(false);
            Sprite.Play("bigFallRecover");
            ReflectionFallScene.ApplyReflectionFallMusic();
            ReflectionFallScene.EndReflectionFallCutscene();
            yield return 1.2f;
            Machine.State = 0;
        }
    }
}
