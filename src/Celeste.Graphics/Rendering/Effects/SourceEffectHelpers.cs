using System;
using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;

namespace Celeste.Graphics.Rendering.Effects
{
    internal static class SourceEffectHelpers
    {
        internal static Vector3 EnableDefaultLighting(SourceDirectionalLight light0, SourceDirectionalLight light1,
            SourceDirectionalLight light2)
        {
            light0.Direction = new Vector3(-0.5265408f, -0.5735765f, -0.6275069f);
            light0.DiffuseColor = new Vector3(1f, 0.9607844f, 0.8078432f);
            light0.SpecularColor = new Vector3(1f, 0.9607844f, 0.8078432f);
            light0.Enabled = true;
            light1.Direction = new Vector3(0.7198464f, 0.3420201f, 0.6040227f);
            light1.DiffuseColor = new Vector3(82f / 85f, 0.7607844f, 0.4078432f);
            light1.SpecularColor = Vector3.Zero;
            light1.Enabled = true;
            light2.Direction = new Vector3(0.4545195f, -0.7660444f, 0.4545195f);
            light2.DiffuseColor = new Vector3(0.3231373f, 0.3607844f, 0.3937255f);
            light2.SpecularColor = new Vector3(0.3231373f, 0.3607844f, 0.3937255f);
            light2.Enabled = true;
            return new Vector3(0.05333332f, 0.09882354f, 0.1819608f);
        }

        internal static SourceEffectDirtyFlags SetWorldViewProjAndFog(SourceEffectDirtyFlags dirtyFlags,
            ref Matrix4x4 world, ref Matrix4x4 view, ref Matrix4x4 projection, ref Matrix4x4 worldView, bool fogEnabled,
            float fogStart, float fogEnd, SourceEffectParameter worldViewProjParam,
            SourceEffectParameter fogVectorParam)
        {
            if ((dirtyFlags & SourceEffectDirtyFlags.WorldViewProj) != 0)
            {
                SourceMatrixMath.Multiply(ref world, ref view, out worldView);
                SourceMatrixMath.Multiply(ref worldView, ref projection, out var result);
                worldViewProjParam.SetValue(result);
                dirtyFlags &= ~SourceEffectDirtyFlags.WorldViewProj;
            }

            if (fogEnabled)
            {
                if ((dirtyFlags & (SourceEffectDirtyFlags.Fog | SourceEffectDirtyFlags.FogEnable)) != 0)
                {
                    SetFogVector(ref worldView, fogStart, fogEnd, fogVectorParam);
                    dirtyFlags &= ~(SourceEffectDirtyFlags.Fog | SourceEffectDirtyFlags.FogEnable);
                }
            }
            else if ((dirtyFlags & SourceEffectDirtyFlags.FogEnable) != 0)
            {
                fogVectorParam.SetValue(Vector4.Zero);
                dirtyFlags &= ~SourceEffectDirtyFlags.FogEnable;
            }

            return dirtyFlags;
        }

        private static void SetFogVector(ref Matrix4x4 worldView, float fogStart, float fogEnd,
            SourceEffectParameter fogVectorParam)
        {
            if (fogStart == fogEnd)
            {
                fogVectorParam.SetValue(new Vector4(0f, 0f, 0f, 1f));
                return;
            }

            float num = 1f / (fogStart - fogEnd);
            fogVectorParam.SetValue(new Vector4
            {
                X = worldView.M13 * num,
                Y = worldView.M23 * num,
                Z = worldView.M33 * num,
                W = (worldView.M43 + fogStart) * num
            });
        }

        internal static SourceEffectDirtyFlags SetLightingMatrices(SourceEffectDirtyFlags dirtyFlags,
            ref Matrix4x4 world,
            ref Matrix4x4 view, SourceEffectParameter worldParam, SourceEffectParameter worldInverseTransposeParam,
            SourceEffectParameter eyePositionParam)
        {
            if ((dirtyFlags & SourceEffectDirtyFlags.World) != 0)
            {
                SourceMatrixMath.Invert(ref world, out var result);
                SourceMatrixMath.Transpose(ref result, out var result2);
                worldParam.SetValue(world);
                worldInverseTransposeParam.SetValue(result2);
                dirtyFlags &= ~SourceEffectDirtyFlags.World;
            }

            if ((dirtyFlags & SourceEffectDirtyFlags.EyePosition) != 0)
            {
                SourceMatrixMath.Invert(ref view, out var result3);
                eyePositionParam.SetValue(new Vector3(result3.M41, result3.M42, result3.M43));
                dirtyFlags &= ~SourceEffectDirtyFlags.EyePosition;
            }

            return dirtyFlags;
        }

        internal static void SetMaterialColor(bool lightingEnabled, float alpha, ref Vector3 diffuseColor,
            ref Vector3 emissiveColor, ref Vector3 ambientLightColor, SourceEffectParameter diffuseColorParam,
            SourceEffectParameter emissiveColorParam)
        {
            if (lightingEnabled)
            {
                Vector4 value = default(Vector4);
                Vector3 value2 = default(Vector3);
                value.X = diffuseColor.X * alpha;
                value.Y = diffuseColor.Y * alpha;
                value.Z = diffuseColor.Z * alpha;
                value.W = alpha;
                value2.X = (emissiveColor.X + ambientLightColor.X * diffuseColor.X) * alpha;
                value2.Y = (emissiveColor.Y + ambientLightColor.Y * diffuseColor.Y) * alpha;
                value2.Z = (emissiveColor.Z + ambientLightColor.Z * diffuseColor.Z) * alpha;
                diffuseColorParam.SetValue(value);
                emissiveColorParam.SetValue(value2);
            }
            else
            {
                diffuseColorParam.SetValue(new Vector4
                {
                    X = (diffuseColor.X + emissiveColor.X) * alpha,
                    Y = (diffuseColor.Y + emissiveColor.Y) * alpha,
                    Z = (diffuseColor.Z + emissiveColor.Z) * alpha,
                    W = alpha
                });
            }
        }
    }
}
