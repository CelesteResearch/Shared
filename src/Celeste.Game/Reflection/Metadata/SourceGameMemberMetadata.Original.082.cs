using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;

namespace Celeste.Game.Reflection.Metadata
{
    public static partial class SourceGameMemberMetadata
    {
        private static void PublishOriginal082(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainState", 67112564,
                "FogColor", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Color", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Skybox", 33555026, 1048577,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Skybox", 67112565, "Verts",
                SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Graphics.VertexPositionColorTexture[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "Microsoft.Xna.Framework.Graphics.VertexPositionColorTexture"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Skybox", 67112566, "Texture",
                SourceMemberKind.Field, 6, "Monocle.VirtualTexture", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.VirtualTexture")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Ring", 33555027, 1048577,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Ring", 67112567, "Verts",
                SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Graphics.VertexPositionColorTexture[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "Microsoft.Xna.Framework.Graphics.VertexPositionColorTexture"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Ring", 67112568, "Texture",
                SourceMemberKind.Field, 6, "Monocle.VirtualTexture", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.VirtualTexture")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Ring", 67112569, "TopColor",
                SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Color", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Ring", 67112570, "BotColor",
                SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Color", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Color")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 33555028,
                1048577, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                ["System.IDisposable"], [], null,
                ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.IDisposable"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112571,
                "Camera", SourceMemberKind.Field, 6, "Celeste.MountainCamera", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.MountainCamera")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112572,
                "Forward", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112573,
                "SkyboxOffset", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112574,
                "LockBufferResizing", SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112575,
                "buffer", SourceMemberKind.Field, 1, "Monocle.VirtualRenderTarget", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.VirtualRenderTarget")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112576,
                "blurA", SourceMemberKind.Field, 1, "Monocle.VirtualRenderTarget", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.VirtualRenderTarget")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112577,
                "blurB", SourceMemberKind.Field, 1, "Monocle.VirtualRenderTarget", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.VirtualRenderTarget")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112578,
                "MountainRasterizer", SourceMemberKind.Field, 22, "Microsoft.Xna.Framework.Graphics.RasterizerState",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Graphics.RasterizerState")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112579,
                "CullNoneRasterizer", SourceMemberKind.Field, 22, "Microsoft.Xna.Framework.Graphics.RasterizerState",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Graphics.RasterizerState")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112580,
                "CullCCRasterizer", SourceMemberKind.Field, 22, "Microsoft.Xna.Framework.Graphics.RasterizerState", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Graphics.RasterizerState")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112581,
                "CullCRasterizer", SourceMemberKind.Field, 22, "Microsoft.Xna.Framework.Graphics.RasterizerState", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Graphics.RasterizerState")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112582,
                "currState", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112583,
                "nextState", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112584,
                "targetState", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112585,
                "easeState", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112586,
                "mountainStates", SourceMemberKind.Field, 1, "Celeste.MountainState[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        "Celeste.MountainState"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112587,
                "CoreWallPosition", SourceMemberKind.Field, 6, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112588,
                "billboardVertices", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Graphics.VertexBuffer", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Graphics.VertexBuffer")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112589,
                "billboardIndices", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Graphics.IndexBuffer", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Graphics.IndexBuffer")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112590,
                "billboardInfo", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.Graphics.VertexPositionColorTexture[]",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "Microsoft.Xna.Framework.Graphics.VertexPositionColorTexture"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112591,
                "billboardTextures", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Graphics.Texture2D[]", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.SzArray,
                    elementType: new(
                        SourceTypeReferenceKind.Named,
                        "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                        "Microsoft.Xna.Framework.Graphics.Texture2D"), arrayRank: 1,
                    arrayDimensions: [new(null, null)])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112592,
                "fog",
                SourceMemberKind.Field, 1, "Celeste.Ring", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Ring")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112593,
                "fog2",
                SourceMemberKind.Field, 1, "Celeste.Ring", -1, -1, 0, (SourceDeclaredAttribute[])[], false,
                null,
                null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Ring")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112594,
                "NearFogAlpha", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112595,
                "StarEase", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112596,
                "SnowStretch", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112597,
                "SnowSpeedAddition", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112598,
                "SnowForceFloat", SourceMemberKind.Field, 6, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112599,
                "starsky", SourceMemberKind.Field, 1, "Celeste.Ring", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Ring")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112600,
                "starfog", SourceMemberKind.Field, 1, "Celeste.Ring", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Ring")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112601,
                "stardots0", SourceMemberKind.Field, 1, "Celeste.Ring", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Ring")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112602,
                "starstream0", SourceMemberKind.Field, 1, "Celeste.Ring", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Ring")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112603,
                "starstream1", SourceMemberKind.Field, 1, "Celeste.Ring", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Ring")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112604,
                "starstream2", SourceMemberKind.Field, 1, "Celeste.Ring", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Ring")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112605,
                "ignoreCameraRotation", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112606,
                "lastCameraRotation", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Quaternion", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Quaternion")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112607,
                "starCenter", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Vector3", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                new(
                    SourceTypeReferenceKind.Named,
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112608,
                "birdTimer", SourceMemberKind.Field, 1, "System.Single", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112609,
                "DebugPoints", SourceMemberKind.Field, 6,
                "System.Collections.Generic.List`1<Microsoft.Xna.Framework.Graphics.VertexPositionColor>", -1, -1, 0,
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
                            "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            "Microsoft.Xna.Framework.Graphics.VertexPositionColor"),
                    ])));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.MountainModel", 67112610,
                "DrawDebugPoints", SourceMemberKind.Field, 6, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldLoader", 33555029,
                1048577, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Scene",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Scene"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldLoader", 67112611,
                "StartMode", SourceMemberKind.Field, 6, "Celeste.Overworld+StartMode", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Overworld+StartMode")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldLoader", 67112612,
                "Snow", SourceMemberKind.Field, 6, "Celeste.HiresSnow", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.HiresSnow")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldLoader", 67112613,
                "loaded", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldLoader", 67112614,
                "fadeIn", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldLoader", 67112615,
                "overworld", SourceMemberKind.Field, 1, "Celeste.Overworld", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Overworld")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldLoader", 67112616,
                "postcard", SourceMemberKind.Field, 1, "Celeste.Postcard", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Postcard")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldLoader", 67112617,
                "showVariantPostcard", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldLoader", 67112618,
                "showUnlockCSidePostcard", SourceMemberKind.Field, 1, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldLoader", 67112619,
                "activeThread", SourceMemberKind.Field, 1, "System.Threading.Thread", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Threading.Thread")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldLoader+<Routine>d__12",
                33555829, 1048835, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object",
                [
                    "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Collections.Generic.IEnumerator`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.IDisposable"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.IEnumerator"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldLoader+<Routine>d__12",
                67118749, "<>1__state", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldLoader+<Routine>d__12",
                67118750, "<>2__current", SourceMemberKind.Field, 1, "System.Object", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldLoader+<Routine>d__12",
                67118751, "<>4__this", SourceMemberKind.Field, 6, "Celeste.OverworldLoader", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OverworldLoader")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldLoader+<Routine>d__12",
                67118752, "session", SourceMemberKind.Field, 6, "Celeste.Session", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Session")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldLoader+<Routine>d__12",
                385877147, "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property,
                0,
                "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldLoader+<Routine>d__12",
                385877148, "System.Collections.IEnumerator.Current", SourceMemberKind.Property, 0, "System.Object",
                2529,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldReflectionsFall",
                33555030, 1048577, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Scene",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Scene"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldReflectionsFall",
                67112620, "returnTo", SourceMemberKind.Field, 1, "Celeste.Level", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Level")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldReflectionsFall",
                67112621, "returnCallback", SourceMemberKind.Field, 1, "System.Action", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Action")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldReflectionsFall",
                67112622, "maddy", SourceMemberKind.Field, 1, "Celeste.Maddy3D", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.Maddy3D")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldReflectionsFall",
                67112623, "mountain", SourceMemberKind.Field, 1, "Celeste.MountainRenderer", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.MountainRenderer")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldReflectionsFall",
                67112624, "startCamera", SourceMemberKind.Field, 1, "Celeste.MountainCamera", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.MountainCamera")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OverworldReflectionsFall",
                67112625, "fallCamera", SourceMemberKind.Field, 1, "Celeste.MountainCamera", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.MountainCamera")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<Routine>d__7", 33555830, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [
                    "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Collections.Generic.IEnumerator`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.IDisposable"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.IEnumerator"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<Routine>d__7", 67118753, "<>1__state", SourceMemberKind.Field, 1,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<Routine>d__7", 67118754, "<>2__current", SourceMemberKind.Field, 1,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<Routine>d__7", 67118755, "<>4__this", SourceMemberKind.Field, 6,
                "Celeste.OverworldReflectionsFall", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OverworldReflectionsFall")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<Routine>d__7", 67118756, "<duration>5__2", SourceMemberKind.Field, 1,
                "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<Routine>d__7", 67118757, "<i>5__3", SourceMemberKind.Field, 1,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<Routine>d__7", 385877149,
                "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property, 0,
                "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<Routine>d__7", 385877150, "System.Collections.IEnumerator.Current",
                SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<MaddyFall>d__8", 33555831, 1048835,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [
                    "System.Collections.Generic.IEnumerator`1<System.Object>", "System.IDisposable",
                    "System.Collections.IEnumerator",
                ],
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null,
                [
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                ], [],
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"),
                [
                    new(
                        SourceTypeReferenceKind.GenericInstance,
                        elementType: new(
                            SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.Collections.Generic.IEnumerator`1"),
                        genericArguments:
                        [
                            new(
                                SourceTypeReferenceKind.Named,
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                "System.Object"),
                        ]),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.IDisposable"),
                    new(
                        SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.IEnumerator"),
                ]));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<MaddyFall>d__8", 67118758, "<>1__state", SourceMemberKind.Field, 1,
                "System.Int32", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<MaddyFall>d__8", 67118759, "<>2__current", SourceMemberKind.Field, 1,
                "System.Object", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<MaddyFall>d__8", 67118760, "<>4__this", SourceMemberKind.Field, 6,
                "Celeste.OverworldReflectionsFall", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null,
                null,
                null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OverworldReflectionsFall")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<MaddyFall>d__8", 67118761, "duration", SourceMemberKind.Field, 6,
                "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<MaddyFall>d__8", 67118762, "<p>5__2", SourceMemberKind.Field, 1,
                "System.Single", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Single")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<MaddyFall>d__8", 385877151,
                "System.Collections.Generic.IEnumerator<System.Object>.Current", SourceMemberKind.Property, 0,
                "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                "Celeste.OverworldReflectionsFall+<MaddyFall>d__8", 385877152, "System.Collections.IEnumerator.Current",
                SourceMemberKind.Property, 0, "System.Object", 2529, -1, 0, (SourceDeclaredAttribute[])[],
                false,
                null, null, null, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                new(
                    SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalDeaths", 33555031,
                1048577, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalPage",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage"),
                []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.OuiJournalDeaths", 67112626,
                "table", SourceMemberKind.Field, 1, "Celeste.OuiJournalPage+Table", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.OuiJournalPage+Table")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TestBreathingGame", 33555032,
                1048577, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Scene",
                [], [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Scene"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.TestBreathingGame", 67112627,
                "game", SourceMemberKind.Field, 1, "Celeste.BreathingMinigame", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.BreathingMinigame")));
            catalog.RegisterTypeDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LevelExit", 33555033,
                1048577,
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.Scene",
                [],
                [], null, [],
                [],
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Monocle.Scene"), []));
            catalog.RegisterDefinition(new(
                "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.LevelExit", 67112628, "mode",
                SourceMemberKind.Field, 1, "Celeste.LevelExit+Mode", -1, -1, 0, (SourceDeclaredAttribute[])[],
                false, null, null, null, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                new(
                    SourceTypeReferenceKind.Named,
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Celeste.LevelExit+Mode")));
        }
    }
}
