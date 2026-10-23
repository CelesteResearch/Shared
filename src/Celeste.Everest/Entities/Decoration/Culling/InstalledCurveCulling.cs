using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;

namespace Celeste.Everest.Entities.Decoration.Culling
{
    public static class InstalledCurveCulling
    {
        public static bool IsVisible(ISourceEngineContext engine, SimpleCurve curve, float lenience)
        {
            var begin = curve.Begin;
            var control = curve.Control;
            var end = curve.End;
            var extrema = ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
            var x = extrema.Min(begin.X, extrema.Min(control.X, end.X));
            var right = extrema.Max(begin.X, extrema.Max(control.X, end.X));
            var y = extrema.Min(begin.Y, extrema.Min(control.Y, end.Y));
            var bottom = extrema.Max(begin.Y, extrema.Max(control.Y, end.Y));
            return IsRectangleVisible(engine, x, y, right - x, bottom - y, lenience);
        }

        private static bool IsRectangleVisible(ISourceEngineContext engine, float x, float y, float width,
            float height, float lenience)
        {
            var camera = (engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot)?.Camera;
            if (camera == null) return true;
            if (x + width >= camera.Left - lenience && x <= camera.Right + lenience &&
                y + height >= camera.Top - lenience)
                return y <= camera.Bottom + 180f + lenience;
            return false;
        }
    }
}
