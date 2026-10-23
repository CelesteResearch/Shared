using System;

namespace Celeste.Scene.Lifecycle
{
    public interface ILevelEndingCallback
    {
        Action OnEnd { get; }
    }
}
