using Celeste.Core.Reflection.Members;

namespace Celeste.Core.Reflection.Intrinsics
{
    public static partial class SourceIntrinsicMemberMetadata
    {
        private static void PublishOriginalBcl026(SourceMemberCatalog catalog)
        {
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.ReadOnlySpan`1+Enumerator", 67110749, "_span", SourceMemberKind.Field, 33,
                "System.ReadOnlySpan`1<T>", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.ReadOnlySpan`1+Enumerator", 67110750, "_index", SourceMemberKind.Field, 1, "System.Int32", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.ReadOnlySpan`1+Enumerator", 385876347, "Current", SourceMemberKind.Property, 0,
                "T& modreq(System.Runtime.InteropServices.InAttribute)", 2182, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.IsReadOnlyAttribute",
                        "System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Span`1",
                33554667,
                1048841, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.ValueType",
                [],
                [
                    new("System.Diagnostics.DebuggerTypeProxyAttribute",
                        "System.Void System.Diagnostics.DebuggerTypeProxyAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x16, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x53, 0x70, 0x61, 0x6E, 0x44,
                            0x65,
                            0x62, 0x75, 0x67, 0x56, 0x69, 0x65, 0x77, 0x60, 0x31, 0x00, 0x00,
                        ]),
                    new("System.Diagnostics.DebuggerDisplayAttribute",
                        "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x14, 0x7B, 0x44, 0x65, 0x62, 0x75, 0x67, 0x67, 0x65, 0x72, 0x44, 0x69, 0x73,
                            0x70,
                            0x6C, 0x61, 0x79, 0x2C, 0x6E, 0x71, 0x7D, 0x00, 0x00,
                        ]),
                    new("System.Reflection.DefaultMemberAttribute",
                        "System.Void System.Reflection.DefaultMemberAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x04, 0x49, 0x74, 0x65, 0x6D, 0x00, 0x00]),
                    new("System.Runtime.CompilerServices.IsByRefLikeAttribute",
                        "System.Void System.Runtime.CompilerServices.IsByRefLikeAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x52, 0x54, 0x79, 0x70, 0x65, 0x73, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x65,
                            0x6D,
                            0x62, 0x65, 0x64, 0x64, 0x65, 0x64, 0x20, 0x72, 0x65, 0x66, 0x65, 0x72, 0x65, 0x6E, 0x63,
                            0x65,
                            0x73, 0x20, 0x61, 0x72, 0x65, 0x20, 0x6E, 0x6F, 0x74, 0x20, 0x73, 0x75, 0x70, 0x70, 0x6F,
                            0x72,
                            0x74, 0x65, 0x64, 0x20, 0x69, 0x6E, 0x20, 0x74, 0x68, 0x69, 0x73, 0x20, 0x76, 0x65, 0x72,
                            0x73,
                            0x69, 0x6F, 0x6E, 0x20, 0x6F, 0x66, 0x20, 0x79, 0x6F, 0x75, 0x72, 0x20, 0x63, 0x6F, 0x6D,
                            0x70,
                            0x69, 0x6C, 0x65, 0x72, 0x2E, 0x01, 0x00, 0x00,
                        ]),
                    new("System.Runtime.CompilerServices.IsReadOnlyAttribute",
                        "System.Void System.Runtime.CompilerServices.IsReadOnlyAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [],
                [
                    new("T", 0, 704643154, 0, [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Span`1",
                67110751,
                "_pinnable", SourceMemberKind.Field, 33, "System.Pinnable`1<T>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Span`1",
                67110752,
                "_byteOffset", SourceMemberKind.Field, 33, "System.IntPtr", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Span`1",
                67110753,
                "_length", SourceMemberKind.Field, 33, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Span`1",
                385876348,
                "DebuggerDisplay", SourceMemberKind.Property, 0, "System.String", 2177, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Span`1",
                385876349,
                "Length", SourceMemberKind.Property, 0, "System.Int32", 2182, -1, 0,
                (SourceDeclaredAttribute[])[],
                false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Span`1",
                385876350,
                "IsEmpty", SourceMemberKind.Property, 0, "System.Boolean", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Span`1",
                385876351,
                "Item", SourceMemberKind.Property, 0, "T&", 2182, -1, 1, (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Span`1",
                385876352,
                "Empty", SourceMemberKind.Property, 0, "System.Span`1<T>", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Span`1",
                385876353,
                "Pinnable", SourceMemberKind.Property, 0, "System.Pinnable`1<T>", 2179, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Span`1",
                385876354,
                "ByteOffset", SourceMemberKind.Property, 0, "System.IntPtr", 2179, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Span`1+Enumerator",
                33554668, 1048842, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.ValueType", [],
                [
                    new("System.Runtime.CompilerServices.IsByRefLikeAttribute",
                        "System.Void System.Runtime.CompilerServices.IsByRefLikeAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                    new("System.ObsoleteAttribute",
                        "System.Void System.ObsoleteAttribute::.ctor(System.String,System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x52, 0x54, 0x79, 0x70, 0x65, 0x73, 0x20, 0x77, 0x69, 0x74, 0x68, 0x20, 0x65,
                            0x6D,
                            0x62, 0x65, 0x64, 0x64, 0x65, 0x64, 0x20, 0x72, 0x65, 0x66, 0x65, 0x72, 0x65, 0x6E, 0x63,
                            0x65,
                            0x73, 0x20, 0x61, 0x72, 0x65, 0x20, 0x6E, 0x6F, 0x74, 0x20, 0x73, 0x75, 0x70, 0x70, 0x6F,
                            0x72,
                            0x74, 0x65, 0x64, 0x20, 0x69, 0x6E, 0x20, 0x74, 0x68, 0x69, 0x73, 0x20, 0x76, 0x65, 0x72,
                            0x73,
                            0x69, 0x6F, 0x6E, 0x20, 0x6F, 0x66, 0x20, 0x79, 0x6F, 0x75, 0x72, 0x20, 0x63, 0x6F, 0x6D,
                            0x70,
                            0x69, 0x6C, 0x65, 0x72, 0x2E, 0x01, 0x00, 0x00,
                        ]),
                ], null, [],
                [
                    new("T", 0, 704643155, 0, [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Span`1+Enumerator",
                67110754, "_span", SourceMemberKind.Field, 33, "System.Span`1<T>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Span`1+Enumerator",
                67110755, "_index", SourceMemberKind.Field, 1, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Span`1+Enumerator",
                385876355, "Current", SourceMemberKind.Property, 0, "T&", 2182, -1, 0,
                (SourceDeclaredAttribute[])[]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SpanDebugView`1",
                33554669, 1048832, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object", [], [], null, [],
                [
                    new("T", 0, 704643156, 0, [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SpanDebugView`1",
                67110756, "_pinnable", SourceMemberKind.Field, 33, "T[]", -1, -1, 0,
                (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SpanDebugView`1",
                67110757, "_byteOffset", SourceMemberKind.Field, 33, "System.IntPtr", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SpanDebugView`1",
                67110758, "_length", SourceMemberKind.Field, 33, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SpanDebugView`1",
                385876356, "Items", SourceMemberKind.Property, 0, "T[]", 2182, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Diagnostics.DebuggerBrowsableAttribute",
                        "System.Void System.Diagnostics.DebuggerBrowsableAttribute::.ctor(System.Diagnostics.DebuggerBrowsableState)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SpanHelpers",
                33554670, 1048960, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object", [],
                [
                    new("System.Runtime.CompilerServices.ExtensionAttribute",
                        "System.Void System.Runtime.CompilerServices.ExtensionAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.SpanHelpers+ComparerComparable`2", 33554671, 1048845,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ValueType",
                ["System.IComparable`1<T>"], [], null,
                ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                [
                    new("T", 0, 704643157, 0, [],
                        []),
                    new("TComparer", 1, 704643158, 0,
                        [],
                        [
                            new("System.Collections.Generic.IComparer`1<T>",
                                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"),
                        ]),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.SpanHelpers+ComparerComparable`2", 67110759, "_value", SourceMemberKind.Field, 33, "T", -1, -1,
                0,
                (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.SpanHelpers+ComparerComparable`2", 67110760, "_comparer", SourceMemberKind.Field, 33,
                "TComparer",
                -1, -1, 0, (SourceDeclaredAttribute[])[]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.SpanHelpers+Reg64",
                33554672, 1048843, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.ValueType", [], [], null,
                [],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.SpanHelpers+Reg32",
                33554673, 1048843, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.ValueType", [], [], null,
                [],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.SpanHelpers+Reg16",
                33554674, 1048843, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.ValueType", [], [], null,
                [],
                []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.SpanHelpers+PerTypeValues`1", 33554675, 1048962,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                [], [], null, [],
                [
                    new("T", 0, 704643159, 0, [],
                        []),
                ]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.SpanHelpers+PerTypeValues`1", 67110761, "IsReferenceOrContainsReferences",
                SourceMemberKind.Field,
                54, "System.Boolean", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.SpanHelpers+PerTypeValues`1", 67110762, "EmptyArray", SourceMemberKind.Field, 54, "T[]", -1, -1,
                0,
                (SourceDeclaredAttribute[])[]));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.SpanHelpers+PerTypeValues`1", 67110763, "ArrayAdjustment", SourceMemberKind.Field, 54,
                "System.IntPtr", -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ThrowHelper",
                33554676, 1048960, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object", [],
                [
                    new("System.Diagnostics.StackTraceHiddenAttribute",
                        "System.Void System.Diagnostics.StackTraceHiddenAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AccessViolationException", 33554677, 1056769,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.SystemException",
                [],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AccessViolationException", 67110764, "_ip", SourceMemberKind.Field, 1, "System.IntPtr", -1, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AccessViolationException", 67110765, "_target", SourceMemberKind.Field, 1, "System.IntPtr", -1,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AccessViolationException", 67110766, "_accessType", SourceMemberKind.Field, 1, "System.Int32",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Action`1",
                33554678,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("T", 0, 704643160, 2, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Action",
                33554679,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [],
                [
                    new("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x4E, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x72, 0x65, 0x2C,
                            0x20,
                            0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x33, 0x2E, 0x35, 0x2E, 0x30, 0x2E, 0x30,
                            0x2C,
                            0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x4E, 0x65, 0x75, 0x74, 0x72, 0x61,
                            0x6C,
                            0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65,
                            0x6E,
                            0x3D, 0x62, 0x37, 0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30,
                            0x38,
                            0x39, 0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Action`2",
                33554680,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [],
                [
                    new("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x4E, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x72, 0x65, 0x2C,
                            0x20,
                            0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x33, 0x2E, 0x35, 0x2E, 0x30, 0x2E, 0x30,
                            0x2C,
                            0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x4E, 0x65, 0x75, 0x74, 0x72, 0x61,
                            0x6C,
                            0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65,
                            0x6E,
                            0x3D, 0x62, 0x37, 0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30,
                            0x38,
                            0x39, 0x00, 0x00,
                        ]),
                ], null, [],
                [
                    new("T1", 0, 704643161, 2, [],
                        []),
                    new("T2", 1, 704643162, 2, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Action`3",
                33554681,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [],
                [
                    new("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x4E, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x72, 0x65, 0x2C,
                            0x20,
                            0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x33, 0x2E, 0x35, 0x2E, 0x30, 0x2E, 0x30,
                            0x2C,
                            0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x4E, 0x65, 0x75, 0x74, 0x72, 0x61,
                            0x6C,
                            0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65,
                            0x6E,
                            0x3D, 0x62, 0x37, 0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30,
                            0x38,
                            0x39, 0x00, 0x00,
                        ]),
                ], null, [],
                [
                    new("T1", 0, 704643163, 2, [],
                        []),
                    new("T2", 1, 704643164, 2, [],
                        []),
                    new("T3", 2, 704643165, 2, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Action`4",
                33554682,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [],
                [
                    new("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x4E, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x72, 0x65, 0x2C,
                            0x20,
                            0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x33, 0x2E, 0x35, 0x2E, 0x30, 0x2E, 0x30,
                            0x2C,
                            0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x4E, 0x65, 0x75, 0x74, 0x72, 0x61,
                            0x6C,
                            0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65,
                            0x6E,
                            0x3D, 0x62, 0x37, 0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30,
                            0x38,
                            0x39, 0x00, 0x00,
                        ]),
                ], null, [],
                [
                    new("T1", 0, 704643166, 2, [],
                        []),
                    new("T2", 1, 704643167, 2, [],
                        []),
                    new("T3", 2, 704643168, 2, [],
                        []),
                    new("T4", 3, 704643169, 2, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Func`1",
                33554683,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [],
                [
                    new("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x4E, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x72, 0x65, 0x2C,
                            0x20,
                            0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x33, 0x2E, 0x35, 0x2E, 0x30, 0x2E, 0x30,
                            0x2C,
                            0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x4E, 0x65, 0x75, 0x74, 0x72, 0x61,
                            0x6C,
                            0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65,
                            0x6E,
                            0x3D, 0x62, 0x37, 0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30,
                            0x38,
                            0x39, 0x00, 0x00,
                        ]),
                ], null, [],
                [
                    new("TResult", 0, 704643170, 1,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Func`2",
                33554684,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [],
                [
                    new("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x4E, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x72, 0x65, 0x2C,
                            0x20,
                            0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x33, 0x2E, 0x35, 0x2E, 0x30, 0x2E, 0x30,
                            0x2C,
                            0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x4E, 0x65, 0x75, 0x74, 0x72, 0x61,
                            0x6C,
                            0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65,
                            0x6E,
                            0x3D, 0x62, 0x37, 0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30,
                            0x38,
                            0x39, 0x00, 0x00,
                        ]),
                ], null, [],
                [
                    new("T", 0, 704643171, 2, [],
                        []),
                    new("TResult", 1, 704643172, 1,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Func`3",
                33554685,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [],
                [
                    new("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x4E, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x72, 0x65, 0x2C,
                            0x20,
                            0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x33, 0x2E, 0x35, 0x2E, 0x30, 0x2E, 0x30,
                            0x2C,
                            0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x4E, 0x65, 0x75, 0x74, 0x72, 0x61,
                            0x6C,
                            0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65,
                            0x6E,
                            0x3D, 0x62, 0x37, 0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30,
                            0x38,
                            0x39, 0x00, 0x00,
                        ]),
                ], null, [],
                [
                    new("T1", 0, 704643173, 2, [],
                        []),
                    new("T2", 1, 704643174, 2, [],
                        []),
                    new("TResult", 2, 704643175, 1,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Func`4",
                33554686,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [],
                [
                    new("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x4E, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x72, 0x65, 0x2C,
                            0x20,
                            0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x33, 0x2E, 0x35, 0x2E, 0x30, 0x2E, 0x30,
                            0x2C,
                            0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x4E, 0x65, 0x75, 0x74, 0x72, 0x61,
                            0x6C,
                            0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65,
                            0x6E,
                            0x3D, 0x62, 0x37, 0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30,
                            0x38,
                            0x39, 0x00, 0x00,
                        ]),
                ], null, [],
                [
                    new("T1", 0, 704643176, 2, [],
                        []),
                    new("T2", 1, 704643177, 2, [],
                        []),
                    new("T3", 2, 704643178, 2, [],
                        []),
                    new("TResult", 3, 704643179, 1,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Func`5",
                33554687,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [],
                [
                    new("System.Runtime.CompilerServices.TypeForwardedFromAttribute",
                        "System.Void System.Runtime.CompilerServices.TypeForwardedFromAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x4E, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x72, 0x65, 0x2C,
                            0x20,
                            0x56, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x33, 0x2E, 0x35, 0x2E, 0x30, 0x2E, 0x30,
                            0x2C,
                            0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x4E, 0x65, 0x75, 0x74, 0x72, 0x61,
                            0x6C,
                            0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63, 0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65,
                            0x6E,
                            0x3D, 0x62, 0x37, 0x37, 0x61, 0x35, 0x63, 0x35, 0x36, 0x31, 0x39, 0x33, 0x34, 0x65, 0x30,
                            0x38,
                            0x39, 0x00, 0x00,
                        ]),
                ], null, [],
                [
                    new("T1", 0, 704643180, 2, [],
                        []),
                    new("T2", 1, 704643181, 2, [],
                        []),
                    new("T3", 2, 704643182, 2, [],
                        []),
                    new("T4", 3, 704643183, 2, [],
                        []),
                    new("TResult", 4, 704643184, 1,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Action`5",
                33554688,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("T1", 0, 704643185, 2, [],
                        []),
                    new("T2", 1, 704643186, 2, [],
                        []),
                    new("T3", 2, 704643187, 2, [],
                        []),
                    new("T4", 3, 704643188, 2, [],
                        []),
                    new("T5", 4, 704643189, 2, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Action`6",
                33554689,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("T1", 0, 704643190, 2, [],
                        []),
                    new("T2", 1, 704643191, 2, [],
                        []),
                    new("T3", 2, 704643192, 2, [],
                        []),
                    new("T4", 3, 704643193, 2, [],
                        []),
                    new("T5", 4, 704643194, 2, [],
                        []),
                    new("T6", 5, 704643195, 2, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Action`7",
                33554690,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("T1", 0, 704643196, 2, [],
                        []),
                    new("T2", 1, 704643197, 2, [],
                        []),
                    new("T3", 2, 704643198, 2, [],
                        []),
                    new("T4", 3, 704643199, 2, [],
                        []),
                    new("T5", 4, 704643200, 2, [],
                        []),
                    new("T6", 5, 704643201, 2, [],
                        []),
                    new("T7", 6, 704643202, 2, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Action`8",
                33554691,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("T1", 0, 704643203, 2, [],
                        []),
                    new("T2", 1, 704643204, 2, [],
                        []),
                    new("T3", 2, 704643205, 2, [],
                        []),
                    new("T4", 3, 704643206, 2, [],
                        []),
                    new("T5", 4, 704643207, 2, [],
                        []),
                    new("T6", 5, 704643208, 2, [],
                        []),
                    new("T7", 6, 704643209, 2, [],
                        []),
                    new("T8", 7, 704643210, 2, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Func`6",
                33554692,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("T1", 0, 704643211, 2, [],
                        []),
                    new("T2", 1, 704643212, 2, [],
                        []),
                    new("T3", 2, 704643213, 2, [],
                        []),
                    new("T4", 3, 704643214, 2, [],
                        []),
                    new("T5", 4, 704643215, 2, [],
                        []),
                    new("TResult", 5, 704643216, 1,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Func`7",
                33554693,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("T1", 0, 704643217, 2, [],
                        []),
                    new("T2", 1, 704643218, 2, [],
                        []),
                    new("T3", 2, 704643219, 2, [],
                        []),
                    new("T4", 3, 704643220, 2, [],
                        []),
                    new("T5", 4, 704643221, 2, [],
                        []),
                    new("T6", 5, 704643222, 2, [],
                        []),
                    new("TResult", 6, 704643223, 1,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Func`8",
                33554694,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("T1", 0, 704643224, 2, [],
                        []),
                    new("T2", 1, 704643225, 2, [],
                        []),
                    new("T3", 2, 704643226, 2, [],
                        []),
                    new("T4", 3, 704643227, 2, [],
                        []),
                    new("T5", 4, 704643228, 2, [],
                        []),
                    new("T6", 5, 704643229, 2, [],
                        []),
                    new("T7", 6, 704643230, 2, [],
                        []),
                    new("TResult", 7, 704643231, 1,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Func`9",
                33554695,
                257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("T1", 0, 704643232, 2, [],
                        []),
                    new("T2", 1, 704643233, 2, [],
                        []),
                    new("T3", 2, 704643234, 2, [],
                        []),
                    new("T4", 3, 704643235, 2, [],
                        []),
                    new("T5", 4, 704643236, 2, [],
                        []),
                    new("T6", 5, 704643237, 2, [],
                        []),
                    new("T7", 6, 704643238, 2, [],
                        []),
                    new("T8", 7, 704643239, 2, [],
                        []),
                    new("TResult", 8, 704643240, 1,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Comparison`1",
                33554696, 257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("T", 0, 704643241, 2, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Converter`2",
                33554697, 257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("TInput", 0, 704643242, 2,
                        [],
                        []),
                    new("TOutput", 1, 704643243, 1,
                        [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Predicate`1",
                33554698, 257, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.MulticastDelegate", [], [], null,
                [],
                [
                    new("T", 0, 704643244, 2, [],
                        []),
                ]));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Activator",
                33554699,
                1048833, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object",
                ["System.Runtime.InteropServices._Activator"],
                [
                    new("System.Runtime.InteropServices.ComVisibleAttribute",
                        "System.Void System.Runtime.InteropServices.ComVisibleAttribute::.ctor(System.Boolean)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x01, 0x00, 0x00]),
                    new("System.Runtime.InteropServices.ComDefaultInterfaceAttribute",
                        "System.Void System.Runtime.InteropServices.ComDefaultInterfaceAttribute::.ctor(System.Type)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x29, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x52, 0x75, 0x6E, 0x74, 0x69,
                            0x6D,
                            0x65, 0x2E, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x6F, 0x70, 0x53, 0x65, 0x72, 0x76, 0x69, 0x63,
                            0x65,
                            0x73, 0x2E, 0x5F, 0x41, 0x63, 0x74, 0x69, 0x76, 0x61, 0x74, 0x6F, 0x72, 0x00, 0x00,
                        ]),
                    new("System.Runtime.InteropServices.ClassInterfaceAttribute",
                        "System.Void System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(System.Runtime.InteropServices.ClassInterfaceType)",
                        /* ReSharper disable once UseUtf8StringLiteral */
                        [0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]),
                ], null, ["mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Activator",
                67110767,
                "LookupMask", SourceMemberKind.Field, 32851, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", [0xFF, 0x00, 0x00, 0x00]), "System.Int32",
                "FF000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Activator",
                67110768,
                "ConLookup", SourceMemberKind.Field, 32851, "System.Reflection.BindingFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x14, 0x00, 0x00, 0x00]), "System.Int32",
                "14000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Activator",
                67110769,
                "ConstructorDefault", SourceMemberKind.Field, 32851, "System.Reflection.BindingFlags", -1, -1, 0,
                (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x14, 0x02, 0x00, 0x00]), "System.Int32",
                "14020000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AggregateException",
                33554700, 1056769, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Exception", [],
                [
                    new("System.Diagnostics.DebuggerDisplayAttribute",
                        "System.Void System.Diagnostics.DebuggerDisplayAttribute::.ctor(System.String)",
                        /* ReSharper disable once UseUtf8StringLiteral */ [
                            0x01, 0x00, 0x1D, 0x43, 0x6F, 0x75, 0x6E, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x49, 0x6E, 0x6E,
                            0x65,
                            0x72, 0x45, 0x78, 0x63, 0x65, 0x70, 0x74, 0x69, 0x6F, 0x6E, 0x43, 0x6F, 0x75, 0x6E, 0x74,
                            0x7D,
                            0x00, 0x00,
                        ]),
                ], null, [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AggregateException",
                67110770, "m_innerExceptions", SourceMemberKind.Field, 1,
                "System.Collections.ObjectModel.ReadOnlyCollection`1<System.Exception>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AggregateException",
                385876357, "InnerExceptions", SourceMemberKind.Property, 0,
                "System.Collections.ObjectModel.ReadOnlyCollection`1<System.Exception>", 2182, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AggregateException",
                385876358, "InnerExceptionCount", SourceMemberKind.Property, 0, "System.Int32", 2177, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppContext",
                33554701, 1048961, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object", [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppContext",
                67110771, "s_switchMap", SourceMemberKind.Field, 49,
                "System.Collections.Generic.Dictionary`2<System.String,System.AppContext+SwitchValueState>", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppContext",
                67110772, "s_defaultsInitialized", SourceMemberKind.Field, 17,
                "System.Boolean modreq(System.Runtime.CompilerServices.IsVolatile)", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppContext",
                385876359, "BaseDirectory", SourceMemberKind.Property, 0, "System.String", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AppContext",
                385876360, "TargetFrameworkName", SourceMemberKind.Property, 0, "System.String", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContext+SwitchValueState", 33554702, 259,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum",
                [],
                [
                    new("System.FlagsAttribute", "System.Void System.FlagsAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], "System.Int32", [], []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContext+SwitchValueState", 67110773, "value__", SourceMemberKind.Field, 1542, "System.Int32",
                -1,
                -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContext+SwitchValueState", 67110774, "HasFalseValue", SourceMemberKind.Field, 32854,
                "System.AppContext+SwitchValueState", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x01, 0x00, 0x00, 0x00]), "System.Int32",
                "01000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContext+SwitchValueState", 67110775, "HasTrueValue", SourceMemberKind.Field, 32854,
                "System.AppContext+SwitchValueState", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x02, 0x00, 0x00, 0x00]), "System.Int32",
                "02000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContext+SwitchValueState", 67110776, "HasLookedForOverride", SourceMemberKind.Field, 32854,
                "System.AppContext+SwitchValueState", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x04, 0x00, 0x00, 0x00]), "System.Int32",
                "04000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContext+SwitchValueState", 67110777, "UnknownValue", SourceMemberKind.Field, 32854,
                "System.AppContext+SwitchValueState", -1, -1, 0, (SourceDeclaredAttribute[])[], true,
                SourceMetadataConstant.Decode("System.Int32", /* ReSharper disable once UseUtf8StringLiteral */
                    [0x08, 0x00, 0x00, 0x00]), "System.Int32",
                "08000000", "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterTypeDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                33554703, 384, "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.Object", [], [], null, [],
                []));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                67110778, "_noAsyncCurrentCulture", SourceMemberKind.Field, 17, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                67110779, "_throwExceptionIfDisposedCancellationTokenSource", SourceMemberKind.Field, 17,
                "System.Int32",
                -1, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                67110780, "_preserveEventListnerObjectIdentity", SourceMemberKind.Field, 17, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                67110781, "_useLegacyPathHandling", SourceMemberKind.Field, 17, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                67110782, "_blockLongPaths", SourceMemberKind.Field, 17, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                67110783, "_cloneActor", SourceMemberKind.Field, 17, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                67110784, "_doNotAddrOfCspParentWindowHandle", SourceMemberKind.Field, 17, "System.Int32", -1, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                67110785, "<DisableCaching>k__BackingField", SourceMemberKind.Field, 17, "System.Boolean", -1, -1, 0,
                (SourceDeclaredAttribute[])
                [
                    new("System.Runtime.CompilerServices.CompilerGeneratedAttribute",
                        "System.Void System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor()",
                        /* ReSharper disable once UseUtf8StringLiteral */ [0x01, 0x00, 0x00, 0x00]),
                ], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                385876361, "NoAsyncCurrentCulture", SourceMemberKind.Property, 0, "System.Boolean", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                385876362, "ThrowExceptionIfDisposedCancellationTokenSource", SourceMemberKind.Property, 0,
                "System.Boolean", 2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                385876363, "PreserveEventListnerObjectIdentity", SourceMemberKind.Property, 0, "System.Boolean", 2198,
                -1,
                0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                385876364, "UseLegacyPathHandling", SourceMemberKind.Property, 0, "System.Boolean", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                385876365, "BlockLongPaths", SourceMemberKind.Property, 0, "System.Boolean", 2198, -1, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                385876366, "SetActorAsReferenceWhenCopyingClaimsIdentity", SourceMemberKind.Property, 0,
                "System.Boolean",
                2198, -1, 0, (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                385876367, "DoNotAddrOfCspParentWindowHandle", SourceMemberKind.Property, 0, "System.Boolean", 2198, -1,
                0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            catalog.RegisterDefinition(new(
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
                "System.AppContextSwitches",
                385876368, "DisableCaching", SourceMemberKind.Property, 0, "System.Boolean", 2193, 2193, 0,
                (SourceDeclaredAttribute[])[], false, null, null, null,
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
        }
    }
}
