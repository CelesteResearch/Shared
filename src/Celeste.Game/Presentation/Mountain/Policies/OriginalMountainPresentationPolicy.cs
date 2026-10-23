using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Mountain.Model;
using Celeste.Game.Presentation.Mountain.Rendering;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Presentation.Mountain.Policies
{
    public sealed class OriginalMountainPresentationPolicy : IOriginalMountainPresentationPolicy
    {
        public static readonly OriginalMountainPresentationPolicy Instance = new();

        private OriginalMountainPresentationPolicy()
        {
        }

        public MountainModelState CreateModel(ISourceEngineContext engine) => new MountainModelState(engine);
        public void UpdateRenderer(MountainRendererState renderer, object scene) => renderer.UpdateOriginal(scene);

        public List<AtlasEntry> GetMaddyRunFrames(MountainRendererState renderer)
        {
            if (renderer.Area < 7)
                return ((IOriginalMountainEnvironment)renderer.EngineContext).MountainResources.Mountain
                    .GetAtlasSubtextures("marker/runBackpack");
            return ((IOriginalMountainEnvironment)renderer.EngineContext).MountainResources.Mountain
                .GetAtlasSubtextures(
                    "marker/runNoBackpack");
        }
    }
}
