using System;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Scheduling;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Save.Runtime;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class SpotlightWipePresentation : ScreenWipePresentation
    {
        public Vector2 FocusPoint
        {
            get => ProcessWipe.SpotlightFocusPoint;
            set => ProcessWipe.SpotlightFocusPoint = value;
        }

        public float Modifier
        {
            get => ProcessWipe.SpotlightModifier;
            set => ProcessWipe.SpotlightModifier = value;
        }

        public bool Linear;

        private const float SmallCircleRadius = 288f;

        private const float EaseDuration = 1.8f;

        private const float EaseOpenPercent = 0.2f;

        private const float EaseClosePercent = 0.2f;

        private static ISourceRendererScene InitializeSourceGlobals(ISourceRendererScene scene)
        {
            ((ISourceScreenWipeEnvironment)((ISourceEngineContextScene)scene).EngineContext)
                .ProcessWipe.InitializeSpotlight();
            return scene;
        }

        private ISourceAudioEventReference sfx;

        public SpotlightWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(InitializeSourceGlobals(scene), wipeIn, onComplete)
        {
            Duration = 1.8f;
            Modifier = 0f;
            if (wipeIn)
                sfx = ((ISourceAudioEnvironment)EngineContext).SourceAudio.Play("event:/game/general/spotlight_intro");
            else
                sfx = ((ISourceAudioEnvironment)EngineContext).SourceAudio.Play("event:/game/general/spotlight_outro");
        }

        public override void Cancel()
        {
            if (sfx != null)
            {
                sfx.Stop(false);
                sfx.Release();
                sfx = null;
            }

            base.Cancel();
        }

        public override void Render(object scene)
        {
            var num = WipeIn ? Percent : 1f - Percent;
            var focusPoint = FocusPoint;
            if (((ISourceCurrentSaveEnvironment)EngineContext).CurrentSave != null &&
                ((ISourceCurrentSaveEnvironment)EngineContext).CurrentSave.MirrorMode)
                focusPoint.X = 320f - focusPoint.X;

            focusPoint.X *= 6f;
            focusPoint.Y *= 6f;
            var num3 = 288f + Modifier;
            DrawSpotlight(EngineContext,
                radius: Linear
                    ? Easing.CubeInOut(num) * 1920f
                    : num < 0.2f
                        ? Easing.CubeInOut(num / 0.2f) * num3
                        : !(num < 0.8f)
                            ? num3 + (num - 0.8f) / 0.2f * (1920f - num3)
                            : num3,
                position: focusPoint,
                color: WipeColor);
        }

        public static void DrawSpotlight(ISourceEngineContext engine, Vector2 position, float radius, PackedColor color)
        {
            var process = ((ISourceScreenWipeEnvironment)engine).ProcessWipe;
            process.InitializeSpotlight();
            var vertexBuffer = process.SpotlightVertices;
            var vector = new Vector2(1f, 0f);
            for (var i = 0; i < vertexBuffer.Length; i += 12)
            {
                var vector2 =
                    Vector2Geometry.AngleToVector((i + 12f) / vertexBuffer.Length * ((float)Math.PI * 2f),
                        1f);
                vertexBuffer[i].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector, 5000f)), 0f);
                vertexBuffer[i].Color = color;
                vertexBuffer[i + 1].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector, radius)), 0f);
                vertexBuffer[i + 1].Color = color;
                vertexBuffer[i + 2].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector2, radius)), 0f);
                vertexBuffer[i + 2].Color = color;
                vertexBuffer[i + 3].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector, 5000f)), 0f);
                vertexBuffer[i + 3].Color = color;
                vertexBuffer[i + 4].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector2, 5000f)), 0f);
                vertexBuffer[i + 4].Color = color;
                vertexBuffer[i + 5].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector2, radius)), 0f);
                vertexBuffer[i + 5].Color = color;
                vertexBuffer[i + 6].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector, radius)), 0f);
                vertexBuffer[i + 6].Color = color;
                vertexBuffer[i + 7].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector, radius - 2f)), 0f);
                vertexBuffer[i + 7].Color = PackedColor.Transparent;
                vertexBuffer[i + 8].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector2, radius - 2f)),
                        0f);
                vertexBuffer[i + 8].Color = PackedColor.Transparent;
                vertexBuffer[i + 9].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector, radius)), 0f);
                vertexBuffer[i + 9].Color = color;
                vertexBuffer[i + 10].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector2, radius)), 0f);
                vertexBuffer[i + 10].Color = color;
                vertexBuffer[i + 11].Position =
                    new(SourceVector2Math.Add(position, SourceVector2Math.Multiply(vector2, radius - 2f)),
                        0f);
                vertexBuffer[i + 11].Color = PackedColor.Transparent;
                vector = vector2;
            }

            DrawPrimitives(engine, vertexBuffer);
        }
    }
}
