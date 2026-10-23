using Celeste.Core.Components.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Game.Presentation.Effects.SpeedRings;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public override void BeforeRender()
        {
            cameraPreShake = Camera.Position;
            Camera.Position += ShakeVector;
            Camera.Position = Vector2Geometry.Floor(Camera.Position);
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (BeforeRenderCallbackComponentState hook in SourceScene.Components.GetTrackedComponents(
                         "Celeste.BeforeRenderHook"))
                if (hook.Visible)
                    hook.Callback();
            OriginalSpeedRingState.DrawToBuffer(this);
            base.BeforeRender();
        }

        public override void AfterRender()
        {
            base.AfterRender();
            Camera.Position = cameraPreShake;
        }
    }
}
