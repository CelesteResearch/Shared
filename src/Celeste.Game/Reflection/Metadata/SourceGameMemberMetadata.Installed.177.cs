using System;
using Celeste.Core.Reflection.Members;

namespace Celeste.Game.Reflection.Metadata;

public static partial class SourceGameMemberMetadata
{
    private static void PublishInstalled177(SourceMemberCatalog catalog)
    {
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+DeadParticle",
            33556491, 1048579, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+DeadParticle",
            67121764, "x", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+DeadParticle",
            67121765, "y", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+DeadParticle",
            67121766, "t", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+DeadParticle",
            67121767, "spd", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Vector2")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 33556492,
            1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121768,
            "p_jump", SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121769,
            "p_dash", SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121770,
            "grace", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121771,
            "jbuffer", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121772,
            "djump", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121773,
            "dash_time", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121774,
            "dash_effect_time", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121775,
            "dash_target", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Vector2")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121776,
            "dash_accel", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Vector2")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121777,
            "spr_off", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121778,
            "was_on_ground", SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player", 67121779,
            "hair", SourceMemberKind.Field, 6, "Celeste.Pico8.Classic+player_hair", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+player_hair")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_hair",
            33556493, 1048578, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_hair",
            67121780, "hair", SourceMemberKind.Field, 1, "Celeste.Pico8.Classic+player_hair+node[]", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.SzArray,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    typeIdentity: "Celeste.Pico8.Classic+player_hair+node"), arrayRank: 1,
                arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                    { new global::Celeste.Core.Reflection.Types.SourceArrayDimension(null, null) })));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_hair",
            67121781, "E", SourceMemberKind.Field, 1, "Celeste.Pico8.Emulator", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Emulator")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_hair",
            67121782, "G", SourceMemberKind.Field, 1, "Celeste.Pico8.Classic", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_hair+node",
            33556494, 1048579, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_hair+node",
            67121783, "x", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_hair+node",
            67121784, "y", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_hair+node",
            67121785, "size", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_spawn",
            33556495, 1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_spawn",
            67121786, "target", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Vector2")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_spawn",
            67121787, "state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_spawn",
            67121788, "delay", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+player_spawn",
            67121789, "hair", SourceMemberKind.Field, 1, "Celeste.Pico8.Classic+player_hair", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+player_hair")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+spring", 33556496,
            1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+spring", 67121790,
            "hide_in", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+spring", 67121791,
            "hide_for", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+spring", 67121792,
            "delay", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+balloon", 33556497,
            1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+balloon", 67121793,
            "offset", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+balloon", 67121794,
            "start", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+balloon", 67121795,
            "timer", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fall_floor",
            33556498, 1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fall_floor",
            67121796, "state", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fall_floor",
            67121797, "solid", SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fall_floor",
            67121798, "delay", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+smoke", 33556499,
            1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fruit", 33556500,
            1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fruit", 67121799,
            "start", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fruit", 67121800,
            "off", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(), false,
            null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fly_fruit",
            33556501, 1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fly_fruit",
            67121801, "start", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fly_fruit",
            67121802, "fly", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fly_fruit",
            67121803, "step", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fly_fruit",
            67121804, "sfx_delay", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+lifeup", 33556502,
            1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+lifeup", 67121805,
            "duration", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+lifeup", 67121806,
            "flash", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+fake_wall",
            33556503, 1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+key", 33556504,
            1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+chest", 33556505,
            1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+chest", 67121807,
            "start", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+chest", 67121808,
            "timer", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+platform",
            33556506, 1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+platform",
            67121809, "dir", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+platform",
            67121810, "last", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+message", 33556507,
            1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+message", 67121811,
            "last", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+message", 67121812,
            "index", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+big_chest",
            33556508, 1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+big_chest",
            67121813, "state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+big_chest",
            67121814, "timer", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+big_chest",
            67121815, "particles", SourceMemberKind.Field, 1,
            "System.Collections.Generic.List`1<Celeste.Pico8.Classic+big_chest+particle>", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Collections.Generic.List`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Pico8.Classic+big_chest+particle")
                })));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+big_chest+particle", 33556509, 1048579,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+big_chest+particle", 67121816, "x", SourceMemberKind.Field, 6, "System.Single", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+big_chest+particle", 67121817, "y", SourceMemberKind.Field, 6, "System.Single", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+big_chest+particle", 67121818, "h", SourceMemberKind.Field, 6, "System.Single", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+big_chest+particle", 67121819, "spd", SourceMemberKind.Field, 6, "System.Single", -1,
            -1, 0, Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+orb", 33556510,
            1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+flag", 33556511,
            1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+flag", 67121820,
            "score", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+flag", 67121821,
            "show", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0, Array.Empty<SourceDeclaredAttribute>(),
            false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+room_title",
            33556512, 1048578, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Pico8.Classic+ClassicObject", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null,
            new string[] { }, Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic+ClassicObject"),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+room_title",
            67121822, "delay", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            33556513, 1048578, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            "System.Object", Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121823, "G", SourceMemberKind.Field, 6, "Celeste.Pico8.Classic", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Classic")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121824, "E", SourceMemberKind.Field, 6, "Celeste.Pico8.Emulator", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Pico8.Emulator")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121825, "type", SourceMemberKind.Field, 6, "System.Int32", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121826, "collideable", SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121827, "solids", SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121828, "spr", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121829, "flipX", SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121830, "flipY", SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121831, "x", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121832, "y", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121833, "hitbox", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Rectangle", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121834, "spd", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Vector2")));
        catalog.RegisterDefinition(new SourceMemberDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Classic+ClassicObject",
            67121835, "rem", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
            Array.Empty<SourceDeclaredAttribute>(), false, null, null, null,
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Vector2")));
        catalog.RegisterTypeDefinition(new SourceTypeDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Pico8.Emulator", 33556514,
            1048577, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Scene",
            Array.Empty<string>(), Array.Empty<SourceDeclaredAttribute>(), null, new string[] { },
            Array.Empty<SourceGenericParameterDefinition>(),
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Scene"), new global::Celeste.Core.Reflection.Types.SourceTypeReference[] { }));
    }
}
