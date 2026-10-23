using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering.States;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Content.Dialogs;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Gui;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Presentation.Hud.Speedrun;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Game.Chapters.Flow
{
    public partial class OriginalAreaCompleteInfoState
    {
        protected readonly ISourceEngineContext engine;
        protected OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;
        protected IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        public OriginalAreaCompleteInfoState(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public virtual void InitializePie(ChapterCompletionSession session)
        {
        }

        public virtual void DisposePie()
        {
        }

        public virtual void VersionNumberAndVariants(ISourceRenderContext context, object owner, string version,
            float ease,
            float alpha)
            => DrawOriginal(context, owner, version, ease, alpha, 0f);

        protected void DrawOriginal(ISourceRenderContext context, object owner, string version, float ease, float alpha,
            float offset)
        {
            Vector2 at =
                new Vector2(1820f + 300f * (1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(ease)),
                    offset == 0f ? 1020f : 1020f + offset);
            if (Process.SaveContext.CurrentSave.AssistMode || Process.SaveContext.CurrentSave.VariantMode)
            {
                var texture =
                    ((ISourceGuiAtlasResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiAtlas[
                        Process.SaveContext.CurrentSave.AssistMode ? "cs_assistmode" : "cs_variantmode"];
                at.Y -= 32f;
                SourceAtlasDrawing.DrawJustified(context, owner, texture, at + new Vector2(0f, -8f),
                    new Vector2(.5f, 1f),
                    PackedColor.White, .6f);
                Text.ActiveFont.DrawOutline(context, owner, version, at, new Vector2(.5f, 0f), Vector2.One * .5f,
                    PackedColor.White, 2f, PackedColor.Black);
            }
            else
                Text.ActiveFont.DrawOutline(context, owner, version, at, new Vector2(.5f, .5f), Vector2.One * .5f,
                    PackedColor.White, 2f, PackedColor.Black);
        }
    }
}
