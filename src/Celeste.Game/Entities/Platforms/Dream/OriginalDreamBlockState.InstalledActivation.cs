using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Components.Shaking;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Entities.Platforms.Dream
{
    public partial class OriginalDreamBlockState
    {
        public void DeactivateNoRoutine()
        {
            if (SourcePlayerHasDreamDash)
            {
                SourcePlayerHasDreamDash = false;
                Setup();
                if (SourceOcclude == null)
                {
                    SourceOcclude = new LightOccludeState();
                }

                Add(SourceOcclude);
                SourceWhiteHeight = 1f;
                SourceWhiteFill = 0f;
                if (SourceShaker != null)
                {
                    SourceShaker.On = false;
                }

                SurfaceSoundIndex = 11;
            }
        }

        public IEnumerator Deactivate()
        {
            OriginalLevelSceneRoot level = (OriginalLevelSceneRoot)Scene;
            yield return 1f;
            ((ISourceRumbleEnvironment)SourceEngine).RumbleSession.Rumble(0, 2);
            if (SourceShaker == null)
            {
                SourceShaker =
                    new ShakerComponentState(SourceEngine, on: true, delegate(Vector2 t) { SourceShake = t; });
            }

            Add(SourceShaker);
            SourceShaker.Interval = 0.02f;
            SourceShaker.On = true;
            for (float alpha = 0f; alpha < 1f; alpha += SourceEngine.DeltaTime)
            {
                SourceWhiteFill = ((ISourceEasingEnvironment)SourceEngine).EasingArithmetic.CubeIn(alpha);
                yield return null;
            }

            SourceShaker.On = false;
            yield return 0.5f;
            DeactivateNoRoutine();
            SourceWhiteHeight = 1f;
            SourceWhiteFill = 1f;
            for (float alpha = 1f; alpha > 0f; alpha -= SourceEngine.DeltaTime * 0.5f)
            {
                SourceWhiteHeight = alpha;
                if (level.Clock.OnInterval(0.1f, SourceEngine))
                {
                    for (int num = 0; (float)num < Width; num += 4)
                    {
                        level.ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)SourceEngine).ParticleTypes.Strawberry.P_WingsBurst,
                            new Vector2(X + (float)num, Y + Height * SourceWhiteHeight + 1f));
                    }
                }

                if (level.Clock.OnInterval(0.1f, SourceEngine))
                {
                    level.Shake();
                }

                ((ISourceRumbleEnvironment)SourceEngine).RumbleSession.Rumble(2, 0);
                yield return null;
            }

            while (SourceWhiteFill > 0f)
            {
                SourceWhiteFill -= SourceEngine.DeltaTime * 3f;
                yield return null;
            }
        }

        public IEnumerator FastDeactivate()
        {
            OriginalLevelSceneRoot level = (OriginalLevelSceneRoot)Scene;
            yield return null;
            ((ISourceRumbleEnvironment)SourceEngine).RumbleSession.Rumble(0, 0);
            if (SourceShaker == null)
            {
                SourceShaker =
                    new ShakerComponentState(SourceEngine, on: true, delegate(Vector2 t) { SourceShake = t; });
            }

            Add(SourceShaker);
            SourceShaker.Interval = 0.02f;
            SourceShaker.On = true;
            for (float alpha = 0f; alpha < 1f; alpha += SourceEngine.DeltaTime * 3f)
            {
                SourceWhiteFill = ((ISourceEasingEnvironment)SourceEngine).EasingArithmetic.CubeIn(alpha);
                yield return null;
            }

            SourceShaker.On = false;
            yield return 0.1f;
            DeactivateNoRoutine();
            SourceWhiteHeight = 1f;
            SourceWhiteFill = 1f;
            level.ParticlesFG.Emit(((IOriginalGameplayProcess)SourceEngine).ParticleTypes.Strawberry.P_WingsBurst,
                (int)Width, TopCenter, Vector2.UnitX * Width / 2f, PackedColor.White, ((float)Math.PI));
            level.ParticlesFG.Emit(((IOriginalGameplayProcess)SourceEngine).ParticleTypes.Strawberry.P_WingsBurst,
                (int)Width, BottomCenter, Vector2.UnitX * Width / 2f, PackedColor.White, 0f);
            level.ParticlesFG.Emit(((IOriginalGameplayProcess)SourceEngine).ParticleTypes.Strawberry.P_WingsBurst,
                (int)Height, CenterLeft, Vector2.UnitY * Height / 2f, PackedColor.White, 4.712389f);
            level.ParticlesFG.Emit(((IOriginalGameplayProcess)SourceEngine).ParticleTypes.Strawberry.P_WingsBurst,
                (int)Height, CenterRight, Vector2.UnitY * Height / 2f, PackedColor.White, ((float)Math.PI) / 2f);
            level.Shake();
            yield return 0.1f;
            while (SourceWhiteFill > 0f)
            {
                SourceWhiteFill -= SourceEngine.DeltaTime * 3f;
                yield return null;
            }
        }

        public IEnumerator FastActivate()
        {
            OriginalLevelSceneRoot level = (OriginalLevelSceneRoot)Scene;
            yield return null;
            ((ISourceRumbleEnvironment)SourceEngine).RumbleSession.Rumble(0, 0);
            if (SourceShaker == null)
            {
                SourceShaker =
                    new ShakerComponentState(SourceEngine, on: true, delegate(Vector2 t) { SourceShake = t; });
            }

            Add(SourceShaker);
            SourceShaker.Interval = 0.02f;
            SourceShaker.On = true;
            for (float alpha = 0f; alpha < 1f; alpha += SourceEngine.DeltaTime * 3f)
            {
                SourceWhiteFill = ((ISourceEasingEnvironment)SourceEngine).EasingArithmetic.CubeIn(alpha);
                yield return null;
            }

            SourceShaker.On = false;
            yield return 0.1f;
            ActivateNoRoutine();
            SourceWhiteHeight = 1f;
            SourceWhiteFill = 1f;
            level.ParticlesFG.Emit(((IOriginalGameplayProcess)SourceEngine).ParticleTypes.Strawberry.P_WingsBurst,
                (int)Width, TopCenter, Vector2.UnitX * Width / 2f, PackedColor.White, ((float)Math.PI));
            level.ParticlesFG.Emit(((IOriginalGameplayProcess)SourceEngine).ParticleTypes.Strawberry.P_WingsBurst,
                (int)Width, BottomCenter, Vector2.UnitX * Width / 2f, PackedColor.White, 0f);
            level.ParticlesFG.Emit(((IOriginalGameplayProcess)SourceEngine).ParticleTypes.Strawberry.P_WingsBurst,
                (int)Height, CenterLeft, Vector2.UnitY * Height / 2f, PackedColor.White, 4.712389f);
            level.ParticlesFG.Emit(((IOriginalGameplayProcess)SourceEngine).ParticleTypes.Strawberry.P_WingsBurst,
                (int)Height, CenterRight, Vector2.UnitY * Height / 2f, PackedColor.White, ((float)Math.PI) / 2f);
            level.Shake();
            yield return 0.1f;
            while (SourceWhiteFill > 0f)
            {
                SourceWhiteFill -= SourceEngine.DeltaTime * 3f;
                yield return null;
            }
        }
    }
}
