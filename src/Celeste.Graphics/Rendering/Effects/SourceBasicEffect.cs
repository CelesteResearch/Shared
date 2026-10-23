using Celeste.Graphics.Rendering.Textures;
using System;
using System.Numerics;
using Celeste.Core.Mathematics.LinearAlgebra;

namespace Celeste.Graphics.Rendering.Effects
{
    public class SourceBasicEffect : SourceEffect, ISourceEffectMatrices, ISourceEffectLights, ISourceEffectFog
    {
        private SourceEffectParameter textureParam;

        private SourceEffectParameter diffuseColorParam;

        private SourceEffectParameter emissiveColorParam;

        private SourceEffectParameter specularColorParam;

        private SourceEffectParameter specularPowerParam;

        private SourceEffectParameter eyePositionParam;

        private SourceEffectParameter fogColorParam;

        private SourceEffectParameter fogVectorParam;

        private SourceEffectParameter worldParam;

        private SourceEffectParameter worldInverseTransposeParam;

        private SourceEffectParameter worldViewProjParam;

        private SourceEffectParameter shaderIndexParam;

        private bool lightingEnabled;

        private bool preferPerPixelLighting;

        private bool oneLight;

        private bool fogEnabled;

        private bool textureEnabled;

        private bool vertexColorEnabled;

        private Matrix4x4 world = Matrix4x4.Identity;

        private Matrix4x4 view = Matrix4x4.Identity;

        private Matrix4x4 projection = Matrix4x4.Identity;

        private Matrix4x4 worldView;

        private Vector3 diffuseColor = Vector3.One;

        private Vector3 emissiveColor = Vector3.Zero;

        private Vector3 ambientLightColor = Vector3.Zero;

        private float alpha = 1f;

        private SourceDirectionalLight light0;

        private SourceDirectionalLight light1;

        private SourceDirectionalLight light2;

        private float fogStart;

        private float fogEnd = 1f;

        private SourceEffectDirtyFlags dirtyFlags = SourceEffectDirtyFlags.All;

        public Matrix4x4 World
        {
            get { return world; }
            set
            {
                world = value;
                dirtyFlags |= SourceEffectDirtyFlags.WorldViewProj | SourceEffectDirtyFlags.World |
                              SourceEffectDirtyFlags.Fog;
            }
        }

        public Matrix4x4 View
        {
            get { return view; }
            set
            {
                view = value;
                dirtyFlags |= SourceEffectDirtyFlags.WorldViewProj | SourceEffectDirtyFlags.EyePosition |
                              SourceEffectDirtyFlags.Fog;
            }
        }

        public Matrix4x4 Projection
        {
            get { return projection; }
            set
            {
                projection = value;
                dirtyFlags |= SourceEffectDirtyFlags.WorldViewProj;
            }
        }

        public Vector3 DiffuseColor
        {
            get { return diffuseColor; }
            set
            {
                diffuseColor = value;
                dirtyFlags |= SourceEffectDirtyFlags.MaterialColor;
            }
        }

        public Vector3 EmissiveColor
        {
            get { return emissiveColor; }
            set
            {
                emissiveColor = value;
                dirtyFlags |= SourceEffectDirtyFlags.MaterialColor;
            }
        }

        public Vector3 SpecularColor
        {
            get { return specularColorParam.GetValueVector3(); }
            set { specularColorParam.SetValue(value); }
        }

        public float SpecularPower
        {
            get { return specularPowerParam.GetValueSingle(); }
            set { specularPowerParam.SetValue(value); }
        }

        public float Alpha
        {
            get { return alpha; }
            set
            {
                alpha = value;
                dirtyFlags |= SourceEffectDirtyFlags.MaterialColor;
            }
        }

        public bool LightingEnabled
        {
            get { return lightingEnabled; }
            set
            {
                if (lightingEnabled != value)
                {
                    lightingEnabled = value;
                    dirtyFlags |= SourceEffectDirtyFlags.MaterialColor | SourceEffectDirtyFlags.ShaderIndex;
                }
            }
        }

        public bool PreferPerPixelLighting
        {
            get { return preferPerPixelLighting; }
            set
            {
                if (preferPerPixelLighting != value)
                {
                    preferPerPixelLighting = value;
                    dirtyFlags |= SourceEffectDirtyFlags.ShaderIndex;
                }
            }
        }

        public Vector3 AmbientLightColor
        {
            get { return ambientLightColor; }
            set
            {
                ambientLightColor = value;
                dirtyFlags |= SourceEffectDirtyFlags.MaterialColor;
            }
        }

        public SourceDirectionalLight DirectionalLight0 => light0;

        public SourceDirectionalLight DirectionalLight1 => light1;

        public SourceDirectionalLight DirectionalLight2 => light2;

        public bool FogEnabled
        {
            get { return fogEnabled; }
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
            get { return fogStart; }
            set
            {
                fogStart = value;
                dirtyFlags |= SourceEffectDirtyFlags.Fog;
            }
        }

        public float FogEnd
        {
            get { return fogEnd; }
            set
            {
                fogEnd = value;
                dirtyFlags |= SourceEffectDirtyFlags.Fog;
            }
        }

        public Vector3 FogColor
        {
            get { return fogColorParam.GetValueVector3(); }
            set { fogColorParam.SetValue(value); }
        }

        public bool TextureEnabled
        {
            get { return textureEnabled; }
            set
            {
                if (textureEnabled != value)
                {
                    textureEnabled = value;
                    dirtyFlags |= SourceEffectDirtyFlags.ShaderIndex;
                }
            }
        }

        public SourceTexture2DResource Texture
        {
            get { return textureParam.GetValueTexture2D(); }
            set { textureParam.SetValue(value); }
        }

        public bool VertexColorEnabled
        {
            get { return vertexColorEnabled; }
            set
            {
                if (vertexColorEnabled != value)
                {
                    vertexColorEnabled = value;
                    dirtyFlags |= SourceEffectDirtyFlags.ShaderIndex;
                }
            }
        }

        public SourceBasicEffect(ISourceEffectDevice device, SourceStockEffectResources stockResources)
            : base(device, stockResources.BasicEffect)
        {
            CacheEffectParameters(null);
            DirectionalLight0.Enabled = true;
            SpecularColor = Vector3.One;
            SpecularPower = 16f;
        }

        protected SourceBasicEffect(SourceBasicEffect cloneSource)
            : base(cloneSource)
        {
            CacheEffectParameters(cloneSource);
            lightingEnabled = cloneSource.lightingEnabled;
            preferPerPixelLighting = cloneSource.preferPerPixelLighting;
            fogEnabled = cloneSource.fogEnabled;
            textureEnabled = cloneSource.textureEnabled;
            vertexColorEnabled = cloneSource.vertexColorEnabled;
            world = cloneSource.world;
            view = cloneSource.view;
            projection = cloneSource.projection;
            diffuseColor = cloneSource.diffuseColor;
            emissiveColor = cloneSource.emissiveColor;
            ambientLightColor = cloneSource.ambientLightColor;
            alpha = cloneSource.alpha;
            fogStart = cloneSource.fogStart;
            fogEnd = cloneSource.fogEnd;
        }

        public override SourceEffect Clone()
        {
            return new SourceBasicEffect(this);
        }

        public void EnableDefaultLighting()
        {
            LightingEnabled = true;
            AmbientLightColor = SourceEffectHelpers.EnableDefaultLighting(light0, light1, light2);
        }

        private void CacheEffectParameters(SourceBasicEffect cloneSource)
        {
            textureParam = base.Parameters["Texture"];
            diffuseColorParam = base.Parameters["DiffuseColor"];
            emissiveColorParam = base.Parameters["EmissiveColor"];
            specularColorParam = base.Parameters["SpecularColor"];
            specularPowerParam = base.Parameters["SpecularPower"];
            eyePositionParam = base.Parameters["EyePosition"];
            fogColorParam = base.Parameters["FogColor"];
            fogVectorParam = base.Parameters["FogVector"];
            worldParam = base.Parameters["World"];
            worldInverseTransposeParam = base.Parameters["WorldInverseTranspose"];
            worldViewProjParam = base.Parameters["WorldViewProj"];
            shaderIndexParam = base.Parameters["ShaderIndex"];
            light0 = new SourceDirectionalLight(base.Parameters["DirLight0Direction"],
                base.Parameters["DirLight0DiffuseColor"], base.Parameters["DirLight0SpecularColor"],
                cloneSource?.light0);
            light1 = new SourceDirectionalLight(base.Parameters["DirLight1Direction"],
                base.Parameters["DirLight1DiffuseColor"], base.Parameters["DirLight1SpecularColor"],
                cloneSource?.light1);
            light2 = new SourceDirectionalLight(base.Parameters["DirLight2Direction"],
                base.Parameters["DirLight2DiffuseColor"], base.Parameters["DirLight2SpecularColor"],
                cloneSource?.light2);
        }

        protected internal override void OnApply()
        {
            dirtyFlags = SourceEffectHelpers.SetWorldViewProjAndFog(dirtyFlags, ref world, ref view, ref projection,
                ref worldView, fogEnabled, fogStart, fogEnd, worldViewProjParam, fogVectorParam);
            if ((dirtyFlags & SourceEffectDirtyFlags.MaterialColor) != 0)
            {
                SourceEffectHelpers.SetMaterialColor(lightingEnabled, alpha, ref diffuseColor, ref emissiveColor,
                    ref ambientLightColor, diffuseColorParam, emissiveColorParam);
                dirtyFlags &= ~SourceEffectDirtyFlags.MaterialColor;
            }

            if (lightingEnabled)
            {
                dirtyFlags = SourceEffectHelpers.SetLightingMatrices(dirtyFlags, ref world, ref view, worldParam,
                    worldInverseTransposeParam, eyePositionParam);
                bool flag = !light1.Enabled && !light2.Enabled;
                if (oneLight != flag)
                {
                    oneLight = flag;
                    dirtyFlags |= SourceEffectDirtyFlags.ShaderIndex;
                }
            }

            if ((dirtyFlags & SourceEffectDirtyFlags.ShaderIndex) != 0)
            {
                int num = 0;
                if (!fogEnabled)
                {
                    num++;
                }

                if (vertexColorEnabled)
                {
                    num += 2;
                }

                if (textureEnabled)
                {
                    num += 4;
                }

                if (lightingEnabled)
                {
                    num = (preferPerPixelLighting ? (num + 24) : ((!oneLight) ? (num + 8) : (num + 16)));
                }

                shaderIndexParam.SetValue(num);
                dirtyFlags &= ~SourceEffectDirtyFlags.ShaderIndex;
            }
        }
    }
}
