using Celeste.Core.Framework.Loading;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Runtime.Content.Loading
{
    public sealed partial class OriginalContentLoadingPresenter
    {
        private SourceRenderTarget2DResource blockedBackdrop;
        private bool blockedBackdropActive;

        // Called after the source frame has rendered, before its loading UI is composited.
        private void PrepareBackdropForSourceFrame()
        {
            if (game.PhysicalIO.LoadingWorkScheduler is ISourceContextualLoadingWorkScheduler
                {
                    SourceUpdatesBlocked: true,
                }) PrepareBlockedBackdrop();
            else blockedBackdropActive = false;
        }

        private void PrepareBlockedBackdrop()
        {
            if (blockedBackdropActive) return;
            blockedBackdropActive = true;
            DisposeBlockedBackdrop();
            game.GraphicsDevice.TryCaptureBackbuffer(out blockedBackdrop);
        }

        private bool RestoreBlockedBackdrop()
        {
            if (blockedBackdrop == null) return false;
            if (game.GraphicsDevice.TryRestoreBackbuffer(blockedBackdrop)) return true;
            // A resize invalidates this snapshot. Never recapture the current loading UI in this cycle.
            DisposeBlockedBackdrop();
            return false;
        }

        private void ReleaseBackdropIfHidden()
        {
            if (!blockedBackdropActive && !presentation.HasPresentation) DisposeBlockedBackdrop();
        }

        private void DisposeBlockedBackdrop()
        {
            var ownedBackdrop = blockedBackdrop;
            blockedBackdrop = null;
            ownedBackdrop?.Dispose();
        }
    }
}
