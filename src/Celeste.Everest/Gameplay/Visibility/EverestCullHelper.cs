using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Everest.Gameplay.Visibility
{
    public static class EverestCullHelper
    {
        public static bool IsRectangleVisible(ISourceEngineContext engine, float x, float y, float w, float h,
            float lenience = 4f, CameraState camera = null)
        {
            if (camera == null) camera = (engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot)?.Camera;
            if (camera == null) return true;
            if (x + w >= camera.Left - lenience && x <= camera.Right + lenience && y + h >= camera.Top - lenience)
                return y <= camera.Bottom + 180f + lenience;
            return false;
        }

        public static bool IsCurveVisible(ISourceEngineContext engine, SimpleCurve curve,
            float lenience = 8f, CameraState camera = null)
        {
            Vector2 begin = curve.Begin;
            Vector2 control = curve.Control;
            Vector2 end = curve.End;
            var arithmetic = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
            float num = arithmetic.Min(begin.X, arithmetic.Min(control.X, end.X));
            float num2 = arithmetic.Max(begin.X, arithmetic.Max(control.X, end.X));
            float num3 = arithmetic.Min(begin.Y, arithmetic.Min(control.Y, end.Y));
            float num4 = arithmetic.Max(begin.Y, arithmetic.Max(control.Y, end.Y));
            return IsRectangleVisible(engine, num, num3, num2 - num, num4 - num3, lenience, camera);
        }
    }
}
