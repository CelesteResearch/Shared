using System;
using System.Collections;
using System.Numerics;

namespace Celeste.Game.Presentation.Camera
{
    public sealed class LevelZoomState
    {
        public float DeltaTime = 1f / 60f;
        public float Zoom = 1, ZoomTarget = 1, ScreenPadding;
        public Vector2 FocusPoint = new Vector2(160, 90);

        public IEnumerator ZoomTo(Vector2 focus, float zoom, float duration)
        {
            FocusPoint = focus;
            ZoomTarget = zoom;
            float from = Zoom;
            for (float p = 0; p < 1; p += DeltaTime / duration)
            {
                Zoom = Lerp(from, ZoomTarget, Sine(p));
                yield return null;
            }

            Zoom = ZoomTarget;
        }

        public IEnumerator ZoomAcross(Vector2 focus, float zoom, float duration)
        {
            float from = Zoom;
            Vector2 oldFocus = FocusPoint;
            for (float p = 0; p < 1; p += DeltaTime / duration)
            {
                float amount = Sine(p);
                Zoom = ZoomTarget = Lerp(from, zoom, amount);
                FocusPoint = oldFocus + (focus - oldFocus) * amount;
                yield return null;
            }

            Zoom = ZoomTarget;
            FocusPoint = focus;
        }

        public IEnumerator ZoomBack(float duration)
        {
            float from = Zoom;
            for (float p = 0; p < 1; p += DeltaTime / duration)
            {
                Zoom = Lerp(from, 1, Sine(p));
                yield return null;
            }

            ResetZoom();
        }

        public void ResetZoom()
        {
            Zoom = ZoomTarget = 1;
            FocusPoint = new Vector2(160, 90);
        }

        public float RenderScale => Zoom * ((320 - ScreenPadding * 2) / 320);

        public Vector2 RenderOrigin(bool mirror = false)
        {
            Vector2 size = new Vector2(320, 180), zoomed = size / ZoomTarget;
            Vector2 origin = ZoomTarget != 1 ? (FocusPoint - zoomed / 2) / (size - zoomed) * size : Vector2.Zero;
            if (mirror) origin.X = 160 - (origin.X - 160);
            return origin;
        }

        public Vector2 RenderPadding(bool mirror = false) =>
            new Vector2(mirror ? -ScreenPadding : ScreenPadding, ScreenPadding * .5625f);

        private static float Lerp(float from, float to, float amount) => from + (to - from) * amount;

        private static float Sine(float value) =>
            (0f - (float)Math.Cos((float)Math.PI * Math.Max(0, Math.Min(1, value)))) / 2f + .5f;
    }
}
