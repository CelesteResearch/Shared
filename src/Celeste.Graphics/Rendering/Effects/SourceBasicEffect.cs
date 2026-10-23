using System.Numerics;
using Celeste.Graphics.Rendering.Textures;

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
            get => world;
            set
            {
                world = value;
                dirtyFlags |= SourceEffectDirtyFlags.WorldViewProj | SourceEffectDirtyFlags.World |
                              SourceEffectDirtyFlags.Fog;
            }
        }

        public Matrix4x4 View
        {
            get => view;
            set
            {
                view = value;
                dirtyFlags |= SourceEffectDirtyFlags.WorldViewProj | SourceEffectDirtyFlags.EyePosition |
                              SourceEffectDirtyFlags.Fog;
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

        public Vector3 EmissiveColor
        {
            get => emissiveColor;
            set
            {
                emissiveColor = value;
                dirtyFlags |= SourceEffectDirtyFlags.MaterialColor;
            }
        }

        public Vector3 SpecularColor
        {
            get => specularColorParam.GetValueVector3();
            set => specularColorParam.SetValue(value);
        }

        public float SpecularPower
        {
            get => specularPowerParam.GetValueSingle();
            set => specularPowerParam.SetValue(value);
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

        public bool LightingEnabled
        {
            get => lightingEnabled;
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
            get => preferPerPixelLighting;
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
            get => ambientLightColor;
            set
            {
                ambientLightColor = value;
                dirtyFlags |= SourceEffectDirtyFlags.MaterialColor;
            }
        }

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public SourceDirectionalLight DirectionalLight0 => light0;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public SourceDirectionalLight DirectionalLight1 => light1;

        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public SourceDirectionalLight DirectionalLight2 => light2;

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

        public bool TextureEnabled
        {
            get => textureEnabled;
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
            AmbientLightColor =
                SourceEffectHelpers.EnableDefaultLighting(DirectionalLight0, DirectionalLight1, DirectionalLight2);
        }

        private void CacheEffectParameters(SourceBasicEffect cloneSource)
        {
            textureParam = Parameters["Texture"];
            diffuseColorParam = Parameters["DiffuseColor"];
            emissiveColorParam = Parameters["EmissiveColor"];
            specularColorParam = Parameters["SpecularColor"];
            specularPowerParam = Parameters["SpecularPower"];
            eyePositionParam = Parameters["EyePosition"];
            fogColorParam = Parameters["FogColor"];
            fogVectorParam = Parameters["FogVector"];
            worldParam = Parameters["World"];
            worldInverseTransposeParam = Parameters["WorldInverseTranspose"];
            worldViewProjParam = Parameters["WorldViewProj"];
            shaderIndexParam = Parameters["ShaderIndex"];
            light0 = new(Parameters["DirLight0Direction"],
                Parameters["DirLight0DiffuseColor"], Parameters["DirLight0SpecularColor"],
                cloneSource?.DirectionalLight0);
            light1 = new(Parameters["DirLight1Direction"],
                Parameters["DirLight1DiffuseColor"], Parameters["DirLight1SpecularColor"],
                cloneSource?.DirectionalLight1);
            light2 = new(Parameters["DirLight2Direction"],
                Parameters["DirLight2DiffuseColor"], Parameters["DirLight2SpecularColor"],
                cloneSource?.DirectionalLight2);
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
                var flag = !DirectionalLight1.Enabled && !DirectionalLight2.Enabled;
                if (oneLight != flag)
                {
                    oneLight = flag;
                    dirtyFlags |= SourceEffectDirtyFlags.ShaderIndex;
                }
            }

            if ((dirtyFlags & SourceEffectDirtyFlags.ShaderIndex) != 0)
            {
                var num = 0;
                if (!fogEnabled) num++;

                if (vertexColorEnabled) num += 2;

                if (textureEnabled) num += 4;

                if (lightingEnabled) num = preferPerPixelLighting ? num + 24 : !oneLight ? num + 8 : num + 16;

                shaderIndexParam.SetValue(num);
                dirtyFlags &= ~SourceEffectDirtyFlags.ShaderIndex;
            }
        }
    }
}
