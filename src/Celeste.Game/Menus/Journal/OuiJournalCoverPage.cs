using System.Numerics;
using Celeste.Core.Display;
using Celeste.Graphics.Content.VirtualAssets;
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
            var text = Text.Dialog.Clean("journal_of");
            if (text.Length > 0) text += "\n";

            text = Journal.Process.SaveContext.CurrentSave == null ||
                   !Text.CanDisplay(Text.Dialog.Language, Journal.Process.SaveContext.CurrentSave.Name)
                ? text + Text.Dialog.Clean("FILE_DEFAULT")
                : text + Journal.Process.SaveContext.CurrentSave.Name;
            Text.ActiveFont.Draw(Context, Journal, text, new(805f, 400f), new(0.5f, 0.5f),
                Vector2.One * 2f,
                PackedColor.Black * 0.5f);
            ((ISourceDrawScope)Context).Draw.SpriteBatch.End();
        }
    }
}
