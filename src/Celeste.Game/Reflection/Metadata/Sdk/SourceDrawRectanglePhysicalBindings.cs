using Celeste.Core.Display;
using System;
using System.Reflection;
using Celeste.Core.Geometry;
using Celeste.Core.Reflection.Members;
using Celeste.Core.Reflection.Methods;
using Celeste.Core.Reflection.Types;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Reflection.Metadata.Sdk;

public static class SourceDrawRectanglePhysicalBindings
{
    private const string GameAssembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

    private const string XnaAssembly =
        "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553";

    private const string FnaAssembly = "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null";
    private const string RectangleIdentity = "Microsoft.Xna.Framework.Rectangle";
    private const string DrawIdentity = "Monocle.Draw";
    private const string BclAssembly = "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

    public static void BindOriginalXna(SourceMemberCatalog members,
        SourceAssemblyMethodCatalog methods, SourceDrawState draw)
        => Bind(members, methods, draw, XnaAssembly, 33554944, 33554729,
            67110497, 100666048, "0005010C0C0C0C11808D", 67110404, 67110405, 67110406, 67110407);

    public static void BindOriginalXnaCompiled(SourceMemberCatalog members,
        SourceAssemblyMethodCatalog methods, SourceDrawState draw)
    {
        if (draw == null) throw new ArgumentNullException(nameof(draw));
        // A direct typed reference retains the same compiled source implementation.
        // Runtime IL availability is a desktop qualification, not gameplay state.
        Action<float, float, float, float, PackedColor> compiledHollowRect = draw.HollowRect;
        Bind(members, methods, draw, XnaAssembly, 33554944, 33554729,
            67110497, 100666048, "0005010C0C0C0C11808D", 67110404, 67110405, 67110406, 67110407,
            compiledHollowRect);
    }

    public static void BindInstalledFna(SourceMemberCatalog members,
        SourceAssemblyMethodCatalog methods, SourceDrawState draw)
        => Bind(members, methods, draw, FnaAssembly, 33554784, 33554810,
            67110790, 100666502, "0005010C0C0C0C1180AD", 67111558, 67111559, 67111560, 67111561);

    private static void Bind(SourceMemberCatalog members, SourceAssemblyMethodCatalog methods,
        SourceDrawState draw, string sdkAssembly, int rectangleToken, int drawToken,
        int drawRectToken, int hollowRectToken, string signatureBlob,
        int xToken, int yToken, int widthToken, int heightToken,
        Action<float, float, float, float, PackedColor> compiledHollowRect = null)
    {
        if (members == null) throw new ArgumentNullException(nameof(members));
        if (methods == null) throw new ArgumentNullException(nameof(methods));
        if (draw == null) throw new ArgumentNullException(nameof(draw));

        // Require all selected original definitions before registering physical targets.
        var rectangleDefinition = members.GetOriginalTypeDefinition(sdkAssembly, RectangleIdentity);
        var drawDefinition = members.GetOriginalTypeDefinition(GameAssembly, DrawIdentity);
        if (rectangleDefinition.MetadataToken != rectangleToken || drawDefinition.MetadataToken != drawToken)
            throw new InvalidOperationException(
                "The selected source profile's true Draw/Rectangle metadata must be published first.");
        var rectangleFields = new[]
        {
            RequireField(members, sdkAssembly, RectangleIdentity, "X", xToken, 6, BclAssembly, "System.Int32"),
            RequireField(members, sdkAssembly, RectangleIdentity, "Y", yToken, 6, BclAssembly, "System.Int32"),
            RequireField(members, sdkAssembly, RectangleIdentity, "Width", widthToken, 6, BclAssembly, "System.Int32"),
            RequireField(members, sdkAssembly, RectangleIdentity, "Height", heightToken, 6, BclAssembly, "System.Int32")
        };
        var drawRect = RequireField(members, GameAssembly, DrawIdentity, "rect", drawRectToken, 17,
            sdkAssembly, RectangleIdentity);
        var hollowRect = methods.RequireDefinition(GameAssembly, hollowRectToken);
        if (hollowRect.TypeDefinitionToken != drawToken || hollowRect.DeclaringType != DrawIdentity
                                                        || hollowRect.Name != "HollowRect" ||
                                                        hollowRect.Attributes != 150
                                                        || hollowRect.SignatureBlob != signatureBlob ||
                                                        hollowRect.GenericParameterCount != 0
                                                        || hollowRect.Parameters == null ||
                                                        hollowRect.Parameters.Count != 5)
            throw new InvalidOperationException(
                "The original five-parameter static Draw.HollowRect definition is required.");
        RequireNamed(hollowRect.ReturnTypeReference, BclAssembly, "System.Void");
        for (int index = 0; index < 5; index++)
        {
            var parameter = hollowRect.Parameters[index];
            if (parameter.Position != index)
                throw new InvalidOperationException("Original HollowRect parameter ordinals differ.");
            RequireNamed(parameter.TypeReference, index == 4 ? sdkAssembly : BclAssembly,
                index == 4 ? "Microsoft.Xna.Framework.Color" : "System.Single");
        }

        var actualDrawRect = typeof(SourceDrawState).GetField("Rectangle",
                                 BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                             ?? throw new MissingFieldException(typeof(SourceDrawState).FullName, "Rectangle");
        if (actualDrawRect.FieldType != typeof(IntRect) || actualDrawRect.IsStatic)
            throw new InvalidOperationException("Draw.rect must bind the same actual Draw state's IntRect field.");
        var actualHollowRect = compiledHollowRect?.Method ?? typeof(SourceDrawState).GetMethod("HollowRect",
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly, null,
                new[]
                {
                    typeof(float), typeof(float), typeof(float), typeof(float), typeof(PackedColor)
                }, null)
            ?? throw new MissingMethodException(typeof(SourceDrawState).FullName, "HollowRect");
        if (actualHollowRect.ReturnType != typeof(void) || actualHollowRect.IsStatic
                                                        || actualHollowRect.ContainsGenericParameters ||
                                                        (compiledHollowRect == null &&
                                                         actualHollowRect.GetMethodBody() == null))
            throw new InvalidOperationException(
                "The actual five-parameter same-owner HollowRect full CPU method is required.");

        if (compiledHollowRect != null && (!ReferenceEquals(compiledHollowRect.Target, draw) ||
                                           actualHollowRect.DeclaringType != typeof(SourceDrawState)))
            throw new InvalidOperationException("The typed compiled HollowRect must belong to the same Draw state.");

        EnsureSourceType(members, typeof(IntRect), rectangleDefinition);
        EnsureSourceType(members, typeof(SourceDrawState), drawDefinition);
        for (int index = 0; index < rectangleFields.Length; index++)
        {
            var definition = rectangleFields[index];
            var actualField = typeof(IntRect).GetField(definition.Name,
                                  BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                              ?? throw new MissingFieldException(typeof(IntRect).FullName, definition.Name);
            if (actualField.FieldType != typeof(int) || actualField.IsStatic)
                throw new InvalidOperationException(
                    "Original Rectangle fields must bind actual mutable IntRect fields.");
            members.RegisterBinding(new SourcePhysicalMemberBinding(definition, typeof(IntRect), actualField));
        }

        members.RegisterBinding(new SourcePhysicalMemberBinding(drawRect,
            typeof(SourceDrawState), actualDrawRect, staticSourceOwner: draw));
        methods.BindActualMethod(GameAssembly, hollowRectToken, actualHollowRect, draw);
    }

    private static SourceMemberDefinition RequireField(SourceMemberCatalog members,
        string assembly, string type, string name, int token, int flags,
        string valueAssembly, string valueIdentity)
    {
        var definition = members.RequireDefinition(assembly, type, name, SourceMemberKind.Field);
        if (definition.MetadataToken != token || definition.Attributes != flags)
            throw new InvalidOperationException("Original field token/flags differ: " + type + "." + name);
        RequireNamed(definition.ValueTypeReference, valueAssembly, valueIdentity);
        return definition;
    }

    private static void RequireNamed(SourceTypeReference reference, string assembly, string identity)
    {
        if (reference == null || reference.Kind != SourceTypeReferenceKind.Named
                              || reference.AssemblyIdentity != assembly || reference.TypeIdentity != identity)
            throw new InvalidOperationException("Original PE named type scope differs: " + identity);
    }

    private static void EnsureSourceType(SourceMemberCatalog members, Type actual,
        SourceTypeDefinition definition)
    {
        if (!members.ContainsSourceType(actual))
        {
            members.RegisterSourceType(actual, definition.AssemblyIdentity, definition.Identity);
            return;
        }

        var existing = members.GetOriginalTypeDefinition(actual);
        if (existing.AssemblyIdentity != definition.AssemblyIdentity
            || existing.Identity != definition.Identity || existing.MetadataToken != definition.MetadataToken)
            throw new InvalidOperationException("The actual type already belongs to another original source profile.");
    }
}
