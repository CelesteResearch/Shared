using System;

namespace Celeste.Core.Components
{
    public interface ISourceEntityRemoved
    {
        void Removed(object actualScene, Action baseRemoved);
    }
}
