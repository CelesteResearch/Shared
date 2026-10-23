using System;

namespace Celeste.Core.Components
{
    public interface ISourceEntitySceneEnd
    {
        void SceneEnd(object actualScene, Action baseSceneEnd);
    }
}
