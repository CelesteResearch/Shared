using Celeste.Core.Reflection.Members;

namespace Celeste.Game.Runtime.Reflection.Members
{
    public static class SourceActorPlayerReferencedValueTypes
    {
        public static void Register(SourceMemberCatalog catalog, string assemblyIdentity)
        {
            const string coreLibrary = "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            catalog.RegisterSourceType(typeof(global::Celeste.Core.Components.SourceComponentState), assemblyIdentity,
                "Monocle.Component",
                coreLibrary, "System.Object");
            catalog.RegisterSourceType(typeof(global::Celeste.Core.Components.SourceOwnedComponentList),
                assemblyIdentity,
                "Monocle.ComponentList",
                coreLibrary, "System.Object");
            catalog.RegisterSourceType(typeof(global::Celeste.Physics.Collision.Shapes.ColliderGeometry),
                assemblyIdentity,
                "Monocle.Collider",
                coreLibrary, "System.Object");
            catalog.RegisterSourceType(typeof(global::Celeste.Graphics.Animation.SourceGraphicsComponentState),
                assemblyIdentity, "Monocle.GraphicsComponent",
                assemblyIdentity, "Monocle.Component");
            catalog.RegisterSourceType(typeof(global::Celeste.Graphics.Animation.SpriteImage), assemblyIdentity,
                "Monocle.Image",
                assemblyIdentity, "Monocle.GraphicsComponent");
            catalog.RegisterSourceType(typeof(global::Celeste.Graphics.Animation.Sprite), assemblyIdentity,
                "Monocle.Sprite",
                assemblyIdentity, "Monocle.Image");
            catalog.RegisterSourceType(
                typeof(global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSpriteMode),
                assemblyIdentity,
                "Celeste.PlayerSpriteMode",
                coreLibrary, "System.Enum");
            catalog.RegisterSourceType(
                typeof(global::Celeste.Simulation.Gameplay.Player.Presentation.Sprites.PlayerSprite),
                assemblyIdentity, "Celeste.PlayerSprite",
                assemblyIdentity, "Monocle.Sprite");
            catalog.RegisterSourceType(typeof(global::Celeste.Simulation.Gameplay.Player.Presentation.Hair.PlayerHair),
                assemblyIdentity, "Celeste.PlayerHair",
                assemblyIdentity, "Monocle.Component");
            catalog.RegisterSourceType(typeof(global::Celeste.Scene.Following.LeaderState), assemblyIdentity,
                "Celeste.Leader",
                assemblyIdentity, "Monocle.Component");
            catalog.RegisterSourceType(typeof(global::Celeste.Simulation.Gameplay.Holdables.HoldableState),
                assemblyIdentity, "Celeste.Holdable",
                assemblyIdentity, "Monocle.Component");
            catalog.RegisterSourceType(typeof(global::Celeste.Simulation.Gameplay.Player.Inventory.RoomPlayerInventory),
                assemblyIdentity, "Celeste.PlayerInventory",
                coreLibrary, "System.ValueType");
            catalog.RegisterSourceType(typeof(global::Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers.ChaserState),
                assemblyIdentity, "Celeste.Player+ChaserState",
                coreLibrary, "System.ValueType");
        }
    }
}
