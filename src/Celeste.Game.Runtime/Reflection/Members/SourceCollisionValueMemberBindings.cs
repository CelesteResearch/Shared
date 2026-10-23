using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Runtime.Reflection.Members
{
    public static class SourceCollisionValueMemberBindings
    {
        public static void Register(SourceMemberCatalog catalog, string assemblyIdentity)
        {
            const string coreLibrary = "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            catalog.RegisterSourceType(typeof(SourceCollisionHandler), assemblyIdentity, "Celeste.Collision",
                coreLibrary, "System.MulticastDelegate");
            catalog.RegisterSourceType(typeof(PixelCollision), assemblyIdentity, "Celeste.CollisionData",
                coreLibrary, "System.ValueType");
            Bind(catalog, assemblyIdentity, "Direction");
            Bind(catalog, assemblyIdentity, "Moved");
            Bind(catalog, assemblyIdentity, "TargetPosition");
            Bind(catalog, assemblyIdentity, "Hit", typeof(SourcePlatformEntityState));
            Bind(catalog, assemblyIdentity, "Pusher", typeof(SourceSolidEntityState));
            Bind(catalog, assemblyIdentity, "Empty");
        }

        private static void Bind(SourceMemberCatalog catalog, string assemblyIdentity, string name,
            Type declaredActualValueType = null)
        {
            var definition = catalog.RequireDefinition(assemblyIdentity, "Celeste.CollisionData", name,
                SourceMemberKind.Field);
            var field = typeof(PixelCollision).GetField(name, BindingFlags.Public | BindingFlags.Instance
                            | BindingFlags.Static |
                            BindingFlags.DeclaredOnly) ??
                        throw new MissingFieldException(typeof(PixelCollision).FullName, name);
            catalog.RegisterBinding(new SourcePhysicalMemberBinding(definition, typeof(PixelCollision), field,
                declaredActualValueType: declaredActualValueType));
        }
    }
}
