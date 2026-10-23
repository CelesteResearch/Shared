using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Game.Menus.Journal
{
    public class OuiJournalProgressPage : OuiJournalPage
    {
        private readonly Table table;

        public OuiJournalProgressPage(OuiJournalSequence journal)
            : base(journal)
        {
            PageTexture = "page";
            table = new Table()
                .AddColumn(new TextCell(engine, Text.Dialog.Clean("journal_progress"), new(0f, 0.5f), 1f,
                    PackedColor.Black * 0.7f)).AddColumn(new EmptyCell(engine, 20f))
                .AddColumn(new EmptyCell(engine, 64f))
                .AddColumn(new EmptyCell(engine, 64f))
                .AddColumn(new EmptyCell(engine, 100f))
                .AddColumn(new IconCell(engine, "strawberry", 150f))
                .AddColumn(new IconCell(engine, "skullblue", 100f));
            if (((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                    .SaveContext
                    .CurrentSave) >= 2)
                table.AddColumn(new IconCell(engine, "skullred", 100f));

            if (((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                    .SaveContext
                    .CurrentSave) >= 3)
                table.AddColumn(new IconCell(engine, "skullgold", 100f));

            table.AddColumn(new IconCell(engine, "time", 220f));
            foreach (var area in ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(
                         Journal.Process.SaveContext.CurrentSave))
            {
                var areaData =
                    ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(
                        ((IOriginalAreaStatsEnvironment)engine).AreaStats.GetAreaStatsId(area));
                if (Journal.GetAreaInterlude(areaData)) continue;

                if (areaData.ID >
                    ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedAreasSafe(Journal.Process
                        .SaveContext.CurrentSave))
                    break;

                string text = null;
                if (areaData.Mode[0].TotalStrawberries > 0 || area.TotalStrawberries > 0)
                {
                    text = area.TotalStrawberries.ToString();
                    if (area.Modes[0].Completed) text = text + "/" + areaData.Mode[0].TotalStrawberries;
                }
                else
                {
                    text = "-";
                }

                var list = new List<string>();
                for (var i = 0; i < area.Modes.Length; i++)
                    if (area.Modes[i].HeartGem)
                        list.Add("heartgem" + i);

                if (list.Count <= 0) list.Add("dot");

                IconsCell iconsCell;
                var row = table.AddRow()
                    .Add(new TextCell(engine, Text.Dialog.Clean(areaData.Name), new(1f, 0.5f), 0.6f, TextColor))
                    .Add(null)
                    .Add(iconsCell = new(engine, CompletionIcon(area)));
                if (areaData.CanFullClear)
                {
                    row.Add(new IconsCell(engine, area.Cassette ? "cassette" : "dot"));
                    row.Add(new IconsCell(engine, -32f, [.. list]));
                }
                else
                {
                    iconsCell.SpreadOverColumns = 3;
                    row.Add(null).Add(null);
                }

                row.Add(new TextCell(engine, text, TextJustify, 0.5f, TextColor));
                if (Journal.GetAreaIsFinal(areaData))
                {
                    row.Add(new TextCell(engine, Text.Deaths(area.Modes[0].Deaths), TextJustify, 0.5f, TextColor)
                    {
                        SpreadOverColumns =
                            ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal
                                .Process
                                .SaveContext.CurrentSave),
                    });
                    for (var j = 0;
                         j < ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal
                             .Process
                             .SaveContext.CurrentSave) - 1;
                         j++)
                        row.Add(null);
                }
                else
                {
                    for (var k = 0;
                         k < ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal
                             .Process
                             .SaveContext.CurrentSave);
                         k++)
                        if (areaData.HasMode((int)(OriginalAreaMode)k))
                            row.Add(new TextCell(engine, Text.Deaths(area.Modes[k].Deaths), TextJustify, 0.5f,
                                TextColor));
                        else
                            row.Add(new TextCell(engine, "-", TextJustify, 0.5f, TextColor));
                }

                if (area.TotalTimePlayed > 0)
                    row.Add(new TextCell(engine, Text.Time(area.TotalTimePlayed), TextJustify, 0.5f, TextColor));
                else
                    row.Add(new IconCell(engine, "dot"));
            }

            if (table.Rows > 1)
            {
                table.AddRow();
                var row2 = table.AddRow()
                    .Add(new TextCell(engine, Text.Dialog.Clean("journal_totals"), new(1f, 0.5f), 0.7f,
                        TextColor))
                    .Add(null)
                    .Add(null)
                    .Add(null)
                    .Add(null)
                    .Add(new TextCell(engine,
                        ((IOriginalSaveCollectibleTotalsEnvironment)engine).SaveCollectibleTotals
                        .GetTotalStrawberriesSafe(Journal.Process.SaveContext.CurrentSave).ToString(), TextJustify,
                        0.6f,
                        TextColor));
                row2.Add(new TextCell(engine, Text.Deaths(Journal.Process.SaveContext.CurrentSave.TotalDeaths),
                    TextJustify,
                    0.6f, TextColor)
                {
                    SpreadOverColumns =
                        ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                            .SaveContext.CurrentSave),
                });
                for (var l = 1;
                     l < ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                         .SaveContext.CurrentSave);
                     l++)
                    row2.Add(null);

                row2.Add(new TextCell(engine, Text.Time(Journal.Process.SaveContext.CurrentSave.Time), TextJustify,
                    0.6f,
                    TextColor));
                table.AddRow();
            }
        }

        private string CompletionIcon(ChapterAreaProgress data)
        {
            if (!((IOriginalAreaKeyEnvironment)engine).AreaKeys
                    .GetAreaById(((IOriginalAreaStatsEnvironment)engine).AreaStats.GetAreaStatsId(data)).CanFullClear &&
                data.Modes[0].Completed)
                return "beat";

            if (data.Modes[0].FullClear) return "fullclear";

            return data.Modes[0].Completed ? "clear" : "dot";
        }

        public override void Redraw(VirtualRenderTarget buffer)
        {
            base.Redraw(buffer);
            ((ISourceDrawScope)Context).Draw.SpriteBatch.Begin();
            table.Render(Context, Journal, new(60f, 20f));
            ((ISourceDrawScope)Context).Draw.SpriteBatch.End();
        }

        private void DrawIcon(Vector2 pos, bool obtained, string icon)
        {
            if (obtained)
                SourceAtlasDrawing.DrawCentered(Context, Journal, MountainResources.Journal[icon], pos,
                    PackedColor.White);
            else
                SourceAtlasDrawing.DrawCentered(Context, Journal, MountainResources.Journal["dot"], pos,
                    PackedColor.White);
        }
    }
}
