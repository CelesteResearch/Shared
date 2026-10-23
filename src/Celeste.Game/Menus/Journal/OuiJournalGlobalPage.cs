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
    public class OuiJournalGlobalPage : OuiJournalPage
    {
        private Table table;

        public OuiJournalGlobalPage(OuiJournalSequence journal)
            : base(journal)
        {
            PageTexture = "page";
            table = new Table().AddColumn(new TextCell(engine, "", new Vector2(1f, 0.5f), 1f, TextColor, 700f))
                .AddColumn(new TextCell(engine, Text.Dialog.Clean("STATS_TITLE"), new Vector2(0.5f, 0.5f), 1f,
                    TextColor,
                    48f, forceWidth: true))
                .AddColumn(new TextCell(engine, "", new Vector2(1f, 0.5f), 0.7f, TextColor, 700f));
            foreach (OriginalStatistic value in Enum.GetValues(typeof(OriginalStatistic)))
            {
                if (Journal.Process.SaveContext.CurrentSave.CheatMode ||
                    Journal.Process.SaveContext.CurrentSave.DebugMode ||
                    ((value != OriginalStatistic.GOLDBERRIES ||
                      Journal.Process.SaveContext.CurrentSave.TotalHeartGems >= 16) &&
                     ((value != OriginalStatistic.PICO_BERRIES && value != OriginalStatistic.PICO_COMPLETES &&
                       value != OriginalStatistic.PICO_DEATHS) ||
                      ((ISettingsContext)engine).Settings.Pico8OnMainMenu)))
                {
                    string text = Journal.Statistics.Global(value).ToString();
                    string text2 = Text.Dialog.Clean("STAT_" + value);
                    string text3 = "";
                    int num = text.Length - 1;
                    int num2 = 0;
                    while (num >= 0)
                    {
                        text3 = text[num] + ((num2 > 0 && num2 % 3 == 0) ? "," : "") + text3;
                        num--;
                        num2++;
                    }

                    Row row = table.AddRow();
                    row.Add(new TextCell(engine, text2, new Vector2(1f, 0.5f), 0.7f, TextColor));
                    row.Add(null);
                    row.Add(new TextCell(engine, text3, new Vector2(0f, 0.5f), 0.8f, TextColor));
                }
            }
        }

        public override void Redraw(VirtualRenderTarget buffer)
        {
            base.Redraw(buffer);
            ((ISourceDrawScope)Context).Draw.SpriteBatch.Begin();
            table.Render(Context, Journal, new Vector2(60f, 20f));
            ((ISourceDrawScope)Context).Draw.SpriteBatch.End();
        }
    }
}
