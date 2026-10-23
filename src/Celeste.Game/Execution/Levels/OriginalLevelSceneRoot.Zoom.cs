using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Game.Settings;
using Celeste.Simulation.Presentation.ScreenEffects;
using Celeste.Graphics.Display;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public float Zoom = 1f;
        public float ZoomTarget = 1f;
        public Vector2 ZoomFocusPoint;

        public void ZoomSnap(Vector2 screenSpaceFocusPoint, float zoom)
        {
            ZoomFocusPoint = screenSpaceFocusPoint;
            ZoomTarget = (Zoom = zoom);
        }

        public IEnumerator ZoomTo(Vector2 screenSpaceFocusPoint, float zoom, float duration)
        {
            ZoomFocusPoint = screenSpaceFocusPoint;
            ZoomTarget = zoom;
            float from = Zoom;
            for (float p = 0f; p < 1f; p += EngineContext.DeltaTime / duration)
            {
                Zoom = ScalarMath.Lerp(from, ZoomTarget,
                    ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.SineInOut(ScalarMath.Clamp(p, 0f, 1f)),
                    ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic);
                yield return null;
            }

            Zoom = ZoomTarget;
        }

        public IEnumerator ZoomAcross(Vector2 screenSpaceFocusPoint, float zoom, float duration)
        {
            float fromZoom = Zoom;
            Vector2 fromFocus = ZoomFocusPoint;
            for (float p = 0f; p < 1f; p += EngineContext.DeltaTime / duration)
            {
                float amount =
                    ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.SineInOut(ScalarMath.Clamp(p, 0f, 1f));
                Zoom = (ZoomTarget = ScalarMath.Lerp(fromZoom, zoom, amount,
                    ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic));
                ZoomFocusPoint = Vector2Interpolation.Lerp(fromFocus, screenSpaceFocusPoint, amount,
                    ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic);
                yield return null;
            }

            Zoom = ZoomTarget;
            ZoomFocusPoint = screenSpaceFocusPoint;
        }

        public IEnumerator ZoomBack(float duration)
        {
            float from = Zoom;
            float to = 1f;
            for (float p = 0f; p < 1f; p += EngineContext.DeltaTime / duration)
            {
                Zoom = ScalarMath.Lerp(from, to,
                    ((ISourceEasingEnvironment)EngineContext).EasingArithmetic.SineInOut(ScalarMath.Clamp(p, 0f, 1f)),
                    ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic);
                yield return null;
            }

            ResetZoom();
        }

        public void ResetZoom()
        {
            Zoom = 1f;
            ZoomTarget = 1f;
            ZoomFocusPoint =
                ((ISourceVectorEnvironment)EngineContext).VectorArithmetic.Divide(new Vector2(320f, 180f), 2f);
        }
    }
}
