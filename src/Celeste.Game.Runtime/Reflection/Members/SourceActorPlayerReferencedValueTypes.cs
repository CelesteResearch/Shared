using Celeste.Core.Components;
using Celeste.Core.Reflection.Members;
using Celeste.Graphics.Animation;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Following;
using Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Player.Inventory;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Game.Runtime.Reflection.Members
{
    public static class SourceActorPlayerReferencedValueTypes
    {
        public static void Register(SourceMemberCatalog catalog, string assemblyIdentity)
        {
            const string coreLibrary = "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
            catalog.RegisterSourceType(typeof(SourceComponentState), assemblyIdentity,
                "Monocle.Component",
                coreLibrary, "System.Object");
            catalog.RegisterSourceType(typeof(SourceOwnedComponentList),
                assemblyIdentity,
                "Monocle.ComponentList",
                coreLibrary, "System.Object");
            catalog.RegisterSourceType(typeof(ColliderGeometry),
                assemblyIdentity,
                "Monocle.Collider",
                coreLibrary, "System.Object");
            catalog.RegisterSourceType(typeof(SourceGraphicsComponentState),
                assemblyIdentity, "Monocle.GraphicsComponent",
                assemblyIdentity, "Monocle.Component");
            catalog.RegisterSourceType(typeof(SpriteImage), assemblyIdentity,
                "Monocle.Image",
                assemblyIdentity, "Monocle.GraphicsComponent");
            catalog.RegisterSourceType(typeof(Sprite), assemblyIdentity,
                "Monocle.Sprite",
                assemblyIdentity, "Monocle.Image");
            catalog.RegisterSourceType(
                typeof(PlayerSpriteMode),
                assemblyIdentity,
                "Celeste.PlayerSpriteMode",
                coreLibrary, "System.Enum");
            catalog.RegisterSourceType(
                typeof(PlayerSprite),
                assemblyIdentity, "Celeste.PlayerSprite",
                assemblyIdentity, "Monocle.Sprite");
            catalog.RegisterSourceType(typeof(PlayerHair),
                assemblyIdentity, "Celeste.PlayerHair",
                assemblyIdentity, "Monocle.Component");
            catalog.RegisterSourceType(typeof(LeaderState), assemblyIdentity,
                "Celeste.Leader",
                assemblyIdentity, "Monocle.Component");
            catalog.RegisterSourceType(typeof(HoldableState),
                assemblyIdentity, "Celeste.Holdable",
                assemblyIdentity, "Monocle.Component");
            catalog.RegisterSourceType(typeof(RoomPlayerInventory),
                assemblyIdentity, "Celeste.PlayerInventory",
                coreLibrary, "System.ValueType");
            catalog.RegisterSourceType(typeof(ChaserState),
                assemblyIdentity, "Celeste.Player+ChaserState",
                coreLibrary, "System.ValueType");
        }
    }
}
