using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Scene.Tracking;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Runtime.Reflection.Members
{
    public static class SourceGamePhysicalTypeBindings
    {
        private const string GameAssembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        public static void Register(SceneEntityCatalog catalog, SourceMemberCatalog members, bool installed)
        {
            Qualify(catalog, members,
                typeof(global::Celeste.Simulation.Presentation.Particles.ParticleSystemPresentation),
                "Monocle.ParticleSystem");
            Qualify(catalog, members,
                typeof(global::Celeste.Simulation.Gameplay.Enemies.Seeker.SeekerBarrierRendererState),
                "Celeste.SeekerBarrierRenderer");
            Qualify(catalog, members, typeof(global::Celeste.Simulation.Audio.Emitters.SoundEmitterState),
                "Celeste.SoundEmitter");
            Qualify(catalog, members,
                typeof(global::Celeste.Simulation.Gameplay.Hazards.Spinners.Dust.DustGraphicState),
                "Celeste.DustGraphic");
            Qualify(catalog, members, typeof(global::Celeste.Game.Execution.EngineRuntime),
                "Monocle.Engine");
            Qualify(catalog, members, typeof(global::Celeste.Game.Execution.Levels.OriginalLevelSceneRoot),
                "Celeste.Level");
            Qualify(catalog, members,
                typeof(global::Celeste.Game.Entities.ReflectionTentacles.OriginalReflectionTentaclesState),
                "Celeste.ReflectionTentacles");
            Qualify(catalog, members,
                typeof(global::Celeste.Simulation.Presentation.Decals.Entities.SourceDecalEntityState),
                "Celeste.Decal");
            Qualify(catalog, members,
                typeof(global::Celeste.Game.Gameplay.Environment.Debris.OriginalFloatingDebrisState),
                "Celeste.FloatingDebris");
            Qualify(catalog, members, typeof(global::Celeste.Graphics.Content.Tiles.AnimatedTiles),
                "Celeste.AnimatedTiles");
            Qualify(catalog, members,
                typeof(global::Celeste.Game.Gameplay.Environment.Water.OriginalWaterState.Surface),
                "Celeste.Water+Surface");
            Qualify(catalog, members, typeof(global::Celeste.Graphics.Effects.Liquids.LavaRectangleComponentState),
                "Celeste.LavaRect");
            Qualify(catalog, members,
                typeof(global::Celeste.Game.Gameplay.Environment.Ridge.OriginalCliffsideWindFlagState),
                "Celeste.CliffsideWindFlag");
            Qualify(catalog, members,
                typeof(global::Celeste.Game.Entities.Hazards.Spinners.Crystal.OriginalCrystalStaticSpinner),
                "Celeste.CrystalStaticSpinner");
            Qualify(catalog, members, typeof(global::Celeste.Game.Presentation.Environment.HiresSnowState),
                "Celeste.HiresSnow");
            Qualify(catalog, members, typeof(global::Celeste.Game.Presentation.Mountain.Particles.Snow3DState),
                "Celeste.Snow3D");
            Qualify(catalog, members, typeof(global::Celeste.Game.Diagnostics.Speedrun.OriginalAutoSplitterInfo),
                "Celeste.AutoSplitterInfo");
            Qualify(catalog, members,
                typeof(global::Celeste.Simulation.Presentation.Hud.Tutorials.Birds.BirdTutorialGuiState),
                "Celeste.BirdTutorialGui");
            Qualify(catalog, members, typeof(global::Celeste.Game.Execution.LevelLoader.Terrain.OriginalSolidTiles),
                "Celeste.SolidTiles");
            Qualify(catalog, members, typeof(global::Celeste.Scene.Following.FollowerState), "Celeste.Follower");
            Qualify(catalog, members, typeof(global::Celeste.Game.Presentation.Rendering.GameplayRendererState),
                "Celeste.GameplayRenderer");
            Qualify(catalog, members, typeof(global::Celeste.Simulation.Gameplay.Enemies.Seeker.SeekerBarrierState),
                "Celeste.SeekerBarrier");
            Qualify(catalog, members, typeof(global::Celeste.Scene.Scheduling.SceneUpdateScheduler),
                "Monocle.EntityList");
            Qualify(catalog, members, typeof(global::Celeste.Game.Presentation.Effects.Mirrors.MirrorSurfacesState),
                "Celeste.MirrorSurfaces");
            Qualify(catalog, members,
                typeof(global::Celeste.Game.Presentation.Lighting.LightingRendererPresentation),
                "Celeste.LightingRenderer");
            Qualify(catalog, members,
                typeof(global::Celeste.Game.Presentation.Effects.Bloom.BloomRendererPresentation),
                "Celeste.BloomRenderer");
            Qualify(catalog, members, typeof(global::Celeste.Game.Presentation.Effects.Glitch.OriginalGlitchRender),
                "Celeste.Glitch");
            Qualify(catalog, members,
                typeof(global::Celeste.Game.Presentation.Effects.Distortion.OriginalDistortionRender),
                "Celeste.Distort");
            Qualify(catalog, members,
                typeof(global::Celeste.Simulation.Gameplay.Hazards.Spinners.Dust.DustEyeballsState),
                "Celeste.DustGraphic+Eyeballs");
            Qualify(catalog, members, typeof(global::Celeste.Formats.Map.Entities.Structure.EntityData),
                "Celeste.EntityData");
            Qualify(catalog, members, typeof(global::Celeste.Game.Content.Maps.Levels.OriginalLevelRoomData),
                "Celeste.LevelData");
            Qualify(catalog, members, typeof(global::Celeste.Graphics.Content.Tiles.Autotiling.Autotiler),
                "Celeste.Autotiler");
            Qualify(catalog, members,
                typeof(global::Celeste.Simulation.Presentation.Backdrops.Rendering.BackdropRendererPresentation),
                "Celeste.BackdropRenderer");
            Qualify(catalog, members, typeof(global::Celeste.Game.Execution.Graphics.OriginalGameGraphicsResources),
                "Celeste.GFX");
            Qualify(catalog, members,
                typeof(global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles.FinalBossBeamState),
                "Celeste.FinalBossBeam");
            Qualify(catalog, members, typeof(global::Celeste.Game.Entities.Platforms.Dream.OriginalDreamBlockState),
                "Celeste.DreamBlock");
            Qualify(catalog, members, typeof(global::Celeste.Game.Gameplay.Hazards.Lightning.LightningStrikeState),
                "Celeste.LightningStrike");
            Qualify(catalog, members,
                typeof(global::Celeste.Simulation.Gameplay.Hazards.Lightning.LightningRendererState),
                "Celeste.LightningRenderer");
            Qualify(catalog, members, typeof(global::Celeste.Simulation.Gameplay.Actors.Debris.DebrisState),
                "Celeste.Debris");
            Qualify(catalog, members, typeof(global::Celeste.Simulation.Gameplay.Effects.Debris.CrystalDebrisState),
                "Celeste.CrystalDebris");
            Qualify(catalog, members, typeof(global::Celeste.Game.Content.Maps.Entities.OriginalLevelEntityData),
                "Celeste.EntityData");
            Qualify(catalog, members,
                RequireNested(
                    typeof(global::Celeste.Game.Entities.Hazards.Spinners.Crystal.OriginalCrystalStaticSpinner),
                    "Border"), "Celeste.CrystalStaticSpinner+Border");
            Qualify(catalog, members,
                typeof(global::Celeste.Simulation.Gameplay.Hazards.Lightning.LightningRendererState.Bolt),
                "Celeste.LightningRenderer+Bolt");
            Qualify(catalog, members,
                RequireNested(typeof(global::Celeste.Game.Stories.Interactions.CS03MemoState), "MemoPage"),
                "Celeste.CS03_Memo+MemoPage");
            // Both split declaration bases keep their exact reverse TypeDef; forward uses the real map birth type.
            catalog.SelectLogicalActualType(
                typeof(global::Celeste.Game.Entities.Decoration.Decals.OriginalDecalEntity), "Celeste.Decal");
            catalog.SelectLogicalActualType(
                typeof(global::Celeste.Game.Content.Maps.Entities.OriginalLevelEntityData), "Celeste.EntityData");
            if (installed)
            {
                Qualify(catalog, members, typeof(global::Celeste.Everest.Content.Tiles.Autotiling.EverestAutotiler),
                    "Celeste.Autotiler");
                catalog.SelectLogicalActualType(
                    typeof(global::Celeste.Everest.Content.Tiles.Autotiling.EverestAutotiler),
                    "Celeste.Autotiler");
            }
        }

        private static void Qualify(SceneEntityCatalog catalog, SourceMemberCatalog members, Type actualType,
            string identity)
        {
            var source = members.GetOriginalTypeDefinition(GameAssembly, identity);
            var logical = catalog.FindLogicalMetadata(identity)
                          ?? throw new InvalidOperationException(
                              "The original physical declaration TypeDef is not published: " + identity);
            if (logical.LogicalAssemblyIdentity != source.AssemblyIdentity ||
                logical.LogicalMetadataToken != source.MetadataToken)
                throw new InvalidOperationException(
                    "The physical declaration has different canonical original TypeDef facts.");
            catalog.RegisterRuntimeType(actualType, logical.RegistryKey);
        }

        private static Type RequireNested(Type owner, string name)
            => owner.GetNestedType(name, BindingFlags.Public | BindingFlags.NonPublic)
               ?? throw new MissingMemberException(owner.FullName, name);
    }
}
