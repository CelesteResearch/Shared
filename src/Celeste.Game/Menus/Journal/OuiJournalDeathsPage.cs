using Celeste.Core.Maps;
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
    public class OuiJournalDeathsPage : OuiJournalPage
    {
        private Table table;

        public OuiJournalDeathsPage(OuiJournalSequence journal)
            : base(journal)
        {
            PageTexture = "page";
            table = new Table().AddColumn(new TextCell(engine, Text.Dialog.Clean("journal_deaths"),
                new Vector2(1f, 0.5f),
                0.7f, TextColor, 300f));
            for (int i = 0;
                 i < ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                     .SaveContext.CurrentSave);
                 i++)
            {
                table.AddColumn(new TextCell(engine, Text.Dialog.Clean("journal_mode_" + (OriginalAreaMode)i),
                    TextJustify,
                    0.6f, TextColor, 240f));
            }

            bool[] array = new bool[3]
            {
                true,
                ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                    .SaveContext
                    .CurrentSave) >= 2,
                ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                    .SaveContext
                    .CurrentSave) >= 3
            };
            int[] array2 = new int[3];
            foreach (ChapterAreaProgress area in ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(
                         Journal.Process.SaveContext.CurrentSave))
            {
                IOriginalAreaData areaData =
                    ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(
                        ((IOriginalAreaStatsEnvironment)engine).AreaStats.GetAreaStatsId(area));
                if (Journal.GetAreaInterlude(areaData) || Journal.GetAreaIsFinal(areaData))
                {
                    continue;
                }

                if (areaData.ID >
                    ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedAreasSafe(Journal.Process
                        .SaveContext.CurrentSave))
                {
                    bool flag;
                    array[1] = (flag = (array[2] = false));
                    array[0] = flag;
                    break;
                }

                Row row = table.AddRow();
                row.Add(new TextCell(engine, Text.Dialog.Clean(areaData.Name), new Vector2(1f, 0.5f), 0.6f, TextColor));
                for (int j = 0;
                     j < ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                         .SaveContext.CurrentSave);
                     j++)
                {
                    if (areaData.HasMode((int)(OriginalAreaMode)j))
                    {
                        if (area.Modes[j].SingleRunCompleted)
                        {
                            int num = area.Modes[j].BestDeaths;
                            if (num > 0)
                            {
                                foreach (OriginalLevelEntityData goldenberry in
                                         ((IOriginalSessionConstructionProcess)engine).AreaTable
                                         .Areas[((IOriginalAreaStatsEnvironment)engine).AreaStats.GetAreaStatsId(area)]
                                         .Mode[j].MapData.Goldenberries)
                                {
                                    MapEntityId item = new MapEntityId(goldenberry.Level.Name, goldenberry.ID);
                                    if (area.Modes[j].Strawberries.Contains(item))
                                    {
                                        num = 0;
                                    }
                                }
                            }

                            row.Add(new TextCell(engine, Text.Deaths(num), TextJustify, 0.5f, TextColor));
                            array2[j] += num;
                        }
                        else
                        {
                            row.Add(new IconCell(engine, "dot"));
                            array[j] = false;
                        }
                    }
                    else
                    {
                        row.Add(new TextCell(engine, "-", TextJustify, 0.5f, TextColor));
                    }
                }
            }

            if (array[0] || array[1] || array[2])
            {
                table.AddRow();
                Row row2 = table.AddRow();
                row2.Add(new TextCell(engine, Text.Dialog.Clean("journal_totals"), new Vector2(1f, 0.5f), 0.7f,
                    TextColor));
                for (int k = 0;
                     k < ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                         .SaveContext.CurrentSave);
                     k++)
                {
                    row2.Add(new TextCell(engine, Text.Deaths(array2[k]), TextJustify, 0.6f, TextColor));
                }

                table.AddRow();
            }

            int num2 = 0;
            foreach (ChapterAreaProgress area2 in ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(
                         Journal.Process.SaveContext.CurrentSave))
            {
                IOriginalAreaData areaData2 = ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(area2.ID);
                if (!Journal.GetAreaIsFinal(areaData2))
                {
                    continue;
                }

                if (areaData2.ID >
                    ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedAreasSafe(Journal.Process
                        .SaveContext.CurrentSave))
                {
                    break;
                }

                Row row3 = table.AddRow();
                row3.Add(
                    new TextCell(engine, Text.Dialog.Clean(areaData2.Name), new Vector2(1f, 0.5f), 0.6f, TextColor));
                if (area2.Modes[0].SingleRunCompleted)
                {
                    int num3 = area2.Modes[0].BestDeaths;
                    if (num3 > 0)
                    {
                        foreach (OriginalLevelEntityData goldenberry2 in ((IOriginalSessionConstructionProcess)engine)
                                 .AreaTable.Areas[area2.ID].Mode[0].MapData.Goldenberries)
                        {
                            MapEntityId item2 = new MapEntityId(goldenberry2.Level.Name, goldenberry2.ID);
                            if (area2.Modes[0].Strawberries.Contains(item2))
                            {
                                num3 = 0;
                            }
                        }
                    }

                    TextCell entry = new TextCell(engine, Text.Deaths(num3), TextJustify, 0.5f, TextColor);
                    row3.Add(entry);
                    num2 += num3;
                }
                else
                {
                    row3.Add(new IconCell(engine, "dot"));
                }

                table.AddRow();
            }

            if (array[0] && array[1] && array[2])
            {
                TextCell entry2 = new TextCell(engine, Text.Deaths(array2[0] + array2[1] + array2[2] + num2),
                    TextJustify,
                    0.6f, TextColor)
                {
                    SpreadOverColumns = 3
                };
                table.AddRow().Add(new TextCell(engine, Text.Dialog.Clean("journal_grandtotal"), new Vector2(1f, 0.5f),
                    0.7f, TextColor)).Add(entry2);
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
