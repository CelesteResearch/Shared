using System;
using System.Numerics;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Game.Entities.Triggers.Camera;

namespace Celeste.Game.Reflection.Bindings
{
    public static class CameraOffsetTriggerPhysicalMemberBindings
    {
        public static void Register(SourceMemberCatalog catalog)
        {
            const string assembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            var definition = catalog.RequireDefinition(assembly, "Celeste.CameraOffsetTrigger", "CameraOffset",
                SourceMemberKind.Field);
            if (definition.IsStatic || !definition.IsPublic || !definition.CanRead || !definition.CanWrite
                || definition.ValueTypeIdentity != "Microsoft.Xna.Framework.Vector2")
                throw new InvalidOperationException("The original CameraOffsetTrigger vector declaration differs.");
            var owner = typeof(OriginalCameraOffsetTriggerState);
            var storage = owner.GetField("CameraOffset",
                              BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                          ?? throw new MissingFieldException(owner.FullName, "CameraOffset");
            if (storage.FieldType != typeof(Vector2) || storage.IsStatic || storage.IsInitOnly)
                throw new InvalidOperationException("The actual CameraOffsetTrigger vector storage differs.");
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(definition, owner, storage));
        }
    }
}
