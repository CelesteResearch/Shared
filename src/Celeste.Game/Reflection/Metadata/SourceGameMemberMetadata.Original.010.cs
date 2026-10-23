using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMemberMetadata
    {
        private static void PublishOriginal010(SourceMemberCatalog catalog)
        {
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_LOWPASS_SIMPLE", 33554591,
                257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_LOWPASS_SIMPLE", 67109663,
                "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_LOWPASS_SIMPLE", 67109664,
                "CUTOFF", SourceMemberKind.Field, 32854, "FMOD.DSP_LOWPASS_SIMPLE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_LOWPASS_SIMPLE")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_SEND", 33554592, 257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_SEND", 67109665, "value__",
                SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_SEND", 67109666, "RETURNID",
                SourceMemberKind.Field, 32854, "FMOD.DSP_SEND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_SEND")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_SEND", 67109667, "LEVEL",
                SourceMemberKind.Field, 32854, "FMOD.DSP_SEND", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_SEND")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_RETURN", 33554593, 257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_RETURN", 67109668,
                "value__",
                SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_RETURN", 67109669, "ID",
                SourceMemberKind.Field, 32854, "FMOD.DSP_RETURN", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_RETURN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_RETURN", 67109670,
                "INPUT_SPEAKER_MODE", SourceMemberKind.Field, 32854, "FMOD.DSP_RETURN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_RETURN")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_HIGHPASS_SIMPLE", 33554594,
                257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_HIGHPASS_SIMPLE", 67109671,
                "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_HIGHPASS_SIMPLE", 67109672,
                "CUTOFF", SourceMemberKind.Field, 32854, "FMOD.DSP_HIGHPASS_SIMPLE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_HIGHPASS_SIMPLE")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_2D_STEREO_MODE_TYPE",
                33554595, 257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_2D_STEREO_MODE_TYPE",
                67109673, "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_2D_STEREO_MODE_TYPE",
                67109674, "DISTRIBUTED", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_2D_STEREO_MODE_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_2D_STEREO_MODE_TYPE")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_2D_STEREO_MODE_TYPE",
                67109675, "DISCRETE", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_2D_STEREO_MODE_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_2D_STEREO_MODE_TYPE")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_MODE_TYPE", 33554596,
                257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_MODE_TYPE", 67109676,
                "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_MODE_TYPE", 67109677,
                "MONO", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_MODE_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_MODE_TYPE")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_MODE_TYPE", 67109678,
                "STEREO", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_MODE_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_MODE_TYPE")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_MODE_TYPE", 67109679,
                "SURROUND", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_MODE_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_MODE_TYPE")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
                33554597,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
                67109680,
                "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
                67109681,
                "LINEARSQUARED", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_3D_ROLLOFF_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_3D_ROLLOFF_TYPE")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
                67109682,
                "LINEAR", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_3D_ROLLOFF_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_3D_ROLLOFF_TYPE")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
                67109683,
                "INVERSE", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_3D_ROLLOFF_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_3D_ROLLOFF_TYPE")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
                67109684,
                "INVERSETAPERED", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_3D_ROLLOFF_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_3D_ROLLOFF_TYPE")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_ROLLOFF_TYPE",
                67109685,
                "CUSTOM", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_3D_ROLLOFF_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_3D_ROLLOFF_TYPE")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE",
                33554598, 257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE",
                67109686, "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE",
                67109687, "AUTO", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE",
                67109688, "USER", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE",
                67109689, "OFF", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN_3D_EXTENT_MODE_TYPE")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 33554599, 257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109690, "value__",
                SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109691, "MODE",
                SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109692,
                "_2D_STEREO_POSITION", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109693,
                "_2D_DIRECTION",
                SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109694,
                "_2D_EXTENT",
                SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109695,
                "_2D_ROTATION",
                SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109696,
                "_2D_LFE_LEVEL",
                SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x05, 0x00, 0x00, 0x00]), "System.Int32",
                "05000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109697,
                "_2D_STEREO_MODE", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x06, 0x00, 0x00, 0x00]), "System.Int32",
                "06000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109698,
                "_2D_STEREO_SEPARATION", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x07, 0x00, 0x00, 0x00]), "System.Int32",
                "07000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109699,
                "_2D_STEREO_AXIS", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x08, 0x00, 0x00, 0x00]), "System.Int32",
                "08000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109700,
                "ENABLED_SPEAKERS", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x09, 0x00, 0x00, 0x00]), "System.Int32",
                "09000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109701,
                "_3D_POSITION",
                SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x0A, 0x00, 0x00, 0x00]), "System.Int32",
                "0A000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109702,
                "_3D_ROLLOFF",
                SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x0B, 0x00, 0x00, 0x00]), "System.Int32",
                "0B000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109703,
                "_3D_MIN_DISTANCE", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x0C, 0x00, 0x00, 0x00]), "System.Int32",
                "0C000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109704,
                "_3D_MAX_DISTANCE", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x0D, 0x00, 0x00, 0x00]), "System.Int32",
                "0D000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109705,
                "_3D_EXTENT_MODE", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x0E, 0x00, 0x00, 0x00]), "System.Int32",
                "0E000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109706,
                "_3D_SOUND_SIZE", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x0F, 0x00, 0x00, 0x00]), "System.Int32",
                "0F000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109707,
                "_3D_MIN_EXTENT", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x10, 0x00, 0x00, 0x00]), "System.Int32",
                "10000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109708,
                "_3D_PAN_BLEND",
                SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x11, 0x00, 0x00, 0x00]), "System.Int32",
                "11000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109709,
                "LFE_UPMIX_ENABLED", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x12, 0x00, 0x00, 0x00]), "System.Int32",
                "12000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109710,
                "OVERALL_GAIN",
                SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x13, 0x00, 0x00, 0x00]), "System.Int32",
                "13000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109711,
                "SURROUND_SPEAKER_MODE", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x14, 0x00, 0x00, 0x00]), "System.Int32",
                "14000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_PAN", 67109712,
                "_2D_HEIGHT_BLEND", SourceMemberKind.Field, 32854, "FMOD.DSP_PAN", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x15, 0x00, 0x00, 0x00]), "System.Int32",
                "15000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_PAN")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE",
                33554600, 257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE",
                67109713, "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE",
                67109714, "_12DB", SourceMemberKind.Field, 32854, "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE",
                67109715, "_24DB", SourceMemberKind.Field, 32854, "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE",
                67109716, "_48DB", SourceMemberKind.Field, 32854, "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_THREE_EQ_CROSSOVERSLOPE_TYPE")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_THREE_EQ", 33554601, 257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_THREE_EQ", 67109717,
                "value__",
                SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_THREE_EQ", 67109718,
                "LOWGAIN",
                SourceMemberKind.Field, 32854, "FMOD.DSP_THREE_EQ", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_THREE_EQ")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_THREE_EQ", 67109719,
                "MIDGAIN",
                SourceMemberKind.Field, 32854, "FMOD.DSP_THREE_EQ", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_THREE_EQ")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_THREE_EQ", 67109720,
                "HIGHGAIN",
                SourceMemberKind.Field, 32854, "FMOD.DSP_THREE_EQ", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_THREE_EQ")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_THREE_EQ", 67109721,
                "LOWCROSSOVER", SourceMemberKind.Field, 32854, "FMOD.DSP_THREE_EQ", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_THREE_EQ")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_THREE_EQ", 67109722,
                "HIGHCROSSOVER", SourceMemberKind.Field, 32854, "FMOD.DSP_THREE_EQ", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_THREE_EQ")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_THREE_EQ", 67109723,
                "CROSSOVERSLOPE", SourceMemberKind.Field, 32854, "FMOD.DSP_THREE_EQ", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x05, 0x00, 0x00, 0x00]), "System.Int32",
                "05000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_THREE_EQ")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT_WINDOW", 33554602, 257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT_WINDOW", 67109724,
                "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT_WINDOW", 67109725,
                "RECT",
                SourceMemberKind.Field, 32854, "FMOD.DSP_FFT_WINDOW", -1, -1, 0, (SourceDeclaredAttribute[])[],
                true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]),
                "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_FFT_WINDOW")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT_WINDOW", 67109726,
                "TRIANGLE", SourceMemberKind.Field, 32854, "FMOD.DSP_FFT_WINDOW", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_FFT_WINDOW")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT_WINDOW", 67109727,
                "HAMMING", SourceMemberKind.Field, 32854, "FMOD.DSP_FFT_WINDOW", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_FFT_WINDOW")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT_WINDOW", 67109728,
                "HANNING", SourceMemberKind.Field, 32854, "FMOD.DSP_FFT_WINDOW", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_FFT_WINDOW")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT_WINDOW", 67109729,
                "BLACKMAN", SourceMemberKind.Field, 32854, "FMOD.DSP_FFT_WINDOW", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_FFT_WINDOW")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT_WINDOW", 67109730,
                "BLACKMANHARRIS", SourceMemberKind.Field, 32854, "FMOD.DSP_FFT_WINDOW", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x05, 0x00, 0x00, 0x00]), "System.Int32",
                "05000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_FFT_WINDOW")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT", 33554603, 257,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT", 67109731, "value__",
                SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT", 67109732,
                "WINDOWSIZE",
                SourceMemberKind.Field, 32854, "FMOD.DSP_FFT", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_FFT")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT", 67109733,
                "WINDOWTYPE",
                SourceMemberKind.Field, 32854, "FMOD.DSP_FFT", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_FFT")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT", 67109734,
                "SPECTRUMDATA",
                SourceMemberKind.Field, 32854, "FMOD.DSP_FFT", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_FFT")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_FFT", 67109735,
                "DOMINANT_FREQ",
                SourceMemberKind.Field, 32854, "FMOD.DSP_FFT", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_FFT")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_ENVELOPEFOLLOWER", 33554604,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_ENVELOPEFOLLOWER", 67109736,
                "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_ENVELOPEFOLLOWER", 67109737,
                "ATTACK", SourceMemberKind.Field, 32854, "FMOD.DSP_ENVELOPEFOLLOWER", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_ENVELOPEFOLLOWER")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_ENVELOPEFOLLOWER", 67109738,
                "RELEASE", SourceMemberKind.Field, 32854, "FMOD.DSP_ENVELOPEFOLLOWER", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_ENVELOPEFOLLOWER")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_ENVELOPEFOLLOWER", 67109739,
                "ENVELOPE", SourceMemberKind.Field, 32854, "FMOD.DSP_ENVELOPEFOLLOWER", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_ENVELOPEFOLLOWER")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_ENVELOPEFOLLOWER", 67109740,
                "USESIDECHAIN", SourceMemberKind.Field, 32854, "FMOD.DSP_ENVELOPEFOLLOWER", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x03, 0x00, 0x00, 0x00]), "System.Int32",
                "03000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_ENVELOPEFOLLOWER")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_CONVOLUTION_REVERB",
                33554605,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [], [], "System.Int32", [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Enum"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_CONVOLUTION_REVERB",
                67109741,
                "value__", SourceMemberKind.Field, 1542, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_CONVOLUTION_REVERB",
                67109742,
                "IR", SourceMemberKind.Field, 32854, "FMOD.DSP_CONVOLUTION_REVERB", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x00, 0x00, 0x00, 0x00]), "System.Int32",
                "00000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_CONVOLUTION_REVERB")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "FMOD.DSP_CONVOLUTION_REVERB",
                67109743,
                "WET", SourceMemberKind.Field, 32854, "FMOD.DSP_CONVOLUTION_REVERB", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "FMOD.DSP_CONVOLUTION_REVERB")));
        }
    }
}
