using System;
using System.Collections;
using System.IO;
using System.Linq;
using Celeste.Core.Scheduling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Settings;
using Celeste.Game.Menus.Files;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Save.Data;

namespace Celeste.Everest.UI.Menus.Files
{
    public class EverestFileSelectSequence : FileSelectSequence
    {
        internal bool startingNewFile;

        public EverestFileSelectSequence(ISourceEngineContext engine) : base(engine)
        {
        }

        protected override ISourceFileSelectSlot ConstructSlot(int index, bool corrupted)
        {
            return new EverestFileSelectSlotState(engine, index, this, corrupted);
        }

        protected override ISourceFileSelectSlot ConstructSlot(int index, OriginalSaveDataState data)
        {
            return new EverestFileSelectSlotState(engine, index, this, data);
        }

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
                    var saveFilePath = Storage.GetSaveFilePath(null);
                    if (Directory.Exists(saveFilePath))
                    {
                        var files = Directory.GetFiles(saveFilePath, "*.celeste");
                        for (var i = 0; i < files.Length; i++)
                        {
                            var fileName = Path.GetFileName(files[i]);
                            if (int.TryParse(fileName.Substring(0, fileName.Length - 8), out var result))
                                num = Math.Max(num, result);

                            if (fileName.Contains("-mod") &&
                                int.TryParse(fileName.Substring(0, fileName.IndexOf('-')), out var result2))
                                num = Math.Max(num, result2);
                        }
                    }

                    num += 2;
                }

                Slots = new ISourceFileSelectSlot[num];
            }

            var slotIndex = 0;
            var orig = base.Enter(from);
            while (orig.MoveNext())
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (orig.Current is float num2 && num2 == 0.02f)
                {
                    if (Math.Abs(SlotIndex - slotIndex) <= 2) yield return orig.Current;

                    slotIndex++;
                }
                else
                {
                    yield return orig.Current;
                }
        }

        protected override void LoadThread()
        {
            base.LoadThread();
            var saveFilePath = Storage.GetSaveFilePath(null);
            if (!Directory.Exists(saveFilePath)) return;

            for (var i = 0; i < Slots.Count() - 1; i++)
                if (!Slots[i].Exists && Directory.GetFiles(saveFilePath, $"{i}-mod*.celeste").Length != 0)
                {
                    ((IEverestLoggerProcessEnvironment)engine).Logger.FileSelectMissingVanillaData(i);
                    ((EverestFileSelectSlotState)Slots[i]).MissingVanillaData = true;
                    Slots[i].Corrupted = true;
                    Slots[i].Exists = true;
                }
        }

        public override IEnumerator Leave(OuiState next)
        {
            var slotIndex = 0;
            var orig = base.Leave(next);
            while (orig.MoveNext())
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (orig.Current is float num && num == 0.02f)
                {
                    if (next is FileNamingSequence && SlotIndex == slotIndex)
                        Slots[slotIndex].MoveTo(Slots[slotIndex].IdlePosition.X, 230f);

                    if (Math.Abs(SlotIndex - slotIndex) <= 2) yield return orig.Current;

                    slotIndex++;
                }
                else
                {
                    yield return orig.Current;
                }
        }

        public override void Update()
        {
            var slotIndex = SlotIndex;
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
                    var y = Slots[SlotIndex].Y;
                    while (Slots[SlotIndex].Y > y - 1080f && SlotIndex > 0) SlotIndex--;

                    Process.AudioSession.Play("event:/ui/main/savefile_rollover_up");
                }
                else if (((IEverestCurrentCoreSettingsEnvironment)engine).CurrentCoreSettings.MenuPageDown.Pressed &&
                         SlotIndex < Slots.Length - 1)
                {
                    var y2 = Slots[SlotIndex].Y;
                    while (Slots[SlotIndex].Y < y2 + 1080f && SlotIndex < Slots.Length - 1) SlotIndex++;

                    Process.AudioSession.Play("event:/ui/main/savefile_rollover_down");
                }
            }

            if (SlotIndex != slotIndex)
            {
                var slots = Slots;
                foreach (var ouiFileSelectSlot in slots)
                    ((EverestFileSelectSlotState)ouiFileSelectSlot).ScrollTo(ouiFileSelectSlot.IdlePosition.X,
                        ouiFileSelectSlot.IdlePosition.Y);
            }
        }
    }
}
