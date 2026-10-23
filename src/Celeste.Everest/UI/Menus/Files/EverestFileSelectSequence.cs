using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Audio.Fmod;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Controls;
using Celeste.Game.Controls.Source;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Hud;
using Celeste.Game.Presentation.Hud.Counters;
using Celeste.Game.Presentation.Hud.Collectibles;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Save.Runtime;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.Save.Progress;
using Celeste.Simulation.UI.Menus.Completion;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Game.Save.Data;
using Celeste.Graphics.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Errors;
using System.IO;
using System.Linq;
using Celeste.Everest.Modules.Settings;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Menus.Files;

namespace Celeste.Everest.UI.Menus.Files
{
    public class EverestFileSelectSequence : FileSelectSequence
    {
        internal bool startingNewFile;

        public EverestFileSelectSequence(ISourceEngineContext engine) : base(engine)
        {
        }

        protected override ISourceFileSelectSlot ConstructSlot(int index, bool corrupted) =>
            new EverestFileSelectSlotState(engine, index, this, corrupted);

        protected override ISourceFileSelectSlot ConstructSlot(int index, OriginalSaveDataState data) =>
            new EverestFileSelectSlotState(engine, index, this, data);

        public override IEnumerator Enter(OuiState from)
        {
            if (!Loaded)
            {
                int num;
                if (((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.MaxSaveSlots.HasValue)
                {
                    num = Math.Max(3,
                        ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.MaxSaveSlots.Value);
                }
                else
                {
                    num = 1;
                    string saveFilePath = Storage.GetSaveFilePath(null);
                    if (Directory.Exists(saveFilePath))
                    {
                        string[] files = Directory.GetFiles(saveFilePath, "*.celeste");
                        for (int i = 0; i < files.Length; i++)
                        {
                            string fileName = Path.GetFileName(files[i]);
                            if (int.TryParse(fileName.Substring(0, fileName.Length - 8), out var result))
                            {
                                num = Math.Max(num, result);
                            }

                            if (fileName.Contains("-mod") &&
                                int.TryParse(fileName.Substring(0, fileName.IndexOf('-')), out var result2))
                            {
                                num = Math.Max(num, result2);
                            }
                        }
                    }

                    num += 2;
                }

                Slots = new ISourceFileSelectSlot[num];
            }

            int slotIndex = 0;
            IEnumerator orig = base.Enter(from);
            while (orig.MoveNext())
            {
                if (orig.Current is float num2 && num2 == 0.02f)
                {
                    if (Math.Abs(SlotIndex - slotIndex) <= 2)
                    {
                        yield return orig.Current;
                    }

                    slotIndex++;
                }
                else
                {
                    yield return orig.Current;
                }
            }
        }

        protected override void LoadThread()
        {
            base.LoadThread();
            string saveFilePath = Storage.GetSaveFilePath(null);
            if (!Directory.Exists(saveFilePath))
            {
                return;
            }

            for (int i = 0; i < Slots.Count() - 1; i++)
            {
                if (!Slots[i].Exists && Directory.GetFiles(saveFilePath, $"{i}-mod*.celeste").Length != 0)
                {
                    ((IEverestLoggerProcessEnvironment)engine).Logger.FileSelectMissingVanillaData(i);
                    ((EverestFileSelectSlotState)Slots[i]).MissingVanillaData = true;
                    Slots[i].Corrupted = true;
                    Slots[i].Exists = true;
                }
            }
        }

        public override IEnumerator Leave(OuiState next)
        {
            int slotIndex = 0;
            IEnumerator orig = base.Leave(next);
            while (orig.MoveNext())
            {
                if (orig.Current is float num && num == 0.02f)
                {
                    if (next is FileNamingSequence && SlotIndex == slotIndex)
                    {
                        Slots[slotIndex].MoveTo(Slots[slotIndex].IdlePosition.X, 230f);
                    }

                    if (Math.Abs(SlotIndex - slotIndex) <= 2)
                    {
                        yield return orig.Current;
                    }

                    slotIndex++;
                }
                else
                {
                    yield return orig.Current;
                }
            }
        }

        public override void Update()
        {
            int slotIndex = SlotIndex;
            if (Focused && !SlotSelected)
            {
                if ((Input.MenuUp.Pressed ||
                     ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.MenuPageUp.Pressed) &&
                    SlotIndex == 0)
                {
                    Process.AudioSession.Play("event:/ui/main/savefile_rollover_up");
                    SlotIndex = Slots.Length - 1;
                    Input.MenuUp.ConsumePress();
                    ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.MenuPageUp.ConsumePress();
                }
                else if ((Input.MenuDown.Pressed || ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings
                             .MenuPageDown.Pressed) && SlotIndex == Slots.Length - 1)
                {
                    Process.AudioSession.Play("event:/ui/main/savefile_rollover_down");
                    SlotIndex = 0;
                    Input.MenuDown.ConsumePress();
                    ((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.MenuPageDown.ConsumePress();
                }
            }

            base.Update();
            if (Focused && !SlotSelected)
            {
                if (((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.MenuPageUp.Pressed &&
                    SlotIndex > 0)
                {
                    float y = Slots[SlotIndex].Y;
                    while (Slots[SlotIndex].Y > y - 1080f && SlotIndex > 0)
                    {
                        SlotIndex--;
                    }

                    Process.AudioSession.Play("event:/ui/main/savefile_rollover_up");
                }
                else if (((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.MenuPageDown.Pressed &&
                         SlotIndex < Slots.Length - 1)
                {
                    float y2 = Slots[SlotIndex].Y;
                    while (Slots[SlotIndex].Y < y2 + 1080f && SlotIndex < Slots.Length - 1)
                    {
                        SlotIndex++;
                    }

                    Process.AudioSession.Play("event:/ui/main/savefile_rollover_down");
                }
            }

            if (SlotIndex != slotIndex)
            {
                ISourceFileSelectSlot[] slots = Slots;
                foreach (ISourceFileSelectSlot ouiFileSelectSlot in slots)
                {
                    ((EverestFileSelectSlotState)ouiFileSelectSlot).ScrollTo(ouiFileSelectSlot.IdlePosition.X,
                        ouiFileSelectSlot.IdlePosition.Y);
                }
            }
        }
    }
}
