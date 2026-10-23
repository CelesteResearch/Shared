using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Rendering;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Simulation.Save.Progress;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Menus.Journal
{
    public class OuiJournalCoverPage : OuiJournalPage
    {
        public OuiJournalCoverPage(OuiJournalSequence journal)
            : base(journal)
        {
            PageTexture = "cover";
        }

        public override void Redraw(VirtualRenderTarget buffer)
        {
            base.Redraw(buffer);
            ((ISourceDrawScope)Context).Draw.SpriteBatch.Begin();
            string text = Text.Dialog.Clean("journal_of");
            if (text.Length > 0)
            {
                text += "\n";
            }

            text = ((Journal.Process.SaveContext.CurrentSave == null ||
                     !Text.CanDisplay(Text.Dialog.Language, Journal.Process.SaveContext.CurrentSave.Name))
                ? (text + Text.Dialog.Clean("FILE_DEFAULT"))
                : (text + Journal.Process.SaveContext.CurrentSave.Name));
            Text.ActiveFont.Draw(Context, Journal, text, new Vector2(805f, 400f), new Vector2(0.5f, 0.5f),
                Vector2.One * 2f,
                PackedColor.Black * 0.5f);
            ((ISourceDrawScope)Context).Draw.SpriteBatch.End();
        }
    }
}
