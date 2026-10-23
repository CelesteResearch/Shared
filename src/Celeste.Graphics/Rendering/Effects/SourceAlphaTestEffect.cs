using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering.States;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Rendering.Effects
{
    public class SourceAlphaTestEffect : SourceEffect, ISourceEffectMatrices, ISourceEffectFog
    {
        private SourceEffectParameter textureParam;

        private SourceEffectParameter diffuseColorParam;

        private SourceEffectParameter alphaTestParam;

        private SourceEffectParameter fogColorParam;

        private SourceEffectParameter fogVectorParam;

        private SourceEffectParameter worldViewProjParam;

        private SourceEffectParameter shaderIndexParam;

        private bool fogEnabled;

        private bool vertexColorEnabled;

        private Matrix4x4 world = Matrix4x4.Identity;

        private Matrix4x4 view = Matrix4x4.Identity;

        private Matrix4x4 projection = Matrix4x4.Identity;

        private Matrix4x4 worldView;

        private Vector3 diffuseColor = Vector3.One;

        private float alpha = 1f;

        private float fogStart;

        private float fogEnd = 1f;

        private SourceCompareFunction alphaFunction = SourceCompareFunction.Greater;

        private int referenceAlpha;

        private bool isEqNe;

        private SourceEffectDirtyFlags dirtyFlags = SourceEffectDirtyFlags.All;

        public Matrix4x4 World
        {
            get => world;
            set
            {
                world = value;
                dirtyFlags |= SourceEffectDirtyFlags.WorldViewProj | SourceEffectDirtyFlags.Fog;
            }
        }

        public Matrix4x4 View
        {
            get => view;
            set
            {
                view = value;
                dirtyFlags |= SourceEffectDirtyFlags.WorldViewProj | SourceEffectDirtyFlags.Fog;
            }
        }

        public Matrix4x4 Projection
        {
            get => projection;
            set
            {
                projection = value;
                dirtyFlags |= SourceEffectDirtyFlags.WorldViewProj;
            }
        }

        public Vector3 DiffuseColor
        {
            get => diffuseColor;
            set
            {
                diffuseColor = value;
                dirtyFlags |= SourceEffectDirtyFlags.MaterialColor;
            }
        }

        public float Alpha
        {
            get => alpha;
            set
            {
                alpha = value;
                dirtyFlags |= SourceEffectDirtyFlags.MaterialColor;
            }
        }

        public bool FogEnabled
        {
            get => fogEnabled;
            set
            {
                if (fogEnabled != value)
                {
                    fogEnabled = value;
                    dirtyFlags |= SourceEffectDirtyFlags.FogEnable | SourceEffectDirtyFlags.ShaderIndex;
                }
            }
        }

        public float FogStart
        {
            get => fogStart;
            set
            {
                fogStart = value;
                dirtyFlags |= SourceEffectDirtyFlags.Fog;
            }
        }

        public float FogEnd
        {
            get => fogEnd;
            set
            {
                fogEnd = value;
                dirtyFlags |= SourceEffectDirtyFlags.Fog;
            }
        }

        public Vector3 FogColor
        {
            get => fogColorParam.GetValueVector3();
            set => fogColorParam.SetValue(value);
        }

        public SourceTexture2DResource Texture
        {
            get => textureParam.GetValueTexture2D();
            set => textureParam.SetValue(value);
        }

        public bool VertexColorEnabled
        {
            get => vertexColorEnabled;
            set
            {
                if (vertexColorEnabled != value)
                {
                    vertexColorEnabled = value;
                    dirtyFlags |= SourceEffectDirtyFlags.ShaderIndex;
                }
            }
        }

        public SourceCompareFunction AlphaFunction
        {
            get => alphaFunction;
            set
            {
                alphaFunction = value;
                dirtyFlags |= SourceEffectDirtyFlags.AlphaTest;
            }
        }

        public int ReferenceAlpha
        {
            get => referenceAlpha;
            set
            {
                referenceAlpha = value;
                dirtyFlags |= SourceEffectDirtyFlags.AlphaTest;
            }
        }

        public SourceAlphaTestEffect(SourceGraphicsDevice device, SourceStockEffectResources stockResources)
            : base(device, stockResources.AlphaTestEffect)
        {
            CacheEffectParameters();
        }

        protected SourceAlphaTestEffect(SourceAlphaTestEffect cloneSource)
            : base(cloneSource)
        {
            CacheEffectParameters();
            fogEnabled = cloneSource.fogEnabled;
            vertexColorEnabled = cloneSource.vertexColorEnabled;
            world = cloneSource.world;
            view = cloneSource.view;
            projection = cloneSource.projection;
            diffuseColor = cloneSource.diffuseColor;
            alpha = cloneSource.alpha;
            fogStart = cloneSource.fogStart;
            fogEnd = cloneSource.fogEnd;
            alphaFunction = cloneSource.alphaFunction;
            referenceAlpha = cloneSource.referenceAlpha;
        }

        public override SourceEffect Clone()
        {
            return new SourceAlphaTestEffect(this);
        }

        private void CacheEffectParameters()
        {
            textureParam = Parameters["Texture"];
            diffuseColorParam = Parameters["DiffuseColor"];
            alphaTestParam = Parameters["AlphaTest"];
            fogColorParam = Parameters["FogColor"];
            fogVectorParam = Parameters["FogVector"];
            worldViewProjParam = Parameters["WorldViewProj"];
            shaderIndexParam = Parameters["ShaderIndex"];
        }

        protected internal override void OnApply()
        {
            dirtyFlags = SourceEffectHelpers.SetWorldViewProjAndFog(dirtyFlags, ref world, ref view, ref projection,
                ref worldView, fogEnabled, fogStart, fogEnd, worldViewProjParam, fogVectorParam);
            if ((dirtyFlags & SourceEffectDirtyFlags.MaterialColor) != 0)
            {
                diffuseColorParam.SetValue(new Vector4(SourceVector3Math.Multiply(diffuseColor, alpha), alpha));
                dirtyFlags &= ~SourceEffectDirtyFlags.MaterialColor;
            }

            if ((dirtyFlags & SourceEffectDirtyFlags.AlphaTest) != 0)
            {
                var value = default(Vector4);
                var flag = false;
                var num = referenceAlpha / 255f;
                switch (alphaFunction)
                {
                    case SourceCompareFunction.Less:
                        value.X = num - 0.0019607844f;
                        value.Z = 1f;
                        value.W = -1f;
                        break;
                    case SourceCompareFunction.LessEqual:
                        value.X = num + 0.0019607844f;
                        value.Z = 1f;
                        value.W = -1f;
                        break;
                    case SourceCompareFunction.GreaterEqual:
                        value.X = num - 0.0019607844f;
                        value.Z = -1f;
                        value.W = 1f;
                        break;
                    case SourceCompareFunction.Greater:
                        value.X = num + 0.0019607844f;
                        value.Z = -1f;
                        value.W = 1f;
                        break;
                    case SourceCompareFunction.Equal:
                        value.X = num;
                        value.Y = 0.0019607844f;
                        value.Z = 1f;
                        value.W = -1f;
                        flag = true;
                        break;
                    case SourceCompareFunction.NotEqual:
                        value.X = num;
                        value.Y = 0.0019607844f;
                        value.Z = -1f;
                        value.W = 1f;
                        flag = true;
                        break;
                    case SourceCompareFunction.Never:
                        value.Z = -1f;
                        value.W = -1f;
                        break;
                    default:
                        value.Z = 1f;
                        value.W = 1f;
                        break;
                }

                alphaTestParam.SetValue(value);
                dirtyFlags &= ~SourceEffectDirtyFlags.AlphaTest;
                if (isEqNe != flag)
                {
                    isEqNe = flag;
                    dirtyFlags |= SourceEffectDirtyFlags.ShaderIndex;
                }
            }

            if ((dirtyFlags & SourceEffectDirtyFlags.ShaderIndex) != 0)
            {
                var num2 = 0;
                if (!fogEnabled) num2++;

                if (vertexColorEnabled) num2 += 2;

                if (isEqNe) num2 += 4;

                shaderIndexParam.SetValue(num2);
                dirtyFlags &= ~SourceEffectDirtyFlags.ShaderIndex;
            }
        }
    }
}
