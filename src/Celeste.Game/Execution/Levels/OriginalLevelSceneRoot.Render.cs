using Celeste.Core.Components.Rendering;
using Celeste.Core.Mathematics;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        public override void BeforeRender()
        {
            cameraPreShake = Camera.Position;
            Camera.Position += ShakeVector;
            Camera.Position = Vector2Geometry.Floor(Camera.Position);
            foreach (BeforeRenderCallbackComponentState hook in SourceScene.Components.GetTrackedComponents(
                         "Celeste.BeforeRenderHook"))
                if (hook.Visible)
                    hook.Callback();
            global::Celeste.Game.Presentation.Effects.SpeedRings.OriginalSpeedRingState.DrawToBuffer(this);
            base.BeforeRender();
        }

        public override void AfterRender()
        {
            base.AfterRender();
            Camera.Position = cameraPreShake;
        }
    }
}
