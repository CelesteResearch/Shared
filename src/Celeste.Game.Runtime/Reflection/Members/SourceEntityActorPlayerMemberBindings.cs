using System;
using System.Reflection;
using Celeste.Simulation.Gameplay.Actors.Facing;
using Celeste.Core.Reflection.Members;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Actors.Foundation;

namespace Celeste.Game.Runtime.Reflection.Members
{
    public static class SourceEntityActorPlayerMemberBindings
    {
        // Invoke after the selected original PE definitions and actual types have
        // been qualified. Entity and Actor bindings apply to their actual inherited
        // storage; the source catalog must resolve qualified base scopes. This
        // producer neither replaces those facts nor owns state.
        public static void Register(SourceMemberCatalog catalog, string assemblyIdentity)
        {
            if (catalog == null) throw new ArgumentNullException(nameof(catalog));
            RegisterSourceTypes(catalog, assemblyIdentity);
            Bind(catalog, assemblyIdentity, "Celeste.Solid", typeof(SourceSolidEntityState), SourceMemberKind.Field,
                "Speed", nameof(SourceSolidEntityState.Speed));
            Bind(catalog, assemblyIdentity, "Celeste.Platform", typeof(SourcePlatformEntityState),
                SourceMemberKind.Field,
                "movementCounter", nameof(SourcePlatformEntityState.MovementCounter));
            Bind(catalog, assemblyIdentity, "Celeste.Platform", typeof(SourcePlatformEntityState),
                SourceMemberKind.Field,
                "shakeAmount", "shakeAmount");
            Bind(catalog, assemblyIdentity, "Celeste.Platform", typeof(SourcePlatformEntityState),
                SourceMemberKind.Field,
                "LiftSpeed", nameof(SourcePlatformEntityState.LiftSpeed));
            Bind(catalog, assemblyIdentity, "Celeste.Platform", typeof(SourcePlatformEntityState),
                SourceMemberKind.Property,
                "Shake", nameof(SourcePlatformEntityState.Shake));
            Bind(catalog, assemblyIdentity, "Celeste.Platform", typeof(SourcePlatformEntityState),
                SourceMemberKind.Property,
                "ExactPosition", nameof(SourcePlatformEntityState.ExactPosition));
            foreach (var definition in catalog.GetOriginalMemberDefinitions(assemblyIdentity, "Celeste.Platform", true))
                if (definition.Kind == SourceMemberKind.Property && definition.Name == "_movementCounter")
                    Bind(catalog, assemblyIdentity, "Celeste.Platform", typeof(SourcePlatformEntityState),
                        SourceMemberKind.Property, "_movementCounter",
                        nameof(SourcePlatformEntityState.MovementCounter));

            SourceCollisionValueMemberBindings.Register(catalog, assemblyIdentity);
            SourceActorPlayerReferencedValueTypes.Register(catalog, assemblyIdentity);
            SourceActorPlayerReferencedMemberBindings.Register(catalog, assemblyIdentity);
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Field,
                "Active",
                "Active");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Field,
                "Visible",
                "Visible");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Field,
                "Collidable", "Collidable");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Field,
                "Position",
                "Position");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Scene",
                "SourceSceneValue");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Components", "Components");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Depth",
                "Depth");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property, "X",
                "X");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property, "Y",
                "Y");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Collider", "Collider");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Width",
                "Width");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Height",
                "Height");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Left",
                "Left");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Right",
                "Right");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Top",
                "Top");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Bottom",
                "Bottom");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "CenterX", "CenterX");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "CenterY", "CenterY");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "TopLeft", "TopLeft");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "TopRight", "TopRight");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "BottomLeft", "BottomLeft");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "BottomRight", "BottomRight");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Center",
                "Center");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "CenterLeft", "CenterLeft");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "CenterRight", "CenterRight");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "TopCenter", "TopCenter");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "BottomCenter", "BottomCenter");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Field,
                "<Scene>k__BackingField", "SourceSceneValue");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Field,
                "<Components>k__BackingField", "<OwnedComponents>k__BackingField");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Field, "depth",
                "RawDepth");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Field,
                "actualDepth", "ActualDepth");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Field,
                "collider",
                "collider");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Field, "tag",
                "SourceRawTagValue");
            Bind(catalog, assemblyIdentity, "Monocle.Entity", typeof(SceneEntityState), SourceMemberKind.Property,
                "Tag",
                "SourceTagValue");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Field,
                "TreatNaive", "TreatNaive");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Field,
                "AllowPushing", "AllowPushing");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Field,
                "SquishCallback", "SquishCallback");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Field,
                "movementCounter", "Body", "Remainder");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Field,
                "IgnoreJumpThrus", "Body", "IgnoreJumpThrus");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Field,
                "LiftSpeedGraceTime", "Body", "LiftSpeedGraceTime");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Field,
                "currentLiftSpeed", "Body", "currentLiftSpeed");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Field,
                "lastLiftSpeed", "Body", "lastLiftSpeed");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Field,
                "liftSpeedTimer", "Body", "liftSpeedTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Property,
                "ExactPosition", "Body", "ExactPosition");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Property,
                "PositionRemainder", "Body", "PositionRemainder");
            Bind(catalog, assemblyIdentity, "Celeste.Actor", typeof(SourceActorEntityState), SourceMemberKind.Property,
                "LiftSpeed", "Body", "LiftSpeed");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "Speed",
                "Data", "Motion", "Normal", "Speed");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "StateMachine", "Machine");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "Facing",
                "SourceFacing");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "Dashes",
                "Data", "Dashes");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "Stamina",
                "Data", "Stamina");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "PreviousPosition", "Data", "PreviousPosition");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "onGround",
                "Data", "OnGround");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "wasOnGround", "Data", "WasOnGround");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "moveX",
                "Data", "MoveX");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "wasDucking", "Data", "WasDucking");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "climbTriggerDir", "Data", "ClimbTriggerDirection");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "holdCannotDuck", "Data", "Motion", "Normal", "HoldCannotDuck");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "windMovedUp", "Data", "WindMovedUp");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "jumpGraceTimer", "Data", "Motion", "JumpGraceTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "AutoJump",
                "Data", "Motion", "AutoJump");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "AutoJumpTimer", "Data", "AutoJumpTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "varJumpSpeed", "Data", "Motion", "Normal", "VariableJumpSpeed");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "varJumpTimer", "Data", "Motion", "Normal", "VariableJumpTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "forceMoveX", "Data", "Motion", "ForceMoveX");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "forceMoveXTimer", "Data", "Motion", "ForceMoveXTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "hopWaitX",
                "Data", "HopWaitX");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "hopWaitXSpeed", "Data", "HopWaitXSpeed");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "lastAim",
                "Data", "LastAim");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "dashCooldownTimer", "Data", "CooldownTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "dashRefillCooldownTimer", "Data", "RefillCooldownTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "DashDir",
                "Data", "Direction");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "wallSlideTimer", "Data", "Motion", "WallSlideTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "wallSlideDir", "Data", "WallSlideDirection");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "climbNoMoveTimer", "Data", "ClimbNoMoveTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "wallSpeedRetentionTimer", "Data", "WallSpeedRetentionTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "wallSpeedRetained", "Data", "WallSpeedRetained");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "wallBoostDir", "Data", "WallBoostDirection");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "wallBoostTimer", "Data", "Motion", "WallBoostTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "maxFall",
                "Data", "Motion", "Normal", "MaxFall");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "dashAttackTimer", "Data", "Motion", "DashAttackTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "gliderBoostTimer", "Data", "Motion", "GliderBoostTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "wasTired",
                "Data", "WasTired");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "highestAirY", "Data", "HighestAirY");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "dashStartedOnGround", "Data", "StartedOnGround");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "fastJump",
                "Data", "FastJump");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "lastClimbMove", "Data", "LastClimbMove");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "noWindTimer", "Data", "NoWindTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "climbHopSolid", "SourceClimbHopSolid");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "climbHopSolidPosition", "Data", "ClimbHopSolidPosition");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "playFootstepOnLand", "Data", "FootstepOnLandTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "minHoldTimer", "Data", "MinHoldTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "calledDashEvents", "Data", "CalledEvents");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "sweatSprite", "Sweat");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "launched",
                "Data", "Motion", "Launched");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "launchedTimer", "Data", "LaunchedTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "dashTrailTimer", "Data", "TrailTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "dashTrailCounter", "Data", "TrailCounter");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "canCurveDash", "Data", "CanCurve");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "lowFrictionStopTimer", "Data", "Motion", "LowFrictionStopTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "MuffleLanding", "Data", "MuffleLanding");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "gliderBoostDir", "Data", "Motion", "GliderBoostDirection");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "explodeLaunchBoostTimer", "Data", "ExplodeLaunchBoostTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "explodeLaunchBoostSpeed", "Data", "ExplodeLaunchBoostSpeed");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "demoDashed", "Data", "DemoDashed");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "wallBoosting", "Data", "WallBoosting");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "beforeDashSpeed", "Data", "BeforeDashSpeed");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "wasDashB",
                "Data", "WasDashB");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "dreamJump", "Data", "DreamJump");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "starFlyTimer", "Data", "StarFlyTimer");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "<StartedDashing>k__BackingField", "Data", "StartedDashing");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "<OnSafeGround>k__BackingField", "Data", "OnSafeGround");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "<Dead>k__BackingField", "<Dead>k__BackingField");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "JustRespawned", "<JustRespawned>k__BackingField");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "flash",
                "<Flash>k__BackingField");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "Sprite",
                "Sprite");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field, "Hair",
                "Hair");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "CameraAnchor", "CameraAnchor");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "CameraAnchorIgnoreX", "CameraAnchorIgnoreX");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "CameraAnchorIgnoreY", "CameraAnchorIgnoreY");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "CameraAnchorLerp", "CameraAnchorLerp");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "ForceCameraUpdate", "ForceCameraUpdate");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "DummyAutoAnimate", "Dummy", "AutoAnimate");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "DummyFriction", "Dummy", "Friction");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "IntroType", nameof(RoomPlayerSession.IntroType));
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "Leader",
                "Leader");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "DefaultSpriteMode", "DefaultSpriteMode");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Field,
                "ChaserStates", "ChaserStates");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Property,
                "Dead",
                "Dead");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Property,
                "CameraTarget", "CameraTarget");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Property,
                "CanRetry", "CanRetry");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Property,
                "Inventory", "Inventory");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Property,
                "OnSafeGround", "Data", "OnSafeGround");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Property,
                "DashAttacking", "DashAttacking");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Property,
                "StartedDashing", "Data", "StartedDashing");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Property,
                "Ducking", "Data", "Motion", "Ducking");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Property,
                "IsTired", "Data", "IsTired");
            Bind(catalog, assemblyIdentity, "Celeste.Player", typeof(RoomPlayerSession), SourceMemberKind.Property,
                "Holding", "Holding", "Holding");
        }

        private static void RegisterSourceTypes(SourceMemberCatalog catalog, string assemblyIdentity)
        {
            // The selected Original and Installed PE definitions both declare this
            // exact chain. RegisterSourceType validates those published definitions;
            // duplicate birth is an error, rather than an idempotent alternate path.
            catalog.RegisterSourceType(typeof(SourceSceneState), assemblyIdentity, "Monocle.Scene",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object");
            catalog.RegisterSourceType(typeof(FacingDirection), assemblyIdentity, "Celeste.Facings",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Enum");
            catalog.RegisterSourceType(typeof(SceneEntityState), assemblyIdentity, "Monocle.Entity",
                "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Object");
            catalog.RegisterSourceType(typeof(SourceActorEntityState), assemblyIdentity, "Celeste.Actor",
                assemblyIdentity, "Monocle.Entity");
            catalog.RegisterSourceType(typeof(RoomPlayerSession), assemblyIdentity, "Celeste.Player",
                assemblyIdentity, "Celeste.Actor");
            catalog.RegisterSourceType(typeof(SourcePlatformEntityState), assemblyIdentity, "Celeste.Platform",
                assemblyIdentity, "Monocle.Entity");
            catalog.RegisterSourceType(typeof(SourceSolidEntityState), assemblyIdentity, "Celeste.Solid",
                assemblyIdentity, "Celeste.Platform");
        }

        private static void Bind(SourceMemberCatalog catalog, string assemblyIdentity,
            string originalDeclaringType, Type scope, SourceMemberKind kind,
            string name, params string[] memberNames)
        {
            var definition = catalog.RequireDefinition(assemblyIdentity, originalDeclaringType, name, kind);
            var declaringType = catalog.GetActualSourceType(assemblyIdentity, originalDeclaringType)
                                ?? throw new TypeLoadException(originalDeclaringType);
            var path = new MemberInfo[memberNames.Length];
            var owner = scope;
            for (int index = 0; index < path.Length; index++)
            {
                var member = RequirePhysicalMember(owner, memberNames[index]);
                path[index] = member;
                owner = member is FieldInfo field ? field.FieldType : ((PropertyInfo)member).PropertyType;
            }

            catalog.RegisterBinding(new SourcePhysicalMemberBinding(definition, declaringType,
                path, actualInstanceScope: scope));
        }

        private static MemberInfo RequirePhysicalMember(Type type, string name)
        {
            const BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public
                                                                 | BindingFlags.NonPublic | BindingFlags.Instance;
            for (var current = type; current != null; current = current.BaseType)
            {
                var field = current.GetField(name, flags);
                if (field != null) return field;
                var property = current.GetProperty(name, flags);
                if (property != null) return property;
            }

            throw new MissingMemberException(type.FullName, name);
        }
    }
}
