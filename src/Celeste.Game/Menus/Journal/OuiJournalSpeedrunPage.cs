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
    public class OuiJournalSpeedrunPage : OuiJournalPage
    {
        private Table table;

        public OuiJournalSpeedrunPage(OuiJournalSequence journal)
            : base(journal)
        {
            PageTexture = "page";
            Vector2 justify = new Vector2(0.5f, 0.5f);
            float num = 0.5f;
            PackedColor color = PackedColor.Black * 0.6f;
            table = new Table()
                .AddColumn(new TextCell(engine, Text.Dialog.Clean("journal_speedruns"), new Vector2(1f, 0.5f), 0.7f,
                    PackedColor.Black * 0.7f))
                .AddColumn(new TextCell(engine, Text.Dialog.Clean("journal_mode_normal"), justify, num + 0.1f, color,
                    240f))
                .AddColumn(new TextCell(engine, Text.Dialog.Clean("journal_mode_normal_fullclear"), justify, num + 0.1f,
                    color, 240f));
            if (((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                    .SaveContext
                    .CurrentSave) >= 2)
            {
                table.AddColumn(new TextCell(engine, Text.Dialog.Clean("journal_mode_bside"), justify, num + 0.1f,
                    color,
                    240f));
            }

            if (((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                    .SaveContext
                    .CurrentSave) >= 3)
            {
                table.AddColumn(new TextCell(engine, Text.Dialog.Clean("journal_mode_cside"), justify, num + 0.1f,
                    color,
                    240f));
            }

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
                    break;
                }

                Row row = table.AddRow().Add(new TextCell(engine, Text.Dialog.Clean(areaData.Name),
                    new Vector2(1f, 0.5f),
                    num + 0.1f, color));
                if (area.Modes[0].BestTime > 0)
                {
                    row.Add(new TextCell(engine, Text.Time(area.Modes[0].BestTime), justify, num, color));
                }
                else
                {
                    row.Add(new IconCell(engine, "dot"));
                }

                if (areaData.CanFullClear)
                {
                    if (area.Modes[0].BestFullClearTime > 0)
                    {
                        row.Add(new TextCell(engine, Text.Time(area.Modes[0].BestFullClearTime), justify, num, color));
                    }
                    else
                    {
                        row.Add(new IconCell(engine, "dot"));
                    }
                }
                else
                {
                    row.Add(new TextCell(engine, "-", TextJustify, 0.5f, TextColor));
                }

                if (((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                        .SaveContext.CurrentSave) >= 2)
                {
                    if (areaData.HasMode((int)OriginalAreaMode.BSide))
                    {
                        if (area.Modes[1].BestTime > 0)
                        {
                            row.Add(new TextCell(engine, Text.Time(area.Modes[1].BestTime), justify, num, color));
                        }
                        else
                        {
                            row.Add(new IconCell(engine, "dot"));
                        }
                    }
                    else
                    {
                        row.Add(new TextCell(engine, "-", TextJustify, 0.5f, TextColor));
                    }
                }

                if (((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                        .SaveContext.CurrentSave) < 3)
                {
                    continue;
                }

                if (areaData.HasMode((int)OriginalAreaMode.CSide))
                {
                    if (area.Modes[2].BestTime > 0)
                    {
                        row.Add(new TextCell(engine, Text.Time(area.Modes[2].BestTime), justify, num, color));
                    }
                    else
                    {
                        row.Add(new IconCell(engine, "dot"));
                    }
                }
                else
                {
                    row.Add(new TextCell(engine, "-", TextJustify, 0.5f, TextColor));
                }
            }

            bool flag = true;
            bool flag2 = true;
            bool flag3 = true;
            bool flag4 = true;
            long num2 = 0L;
            long num3 = 0L;
            long num4 = 0L;
            long num5 = 0L;
            foreach (ChapterAreaProgress area2 in ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(
                         Journal.Process.SaveContext.CurrentSave))
            {
                IOriginalAreaData areaData2 = ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(area2.ID);
                if (!Journal.GetAreaInterlude(areaData2) && !Journal.GetAreaIsFinal(areaData2))
                {
                    if (area2.ID >
                        ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedAreasSafe(Journal
                            .Process
                            .SaveContext.CurrentSave))
                    {
                        flag = (flag2 = (flag3 = (flag4 = false)));
                        break;
                    }

                    num2 += area2.Modes[0].BestTime;
                    num3 += area2.Modes[0].BestFullClearTime;
                    num4 += area2.Modes[1].BestTime;
                    num5 += area2.Modes[2].BestTime;
                    if (area2.Modes[0].BestTime <= 0)
                    {
                        flag = false;
                    }

                    if (areaData2.CanFullClear && area2.Modes[0].BestFullClearTime <= 0)
                    {
                        flag2 = false;
                    }

                    if (areaData2.HasMode((int)OriginalAreaMode.BSide) && area2.Modes[1].BestTime <= 0)
                    {
                        flag3 = false;
                    }

                    if (areaData2.HasMode((int)OriginalAreaMode.CSide) && area2.Modes[2].BestTime <= 0)
                    {
                        flag4 = false;
                    }
                }
            }

            if (flag || flag2 || flag3 || flag4)
            {
                table.AddRow();
                Row row2 = table.AddRow().Add(new TextCell(engine, Text.Dialog.Clean("journal_totals"),
                    new Vector2(1f, 0.5f), num + 0.2f, color));
                if (flag)
                {
                    row2.Add(new TextCell(engine, Text.Time(num2), justify, num + 0.1f, color));
                }
                else
                {
                    row2.Add(new IconCell(engine, "dot"));
                }

                if (flag2)
                {
                    row2.Add(new TextCell(engine, Text.Time(num3), justify, num + 0.1f, color));
                }
                else
                {
                    row2.Add(new IconCell(engine, "dot"));
                }

                if (((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                        .SaveContext.CurrentSave) >= 2)
                {
                    if (flag3)
                    {
                        row2.Add(new TextCell(engine, Text.Time(num4), justify, num + 0.1f, color));
                    }
                    else
                    {
                        row2.Add(new IconCell(engine, "dot"));
                    }
                }

                if (((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(Journal.Process
                        .SaveContext.CurrentSave) >= 3)
                {
                    if (flag4)
                    {
                        row2.Add(new TextCell(engine, Text.Time(num5), justify, num + 0.1f, color));
                    }
                    else
                    {
                        row2.Add(new IconCell(engine, "dot"));
                    }
                }

                table.AddRow();
            }

            long num6 = 0L;
            foreach (ChapterAreaProgress area3 in ((IOriginalSaveCounterEnvironment)engine).SaveCounters.GetAreasSafe(
                         Journal.Process.SaveContext.CurrentSave))
            {
                IOriginalAreaData areaData3 = ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetAreaById(area3.ID);
                if (Journal.GetAreaIsFinal(areaData3))
                {
                    if (areaData3.ID >
                        ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedAreasSafe(Journal
                            .Process
                            .SaveContext.CurrentSave))
                    {
                        break;
                    }

                    num6 += area3.Modes[0].BestTime;
                    Row row3 = table.AddRow().Add(new TextCell(engine, Text.Dialog.Clean(areaData3.Name),
                        new Vector2(1f, 0.5f), num + 0.1f, color));
                    row3.Add(null);
                    if (area3.Modes[0].BestTime > 0)
                    {
                        Cell cell;
                        row3.Add(cell = new TextCell(engine, Text.Time(area3.Modes[0].BestTime), justify, num, color));
                    }
                    else
                    {
                        Cell cell;
                        row3.Add(cell = new IconCell(engine, "dot"));
                    }

                    table.AddRow();
                }
            }

            if (flag && flag2 && flag3 && flag4)
            {
                TextCell entry =
                    new TextCell(engine, Text.Time(num2 + num3 + num4 + num5 + num6), justify, num + 0.2f, color)
                    {
                        SpreadOverColumns =
                            1 + ((IOriginalSaveProgressionEnvironment)engine).SaveProgression.GetUnlockedModes(
                                Journal.Process.SaveContext.CurrentSave)
                    };
                table.AddRow().Add(new TextCell(engine, Text.Dialog.Clean("journal_grandtotal"), new Vector2(1f, 0.5f),
                    num + 0.3f, color)).Add(entry);
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
