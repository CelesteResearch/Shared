using System.Numerics;
using Celeste.Core.Framework.Timing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Graphics.Rendering.Primitives
{
    public static class SourcePrimitiveGraphics
    {
        public static void DrawVertices<T>(ISourcePrimitiveGraphicsDevice device, Matrix4x4 matrix,
            T[] vertices, int vertexCount,
            SourceEffect effect = null, SourceBlendState blendState = null) where T : struct, ISourceVertexType
        {
            var selectedEffect = effect != null ? effect : device.FxPrimitive;
            var selectedBlend = blendState != null ? blendState : SourceBlendState.AlphaBlend;
            var worldTransform = matrix;
            var viewport = new Vector2(device.ViewportWidth, device.ViewportHeight);
            matrix = SourceMatrixMath.Multiply(matrix,
                SourceMatrixMath.CreateScale(1f / viewport.X * 2f, (0f - 1f / viewport.Y) * 2f, 1f));
            matrix = SourceMatrixMath.Multiply(matrix, SourceMatrixMath.CreateTranslation(-1f, 1f, 0f));
            device.SetRasterizerState(SourceRasterizerState.CullNone);
            device.SetBlendState(selectedBlend);
            selectedEffect.Parameters["World"].SetValue(matrix);
            foreach (var pass in selectedEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                var observation = SourcePrimitivePresentation.Prepare(device, worldTransform, viewport, selectedEffect);
                var diagnostics = SourceFrameDiagnostics.Current;
                long submitStarted = 0;
                var measuringSubmit = diagnostics?.BeginPrimitiveNativeSubmit(out submitStarted) ?? false;
                try
                {
                    device.DrawUserTriangleList(vertices, 0, vertexCount / 3);
                }
                finally
                {
                    if (measuringSubmit) diagnostics.EndPrimitiveNativeSubmit(submitStarted);
                }

                long recordStarted = 0;
                var measuringRecord = diagnostics?.BeginPrimitivePresentationRecord(out recordStarted) ?? false;
                try
                {
                    observation.Record(vertices, vertexCount, null, vertexCount / 3);
                }
                finally
                {
                    if (measuringRecord) diagnostics.EndPrimitivePresentationRecord(recordStarted);
                }
            }
        }

        public static void DrawIndexedVertices<T>(ISourcePrimitiveGraphicsDevice device, Matrix4x4 matrix,
            T[] vertices, int vertexCount, int[] indices, int primitiveCount,
            SourceEffect effect = null, SourceBlendState blendState = null) where T : struct, ISourceVertexType
        {
            var selectedEffect = effect != null ? effect : device.FxPrimitive;
            var selectedBlend = blendState != null ? blendState : SourceBlendState.AlphaBlend;
            var worldTransform = matrix;
            var viewport = new Vector2(device.ViewportWidth, device.ViewportHeight);
            matrix = SourceMatrixMath.Multiply(matrix,
                SourceMatrixMath.CreateScale(1f / viewport.X * 2f, (0f - 1f / viewport.Y) * 2f, 1f));
            matrix = SourceMatrixMath.Multiply(matrix, SourceMatrixMath.CreateTranslation(-1f, 1f, 0f));
            device.SetRasterizerState(SourceRasterizerState.CullNone);
            device.SetBlendState(selectedBlend);
            selectedEffect.Parameters["World"].SetValue(matrix);
            foreach (var pass in selectedEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                var observation = SourcePrimitivePresentation.Prepare(device, worldTransform, viewport, selectedEffect);
                var diagnostics = SourceFrameDiagnostics.Current;
                long submitStarted = 0;
                var measuringSubmit = diagnostics?.BeginPrimitiveNativeSubmit(out submitStarted) ?? false;
                try
                {
                    device.DrawUserIndexedTriangleList(vertices, 0, vertexCount, indices, 0, primitiveCount);
                }
                finally
                {
                    if (measuringSubmit) diagnostics.EndPrimitiveNativeSubmit(submitStarted);
                }

                long recordStarted = 0;
                var measuringRecord = diagnostics?.BeginPrimitivePresentationRecord(out recordStarted) ?? false;
                try
                {
                    observation.Record(vertices, vertexCount, indices, primitiveCount);
                }
                finally
                {
                    if (measuringRecord) diagnostics.EndPrimitivePresentationRecord(recordStarted);
                }
            }
        }
    }
}
