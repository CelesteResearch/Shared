using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Mountain.Model;
using Celeste.Game.Presentation.Mountain.Rendering;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Presentation.Mountain.Policies
{
    public interface IOriginalMountainPresentationPolicy
    {
        MountainModelState CreateModel(ISourceEngineContext engine);
        void UpdateRenderer(MountainRendererState renderer, object scene);
        List<AtlasEntry> GetMaddyRunFrames(MountainRendererState renderer);
    }
}
