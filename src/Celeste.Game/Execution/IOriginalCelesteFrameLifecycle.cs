using System;
using Celeste.Core.Framework.Components;
using Celeste.Game.Execution.Engine.Update;
using Celeste.Game.Execution.Engine.Rendering;
using global::Celeste.Game.Execution.Startup;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution
{
    public interface IOriginalCelesteFrameLifecycle
    {
        void BeginSourceFrame();
        void CompleteSourceFrame();
        void AbortSourceFrame();
    }
}
