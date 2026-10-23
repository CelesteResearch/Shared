using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static class SourceIntrinsicPhysicalBindings
    {
        private const string OriginalBclIdentity =
            "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

        private const string InstalledBclIdentity =
            "System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e";

        public static void RegisterOriginalBcl(SourceMemberCatalog catalog) =>
            RegisterBclTypes(catalog, OriginalBclIdentity);

        public static void RegisterInstalledBcl(SourceMemberCatalog catalog) =>
            RegisterBclTypes(catalog, InstalledBclIdentity);

        private static void RegisterBclTypes(SourceMemberCatalog catalog, string expectedDefinitionAssembly)
        {
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(void), "System.Void");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(object), "System.Object");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(ValueType), "System.ValueType");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(Enum), "System.Enum");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(bool), "System.Boolean");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(byte), "System.Byte");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(sbyte), "System.SByte");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(short), "System.Int16");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(ushort), "System.UInt16");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(int), "System.Int32");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(uint), "System.UInt32");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(long), "System.Int64");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(ulong), "System.UInt64");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(char), "System.Char");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(float), "System.Single");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(double), "System.Double");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(decimal), "System.Decimal");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(string), "System.String");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(Delegate), "System.Delegate");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(MulticastDelegate), "System.MulticastDelegate");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(IEnumerable<>),
                "System.Collections.Generic.IEnumerable`1");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(IEnumerator<>),
                "System.Collections.Generic.IEnumerator`1");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(System.Collections.IEnumerable),
                "System.Collections.IEnumerable");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(System.Collections.IEnumerator),
                "System.Collections.IEnumerator");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(IntPtr), "System.IntPtr");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(UIntPtr), "System.UIntPtr");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(List<>), "System.Collections.Generic.List`1");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(Dictionary<,>),
                "System.Collections.Generic.Dictionary`2");
            RegisterBclType(catalog, expectedDefinitionAssembly, typeof(KeyValuePair<,>),
                "System.Collections.Generic.KeyValuePair`2");
        }

        private static void RegisterBclType(SourceMemberCatalog catalog, string expectedDefinitionAssembly,
            Type actualType,
            string originalName)
        {
            var definition = catalog.ResolveNamedTypeDefinition(
                new global::Celeste.Core.Reflection.Types.SourceTypeReference(
                    global::Celeste.Core.Reflection.Types.SourceTypeReferenceKind.Named, OriginalBclIdentity,
                    originalName));
            if (definition.AssemblyIdentity != expectedDefinitionAssembly || definition.Identity != originalName)
                throw new InvalidOperationException(
                    "The actual intrinsic must bind the selected profile's genuine terminal TypeDef.");
            if (definition.GenericParameters == null)
                throw new InvalidOperationException("The source intrinsic generic parameters were not published.");
            int actualArity = actualType.IsGenericTypeDefinition ? actualType.GetGenericArguments().Length : 0;
            if (definition.GenericParameters.Count != actualArity ||
                ((definition.Attributes & 0x20) != 0) != actualType.IsInterface)
                throw new InvalidOperationException("The source and actual intrinsic type shapes do not match.");
            if (actualArity != 0)
            {
                var actualParameters = actualType.GetGenericArguments();
                for (int index = 0; index < actualArity; index++)
                    if ((definition.GenericParameters[index].Attributes & 3) !=
                        ((int)actualParameters[index].GenericParameterAttributes & 3))
                        throw new InvalidOperationException(
                            "The source intrinsic generic variance does not match the actual type.");
            }

            catalog.RegisterSourceType(actualType, definition.AssemblyIdentity, definition.Identity);
        }

        public static void RegisterOriginalXnaColor(SourceMemberCatalog catalog, Type actualColor)
            => RegisterColor(catalog, actualColor,
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553", 33554938);

        public static void RegisterInstalledFnaColor(SourceMemberCatalog catalog, Type actualColor)
            => RegisterColor(catalog, actualColor,
                "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null", 33554692);

        private static void RegisterColor(SourceMemberCatalog catalog, Type actualColor, string sourceAssembly,
            int sourceToken)
        {
            if (actualColor == null) throw new ArgumentNullException(nameof(actualColor));
            var definition = catalog.GetOriginalTypeDefinition(sourceAssembly, "Microsoft.Xna.Framework.Color");
            if (definition.AssemblyIdentity != sourceAssembly || definition.Identity != "Microsoft.Xna.Framework.Color"
                                                              || definition.MetadataToken != sourceToken ||
                                                              definition.BaseAssemblyIdentity != OriginalBclIdentity
                                                              || definition.BaseTypeIdentity != "System.ValueType" ||
                                                              !actualColor.IsValueType || actualColor.IsEnum
                                                              || actualColor.ContainsGenericParameters)
                throw new InvalidOperationException(
                    "The color intrinsic must bind the selected profile's genuine SDK value TypeDef.");
            catalog.RegisterSourceType(actualColor, definition.AssemblyIdentity, definition.Identity);
        }

        public static void RegisterOriginalXnaVectors(SourceMemberCatalog catalog)
        {
            catalog.RegisterSourceType(typeof(Vector2),
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector2");
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition(
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2", "X", SourceMemberKind.Field),
                typeof(Vector2),
                typeof(Vector2).GetField(nameof(Vector2.X),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition(
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector2", "Y", SourceMemberKind.Field),
                typeof(Vector2),
                typeof(Vector2).GetField(nameof(Vector2.Y),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterSourceType(typeof(Vector3),
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector3");
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition(
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3", "X", SourceMemberKind.Field),
                typeof(Vector3),
                typeof(Vector3).GetField(nameof(Vector3.X),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition(
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3", "Y", SourceMemberKind.Field),
                typeof(Vector3),
                typeof(Vector3).GetField(nameof(Vector3.Y),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition(
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector3", "Z", SourceMemberKind.Field),
                typeof(Vector3),
                typeof(Vector3).GetField(nameof(Vector3.Z),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterSourceType(typeof(Vector4),
                "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                "Microsoft.Xna.Framework.Vector4");
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition(
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector4", "X", SourceMemberKind.Field),
                typeof(Vector4),
                typeof(Vector4).GetField(nameof(Vector4.X),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition(
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector4", "Y", SourceMemberKind.Field),
                typeof(Vector4),
                typeof(Vector4).GetField(nameof(Vector4.Y),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition(
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector4", "Z", SourceMemberKind.Field),
                typeof(Vector4),
                typeof(Vector4).GetField(nameof(Vector4.Z),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition(
                    "Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553",
                    "Microsoft.Xna.Framework.Vector4", "W", SourceMemberKind.Field),
                typeof(Vector4),
                typeof(Vector4).GetField(nameof(Vector4.W),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
        }

        public static void RegisterInstalledFnaVectors(SourceMemberCatalog catalog)
        {
            catalog.RegisterSourceType(typeof(Vector2), "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                "Microsoft.Xna.Framework.Vector2");
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition("FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2", "X", SourceMemberKind.Field),
                typeof(Vector2),
                typeof(Vector2).GetField(nameof(Vector2.X),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition("FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector2", "Y", SourceMemberKind.Field),
                typeof(Vector2),
                typeof(Vector2).GetField(nameof(Vector2.Y),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterSourceType(typeof(Vector3), "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                "Microsoft.Xna.Framework.Vector3");
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition("FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector3", "X", SourceMemberKind.Field),
                typeof(Vector3),
                typeof(Vector3).GetField(nameof(Vector3.X),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition("FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector3", "Y", SourceMemberKind.Field),
                typeof(Vector3),
                typeof(Vector3).GetField(nameof(Vector3.Y),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition("FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector3", "Z", SourceMemberKind.Field),
                typeof(Vector3),
                typeof(Vector3).GetField(nameof(Vector3.Z),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterSourceType(typeof(Vector4), "FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                "Microsoft.Xna.Framework.Vector4");
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition("FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector4", "X", SourceMemberKind.Field),
                typeof(Vector4),
                typeof(Vector4).GetField(nameof(Vector4.X),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition("FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector4", "Y", SourceMemberKind.Field),
                typeof(Vector4),
                typeof(Vector4).GetField(nameof(Vector4.Y),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition("FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector4", "Z", SourceMemberKind.Field),
                typeof(Vector4),
                typeof(Vector4).GetField(nameof(Vector4.Z),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(
                catalog.RequireDefinition("FNA, Version=24.1.0.0, Culture=neutral, PublicKeyToken=null",
                    "Microsoft.Xna.Framework.Vector4", "W", SourceMemberKind.Field),
                typeof(Vector4),
                typeof(Vector4).GetField(nameof(Vector4.W),
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)));
        }
    }
}
