using System.Collections.Generic;
using Celeste.Core.Reflection.Methods;

namespace Celeste.Game.Reflection.Metadata;

public static partial class SourceGameMethodMetadata
{
    private static void PublishInstalled022(SourceAssemblyMethodCatalog catalog)
    {
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualRenderTarget", 33554848,
            100666817, "set_Preserve", 2177, "20010102",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 1, 134223565)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualRenderTarget", 33554848,
            100666818, "get_IsDisposed", 2182, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 14, 40));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualRenderTarget", 33554848,
            100666819, "get_Bounds", 2182, "20001180B1", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Rectangle", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Rectangle"), true, 4, 12));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualRenderTarget", 33554848,
            100666820, ".ctor", 6275, "2006010E0808080202", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
                { "System.String", "System.Int32", "System.Int32", "System.Int32", "System.Boolean", "System.Boolean" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("name", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223566),
                new SourceMethodParameterDefinition("width", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223567),
                new SourceMethodParameterDefinition("height", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223568),
                new SourceMethodParameterDefinition("multiSampleCount", 3, 0, "System.Int32", false, null,
                    new byte[] { }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 4, 134223569),
                new SourceMethodParameterDefinition("depth", 4, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 5, 134223570),
                new SourceMethodParameterDefinition("preserve", 5, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 6, 134223571)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 23, 58));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualRenderTarget", 33554848,
            100666821, "Unload", 707, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 33));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualRenderTarget", 33554848,
            100666822, "Reload", 707, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 28, 72));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualRenderTarget", 33554848,
            100666823, "Dispose", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualRenderTarget", 33554848,
            100666824, "op_Implicit", 2198, "00011281E9128680", new KeyValuePair<string, string>[] { },
            "Microsoft.Xna.Framework.Graphics.RenderTarget2D", new string[] { "Monocle.VirtualRenderTarget" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("target", 0, 0, "Monocle.VirtualRenderTarget", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.VirtualRenderTarget"), 1, 134223572)
            }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Microsoft.Xna.Framework.Graphics.RenderTarget2D"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666825, "get_Count", 2198, "000008", new KeyValuePair<string, string>[] { }, "System.Int32",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 3, 11));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666826, "CreateTexture", 150, "00011286640E", new KeyValuePair<string, string>[] { },
            "Monocle.VirtualTexture", new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("path", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223573)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.VirtualTexture"), true, 37, 91));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666827, "CreateTexture", 150, "00041286640E08081180AD", new KeyValuePair<string, string>[] { },
            "Monocle.VirtualTexture",
            new string[] { "System.String", "System.Int32", "System.Int32", "Microsoft.Xna.Framework.Color" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("name", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223574),
                new SourceMethodParameterDefinition("width", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223575),
                new SourceMethodParameterDefinition("height", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223576),
                new SourceMethodParameterDefinition("color", 3, 0, "Microsoft.Xna.Framework.Color", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Color"), 4, 134223577)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.VirtualTexture"), true, 11, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666828, "CreateRenderTarget", 150, "00061286800E0808020208", new KeyValuePair<string, string>[] { },
            "Monocle.VirtualRenderTarget",
            new string[]
                { "System.String", "System.Int32", "System.Int32", "System.Boolean", "System.Boolean", "System.Int32" },
            0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("name", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223578),
                new SourceMethodParameterDefinition("width", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223579),
                new SourceMethodParameterDefinition("height", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223580),
                new SourceMethodParameterDefinition("depth", 3, 4112, "System.Boolean", true, "System.Boolean",
                    new byte[] { 0x00 }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 4, 134223581),
                new SourceMethodParameterDefinition("preserve", 4, 4112, "System.Boolean", true, "System.Boolean",
                    new byte[] { 0x01 }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 5, 134223582),
                new SourceMethodParameterDefinition("multiSampleCount", 5, 4112, "System.Int32", true, "System.Int32",
                    new byte[] { 0x00, 0x00, 0x00, 0x00 },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 6, 134223583)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.VirtualRenderTarget"), true, 13, 27));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666829, "BySize", 150, "000001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 121, 354));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666830, "ByName", 150, "000001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 49, 124));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666831, "Remove", 147, "000101128660", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.VirtualAsset" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("asset", 0, 0, "Monocle.VirtualAsset", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.VirtualAsset"), 1, 134223584)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666832, "Reload", 150, "000001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 20, 64));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666833, "Unload", 150, "000001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 18, 57));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666834, ".cctor", 6289, "000001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 11));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666835, "get_Assets", 2198, "000015126901128660", new KeyValuePair<string, string>[] { },
            "System.Collections.Generic.List`1<Monocle.VirtualAsset>", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    typeIdentity: "System.Collections.Generic.List`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.VirtualAsset")
                }), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666836, "CreateTexture", 150, "000112866412A810", new KeyValuePair<string, string>[] { },
            "Monocle.VirtualTexture", new string[] { "Celeste.Mod.ModAsset" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("metadata", 0, 0, "Celeste.Mod.ModAsset", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Mod.ModAsset"), 1, 134223585)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.VirtualTexture"), true, 9, 25));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666837, "ForceReload", 150, "000001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 12));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualContent", 33554849,
            100666838, "UnloadOverworld", 150, "000001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 52, 162));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666839, ".ctor", 6278, "20030108081300", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32", "System.Int32", "T" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("columns", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223586),
                new SourceMethodParameterDefinition("rows", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223587),
                new SourceMethodParameterDefinition("emptyValue", 2, 4112, "T", true, null,
                    new byte[] { 0x00, 0x00, 0x00, 0x00 }, null,
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                        genericParameterPosition: 0,
                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                            .Type,
                        ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        ownerTypeIdentity: "Monocle.VirtualMap`1"), 3, 134223588)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 33, 75));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666840, ".ctor", 6278, "20020114130002000200001300", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "T[0...,0...]", "T" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("map", 0, 0, "T[0...,0...]", false, null, new byte[] { }, null,
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Array,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                            genericParameterPosition: 0,
                            genericParameterOwnerKind: global::Celeste.Core.Reflection.Types
                                .SourceGenericParameterOwnerKind.Type,
                            ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                            ownerTypeIdentity: "Monocle.VirtualMap`1"), arrayRank: 2,
                        arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceArrayDimension(0, null),
                            new global::Celeste.Core.Reflection.Types.SourceArrayDimension(0, null)
                        }), 1, 134223589),
                new SourceMethodParameterDefinition("emptyValue", 1, 4112, "T", true, null,
                    new byte[] { 0x00, 0x00, 0x00, 0x00 }, null,
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                        genericParameterPosition: 0,
                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                            .Type,
                        ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        ownerTypeIdentity: "Monocle.VirtualMap`1"), 2, 134223590)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 40, 72));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666841, "AnyInSegmentAtTile", 134, "2002020808", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223591),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223592)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 16, 27));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666842, "AnyInSegment", 134, "2002020808", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("segmentX", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223593),
                new SourceMethodParameterDefinition("segmentY", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223594)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 8, 17));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666843, "InSegment", 134, "2004130008080808", new KeyValuePair<string, string>[] { }, "T",
            new string[] { "System.Int32", "System.Int32", "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("segmentX", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223595),
                new SourceMethodParameterDefinition("segmentY", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223596),
                new SourceMethodParameterDefinition("x", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223597),
                new SourceMethodParameterDefinition("y", 3, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 4, 134223598)
            }, null,
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                genericParameterPosition: 0,
                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind.Type,
                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                ownerTypeIdentity: "Monocle.VirtualMap`1"), true, 9, 22));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666844, "GetSegment", 134, "200214130002000200000808", new KeyValuePair<string, string>[] { },
            "T[0...,0...]", new string[] { "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("segmentX", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223599),
                new SourceMethodParameterDefinition("segmentY", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223600)
            }, null,
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Array,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type, ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.VirtualMap`1"), arrayRank: 2,
                arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceArrayDimension(0, null),
                    new global::Celeste.Core.Reflection.Types.SourceArrayDimension(0, null)
                }), true, 6, 14));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666845, "SafeCheck", 134, "200213000808", new KeyValuePair<string, string>[] { }, "T",
            new string[] { "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223601),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223602)
            }, null,
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                genericParameterPosition: 0,
                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind.Type,
                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                ownerTypeIdentity: "Monocle.VirtualMap`1"), true, 22, 42));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666846, "get_Item", 2182, "200213000808", new KeyValuePair<string, string>[] { }, "T",
            new string[] { "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223603),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223604)
            }, null,
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                genericParameterPosition: 0,
                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind.Type,
                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                ownerTypeIdentity: "Monocle.VirtualMap`1"), true, 22, 42));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666847, "set_Item", 2182, "20030108081300", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32", "System.Int32", "T" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223605),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223606),
                new SourceMethodParameterDefinition("value", 2, 0, "T", false, null, new byte[] { }, null,
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                        genericParameterPosition: 0,
                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                            .Type,
                        ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        ownerTypeIdentity: "Monocle.VirtualMap`1"), 3, 134223607)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 21, 37));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666848, "ToArray", 134, "20001413000200020000", new KeyValuePair<string, string>[] { }, "T[0...,0...]",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { }, null,
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Array,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                    genericParameterPosition: 0,
                    genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                        .Type, ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    ownerTypeIdentity: "Monocle.VirtualMap`1"), arrayRank: 2,
                arrayDimensions: new global::Celeste.Core.Reflection.Types.SourceArrayDimension[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceArrayDimension(0, null),
                    new global::Celeste.Core.Reflection.Types.SourceArrayDimension(0, null)
                }), true, 38, 70));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666849, "Clone", 134, "200015128688011300", new KeyValuePair<string, string>[] { },
            "Monocle.VirtualMap`1<T>", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    typeIdentity: "Monocle.VirtualMap`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                        genericParameterPosition: 0,
                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                            .Type,
                        ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        ownerTypeIdentity: "Monocle.VirtualMap`1")
                }), true, 40, 76));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666850, "orig_get_Item", 134, "200213000808", new KeyValuePair<string, string>[] { }, "T",
            new string[] { "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223608),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223609)
            }, null,
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                genericParameterPosition: 0,
                genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind.Type,
                ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                ownerTypeIdentity: "Monocle.VirtualMap`1"), true, 32, 53));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Monocle.VirtualMap`1", 33554850,
            100666851, "orig_set_Item", 134, "20030108081300", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32", "System.Int32", "T" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223610),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 2, 134223611),
                new SourceMethodParameterDefinition("value", 2, 0, "T", false, null, new byte[] { }, null,
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericParameter,
                        genericParameterPosition: 0,
                        genericParameterOwnerKind: global::Celeste.Core.Reflection.Types.SourceGenericParameterOwnerKind
                            .Type,
                        ownerAssemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        ownerTypeIdentity: "Monocle.VirtualMap`1"), 3, 134223612)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 85, 193));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666852,
            "get_Font", 2182, "2000128610", new KeyValuePair<string, string>[] { }, "Monocle.PixelFont",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.PixelFont"), true, 4, 12));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666853,
            "get_FontSize", 2182, "200012860C", new KeyValuePair<string, string>[] { }, "Monocle.PixelFontSize",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.PixelFontSize"), true, 6, 18));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666854,
            "get_Item", 2182, "20010E0E", new KeyValuePair<string, string>[] { }, "System.String",
            new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("name", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223613)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666855,
            "CanDisplay", 134, "2001020E", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("text", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223614)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 29, 54));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666856,
            "Export", 134, "2001010E", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("path", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223615)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 90, 269));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666857,
            "FromExport", 150, "000112868C0E", new KeyValuePair<string, string>[] { }, "Celeste.Language",
            new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("path", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223616)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Language"), true, 7, 19));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666858,
            "FromTxt", 150, "000112868C0E", new KeyValuePair<string, string>[] { }, "Celeste.Language",
            new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("path", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223617)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Language"), true, 361, 1138));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666859,
            "Dispose", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 14, 48));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666860,
            ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 23, 80));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666861,
            ".cctor", 6289, "000001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 15, 64));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666862,
            "WholeLineIsCommandsRegex", 145, "0000128461",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Text.RegularExpressions.GeneratedRegexAttribute",
                    "0100135E283F3A5C7B5B5E7D5D2A5C7D5C732A292A240000"),
                new KeyValuePair<string, string>("System.CodeDom.Compiler.GeneratedCodeAttribute",
                    "01002853797374656D2E546578742E526567756C617245787072657373696F6E732E47656E657261746F720C382E302E31322E33363531340000")
            }, "System.Text.RegularExpressions.Regex", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                typeIdentity: "System.Text.RegularExpressions.Regex"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666863,
            "CommandRegex", 145, "0000128461",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Text.RegularExpressions.GeneratedRegexAttribute",
                    "0100095C7B282E2A3F295C7D400000000000"),
                new KeyValuePair<string, string>("System.CodeDom.Compiler.GeneratedCodeAttribute",
                    "01002853797374656D2E546578742E526567756C617245787072657373696F6E732E47656E657261746F720C382E302E31322E33363531340000")
            }, "System.Text.RegularExpressions.Regex", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                typeIdentity: "System.Text.RegularExpressions.Regex"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666864,
            "PortraitRegex", 145, "0000128461",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Text.RegularExpressions.GeneratedRegexAttribute",
                    "0100285C5B283F3C636F6E74656E743E5B5E5C5B5C5C5D2A283F3A5C5C2E5B5E5C5D5C5C5D2A292A295C5D010000000000"),
                new KeyValuePair<string, string>("System.CodeDom.Compiler.GeneratedCodeAttribute",
                    "01002853797374656D2E546578742E526567756C617245787072657373696F6E732E47656E657261746F720C382E302E31322E33363531340000")
            }, "System.Text.RegularExpressions.Regex", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                typeIdentity: "System.Text.RegularExpressions.Regex"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666865,
            "VariableRegex", 145, "0000128461",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Text.RegularExpressions.GeneratedRegexAttribute",
                    "0100085E5C772B5C3D2E2A0000"),
                new KeyValuePair<string, string>("System.CodeDom.Compiler.GeneratedCodeAttribute",
                    "01002853797374656D2E546578742E526567756C617245787072657373696F6E732E47656E657261746F720C382E302E31322E33363531340000")
            }, "System.Text.RegularExpressions.Regex", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                typeIdentity: "System.Text.RegularExpressions.Regex"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666866,
            "InsertRegex", 145, "0000128461",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Text.RegularExpressions.GeneratedRegexAttribute",
                    "01000E5C7B5C2B5C732A282E2A3F295C7D0000"),
                new KeyValuePair<string, string>("System.CodeDom.Compiler.GeneratedCodeAttribute",
                    "01002853797374656D2E546578742E526567756C617245787072657373696F6E732E47656E657261746F720C382E302E31322E33363531340000")
            }, "System.Text.RegularExpressions.Regex", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity:
                "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                typeIdentity: "System.Text.RegularExpressions.Regex"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666867,
            "SplitPair", 145, "000402151180B901030310151180B9010310151180B90103",
            new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[]
            {
                "System.ReadOnlySpan`1<System.Char>", "System.Char", "System.ReadOnlySpan`1<System.Char>&",
                "System.ReadOnlySpan`1<System.Char>&"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("from", 0, 0, "System.ReadOnlySpan`1<System.Char>", false, null,
                    new byte[] { }, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.ReadOnlySpan`1"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                typeIdentity: "System.Char")
                        }), 1, 134223618),
                new SourceMethodParameterDefinition("separator", 1, 0, "System.Char", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Char"), 2, 134223619),
                new SourceMethodParameterDefinition("left", 2, 2, "System.ReadOnlySpan`1<System.Char>&", false, null,
                    new byte[] { }, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                            elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                typeIdentity: "System.ReadOnlySpan`1"),
                            genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                            {
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                    assemblyIdentity:
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    typeIdentity: "System.Char")
                            })), 3, 134223620),
                new SourceMethodParameterDefinition("right", 3, 2, "System.ReadOnlySpan`1<System.Char>&", false, null,
                    new byte[] { }, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.ByReference,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                            elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                typeIdentity: "System.ReadOnlySpan`1"),
                            genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                            {
                                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                    assemblyIdentity:
                                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                    typeIdentity: "System.Char")
                            })), 4, 134223621)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 40, 87));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666868,
            "orig_FromExport", 150, "000112868C0E", new KeyValuePair<string, string>[] { }, "Celeste.Language",
            new string[] { "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("path", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223622)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Language"), true, 94, 261));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666869,
            "FromModExport", 150, "000112868C12A810", new KeyValuePair<string, string>[] { }, "Celeste.Language",
            new string[] { "Celeste.Mod.ModAsset" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("asset", 0, 0, "Celeste.Mod.ModAsset", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Mod.ModAsset"), 1, 134223623)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Language"), true, 99, 278));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666870,
            "_GetLanguageText", 145, "00021512808D010E0E12845D",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002843656C657374652E4C616E67756167652B3C5F4765744C616E6775616765546578743E645F5F31360000")
            }, "System.Collections.Generic.IEnumerable`1<System.String>",
            new string[] { "System.String", "System.Text.Encoding" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("path", 0, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 1, 134223624),
                new SourceMethodParameterDefinition("encoding", 1, 0, "System.Text.Encoding", false, null,
                    new byte[] { }, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        typeIdentity: "System.Text.Encoding"), 2, 134223625)
            }, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    typeIdentity: "System.Collections.Generic.IEnumerable`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String")
                }), true, 9, 22));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666871,
            "_NewLanguage", 145, "000012868C", new KeyValuePair<string, string>[] { }, "Celeste.Language",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Language"), true, 8, 21));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666872,
            "_SetItem", 145, "00040115128125020E0E0E0E12868C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
            {
                "System.Collections.Generic.Dictionary`2<System.String,System.String>", "System.String",
                "System.String", "Celeste.Language"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("dict", 0, 0,
                    "System.Collections.Generic.Dictionary`2<System.String,System.String>", false, null, new byte[] { },
                    "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.Collections.Generic.Dictionary`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                typeIdentity: "System.String"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                typeIdentity: "System.String")
                        }), 1, 134223626),
                new SourceMethodParameterDefinition("key", 1, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 2, 134223627),
                new SourceMethodParameterDefinition("value", 2, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 3, 134223628),
                new SourceMethodParameterDefinition("_lang", 3, 0, "Celeste.Language", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Language"), 4, 134223629)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 103, 292));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language", 33554851, 100666873,
            "<FromTxt>g__GetDialogWithResolvedInserts|12_0", 147, "00020E12868C0E",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.String", new string[] { "Celeste.Language", "System.String" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("language", 0, 0, "Celeste.Language", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Language"), 1, 134223630),
                new SourceMethodParameterDefinition("dialog", 1, 0, "System.String", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String"), 2, 134223631)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String"), true, 12, 37));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language+<>c", 33554852,
            100666874, ".cctor", 6289, "000001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 11));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language+<>c", 33554852,
            100666875, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language+<>c", 33554852,
            100666876, "<FromTxt>b__12_2", 131, "20010E12847D",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.NullableContextAttribute",
                    "0100010000")
            }, "System.String", new string[] { "System.Text.RegularExpressions.Match" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("match", 0, 0, "System.Text.RegularExpressions.Match", false, null,
                    new byte[] { },
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        typeIdentity: "System.Text.RegularExpressions.Match"), 1, 134223632)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String"), true, 24, 64));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language+<>c", 33554852,
            100666877, "<_GetLanguageText>b__16_1", 131, "200112A81015118289020E12A810",
            new KeyValuePair<string, string>[] { }, "Celeste.Mod.ModAsset",
            new string[] { "System.Collections.Generic.KeyValuePair`2<System.String,Celeste.Mod.ModAsset>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entry", 0, 0,
                    "System.Collections.Generic.KeyValuePair`2<System.String,Celeste.Mod.ModAsset>", false, null,
                    new byte[] { }, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.Collections.Generic.KeyValuePair`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                typeIdentity: "System.String"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Celeste.Mod.ModAsset")
                        }), 1, 134223633)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Mod.ModAsset"), true, 3, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language+<>c__DisplayClass12_0",
            33554853, 100666878, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language+<>c__DisplayClass12_0",
            33554853, 100666879, "<FromTxt>b__1", 131, "20010E12847D",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.NullableContextAttribute",
                    "0100010000")
            }, "System.String", new string[] { "System.Text.RegularExpressions.Match" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("match", 0, 0, "System.Text.RegularExpressions.Match", false, null,
                    new byte[] { },
                    "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity:
                        "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                        typeIdentity: "System.Text.RegularExpressions.Match"), 1, 134223634)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String"), true, 16, 52));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language+<>c__DisplayClass16_0",
            33554854, 100666880, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.Language+<>c__DisplayClass16_0",
            33554854, 100666881, "<_GetLanguageText>b__0", 131, "20010215118289020E12A810",
            new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Collections.Generic.KeyValuePair`2<System.String,Celeste.Mod.ModAsset>" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("entry", 0, 0,
                    "System.Collections.Generic.KeyValuePair`2<System.String,Celeste.Mod.ModAsset>", false, null,
                    new byte[] { }, "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                        elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                            global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                            typeIdentity: "System.Collections.Generic.KeyValuePair`2"),
                        genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                        {
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity:
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                                typeIdentity: "System.String"),
                            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                                typeIdentity: "Celeste.Mod.ModAsset")
                        }), 1, 134223635)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 16, 51));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666882,
            "System.Collections.Generic.IEnumerator<System.String>.get_Current", 2529, "20000E",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.String", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.String"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666883,
            "System.Collections.IEnumerator.get_Current", 2529, "20001C",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Object", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Object"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666884, ".ctor", 6278, "20010108",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("<>1__state", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223636)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 9, 25));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666885, "System.IDisposable.Dispose", 481,
            "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 66, 180));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666886, "MoveNext", 481, "200002",
            new KeyValuePair<string, string>[] { }, "System.Boolean", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 307, 945));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666887, "<>m__Finally1", 129, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 10, 27));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666888, "<>m__Finally2", 129, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 25));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666889, "<>m__Finally3", 129, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 10, 28));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666890, "<>m__Finally4", 129, "200001",
            new KeyValuePair<string, string>[] { }, "System.Void", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 10, 28));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666891, "System.Collections.IEnumerator.Reset",
            481, "200001",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 2, 6));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666892,
            "System.Collections.Generic.IEnumerable<System.String>.GetEnumerator", 481, "2000151280BD010E",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Collections.Generic.IEnumerator`1<System.String>", new string[] { }, 0,
            new SourceMethodParameterDefinition[] { },
            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.GenericInstance,
                elementType: new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                    typeIdentity: "System.Collections.Generic.IEnumerator`1"),
                genericArguments: new global::Celeste.Core.Reflection.Types.SourceTypeReference[]
                {
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.String")
                }), true, 27, 67));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "Celeste.Language+<_GetLanguageText>d__16", 33554855, 100666893,
            "System.Collections.IEnumerable.GetEnumerator", 481, "20001280C1",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("System.Diagnostics.DebuggerHiddenAttribute", "01000000") },
            "System.Collections.IEnumerator", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                typeIdentity: "System.Collections.IEnumerator"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DisconnectedControllerUI",
            33554856, 100666894, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 9, 30));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DisconnectedControllerUI",
            33554856, 100666895, "OnClose", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 5, 13));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DisconnectedControllerUI",
            33554856, 100666896, "Update", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 40, 111));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DisconnectedControllerUI",
            33554856, 100666897, "Render", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 58, 250));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DisconnectedControllerUI",
            33554856, 100666898, "IsGamepadConnected", 145, "000002", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 7, 19));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DisconnectedControllerUI",
            33554856, 100666899, "RequiresGamepad", 145, "000002", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 23, 64));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.DisconnectedControllerUI",
            33554856, 100666900, "CheckGamepadDisconnect", 150, "000001", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 31));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666901, ".ctor", 6278, "2003011180A10C0C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2", "System.Single", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223639),
                new SourceMethodParameterDefinition("width", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223640),
                new SourceMethodParameterDefinition("height", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134223641)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 83, 280));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666902, ".ctor", 6278, "200201129E781180A1", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223642),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223643)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 19, 51));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666903, "BuildSprite", 129, "2001151259011283DC128478", new KeyValuePair<string, string>[] { },
            "System.Collections.Generic.List`1<Monocle.Image>", new string[] { "Monocle.MTexture" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("source", 0, 0, "Monocle.MTexture", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.MTexture"), 1, 134223644)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
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
                        typeIdentity: "Monocle.Image")
                }), true, 112, 231));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666904, "ToggleSprite", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 51, 155));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666905, "Added", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223645)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 22, 52));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666906, "OnChangeMode", 129, "200101119BE0", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Session+CoreModes" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("coreMode", 0, 0, "Celeste.Session+CoreModes", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Session+CoreModes"), 1, 134223646)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 11));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666907, "CheckModeChange", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 12, 33));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666908, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 60, 159));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666909, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 530, 1619));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666910, "ReformParticles", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 116, 312));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666911, "WindUpPlayerCheck", 129, "2000129F24", new KeyValuePair<string, string>[] { }, "Celeste.Player",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.Player"), true, 58, 151));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666912, "ShakeOffPlayer", 129, "2001011180A1", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("liftSpeed", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223647)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 15, 36));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666913, "Break", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 177, 480));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock", 33554857,
            100666914, "<Update>b__38_0", 129, "200001",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 31));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock+RespawnDebris",
            33554859, 100666915, "Init", 134, "20041286AC1180A11180A1020C", new KeyValuePair<string, string>[] { },
            "Celeste.BounceBlock+RespawnDebris",
            new string[]
            {
                "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "System.Boolean", "System.Single"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("from", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223648),
                new SourceMethodParameterDefinition("to", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223649),
                new SourceMethodParameterDefinition("ice", 2, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 3, 134223650),
                new SourceMethodParameterDefinition("duration", 3, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 4, 134223651)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.BounceBlock+RespawnDebris"), true, 52, 137));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock+RespawnDebris",
            33554859, 100666916, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 35, 112));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock+RespawnDebris",
            33554859, 100666917, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 24));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock+RespawnDebris",
            33554859, 100666918, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock+BreakDebris",
            33554860, 100666919, "Init", 134, "20031286B01180A11180A102", new KeyValuePair<string, string>[] { },
            "Celeste.BounceBlock+BreakDebris",
            new string[] { "Microsoft.Xna.Framework.Vector2", "Microsoft.Xna.Framework.Vector2", "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223652),
                new SourceMethodParameterDefinition("direction", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223653),
                new SourceMethodParameterDefinition("ice", 2, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 3, 134223654)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.BounceBlock+BreakDebris"), true, 74, 220));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock+BreakDebris",
            33554860, 100666920, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 58, 187));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock+BreakDebris",
            33554860, 100666921, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 24));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.BounceBlock+BreakDebris",
            33554860, 100666922, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666923, ".ctor", 6278, "2006011180A1119BF00C0C080C", new KeyValuePair<string, string>[] { },
            "System.Void",
            new string[]
            {
                "Microsoft.Xna.Framework.Vector2", "Celeste.EntityID", "System.Single", "System.Single", "System.Int32",
                "System.Single"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223655),
                new SourceMethodParameterDefinition("id", 1, 0, "Celeste.EntityID", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityID"), 2, 134223656),
                new SourceMethodParameterDefinition("width", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134223657),
                new SourceMethodParameterDefinition("height", 3, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 4, 134223658),
                new SourceMethodParameterDefinition("index", 4, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 5, 134223659),
                new SourceMethodParameterDefinition("tempo", 5, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 6, 134223660)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 67, 214));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666924, ".ctor", 6278, "200301129E781180A1119BF0", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2", "Celeste.EntityID" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223661),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223662),
                new SourceMethodParameterDefinition("id", 2, 0, "Celeste.EntityID", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityID"), 3, 134223663)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 22, 62));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666925, "Awake", 198, "200101128588",
            new KeyValuePair<string, string>[]
                { new KeyValuePair<string, string>("MonoMod.PatchCassetteBlockAwakeAttribute", "01000000") },
            "System.Void", new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223664)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 550, 1426));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666926, "FindInGroup", 129, "2001011286B4", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.CassetteBlock" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("block", 0, 0, "Celeste.CassetteBlock", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.CassetteBlock"), 1, 134223665)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 89, 238));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666927, "CheckForSame", 129, "2002020C0C", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { "System.Single", "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223666),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223667)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 42, 108));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666928, "SetImage", 129, "2004010C0C0808", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single", "System.Single", "System.Int32", "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223668),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223669),
                new SourceMethodParameterDefinition("tx", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223670),
                new SourceMethodParameterDefinition("ty", 3, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 4, 134223671)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 33, 95));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666929, "CreateImage", 129, "20051283DC0C0C0808128478", new KeyValuePair<string, string>[] { },
            "Monocle.Image",
            new string[] { "System.Single", "System.Single", "System.Int32", "System.Int32", "Monocle.MTexture" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("x", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223672),
                new SourceMethodParameterDefinition("y", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223673),
                new SourceMethodParameterDefinition("tx", 2, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 3, 134223674),
                new SourceMethodParameterDefinition("ty", 3, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 4, 134223675),
                new SourceMethodParameterDefinition("tex", 4, 0, "Monocle.MTexture", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.MTexture"), 5, 134223676)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Monocle.Image"), true, 50, 117));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666930, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 78, 225));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666931, "BlockedCheck", 134, "200002", new KeyValuePair<string, string>[] { }, "System.Boolean",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 24, 44));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666932, "UpdateVisualState", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 210, 641));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666933, "SetActivatedSilently", 134, "20010102", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("activated", 0, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 1, 134223677)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 21, 46));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666934, "Finish", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666935, "WillToggle", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 25));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666936, "ShiftSize", 129, "20010108", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("amount", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223678)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666937, "TryActorWiggleUp", 129, "20010212846C", new KeyValuePair<string, string>[] { },
            "System.Boolean", new string[] { "Monocle.Entity" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("actor", 0, 0, "Monocle.Entity", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Entity"), 1, 134223679)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 79, 205));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock", 33554861,
            100666938, ".ctor", 6278, "200201129E781180A1", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223680),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223681)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 31));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock+BoxSide", 33554863,
            100666939, ".ctor", 6278, "2002011286B41180AD", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.CassetteBlock", "Microsoft.Xna.Framework.Color" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("block", 0, 0, "Celeste.CassetteBlock", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.CassetteBlock"), 1, 134223682),
                new SourceMethodParameterDefinition("color", 1, 0, "Microsoft.Xna.Framework.Color", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Color"), 2, 134223683)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 9, 21));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlock+BoxSide", 33554863,
            100666940, "Render", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 25, 77));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666941, ".ctor", 6278, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 17, 54));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666942, "Awake", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223684)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 83, 231));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666943, "Removed", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223685)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 15, 40));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666944, "SceneEnd", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223686)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 15, 40));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666945, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 57, 168));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666946, "AdvanceMusic", 134, "2001010C", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("time", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223687)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 142, 356));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666947, "GetSixteenthNote", 134, "200008", new KeyValuePair<string, string>[] { }, "System.Int32",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Int32"), true, 11, 23));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666948, "StopBlocks", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 46, 153));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666949, "Finish", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 10, 27));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666950, "OnLevelStart", 134, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 76, 187));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666951, "SilentUpdateBlocks", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 77, 256));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666952, "SetActiveIndex", 134, "20010108", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("index", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223688)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 47, 151));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666953, "SetWillActivate", 134, "20010108", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "System.Int32" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("index", 0, 0, "System.Int32", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Int32"), 1, 134223689)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 57, 171));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666954, "<.ctor>b__10_0", 129, "200001",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 18, 55));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666955, "orig_Awake", 134, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223690)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 47, 143));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CassetteBlockManager", 33554864,
            100666956, "<Awake>b__15_0", 129, "2001010C",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("_", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223691)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 6, 15));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666957, "get_HasGroup", 2182, "200002",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Boolean", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666958, "set_HasGroup", 2177, "20010102",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 1, 134223692)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666959, "get_MasterOfGroup", 2182, "200002",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Boolean", new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Boolean"), true, 3, 7));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666960, "set_MasterOfGroup", 2177, "20010102",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                    "01000000")
            }, "System.Void", new string[] { "System.Boolean" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("value", 0, 0, "System.Boolean", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 1, 134223693)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 4, 8));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666961, ".ctor", 6278, "2005011180A10C0C0302", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[]
            {
                "Microsoft.Xna.Framework.Vector2", "System.Single", "System.Single", "System.Char", "System.Boolean"
            }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("position", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223694),
                new SourceMethodParameterDefinition("width", 1, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 2, 134223695),
                new SourceMethodParameterDefinition("height", 2, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 3, 134223696),
                new SourceMethodParameterDefinition("tileType", 3, 0, "System.Char", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Char"), 4, 134223697),
                new SourceMethodParameterDefinition("disableSpawnOffset", 4, 0, "System.Boolean", false, null,
                    new byte[] { }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Boolean"), 5, 134223698)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 33, 101));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666962, ".ctor", 6278, "200201129E781180A1", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.EntityData", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("data", 0, 0, "Celeste.EntityData", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.EntityData"), 1, 134223699),
                new SourceMethodParameterDefinition("offset", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223700)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 21, 58));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666963, "Awake", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223701)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 203, 545));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666964, "OnStaticMoverTrigger", 198, "200101129CA4", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Celeste.StaticMover" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("sm", 0, 0, "Celeste.StaticMover", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.StaticMover"), 1, 134223702)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 31, 112));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666965, "TryToInitPosition", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 28, 82));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666966, "AddToGroupAndFindChildren", 129, "2001011286C4", new KeyValuePair<string, string>[] { },
            "System.Void", new string[] { "Celeste.FloatySpaceBlock" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("from", 0, 0, "Celeste.FloatySpaceBlock", false, null,
                    new byte[] { }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.FloatySpaceBlock"), 1, 134223703)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 235, 647));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666967, "AddJumpThru", 129, "200101129F10", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.JumpThru" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("jp", 0, 0, "Celeste.JumpThru", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.JumpThru"), 1, 134223704)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 68, 191));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666968, "OnDash", 129, "2002119F14129F241180A1", new KeyValuePair<string, string>[] { },
            "Celeste.DashCollisionResults", new string[] { "Celeste.Player", "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223705),
                new SourceMethodParameterDefinition("direction", 1, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 2, 134223706)
            }, "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                typeIdentity: "Celeste.DashCollisionResults"), true, 15, 41));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666969, "Update", 198, "200001", new KeyValuePair<string, string>[] { }, "System.Void", new string[] { },
            0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 109, 333));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666970, "MoveToTarget", 129, "200001", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { }, 0, new SourceMethodParameterDefinition[] { },
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 116, 308));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666971, "OnShake", 198, "2001011180A1", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Microsoft.Xna.Framework.Vector2" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("amount", 0, 0, "Microsoft.Xna.Framework.Vector2", false, null,
                    new byte[] { }, "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Microsoft.Xna.Framework.Vector2"), 1, 134223707)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 54, 154));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.FloatySpaceBlock", 33554865,
            100666972, "JITBarrier", 145, "00010C0C", new KeyValuePair<string, string>[] { }, "System.Single",
            new string[] { "System.Single" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("v", 0, 0, "System.Single", false, null, new byte[] { },
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Single"), 1, 134223708)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Single"), true, 2, 2));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS10_Farewell", 33554866,
            100666973, ".ctor", 6278, "200101129F24", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Player" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("player", 0, 0, "Celeste.Player", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Player"), 1, 134223709)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 11, 27));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS10_Farewell", 33554866,
            100666974, "Awake", 198, "200101128588", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Monocle.Scene" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("scene", 0, 0, "Monocle.Scene", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Monocle.Scene"), 1, 134223710)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 22, 62));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS10_Farewell", 33554866,
            100666975, "OnBegin", 198, "200101129E94", new KeyValuePair<string, string>[] { }, "System.Void",
            new string[] { "Celeste.Level" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("level", 0, 0, "Celeste.Level", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Level"), 1, 134223711)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Void"), true, 8, 20));
        catalog.RegisterDefinition(new SourceMethodDefinition(
            "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Celeste.CS10_Farewell", 33554866,
            100666976, "Cutscene", 129, "2001128109129E94",
            new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("System.Runtime.CompilerServices.IteratorStateMachineAttribute",
                    "01002443656C657374652E435331305F4661726577656C6C2B3C4375747363656E653E645F5F390000")
            }, "System.Collections.IEnumerator", new string[] { "Celeste.Level" }, 0,
            new SourceMethodParameterDefinition[]
            {
                new SourceMethodParameterDefinition("level", 0, 0, "Celeste.Level", false, null, new byte[] { },
                    "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                        global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                        assemblyIdentity: "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                        typeIdentity: "Celeste.Level"), 1, 134223712)
            }, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
            new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named,
                assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                typeIdentity: "System.Collections.IEnumerator"), true, 9, 21));
    }
}
