using System;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Types;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalXnaGame(SourceMemberCatalog catalog)
        {
            catalog.RegisterTypeDefinition(new SourceTypeDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 33554440, 1048577,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                new string[] { "System.IDisposable" }, new SourceDeclaredAttribute[] { },
                interfaceAssemblyIdentities: new string[]
                    { "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" },
                genericParameters: Array.Empty<SourceGenericParameterDefinition>(),
                baseTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Object"),
                interfaceTypeReferences: new SourceTypeReference[]
                {
                    new SourceTypeReference(SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.IDisposable")
                }));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108878, "maximumElapsedTime", SourceMemberKind.Field, 33,
                "System.TimeSpan", declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false,
                constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.TimeSpan")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108879, "graphicsDeviceManager", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.IGraphicsDeviceManager", declaredAttributes: new SourceDeclaredAttribute[] { },
                hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.IGraphicsDeviceManager")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108880, "graphicsDeviceService", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.Graphics.IGraphicsDeviceService")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108881, "host", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.GameHost", declaredAttributes: new SourceDeclaredAttribute[] { },
                hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.GameHost")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108882, "isActive", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108883, "exitRequested", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108884, "inactiveSleepTime", SourceMemberKind.Field, 1,
                "System.TimeSpan", declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false,
                constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.TimeSpan")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108885, "isMouseVisible", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108886, "inRun", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108887, "endRunRequired", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108888, "gameTime", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.GameTime", declaredAttributes: new SourceDeclaredAttribute[] { },
                hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.GameTime")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108889, "clock", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.GameClock", declaredAttributes: new SourceDeclaredAttribute[] { },
                hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.GameClock")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108890, "totalGameTime", SourceMemberKind.Field, 1, "System.TimeSpan",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.TimeSpan")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108891, "targetElapsedTime", SourceMemberKind.Field, 1,
                "System.TimeSpan", declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false,
                constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.TimeSpan")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108892, "accumulatedElapsedGameTime", SourceMemberKind.Field, 1,
                "System.TimeSpan", declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false,
                constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.TimeSpan")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108893, "lastFrameElapsedGameTime", SourceMemberKind.Field, 1,
                "System.TimeSpan", declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false,
                constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.TimeSpan")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108894, "isFixedTimeStep", SourceMemberKind.Field, 1,
                "System.Boolean", declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false,
                constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108895, "drawRunningSlowly", SourceMemberKind.Field, 1,
                "System.Boolean", declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false,
                constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108896, "updatesSinceRunningSlowly1", SourceMemberKind.Field, 1,
                "System.Int32", declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false,
                constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Int32")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108897, "updatesSinceRunningSlowly2", SourceMemberKind.Field, 1,
                "System.Int32", declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false,
                constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Int32")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108898, "doneFirstUpdate", SourceMemberKind.Field, 1,
                "System.Boolean", declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false,
                constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108899, "doneFirstDraw", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108900, "forceElapsedTimeToZero", SourceMemberKind.Field, 1,
                "System.Boolean", declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false,
                constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108901, "suppressDraw", SourceMemberKind.Field, 1, "System.Boolean",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108902, "gameComponents", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.GameComponentCollection",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.GameComponentCollection")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108903, "updateableComponents", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List\u00601\u003CMicrosoft.Xna.Framework.IUpdateable\u003E",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.GenericInstance,
                    elementType: new SourceTypeReference(SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Collections.Generic.List\u00601"),
                    genericArguments: new SourceTypeReference[]
                    {
                        new SourceTypeReference(SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.IUpdateable")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108904, "currentlyUpdatingComponents", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List\u00601\u003CMicrosoft.Xna.Framework.IUpdateable\u003E",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.GenericInstance,
                    elementType: new SourceTypeReference(SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Collections.Generic.List\u00601"),
                    genericArguments: new SourceTypeReference[]
                    {
                        new SourceTypeReference(SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.IUpdateable")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108905, "drawableComponents", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List\u00601\u003CMicrosoft.Xna.Framework.IDrawable\u003E",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.GenericInstance,
                    elementType: new SourceTypeReference(SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Collections.Generic.List\u00601"),
                    genericArguments: new SourceTypeReference[]
                    {
                        new SourceTypeReference(SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.IDrawable")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108906, "currentlyDrawingComponents", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List\u00601\u003CMicrosoft.Xna.Framework.IDrawable\u003E",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.GenericInstance,
                    elementType: new SourceTypeReference(SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Collections.Generic.List\u00601"),
                    genericArguments: new SourceTypeReference[]
                    {
                        new SourceTypeReference(SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.IDrawable")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108907, "notYetInitialized", SourceMemberKind.Field, 1,
                "System.Collections.Generic.List\u00601\u003CMicrosoft.Xna.Framework.IGameComponent\u003E",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.GenericInstance,
                    elementType: new SourceTypeReference(SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.Collections.Generic.List\u00601"),
                    genericArguments: new SourceTypeReference[]
                    {
                        new SourceTypeReference(SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                            typeIdentity: "Microsoft.Xna.Framework.IGameComponent")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108908, "gameServices", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.GameServiceContainer", declaredAttributes: new SourceDeclaredAttribute[] { },
                hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.GameServiceContainer")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108909, "content", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.Content.ContentManager", declaredAttributes: new SourceDeclaredAttribute[] { },
                hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.Content.ContentManager")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108910, "launchParameters", SourceMemberKind.Field, 1,
                "Microsoft.Xna.Framework.LaunchParameters", declaredAttributes: new SourceDeclaredAttribute[] { },
                hasConstant: false, constantValue: null, constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.LaunchParameters")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108911, "Activated", SourceMemberKind.Field, 1,
                "System.EventHandler\u00601\u003CSystem.EventArgs\u003E",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.GenericInstance,
                    elementType: new SourceTypeReference(SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.EventHandler\u00601"),
                    genericArguments: new SourceTypeReference[]
                    {
                        new SourceTypeReference(SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.EventArgs")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108912, "Deactivated", SourceMemberKind.Field, 1,
                "System.EventHandler\u00601\u003CSystem.EventArgs\u003E",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.GenericInstance,
                    elementType: new SourceTypeReference(SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.EventHandler\u00601"),
                    genericArguments: new SourceTypeReference[]
                    {
                        new SourceTypeReference(SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.EventArgs")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108913, "Exiting", SourceMemberKind.Field, 1,
                "System.EventHandler\u00601\u003CSystem.EventArgs\u003E",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.GenericInstance,
                    elementType: new SourceTypeReference(SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.EventHandler\u00601"),
                    genericArguments: new SourceTypeReference[]
                    {
                        new SourceTypeReference(SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.EventArgs")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 67108914, "Disposed", SourceMemberKind.Field, 1,
                "System.EventHandler\u00601\u003CSystem.EventArgs\u003E",
                declaredAttributes: new SourceDeclaredAttribute[] { }, hasConstant: false, constantValue: null,
                constantTypeIdentity: null,
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.GenericInstance,
                    elementType: new SourceTypeReference(SourceTypeReferenceKind.Named,
                        assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                        typeIdentity: "System.EventHandler\u00601"),
                    genericArguments: new SourceTypeReference[]
                    {
                        new SourceTypeReference(SourceTypeReferenceKind.Named,
                            assemblyIdentity:
                            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                            typeIdentity: "System.EventArgs")
                    })));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875980, "LaunchParameters", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.LaunchParameters", getterAttributes: 2182, setterAttributes: -1,
                indexParameterCount: 0, declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.LaunchParameters")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875981, "Components", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.GameComponentCollection", getterAttributes: 2182, setterAttributes: -1,
                indexParameterCount: 0, declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.GameComponentCollection")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875982, "Services", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.GameServiceContainer", getterAttributes: 2182, setterAttributes: -1,
                indexParameterCount: 0, declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.GameServiceContainer")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875983, "InactiveSleepTime", SourceMemberKind.Property, 0,
                "System.TimeSpan", getterAttributes: 2182, setterAttributes: 2182, indexParameterCount: 0,
                declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.TimeSpan")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875984, "IsMouseVisible", SourceMemberKind.Property, 0,
                "System.Boolean", getterAttributes: 2182, setterAttributes: 2182, indexParameterCount: 0,
                declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875985, "TargetElapsedTime", SourceMemberKind.Property, 0,
                "System.TimeSpan", getterAttributes: 2182, setterAttributes: 2182, indexParameterCount: 0,
                declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.TimeSpan")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875986, "IsFixedTimeStep", SourceMemberKind.Property, 0,
                "System.Boolean", getterAttributes: 2182, setterAttributes: 2182, indexParameterCount: 0,
                declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875987, "Window", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.GameWindow", getterAttributes: 2182, setterAttributes: -1,
                indexParameterCount: 0, declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.GameWindow")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875988, "IsActive", SourceMemberKind.Property, 0, "System.Boolean",
                getterAttributes: 2182, setterAttributes: -1, indexParameterCount: 0,
                declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875989, "GraphicsDevice", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Graphics.GraphicsDevice", getterAttributes: 2182, setterAttributes: -1,
                indexParameterCount: 0, declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework.Graphics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.Graphics.GraphicsDevice")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875990, "Content", SourceMemberKind.Property, 0,
                "Microsoft.Xna.Framework.Content.ContentManager", getterAttributes: 2182, setterAttributes: 2182,
                indexParameterCount: 0, declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity:
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    typeIdentity: "Microsoft.Xna.Framework.Content.ContentManager")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875991, "IsActiveIgnoringGuide", SourceMemberKind.Property, 0,
                "System.Boolean", getterAttributes: 2179, setterAttributes: -1, indexParameterCount: 0,
                declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
            catalog.RegisterDefinition(new SourceMemberDefinition(
                "Microsoft.Xna.Framework.Game, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Game", 385875992, "ShouldExit", SourceMemberKind.Property, 0, "System.Boolean",
                getterAttributes: 2177, setterAttributes: -1, indexParameterCount: 0,
                declaredAttributes: new SourceDeclaredAttribute[] { },
                valueTypeAssemblyIdentity:
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                valueTypeReference: new SourceTypeReference(SourceTypeReferenceKind.Named,
                    assemblyIdentity: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                    typeIdentity: "System.Boolean")));
        }
    }
}
