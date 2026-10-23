#nullable enable annotations
using System;
using Celeste.Game.Presentation.Environment;
using Celeste.Scene.Scenes;

namespace Celeste.Everest.Runtime.Startup
{
    public interface IEverestGameLoaderSourceHooksEnvironment
    {
        Action<EverestGameLoaderScene>? SourceLoaderBeginCompleted { get; }
        Func<EverestGameLoaderScene, HiresSnowState, SourceSceneState>? SourceLoaderNextSceneOverride { get; }
    }
}
