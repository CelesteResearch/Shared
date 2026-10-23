using System;
using Celeste.Core.Display;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;

namespace Celeste.Everest.Modules.Capabilities
{
    public interface ISourceSpinnerPresentation
    {
        ISourceEngineContext EngineContext { get; }
        bool Rainbow { get; set; }
        PackedColor Tint { get; set; }
        void BuildGraphicsWithSource(string directory, Action<SceneEntityState> build);
        void RebuildGraphics(string directory);
    }
}
