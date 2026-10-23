using System;
using Celeste.Core.Components.Rendering;

namespace Celeste.Scene.Components.Rendering
{
    public static class BeforeRenderCallbackDispatch
    {
        public static void Invoke(SceneComponentTracker components, string trackedType)
        {
            if (components == null) throw new ArgumentNullException(nameof(components));
            // Read the live component Tracker order, including actual hooks of hidden entities.
            // The type key is supplied by the caller's rendering policy.
            foreach (BeforeRenderCallbackComponentState hook in components.GetTrackedComponents(trackedType))
            {
                if (hook.Visible)
                    hook.Callback();
            }
        }
    }
}
