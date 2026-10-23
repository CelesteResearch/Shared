using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Graphics.Animation;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Simulation.Gameplay.Player.Inventory;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;

namespace Celeste.Game.Runtime.Reflection.Members
{
    public static class SourceActorPlayerReferencedMemberBindings
    {
        public static void Register(SourceMemberCatalog catalog, string assemblyIdentity)
        {
            Bind(catalog, assemblyIdentity, "Celeste.Player",
                typeof(RoomPlayerSession),
                SourceMemberKind.Field, "normalLightOffset", "NormalLightOffset");
            Bind(catalog, assemblyIdentity, "Celeste.Player",
                typeof(RoomPlayerSession),
                SourceMemberKind.Field, "duckingLightOffset", "DuckingLightOffset");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerInventory",
                typeof(RoomPlayerInventory),
                SourceMemberKind.Field, "Prologue", "Prologue");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerInventory",
                typeof(RoomPlayerInventory),
                SourceMemberKind.Field, "Default", "Default");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerInventory",
                typeof(RoomPlayerInventory),
                SourceMemberKind.Field, "OldSite", "OldSite");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerInventory",
                typeof(RoomPlayerInventory),
                SourceMemberKind.Field, "CH6End", "CH6End");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerInventory",
                typeof(RoomPlayerInventory),
                SourceMemberKind.Field, "TheSummit", "TheSummit");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerInventory",
                typeof(RoomPlayerInventory),
                SourceMemberKind.Field, "Core", "Core");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerInventory",
                typeof(RoomPlayerInventory),
                SourceMemberKind.Field, "Farewell", "Farewell");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerInventory",
                typeof(RoomPlayerInventory),
                SourceMemberKind.Field, "Dashes", "Dashes");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerInventory",
                typeof(RoomPlayerInventory),
                SourceMemberKind.Field, "DreamDash", "DreamDash");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerInventory",
                typeof(RoomPlayerInventory),
                SourceMemberKind.Field, "Backpack", "Backpack");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerInventory",
                typeof(RoomPlayerInventory),
                SourceMemberKind.Field, "NoRefills", "NoRefills");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerHair",
                typeof(PlayerHair),
                SourceMemberKind.Field, "Alpha", "Alpha");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerHair",
                typeof(PlayerHair),
                SourceMemberKind.Field, "DrawPlayerSpriteOutline", "DrawPlayerSpriteOutline");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerHair",
                typeof(PlayerHair),
                SourceMemberKind.Field, "SimulateMotion", "SimulateMotion");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerHair",
                typeof(PlayerHair),
                SourceMemberKind.Field, "StepPerSegment", "StepPerSegment");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerHair",
                typeof(PlayerHair),
                SourceMemberKind.Field, "StepInFacingPerSegment", "StepInFacingPerSegment");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerHair",
                typeof(PlayerHair),
                SourceMemberKind.Field, "StepApproach", "StepApproach");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerHair",
                typeof(PlayerHair),
                SourceMemberKind.Field, "StepYSinePerSegment", "StepYSinePerSegment");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerHair",
                typeof(PlayerHair),
                SourceMemberKind.Field, "Sprite", "Sprite");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerHair",
                typeof(PlayerHair),
                SourceMemberKind.Field, "wave", "wave");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerHair",
                typeof(PlayerHair),
                SourceMemberKind.Field, "Facing", "SourceFacing");
            Bind(catalog, assemblyIdentity, "Celeste.Player+ChaserState",
                typeof(ChaserState),
                SourceMemberKind.Field, "Position", "Position");
            Bind(catalog, assemblyIdentity, "Celeste.Player+ChaserState",
                typeof(ChaserState),
                SourceMemberKind.Field, "TimeStamp", "TimeStamp");
            Bind(catalog, assemblyIdentity, "Celeste.Player+ChaserState",
                typeof(ChaserState),
                SourceMemberKind.Field, "Animation", "Animation");
            Bind(catalog, assemblyIdentity, "Celeste.Player+ChaserState",
                typeof(ChaserState),
                SourceMemberKind.Field, "OnGround", "OnGround");
            Bind(catalog, assemblyIdentity, "Celeste.Player+ChaserState",
                typeof(ChaserState),
                SourceMemberKind.Field, "Depth", "Depth");
            Bind(catalog, assemblyIdentity, "Celeste.Player+ChaserState",
                typeof(ChaserState),
                SourceMemberKind.Field, "Scale", "Scale");
            Bind(catalog, assemblyIdentity, "Celeste.Player+ChaserState",
                typeof(ChaserState),
                SourceMemberKind.Field, "DashDirection", "DashDirection");
            Bind(catalog, assemblyIdentity, "Celeste.Player+ChaserState",
                typeof(ChaserState),
                SourceMemberKind.Field, "Sounds", "Sounds");
            Bind(catalog, assemblyIdentity, "Celeste.Player+ChaserState",
                typeof(ChaserState),
                SourceMemberKind.Field, "Facing", "SourceFacing");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerSprite",
                typeof(PlayerSprite),
                SourceMemberKind.Property, "Mode", "Mode");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerSprite",
                typeof(PlayerSprite),
                SourceMemberKind.Field, "<Mode>k__BackingField", "<Mode>k__BackingField");
            Bind(catalog, assemblyIdentity, "Celeste.PlayerSprite",
                typeof(PlayerSprite),
                SourceMemberKind.Field, "HairCount", "HairCount");
            Bind(catalog, assemblyIdentity, "Monocle.GraphicsComponent",
                typeof(SourceGraphicsComponentState),
                SourceMemberKind.Field, "Position", "Position");
            Bind(catalog, assemblyIdentity, "Monocle.GraphicsComponent",
                typeof(SourceGraphicsComponentState),
                SourceMemberKind.Field, "Origin", "Origin");
            Bind(catalog, assemblyIdentity, "Monocle.GraphicsComponent",
                typeof(SourceGraphicsComponentState),
                SourceMemberKind.Field, "Scale", "Scale");
            Bind(catalog, assemblyIdentity, "Monocle.GraphicsComponent",
                typeof(SourceGraphicsComponentState),
                SourceMemberKind.Field, "Rotation", "Rotation");
            Bind(catalog, assemblyIdentity, "Monocle.GraphicsComponent",
                typeof(SourceGraphicsComponentState),
                SourceMemberKind.Property, "X", "X");
            Bind(catalog, assemblyIdentity, "Monocle.GraphicsComponent",
                typeof(SourceGraphicsComponentState),
                SourceMemberKind.Property, "Y", "Y");
            Bind(catalog, assemblyIdentity, "Monocle.GraphicsComponent",
                typeof(SourceGraphicsComponentState),
                SourceMemberKind.Property, "RenderPosition", "RenderPosition");
        }

        private static void Bind(SourceMemberCatalog catalog, string assemblyIdentity,
            string logicalDeclaringType, Type actualType, SourceMemberKind kind, string name, string physicalName)
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public
                                       | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            var definition = catalog.RequireDefinition(assemblyIdentity, logicalDeclaringType, name, kind);
            MemberInfo member = actualType.GetField(physicalName, flags);
            if (member == null) member = actualType.GetProperty(physicalName, flags);
            if (member == null) throw new MissingMemberException(actualType.FullName, physicalName);
            catalog.RegisterBinding(new(definition, actualType, member));
        }
    }
}
