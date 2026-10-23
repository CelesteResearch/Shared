using System.Collections;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation.Gameplay.Player.Runtime;
using Celeste.Simulation.Gameplay.Player.Scene.Reflection;

// ReSharper disable once CheckNamespace
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
                    400f * EngineContext.DeltaTime, ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);
            else
                Data.Motion.Normal.Speed.Y = ScalarMath.Approach(Data.Motion.Normal.Speed.Y, 320f,
                    225f * EngineContext.DeltaTime, ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);
            ReflectionFallScene.RemoveReflectionFallFeathers();
            ReflectionFallScene.DestroyReflectionFallSpinner(new((int)(Position.X - 6f), (int)(Position.Y - 6f),
                12,
                12));
            return 18;
        }

        public IEnumerator ReflectionFallCoroutine()
        {
            if (((ISourcePlayerRuntimeEnvironment)EngineContext)
                .PlayerRuntimePolicy.UsesOriginalReflectionFall(this))
            {
                var enumerator = OriginalReflectionFallCoroutine();
                while (enumerator.MoveNext()) yield return enumerator.Current;
                yield break;
            }

            Sprite.Play("bigFall");
            for (var t = 0f; t < 2f; t += EngineContext.DeltaTime)
            {
                Data.Motion.Normal.Speed.Y = 0f;
                yield return null;
            }

            ReflectionFallScene.ShowReflectionFallEffects(true);
            Data.Motion.Normal.Speed.Y = 320f;
            while (!ReflectionFallScene.CheckReflectionFallWater(this)) yield return null;
            ((ISourceRumbleEnvironment)EngineContext).RumbleSession
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
            for (var t = 0f; t < 2f; t += EngineContext.DeltaTime)
            {
                Data.Motion.Normal.Speed.Y = 0f;
                yield return null;
            }

            ReflectionFallScene.ShowReflectionFallEffects(true);
            Data.Motion.Normal.Speed.Y = 320f;
            while (!ReflectionFallScene.CheckReflectionFallWater(this)) yield return null;
            ((ISourceRumbleEnvironment)EngineContext).RumbleSession
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
