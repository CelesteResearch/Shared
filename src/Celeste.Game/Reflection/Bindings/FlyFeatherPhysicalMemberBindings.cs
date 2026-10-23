using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Entities.StarJump;

namespace Celeste.Game.Reflection.Bindings
{
    public static class FlyFeatherPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog members)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition =
                members.RequireDefinition(assembly, "Celeste.FlyFeather", "moveWiggleDir", SourceMemberKind.Field);
            var field = typeof(OriginalFlyFeatherState).GetField("moveWiggleDir", BindingFlags.Instance |
                            BindingFlags.NonPublic |
                            BindingFlags.DeclaredOnly)
                        ?? throw new MissingFieldException(typeof(OriginalFlyFeatherState).FullName, "moveWiggleDir");
            if (definition.IsStatic != field.IsStatic || definition.IsLiteral != field.IsLiteral)
                throw new InvalidOperationException(
                    "FlyFeather source field differs from actual storage: moveWiggleDir");
            members.RegisterBinding(new SourcePhysicalMemberBinding(definition, typeof(OriginalFlyFeatherState),
                field));
        }
    }
}
