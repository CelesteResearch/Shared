using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Rendering.States;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Engine;
using Celeste.Game.UI.Controls;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Text;

namespace Celeste.Everest.Runtime.Startup
{
    public partial class EverestAutoModUpdaterScene
    {
        public override void Render()
        {
            base.Render();
            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, SourceDepthStencilState.None,
                SourceRasterizerState.CullNone, null,
                ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.ScreenMatrix);
            Vector2 position = new Vector2(96f, 96f);
            if (!(cogwheel?.Texture?.TextureSafe?.IsDisposed ?? true))
            {
                Vector2 center = position + new Vector2(0f, 0f);
                float scale = .25f;
                float rotation = (cogwheelSpinning ? RawTimeActive : cogwheelStopTime) * 4f;
                for (int i = -2; i <= 2; i++)
                for (int j = -2; j <= 2; j++)
                    if (i != 0 || j != 0)
                        SourceAtlasDrawing.DrawCentered((ISourceDrawScope)EngineContext, cogwheel,
                            center + new Vector2(i, j), PackedColor.Black, scale, rotation);
                SourceAtlasDrawing.DrawCentered((ISourceDrawScope)EngineContext, cogwheel,
                    center, PackedColor.White, scale, rotation);
            }

            if (modUpdatingMessage != null) DrawText(modUpdatingMessage, position + new Vector2(48f, 0f), .8f);
            if (modUpdatingSubMessage != null) DrawText(modUpdatingSubMessage, position + new Vector2(53f, 40f), .5f);
            if (showCancel)
            {
                string label = ((IOriginalGameTextEnvironment)EngineContext).Text.CleanDialog("AUTOUPDATECHECKER_SKIP");
                OriginalButtonUi.Render(SourceRenderContext, this, EngineContext, new Vector2(1880f, 1024f), label,
                    ((IOriginalGameInputProcessEnvironment)EngineContext).InputSource.MenuCancel, .5f, 1f);
            }

            ((ISourceDrawScope)EngineContext).Draw.SpriteBatch.End();
        }

        private void DrawText(string text, Vector2 position, float scale)
        {
            ((ISourceActiveFontScope)EngineContext).ActiveFont.DrawOutline(SourceRenderContext, this, text,
                position + new Vector2(((ISourceActiveFontScope)EngineContext).ActiveFont.Measure(text).X * .5f * scale,
                    0f),
                new Vector2(.5f, .5f), Vector2.One * scale, PackedColor.White, 2f, PackedColor.Black);
        }
    }
}
