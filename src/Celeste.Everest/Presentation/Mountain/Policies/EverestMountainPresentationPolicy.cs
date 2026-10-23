using System.Collections.Generic;
using System.IO;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Maps.Registry;
using Celeste.Everest.Presentation.Mountain.Model;
using Celeste.Everest.UI.Settings;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Mountain.Model;
using Celeste.Game.Presentation.Mountain.Policies;
using Celeste.Game.Presentation.Mountain.Rendering;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Everest.Presentation.Mountain.Policies
{
    public sealed class EverestMountainPresentationPolicy : IOriginalMountainPresentationPolicy
    {
        public static readonly EverestMountainPresentationPolicy Instance = new();

        private EverestMountainPresentationPolicy()
        {
        }

        public MountainModelState CreateModel(ISourceEngineContext engine) => new EverestMountainModelState(engine);

        public void UpdateRenderer(MountainRendererState renderer, object scene)
        {
            EverestArea area = (-1 < renderer.Area && renderer.Area <
                (((IOriginalSessionConstructionProcess)renderer.EngineContext).AreaTable.Areas?.Count ?? 0))
                ? (EverestArea)((IOriginalSessionConstructionProcess)renderer.EngineContext).AreaTable.Areas[
                    renderer.Area]
                : null;
            var metadata = area?.Metadata;
            bool wasFree = renderer.InFreeCameraDebugMode;
            if (metadata?.Mountain?.ShowCore == true)
            {
                renderer.Area = 9;
                // Required shared source body with live installed camera bindings.
                renderer.UpdateInstalledOriginal(scene);
                renderer.Area = area.ID;
            }
            else
                renderer.UpdateInstalledOriginal(scene);

            OverworldSequence overworld = scene as OverworldSequence;
            if (!wasFree && renderer.InFreeCameraDebugMode &&
                ((overworld.Current ?? overworld.Next) is EverestFileNamingState { UseKeyboardInput: not false } ||
                 (overworld.Current ?? overworld.Next) is EverestModOptionStringState { UseKeyboardInput: not false }))
                renderer.SetFreeCam(false);
        }

        public List<AtlasEntry> GetMaddyRunFrames(MountainRendererState renderer)
        {
            var engine = renderer.EngineContext;
            if (renderer.Area < 0 ||
                ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[renderer.Area].LevelSet == "Celeste")
                return OriginalMountainPresentationPolicy.Instance.GetMaddyRunFrames(renderer);
            string markerTexture = GetMarkerTexture(renderer);
            if (markerTexture != null)
                return ((IOriginalMountainEnvironment)engine).MountainResources.Mountain.GetAtlasSubtextures(
                    markerTexture);
            if (((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[renderer.Area].GetOriginalMode(0)
                .Inventory
                .Dashes > 1)
                return ((IOriginalMountainEnvironment)engine).MountainResources.Mountain.GetAtlasSubtextures(
                    "marker/runNoBackpack");
            return ((IOriginalMountainEnvironment)engine).MountainResources.Mountain.GetAtlasSubtextures(
                "marker/runBackpack");
        }

        private string GetMarkerTexture(MountainRendererState renderer)
        {
            var engine = renderer.EngineContext;
            if (!((IEverestMountainContentEnvironment)engine).Content.TryGet(Path.Combine("Maps",
                        ((IOriginalSessionConstructionProcess)engine).AreaTable.Areas[renderer.Area].SID ?? ""),
                    out var metadata))
                return null;
            return metadata.GetMeta<EverestMapMetadata>()?.Mountain?.MarkerTexture;
        }
    }
}
