using System;
using System.Numerics;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Everest.Gameplay.Triggers.Camera;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Reflection.Bindings
{
    public static class SmoothCameraOffsetTriggerPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog catalog)
        {
            Bind(catalog, "offsetFrom", "Microsoft.Xna.Framework.Vector2", typeof(Vector2));
            Bind(catalog, "offsetTo", "Microsoft.Xna.Framework.Vector2", typeof(Vector2));
            Bind(catalog, "positionMode", "Celeste.Trigger+PositionModes",
                typeof(SourceTriggerEntityState.PositionModes));
            Bind(catalog, "onlyOnce", "System.Boolean", typeof(bool));
            Bind(catalog, "xOnly", "System.Boolean", typeof(bool));
            Bind(catalog, "yOnly", "System.Boolean", typeof(bool));
        }

        private static void Bind(SourceMemberCatalog catalog, string name, string sourceValueType, Type actualValueType)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition = catalog.RequireDefinition(assembly, "Celeste.Mod.Entities.SmoothCameraOffsetTrigger", name,
                SourceMemberKind.Field);
            if (definition.IsStatic || definition.IsPublic || !definition.CanRead || !definition.CanWrite
                || definition.ValueTypeIdentity != sourceValueType)
                throw new InvalidOperationException("The original SmoothCameraOffsetTrigger declaration differs: " +
                                                    name);
            var owner = typeof(SmoothCameraOffsetTrigger);
            var storage = owner.GetField(name,
                              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                          ?? throw new MissingFieldException(owner.FullName, name);
            if (storage.FieldType != actualValueType || !storage.IsPrivate || storage.IsStatic || storage.IsInitOnly)
                throw new InvalidOperationException("The actual SmoothCameraOffsetTrigger storage differs: " + name);
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(definition, owner, storage));
        }
    }
}
