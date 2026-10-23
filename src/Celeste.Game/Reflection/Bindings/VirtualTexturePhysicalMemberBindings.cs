using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Reflection.Bindings
{
    public static class VirtualTexturePhysicalMemberBindings
    {
        public static void RegisterInstalled(SourceMemberCatalog members)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition = members.RequireDefinition(assembly, "Monocle.VirtualTexture", "Texture_Safe",
                SourceMemberKind.Property);
            var owner = typeof(VirtualTexture);
            var property = owner.GetProperty(nameof(VirtualTexture.TextureSafe), BindingFlags.Public |
                               BindingFlags.Instance | BindingFlags.DeclaredOnly)
                           ?? throw new MissingMemberException(owner.FullName, nameof(VirtualTexture.TextureSafe));
            members.RegisterBinding(new(definition, owner, property));
        }

        public static void Register(SourceMemberCatalog members)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition = members.RequireDefinition(assembly, "Monocle.VirtualTexture", "Texture",
                SourceMemberKind.Field);
            if ((definition.MetadataToken != 67110605 && definition.MetadataToken != 67110941) ||
                definition.IsStatic || !definition.IsPublic || definition.IsLiteral || definition.IsInitOnly ||
                definition.ValueTypeIdentity != "Microsoft.Xna.Framework.Graphics.Texture2D")
                throw new InvalidOperationException(
                    "VirtualTexture.Texture source FieldDef differs from the supported profiles.");
            var owner = typeof(VirtualTexture);
            var property = owner.GetProperty(nameof(VirtualTexture.Texture), BindingFlags.Public |
                                                                             BindingFlags.Instance |
                                                                             BindingFlags.DeclaredOnly)
                           ?? throw new MissingMemberException(owner.FullName, nameof(VirtualTexture.Texture));
            if (property.PropertyType != typeof(SourceTexture2DResource) || !property.CanRead || !property.CanWrite ||
                property.GetMethod.IsStatic || property.SetMethod.IsStatic)
                throw new InvalidOperationException("VirtualTexture.Texture must bind its raw resource property.");
            members.RegisterBinding(new(definition, owner, property));
        }
    }
}
