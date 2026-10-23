using System;
using Celeste.Core.Framework.Timing;
using Celeste.Core.IO.Content;
using Celeste.Game.Content.Loading;
using Celeste.Game.Execution;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Runtime.Content.Loading
{
    public sealed partial class OriginalContentLoadingPresenter : IDisposable
    {
        private readonly GameApplication game;
        private readonly ContentLoadingPresentation presentation;
        private readonly Action overlay;
        private bool disposed;

        public OriginalContentLoadingPresenter(GameApplication game)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            presentation = new ContentLoadingPresentation(game.Draw, game.Text, game.CurrentContext,
                () => game.OverworldGraphics.Loaded ? game.OverworldGraphics.Atlas : null);
            if (game.EngineDraw.ContentLoadingOverlay != null)
                throw new InvalidOperationException("The content loading overlay already has an owner.");
            overlay = RenderOverlay;
            game.EngineDraw.ContentLoadingOverlay = overlay;
        }

        public void SetProgress(ContentLoadProgress content, ContentLoadProgress audio)
        {
            if (disposed) throw new ObjectDisposedException(nameof(OriginalContentLoadingPresenter));
            presentation.SetProgress(content, audio);
        }

        public void PresentBlocked()
        {
            if (disposed) throw new ObjectDisposedException(nameof(OriginalContentLoadingPresenter));
            if (!game.ActualGame.SourceHostRunOpen || game.FrameOpen)
                throw new InvalidOperationException(
                    "Present loading UI only between source frames in an open host run.");
            PrepareBlockedBackdrop();
            ContentLoadingPresentation.PresentWithoutUpdate((ISourceGameTickFrame)game.ActualGame, RenderBlocked);
        }

        private void SetBackbuffer()
        {
            game.GraphicsDevice.SetRenderTarget((SourceRenderTarget2DResource)null);
            game.GraphicsDevice.Viewport = EngineRuntime.Viewport;
        }

        private void RenderOverlay()
        {
            PrepareBackdropForSourceFrame();
            if (!presentation.PreparePresentation(false))
            {
                ReleaseBackdropIfHidden();
                return;
            }

            SetBackbuffer();
            presentation.Render(false);
        }

        private void RenderBlocked()
        {
            SetBackbuffer();
            if (!RestoreBlockedBackdrop())
                game.GraphicsDevice.Clear(global::Celeste.Core.Display.PackedColor.Black);
            presentation.PreparePresentation(true);
            presentation.Render(true);
        }

        public void Dispose()
        {
            if (disposed) return;
            disposed = true;
            try
            {
                game.EngineDraw.ContentLoadingOverlay -= overlay;
            }
            finally
            {
                DisposeBlockedBackdrop();
            }
        }
    }
}
