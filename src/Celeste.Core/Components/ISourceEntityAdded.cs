using System;

namespace Celeste.Core.Components
{
    public interface ISourceEntityAdded
    {
        void Added(object actualScene, Action baseAdded);
    }
}
