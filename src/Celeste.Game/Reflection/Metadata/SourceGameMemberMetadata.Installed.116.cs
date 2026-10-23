using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMemberMetadata
    {
        private static void PublishInstalled116(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustStaticSpinner", 67116979,
                "P_Move", SourceMemberKind.Field, 22, "Monocle.ParticleType", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.ParticleType")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustStaticSpinner", 67116980,
                "ParticleInterval", SourceMemberKind.Field, 32854, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x0A, 0xD7, 0xA3, 0x3C]), "System.Single",
                "0AD7A33C", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustStaticSpinner", 67116981,
                "Sprite", SourceMemberKind.Field, 6, "Celeste.DustGraphic", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.DustGraphic")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustStaticSpinner", 67116982,
                "offset", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustTrackSpinner", 33555959,
                1048577, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TrackSpinner",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.TrackSpinner"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustTrackSpinner", 67116983,
                "dusty", SourceMemberKind.Field, 1, "Celeste.DustGraphic", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.DustGraphic")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DustTrackSpinner", 67116984,
                "outwards", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snowball", 33555960, 1048577,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Entity",
                [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Entity"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snowball", 67116985,
                "ResetTime",
                SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", [0xCD, 0xCC, 0x4C, 0x3F]), "System.Single",
                "CDCC4C3F", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snowball", 67116986,
                "sprite",
                SourceMemberKind.Field, 1, "Monocle.Sprite", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Sprite")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snowball", 67116987,
                "resetTimer", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snowball", 67116988, "level",
                SourceMemberKind.Field, 1, "Celeste.Level", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Level")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snowball", 67116989, "sine",
                SourceMemberKind.Field, 1, "Monocle.SineWave", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.SineWave")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snowball", 67116990, "atY",
                SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snowball", 67116991,
                "spawnSfx",
                SourceMemberKind.Field, 1, "Celeste.SoundSource", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.SoundSource")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Snowball", 67116992,
                "bounceCollider", SourceMemberKind.Field, 1, "Monocle.Collider", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Collider")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 33555961,
                1048577,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Solid",
                [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Solid"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67116993,
                "P_PressA", SourceMemberKind.Field, 22, "Monocle.ParticleType", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.ParticleType")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67116994,
                "P_PressB", SourceMemberKind.Field, 22, "Monocle.ParticleType", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.ParticleType")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67116995,
                "P_PressAMirror", SourceMemberKind.Field, 22, "Monocle.ParticleType", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.ParticleType")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67116996,
                "P_PressBMirror", SourceMemberKind.Field, 22, "Monocle.ParticleType", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.ParticleType")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67116997,
                "side",
                SourceMemberKind.Field, 1, "Celeste.DashSwitch+Sides", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.DashSwitch+Sides")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67116998,
                "pressedTarget", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67116999,
                "pressed",
                SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67117000,
                "pressDirection", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67117001,
                "speedY",
                SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67117002,
                "startY",
                SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67117003,
                "persistent", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67117004, "id",
                SourceMemberKind.Field, 1, "Celeste.EntityID", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.EntityID")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67117005,
                "mirrorMode", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67117006,
                "playerWasOn", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67117007,
                "allGates", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 67117008,
                "sprite",
                SourceMemberKind.Field, 1, "Monocle.Sprite", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Sprite")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch", 385877465,
                "FlagName", SourceMemberKind.Property, 0, "System.String", 2177, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch+Sides", 33555962,
                258,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch+Sides", 67117009,
                "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch+Sides", 67117010,
                "Up", SourceMemberKind.Field, 32854, "Celeste.DashSwitch+Sides", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.DashSwitch+Sides")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch+Sides", 67117011,
                "Down", SourceMemberKind.Field, 32854, "Celeste.DashSwitch+Sides", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.DashSwitch+Sides")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch+Sides", 67117012,
                "Left", SourceMemberKind.Field, 32854, "Celeste.DashSwitch+Sides", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.DashSwitch+Sides")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DashSwitch+Sides", 67117013,
                "Right", SourceMemberKind.Field, 32854, "Celeste.DashSwitch+Sides", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.DashSwitch+Sides")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cobweb", 33555963, 1048577,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Entity",
                [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Entity"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cobweb", 67117014, "color",
                SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Color", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Color")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cobweb", 67117015, "edge",
                SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Color", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Color")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cobweb", 67117016, "anchorA",
                SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cobweb", 67117017, "anchorB",
                SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cobweb", 67117018,
                "offshoots",
                SourceMemberKind.Field, 1, "System.Collections.Generic.List`1<Microsoft.Xna.Framework.Vector2>", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.Vector2"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cobweb", 67117019,
                "offshootEndings", SourceMemberKind.Field, 1, "System.Collections.Generic.List`1<System.Single>", -1,
                -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.GenericInstance,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.Generic.List`1"),
                    genericArguments:
                    [
                        new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Single"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cobweb", 67117020,
                "waveTimer",
                SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Cobweb", 67117021,
                "OverrideColors", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Color[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        "Microsoft.Xna.Framework.Color"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ResortLantern", 33555964,
                1048577, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Entity",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Entity"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ResortLantern", 67117022,
                "holder", SourceMemberKind.Field, 1, "Monocle.Image", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Image")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ResortLantern", 67117023,
                "lantern", SourceMemberKind.Field, 1, "Monocle.Sprite", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Sprite")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ResortLantern", 67117024,
                "collideTimer", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ResortLantern", 67117025,
                "mult",
                SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ResortLantern", 67117026,
                "wiggler", SourceMemberKind.Field, 1, "Monocle.Wiggler", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Wiggler")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ResortLantern", 67117027,
                "light", SourceMemberKind.Field, 1, "Celeste.VertexLight", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.VertexLight")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ResortLantern", 67117028,
                "bloom", SourceMemberKind.Field, 1, "Celeste.BloomPoint", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.BloomPoint")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ResortLantern", 67117029,
                "alphaTimer", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.ResortLantern", 67117030,
                "sfx",
                SourceMemberKind.Field, 1, "Celeste.SoundSource", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.SoundSource")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MrOshiroDoor", 33555965,
                1048577,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Solid",
                [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Solid"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MrOshiroDoor", 67117031,
                "sprite", SourceMemberKind.Field, 1, "Monocle.Sprite", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Sprite")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MrOshiroDoor", 67117032,
                "wiggler", SourceMemberKind.Field, 1, "Monocle.Wiggler", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Wiggler")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Door", 33555966, 1048577,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Actor",
                [],
                [
                    new("Monocle.Tracked", "System.Void Monocle.Tracked::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00, 0x00]),
                ], null, [], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Actor"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Door", 67117033, "sprite",
                SourceMemberKind.Field, 1, "Monocle.Sprite", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Sprite")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Door", 67117034, "openSfx",
                SourceMemberKind.Field, 1, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Door", 67117035, "closeSfx",
                SourceMemberKind.Field, 1, "System.String", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.String")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Door", 67117036, "occlude",
                SourceMemberKind.Field, 1, "Celeste.LightOcclude", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.LightOcclude")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Door", 67117037, "disabled",
                SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 33555967,
                1048577,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Solid",
                [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Solid"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117038,
                "P_Activate", SourceMemberKind.Field, 22, "Monocle.ParticleType", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.ParticleType")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117039,
                "P_Break",
                SourceMemberKind.Field, 22, "Monocle.ParticleType", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.ParticleType")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117040,
                "P_Move",
                SourceMemberKind.Field, 22, "Monocle.ParticleType", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.ParticleType")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117041,
                "Accel",
                SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", [0x00, 0x00, 0x96, 0x43]), "System.Single",
                "00009643", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117042,
                "MoveSpeed", SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x70, 0x42]), "System.Single",
                "00007042", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117043,
                "FastMoveSpeed", SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", [0x00, 0x00, 0x96, 0x42]), "System.Single",
                "00009642", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117044,
                "SteerSpeed", SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", [0xDB, 0x0F, 0x49, 0x42]), "System.Single",
                "DB0F4942", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117045,
                "MaxAngle",
                SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", [0xDB, 0x0F, 0x49, 0x3F]), "System.Single",
                "DB0F493F", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117046,
                "NoSteerTime", SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", [0xCD, 0xCC, 0x4C, 0x3E]), "System.Single",
                "CDCC4C3E", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117047,
                "CrashTime", SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", [0x9A, 0x99, 0x19, 0x3E]), "System.Single",
                "9A99193E", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117048,
                "CrashResetTime", SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", [0xCD, 0xCC, 0xCC, 0x3D]), "System.Single",
                "CDCCCC3D", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117049,
                "RegenTime", SourceMemberKind.Field, 32849, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Single", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x40, 0x40]), "System.Single",
                "00004040", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117050,
                "canSteer",
                SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117051, "fast",
                SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117052,
                "direction", SourceMemberKind.Field, 1, "Celeste.MoveBlock+Directions", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.MoveBlock+Directions")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117053,
                "homeAngle", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117054,
                "angleSteerSign", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117055,
                "startPosition", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector2", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117056,
                "state",
                SourceMemberKind.Field, 1, "Celeste.MoveBlock+MovementState", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.MoveBlock+MovementState")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117057,
                "leftPressed", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117058,
                "rightPressed", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117059,
                "topPressed", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117060,
                "speed",
                SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117061,
                "targetSpeed", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117062,
                "angle",
                SourceMemberKind.Field, 1, "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117063,
                "targetAngle", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MoveBlock", 67117064,
                "noSquish",
                SourceMemberKind.Field, 1, "Celeste.Player", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Player")));
        }
    }
}
