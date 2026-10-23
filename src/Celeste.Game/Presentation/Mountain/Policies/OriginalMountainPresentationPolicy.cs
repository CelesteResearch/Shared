using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Presentation.Mountain.Model;
using Celeste.Game.Presentation.Mountain.Rendering;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Presentation.Mountain.Policies
{
    public sealed class OriginalMountainPresentationPolicy : IOriginalMountainPresentationPolicy
    {
        public static readonly OriginalMountainPresentationPolicy Instance = new();

        private OriginalMountainPresentationPolicy()
        {
        }

        public MountainModelState CreateModel(ISourceEngineContext engine)
        {
            return new(engine);
        }

        public void UpdateRenderer(MountainRendererState renderer, object scene)
        {
            renderer.UpdateOriginal(scene);
        }

        public List<AtlasEntry> GetMaddyRunFrames(MountainRendererState renderer)
        {
            return renderer.Area < 7
                ? ((IOriginalMountainEnvironment)renderer.EngineContext).MountainResources.Mountain.GetAtlasSubtextures(
                    "marker/runBackpack")
                : ((IOriginalMountainEnvironment)renderer.EngineContext).MountainResources.Mountain.GetAtlasSubtextures(
                    "marker/runNoBackpack");
        }
    }
}
