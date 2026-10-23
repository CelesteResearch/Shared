using System;
using System.Reflection;
using Celeste.Core.Reflection.Members;
using Celeste.Everest.Content.Tiles.Autotiling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Diagnostics.Speedrun;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Game.Entities.Hazards.Spinners.Crystal;
using Celeste.Game.Entities.Platforms.Dream;
using Celeste.Game.Entities.ReflectionTentacles;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.LevelLoader.Terrain;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles;
using Celeste.Game.Gameplay.Environment.Debris;
using Celeste.Game.Gameplay.Environment.Ridge;
using Celeste.Game.Gameplay.Environment.Water;
using Celeste.Game.Gameplay.Hazards.Lightning;
using Celeste.Game.Presentation.Effects.Bloom;
using Celeste.Game.Presentation.Effects.Distortion;
using Celeste.Game.Presentation.Effects.Glitch;
using Celeste.Game.Presentation.Effects.Mirrors;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Presentation.Lighting;
using Celeste.Game.Presentation.Mountain.Particles;
using Celeste.Game.Presentation.Rendering;
using Celeste.Game.Stories.Interactions;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Content.Tiles.Autotiling;
using Celeste.Graphics.Effects.Liquids;
using Celeste.Scene.Following;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Audio.Emitters;
using Celeste.Simulation.Gameplay.Actors.Debris;
using Celeste.Simulation.Gameplay.Effects.Debris;
using Celeste.Simulation.Gameplay.Enemies.Seeker;
using Celeste.Simulation.Gameplay.Hazards.Lightning;
using Celeste.Simulation.Gameplay.Hazards.Spinners.Dust;
using Celeste.Simulation.Presentation.Backdrops.Rendering;
using Celeste.Simulation.Presentation.Decals.Entities;
using Celeste.Simulation.Presentation.Hud.Tutorials.Birds;
using Celeste.Simulation.Presentation.Particles;

namespace Celeste.Game.Runtime.Reflection.Members
{
    public static class SourceGamePhysicalTypeBindings
    {
        private const string GameAssembly = "Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        public static void Register(SceneEntityCatalog catalog, SourceMemberCatalog members, bool installed)
        {
            Qualify(catalog, members,
                typeof(ParticleSystemPresentation),
                "Monocle.ParticleSystem");
            Qualify(catalog, members,
                typeof(SeekerBarrierRendererState),
                "Celeste.SeekerBarrierRenderer");
            Qualify(catalog, members, typeof(SoundEmitterState),
                "Celeste.SoundEmitter");
            Qualify(catalog, members,
                typeof(DustGraphicState),
                "Celeste.DustGraphic");
            Qualify(catalog, members, typeof(EngineRuntime),
                "Monocle.Engine");
            Qualify(catalog, members, typeof(OriginalLevelSceneRoot),
                "Celeste.Level");
            Qualify(catalog, members,
                typeof(OriginalReflectionTentaclesState),
                "Celeste.ReflectionTentacles");
            Qualify(catalog, members,
                typeof(SourceDecalEntityState),
                "Celeste.Decal");
            Qualify(catalog, members,
                typeof(OriginalFloatingDebrisState),
                "Celeste.FloatingDebris");
            Qualify(catalog, members, typeof(AnimatedTiles),
                "Celeste.AnimatedTiles");
            Qualify(catalog, members,
                typeof(OriginalWaterState.Surface),
                "Celeste.Water+Surface");
            Qualify(catalog, members, typeof(LavaRectangleComponentState),
                "Celeste.LavaRect");
            Qualify(catalog, members,
                typeof(OriginalCliffsideWindFlagState),
                "Celeste.CliffsideWindFlag");
            Qualify(catalog, members,
                typeof(OriginalCrystalStaticSpinner),
                "Celeste.CrystalStaticSpinner");
            Qualify(catalog, members, typeof(HiresSnowState),
                "Celeste.HiresSnow");
            Qualify(catalog, members, typeof(Snow3DState),
                "Celeste.Snow3D");
            Qualify(catalog, members, typeof(OriginalAutoSplitterInfo),
                "Celeste.AutoSplitterInfo");
            Qualify(catalog, members,
                typeof(BirdTutorialGuiState),
                "Celeste.BirdTutorialGui");
            Qualify(catalog, members, typeof(OriginalSolidTiles),
                "Celeste.SolidTiles");
            Qualify(catalog, members, typeof(FollowerState), "Celeste.Follower");
            Qualify(catalog, members, typeof(GameplayRendererState),
                "Celeste.GameplayRenderer");
            Qualify(catalog, members, typeof(SeekerBarrierState),
                "Celeste.SeekerBarrier");
            Qualify(catalog, members, typeof(SceneUpdateScheduler),
                "Monocle.EntityList");
            Qualify(catalog, members, typeof(MirrorSurfacesState),
                "Celeste.MirrorSurfaces");
            Qualify(catalog, members,
                typeof(LightingRendererPresentation),
                "Celeste.LightingRenderer");
            Qualify(catalog, members,
                typeof(BloomRendererPresentation),
                "Celeste.BloomRenderer");
            Qualify(catalog, members, typeof(OriginalGlitchRender),
                "Celeste.Glitch");
            Qualify(catalog, members,
                typeof(OriginalDistortionRender),
                "Celeste.Distort");
            Qualify(catalog, members,
                typeof(DustEyeballsState),
                "Celeste.DustGraphic+Eyeballs");
            Qualify(catalog, members, typeof(EntityData),
                "Celeste.EntityData");
            Qualify(catalog, members, typeof(OriginalLevelRoomData),
                "Celeste.LevelData");
            Qualify(catalog, members, typeof(Autotiler),
                "Celeste.Autotiler");
            Qualify(catalog, members,
                typeof(BackdropRendererPresentation),
                "Celeste.BackdropRenderer");
            Qualify(catalog, members, typeof(OriginalGameGraphicsResources),
                "Celeste.GFX");
            Qualify(catalog, members,
                typeof(FinalBossBeamState),
                "Celeste.FinalBossBeam");
            Qualify(catalog, members, typeof(OriginalDreamBlockState),
                "Celeste.DreamBlock");
            Qualify(catalog, members, typeof(LightningStrikeState),
                "Celeste.LightningStrike");
            Qualify(catalog, members,
                typeof(LightningRendererState),
                "Celeste.LightningRenderer");
            Qualify(catalog, members, typeof(DebrisState),
                "Celeste.Debris");
            Qualify(catalog, members, typeof(CrystalDebrisState),
                "Celeste.CrystalDebris");
            Qualify(catalog, members, typeof(OriginalLevelEntityData),
                "Celeste.EntityData");
            Qualify(catalog, members,
                RequireNested(
                    typeof(OriginalCrystalStaticSpinner),
                    "Border"), "Celeste.CrystalStaticSpinner+Border");
            Qualify(catalog, members,
                typeof(LightningRendererState.Bolt),
                "Celeste.LightningRenderer+Bolt");
            Qualify(catalog, members,
                RequireNested(typeof(CS03MemoState), "MemoPage"),
                "Celeste.CS03_Memo+MemoPage");
            // Both split declaration bases keep their exact reverse TypeDef; forward uses the real map birth type.
            catalog.SelectLogicalActualType(
                typeof(OriginalDecalEntity), "Celeste.Decal");
            catalog.SelectLogicalActualType(
                typeof(OriginalLevelEntityData), "Celeste.EntityData");
            if (!installed)
                return;
            Qualify(catalog, members, typeof(EverestAutotiler),
                "Celeste.Autotiler");
            catalog.SelectLogicalActualType(
                typeof(EverestAutotiler),
                "Celeste.Autotiler");
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
        {
            return owner.GetNestedType(name, BindingFlags.Public | BindingFlags.NonPublic)
                   ?? throw new MissingMemberException(owner.FullName, name);
        }
    }
}
