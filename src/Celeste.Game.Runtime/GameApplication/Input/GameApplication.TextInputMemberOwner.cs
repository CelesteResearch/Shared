using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Everest.Runtime.Input;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication
    {
        private void PublishSourceInstalledTextInputMemberOwner()
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            const string sourceType = "Celeste.Mod.TextInput";
            Type actualType = typeof(EverestTextInputProcess);
            var type = SourceMembers.GetOriginalTypeDefinition(assembly, sourceType);
            if (type.MetadataToken != 33557005)
                throw new InvalidOperationException(
                    "The installed TextInput source TypeDef differs from the selected original PE.");
            SourceMembers.RegisterSourceType(actualType, assembly, sourceType);
            var field = SourceMembers.RequireDefinition(assembly, sourceType, "_OnInput", SourceMemberKind.Field);
            if (field.MetadataToken != 67122600 || !field.IsStatic)
                throw new InvalidOperationException(
                    "The installed TextInput source event backing field differs from the selected original PE.");
            var actualField = actualType.GetField("onInput",
                                  BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                              ?? throw new MissingFieldException(actualType.FullName, "onInput");
            SourceMembers.RegisterBinding(new SourcePhysicalMemberBinding(field, actualType, actualField,
                staticSourceOwner: InstalledTextInput));
        }
    }
}
