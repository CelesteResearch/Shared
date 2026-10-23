using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Nodes;
using Celeste.Scene.Entities;

namespace Celeste.Game.Stories.Prologue.Ending
{
    public class PrologueEndingTextPresentation : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly RichTextLayout text;

        public PrologueEndingTextPresentation(ISourceEngineContext engine, bool instant)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            var process = (IOriginalFancyTextProcess)engine;
            text = OriginalFancyTextParser.Parse(((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("CH0_END"),
                960,
                4, 0f, context: OriginalFancyTextContext.Create(process));
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine(instant)));
        }

        private IEnumerator Routine(bool instant)
        {
            if (!instant) yield return 4f;

            for (var i = 0; i < text.Count; i++)
                if (text[i] is RichTextGlyph c)
                {
                    while ((c.Fade += engine.Frame.DeltaTime * 20f) < 1f) yield return null;

                    c.Fade = 1f;
                }
        }

        public override void Render(ISourceRenderContext context)
        {
            text.Draw(context, this, (ISourceRichTextDrawProcess)engine, Position, new(0.5f, 0.5f), Vector2.One,
                1f);
        }
    }
}
