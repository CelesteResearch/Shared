using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Display;
using Celeste.Game.Gameplay.Environment.Ridge;
using Celeste.Everest.Gameplay.Visibility;

namespace Celeste.Everest.Gameplay.Environment.Ridge
{
    public sealed class EverestFlaglineState : OriginalFlaglineState
    {
        public EverestFlaglineState(ISourceEngineContext engine, Vector2 to, PackedColor lineColor,
            PackedColor pinColor, PackedColor[] colors, int minFlagHeight, int maxFlagHeight,
            int minFlagLength, int maxFlagLength, int minSpace, int maxSpace)
            : base(engine, to, lineColor, pinColor, colors, minFlagHeight, maxFlagHeight,
                minFlagLength, maxFlagLength, minSpace, maxSpace)
        {
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 vector = ((From.X < To.X) ? From : To);
            Vector2 vector2 = ((From.X < To.X) ? To : From);
            float num = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(vector - vector2);
            float num2 = num / 8f;
            SimpleCurve simpleCurve = new SimpleCurve(vector, vector2,
                (vector2 + vector) / 2f + Vector2.UnitY * (num2 + (float)Math.Sin(waveTimer) * num2 * 0.3f));
            if (!IsVisible(simpleCurve)) return;
            RenderCurve(context, vector, simpleCurve, num);
        }

        private bool IsVisible(SimpleCurve curve)
        {
            Cloth[] array = clothes;
            float num = 0f;
            for (int i = 0; i < array.Length; i++)
            {
                Cloth cloth = array[i];
                float num2 = (float)cloth.Height + (float)cloth.Length * ClothDroopAmount * 1.4f;
                if (num2 > num) num = num2;
            }

            return EverestCullHelper.IsCurveVisible(engine, curve, num + 8f);
        }
    }
}
