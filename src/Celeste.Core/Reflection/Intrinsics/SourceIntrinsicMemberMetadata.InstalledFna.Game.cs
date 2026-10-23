using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishInstalledFnaGame(SourceMemberCatalog catalog)
        {
            catalog.RegisterTypeDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 33554761,
                1048577, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                ["System.IDisposable"], [],
                interfaceAssemblyIdentities:
                ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                genericParameters: [],
                baseTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Object"),
                interfaceTypeReferences:
                [
                    new(SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.IDisposable"),
                ]));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111425,
                "\u003CComponents\u003Ek__BackingField", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.GameComponentCollection",
                declaredAttributes: (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.GameComponentCollection")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111426,
                "INTERNAL_content", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Content.ContentManager",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Content.ContentManager")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111427,
                "INTERNAL_inactiveSleepTime", SourceMemberKind.Field, 1, "System.TimeSpan",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.TimeSpan")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111428,
                "INTERNAL_isActive", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111429,
                "\u003CIsFixedTimeStep\u003Ek__BackingField", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111430,
                "INTERNAL_isMouseVisible", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111431,
                "\u003CLaunchParameters\u003Ek__BackingField", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.LaunchParameters",
                declaredAttributes: (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.LaunchParameters")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111432,
                "INTERNAL_targetElapsedTime", SourceMemberKind.Field, 1, "System.TimeSpan",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.TimeSpan")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111433,
                "\u003CServices\u003Ek__BackingField", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.GameServiceContainer",
                declaredAttributes: (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.GameServiceContainer")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111434,
                "\u003CWindow\u003Ek__BackingField", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.GameWindow",
                declaredAttributes: (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.GameWindow")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111435,
                "RunApplication", SourceMemberKind.Field, 3, "System.Boolean",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111436,
                "updateableComponents", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List\u00601\u003CMicrosoft.Xna.Framework.IUpdateable\u003E",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.GenericInstance,
                    elementType: new(SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.Generic.List\u00601"),
                    genericArguments:
                    [
                        new(SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.IUpdateable"),
                    ])));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111437,
                "currentlyUpdatingComponents", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List\u00601\u003CMicrosoft.Xna.Framework.IUpdateable\u003E",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.GenericInstance,
                    elementType: new(SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.Generic.List\u00601"),
                    genericArguments:
                    [
                        new(SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.IUpdateable"),
                    ])));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111438,
                "drawableComponents", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List\u00601\u003CMicrosoft.Xna.Framework.IDrawable\u003E",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.GenericInstance,
                    elementType: new(SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.Generic.List\u00601"),
                    genericArguments:
                    [
                        new(SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.IDrawable"),
                    ])));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111439,
                "currentlyDrawingComponents", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List\u00601\u003CMicrosoft.Xna.Framework.IDrawable\u003E",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.GenericInstance,
                    elementType: new(SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Collections.Generic.List\u00601"),
                    genericArguments:
                    [
                        new(SourceTypeReferenceKind.Named,
                            "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                            "Microsoft.Xna.Framework.IDrawable"),
                    ])));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111440,
                "graphicsDeviceService", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111441,
                "graphicsDeviceManager", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.IGraphicsDeviceManager",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.IGraphicsDeviceManager")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111442,
                "currentAdapter", SourceMemberKind.Field, 1, "Microsoft.Xna.Framework.Graphics.GraphicsAdapter",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Graphics.GraphicsAdapter")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111443,
                "hasInitialized", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111444,
                "suppressDraw", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111445,
                "isDisposed", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111446,
                "gameTime", SourceMemberKind.Field, 33, "Microsoft.Xna.Framework.GameTime",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.GameTime")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111447,
                "gameTimer", SourceMemberKind.Field, 1, "System.Diagnostics.Stopwatch",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity: "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Diagnostics.Stopwatch")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111448,
                "accumulatedElapsedTime", SourceMemberKind.Field, 1, "System.TimeSpan",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.TimeSpan")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111449,
                "previousTicks", SourceMemberKind.Field, 1, "System.Int64",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int64")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111450,
                "updateFrameLag", SourceMemberKind.Field, 1, "System.Int32",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111451,
                "forceElapsedTimeToZero", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111452,
                "PREVIOUS_SLEEP_TIME_COUNT", SourceMemberKind.Field, 32849, "System.Int32",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: true, constantValue: 128,
                constantTypeIdentity: "System.Int32",
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111453,
                "SLEEP_TIME_MASK", SourceMemberKind.Field, 32849, "System.Int32",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: true, constantValue: 127,
                constantTypeIdentity: "System.Int32",
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111454,
                "previousSleepTimes", SourceMemberKind.Field, 1, "System.TimeSpan[]",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.SzArray,
                    elementType: new(SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.TimeSpan"))));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111455,
                "sleepTimeIndex", SourceMemberKind.Field, 1, "System.Int32",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Int32")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111456,
                "worstCaseSleepPrecision", SourceMemberKind.Field, 1, "System.TimeSpan",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.TimeSpan")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111457,
                "MaxElapsedTime", SourceMemberKind.Field, 49, "System.TimeSpan",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.TimeSpan")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111458,
                "textInputControlDown", SourceMemberKind.Field, 1, "System.Boolean[]",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.SzArray,
                    elementType: new(SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.Boolean"))));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111459,
                "textInputSuppress", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: (SourceDeclaredAttribute[])[], hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111460,
                "Activated", SourceMemberKind.Field, 1, "System.EventHandler\u00601\u003CSystem.EventArgs\u003E",
                declaredAttributes: (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.GenericInstance,
                    elementType: new(SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.EventHandler\u00601"),
                    genericArguments:
                    [
                        new(SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.EventArgs"),
                    ])));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111461,
                "Deactivated", SourceMemberKind.Field, 1, "System.EventHandler\u00601\u003CSystem.EventArgs\u003E",
                declaredAttributes: (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.GenericInstance,
                    elementType: new(SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.EventHandler\u00601"),
                    genericArguments:
                    [
                        new(SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.EventArgs"),
                    ])));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111462,
                "Disposed", SourceMemberKind.Field, 1, "System.EventHandler\u00601\u003CSystem.EventArgs\u003E",
                declaredAttributes: (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.GenericInstance,
                    elementType: new(SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.EventHandler\u00601"),
                    genericArguments:
                    [
                        new(SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.EventArgs"),
                    ])));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game", 67111463,
                "Exiting", SourceMemberKind.Field, 1, "System.EventHandler\u00601\u003CSystem.EventArgs\u003E",
                declaredAttributes: (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.GenericInstance,
                    elementType: new(SourceTypeReferenceKind.Named,
                        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        "System.EventHandler\u00601"),
                    genericArguments:
                    [
                        new(SourceTypeReferenceKind.Named,
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            "System.EventArgs"),
                    ])));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game",
                385876147, "Components", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.GameComponentCollection", 2182, 2177,
                0, (SourceDeclaredAttribute[])[],
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.GameComponentCollection")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game",
                385876148, "Content", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.Content.ContentManager",
                2182, 2182, 0,
                (SourceDeclaredAttribute[])[],
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Content.ContentManager")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game",
                385876149, "GraphicsDevice", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Graphics.GraphicsDevice", 2182, -1,
                0, (SourceDeclaredAttribute[])[],
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Graphics.GraphicsDevice")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game",
                385876150, "InactiveSleepTime", SourceMemberKind.Property, 0, "System.TimeSpan", 2182,
                2182, 0, (SourceDeclaredAttribute[])[],
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.TimeSpan")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game",
                385876151, "IsActive", SourceMemberKind.Property, 0, "System.Boolean", 2182,
                2179, 0, (SourceDeclaredAttribute[])[],
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game",
                385876152, "IsFixedTimeStep", SourceMemberKind.Property, 0, "System.Boolean", 2182,
                2182, 0, (SourceDeclaredAttribute[])[],
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game",
                385876153, "IsMouseVisible", SourceMemberKind.Property, 0, "System.Boolean", 2182,
                2182, 0, (SourceDeclaredAttribute[])[],
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.Boolean")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game",
                385876154, "LaunchParameters", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.LaunchParameters",
                2182, 2177, 0,
                (SourceDeclaredAttribute[])[],
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.LaunchParameters")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game",
                385876155, "TargetElapsedTime", SourceMemberKind.Property, 0, "System.TimeSpan", 2182,
                2182, 0, (SourceDeclaredAttribute[])[],
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    "System.TimeSpan")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game",
                385876156, "Services", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.GameServiceContainer",
                2182, 2177, 0,
                (SourceDeclaredAttribute[])[],
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.GameServiceContainer")));
            catalog.RegisterDefinition(new(
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", "Microsoft.Xna.Framework.Game",
                385876157, "Window", SourceMemberKind.Property, 0, "Microsoft.Xna.Framework.GameWindow",
                2182, 2177, 0,
                (SourceDeclaredAttribute[])[],
                valueTypeAssemblyIdentity: "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                valueTypeReference: new(SourceTypeReferenceKind.Named,
                    "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.GameWindow")));
        }
    }
}
