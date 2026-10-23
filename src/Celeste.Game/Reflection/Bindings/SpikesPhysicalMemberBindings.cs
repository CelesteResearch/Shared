using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Simulation.Gameplay.Hazards.Spikes;

namespace Celeste.Game.Reflection.Bindings
{
    public static class SpikesPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog members)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            foreach (var name in new[] { "imageOffset", "Direction" })
            {
                var definition = members.RequireDefinition(assembly, "Celeste.Spikes", name, SourceMemberKind.Field);
                var field = typeof(SpikesState).GetField(name, BindingFlags.Instance | BindingFlags.Public |
                                                               BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                            ?? throw new MissingFieldException(typeof(SpikesState).FullName, name);
                if (definition.IsStatic != field.IsStatic || definition.IsLiteral != field.IsLiteral)
                    throw new InvalidOperationException("Spikes source field differs from actual storage: " + name);
                members.RegisterBinding(new(definition, typeof(SpikesState), field));
            }
        }
    }
}
