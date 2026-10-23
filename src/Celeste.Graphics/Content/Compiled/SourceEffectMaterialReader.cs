using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Graphics.Content.Compiled
{
    internal class SourceEffectMaterialReader : SourceContentTypeReader<SourceEffectMaterial>
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override SourceEffectMaterial Read(SourceContentReader input,
            SourceEffectMaterial existingInstance)
        {
            var effectMaterial = new SourceEffectMaterial(input.ReadExternalReference<SourceEffect>());
            foreach (var item in input.ReadObject<Dictionary<string, object>>())
            {
                var effectParameter = effectMaterial.Parameters[item.Key];
                if (effectParameter == null) continue;

                var type = item.Value.GetType();
                if (typeof(SourceTextureResource).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((SourceTextureResource)item.Value);
                    continue;
                }

                if (typeof(int).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((int)item.Value);
                    continue;
                }

                if (typeof(int[]).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((int[])item.Value);
                    continue;
                }

                if (typeof(bool).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((bool)item.Value);
                    continue;
                }

                if (typeof(float).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((float)item.Value);
                    continue;
                }

                if (typeof(float[]).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((float[])item.Value);
                    continue;
                }

                if (typeof(Vector2).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((Vector2)item.Value);
                    continue;
                }

                if (typeof(Vector2[]).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((Vector2[])item.Value);
                    continue;
                }

                if (typeof(Vector3).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((Vector3)item.Value);
                    continue;
                }

                if (typeof(Vector3[]).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((Vector3[])item.Value);
                    continue;
                }

                if (typeof(Vector4).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((Vector4)item.Value);
                    continue;
                }

                if (typeof(Vector4[]).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((Vector4[])item.Value);
                    continue;
                }

                if (typeof(Matrix4x4).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((Matrix4x4)item.Value);
                    continue;
                }

                if (typeof(Matrix4x4[]).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((Matrix4x4[])item.Value);
                    continue;
                }

                if (typeof(Quaternion).IsAssignableFrom(type))
                {
                    effectParameter.SetValue((Quaternion)item.Value);
                    continue;
                }

                throw new NotSupportedException("Parameter type is not supported");
            }

            return effectMaterial;
        }
    }
}
