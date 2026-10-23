using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Mountain.Model;
using Celeste.Game.Presentation.Mountain.Rendering;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content.Atlas;

namespace Celeste.Game.Presentation.Mountain.Policies
{
    public interface IOriginalMountainPresentationEnvironment
    {
        IOriginalMountainPresentationPolicy MountainPresentationPolicy { get; }
    }
}
