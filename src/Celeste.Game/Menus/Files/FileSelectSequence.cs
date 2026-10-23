using System.Collections;
using Celeste.Core.Components.Timing;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Threading;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Title;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Errors;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Menus.Files
{
    public class FileSelectSequence : OuiState
    {
        protected readonly ISourceEngineContext engine;
        protected IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected OriginalUserIOStorage Storage => ((IOriginalUserIOStorageEnvironment)engine).UserIOStorage;
        public ISourceFileSelectSlot[] Slots = new ISourceFileSelectSlot[3];

        public int SlotIndex;

        public bool SlotSelected;

        public static bool Loaded;

        private bool loadedSuccess;

        public bool HasSlots;

        public FileSelectSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            Loaded = false;
        }

        public override IEnumerator Enter(OuiState from)
        {
            SlotSelected = false;
            if (!Loaded)
            {
                for (var i = 0; i < Slots.Length; i++)
                    if (Slots[i] != null)
                        ((ISourceScene)Scene).SourceScene.RemoveEntity((SceneEntityState)Slots[i]);

                ((IOriginalThreadEnvironment)engine).Threads.Start(LoadThread, "FILE_LOADING");
                var elapsed = 0f;
                while (!Loaded || elapsed < 0.5f)
                {
                    elapsed += engine.DeltaTime;
                    yield return null;
                }

                for (var j = 0; j < Slots.Length; j++)
                    if (Slots[j] != null)
                        ((ISourceScene)Scene).SourceScene.QueueSourceEntity((SceneEntityState)Slots[j]);

                if (!loadedSuccess)
                {
                    var error =
                        new FileErrorOverlayEntity(FileErrorOverlayEntity.Error.Load, engine);
                    while (error.Open) yield return null;

                    if (!error.Ignore)
                    {
                        Overworld.Goto<MainMenuSequence>();
                        yield break;
                    }
                }
            }
            else if (!(from is FileNamingSequence) && !(from is AssistModeSequence))
            {
                yield return 0.2f;
            }

            HasSlots = false;
            for (var k = 0; k < Slots.Length; k++)
                if (Slots[k].Exists)
                    HasSlots = true;

            Process.AudioSession.Play("event:/ui/main/whoosh_savefile_in");
            if (from is FileNamingSequence || from is AssistModeSequence)
            {
                if (!SlotSelected) SelectSlot(false);
            }
            else if (!HasSlots)
            {
                SlotIndex = 0;
                Slots[SlotIndex].Position =
                    new(Slots[SlotIndex].HiddenPosition(1, 0).X, Slots[SlotIndex].SelectedPosition.Y);
                SelectSlot(true);
            }
            else if (!SlotSelected)
            {
                SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 0.4f,
                    delegate { Process.AudioSession.Play("event:/ui/main/savefile_rollover_first"); });
                for (var i2 = 0; i2 < Slots.Length; i2++)
                {
                    Slots[i2].Position = new(Slots[i2].HiddenPosition(1, 0).X, Slots[i2].IdlePosition.Y);
                    Slots[i2].Show();
                    yield return 0.02f;
                }
            }
        }

        protected virtual void LoadThread()
        {
            if (Storage.Open(OriginalUserIOStorage.Mode.Read))
            {
                for (var i = 0; i < Slots.Length; i++)
                {
                    ISourceFileSelectSlot ouiFileSelectSlot;
                    if (!Storage.Exists(
                            ((IOriginalSaveInitializationEnvironment)engine).SaveInitialization.GetFilename(i)))
                    {
                        ouiFileSelectSlot = ConstructSlot(i, false);
                    }
                    else
                    {
                        var saveData = Storage.Load<OriginalSaveDataState>(
                            ((IOriginalSaveInitializationEnvironment)engine).SaveInitialization.GetFilename(i));
                        if (saveData != null)
                        {
                            ((IOriginalSaveInitializationEnvironment)engine).SaveInitialization.AfterInitialize(
                                saveData,
                                ((IOriginalSaveInitializationEnvironment)engine).SaveInitializationServices);
                            ouiFileSelectSlot = ConstructSlot(i, saveData);
                        }
                        else
                        {
                            ouiFileSelectSlot = ConstructSlot(i, true);
                        }
                    }

                    Slots[i] = ouiFileSelectSlot;
                }

                Storage.Close();
                loadedSuccess = true;
            }

            Loaded = true;
        }

        protected virtual ISourceFileSelectSlot ConstructSlot(int index, bool corrupted)
        {
            return new FileSelectSlotPresentation(engine, index, this, corrupted);
        }

        protected virtual ISourceFileSelectSlot ConstructSlot(int index, OriginalSaveDataState data)
        {
            return new FileSelectSlotPresentation(engine, index, this, data);
        }

        public override IEnumerator Leave(OuiState next)
        {
            Process.AudioSession.Play("event:/ui/main/whoosh_savefile_out");
            var slideTo = 1;
            if (next == null || next is ChapterSelectSequence || next is FileNamingSequence ||
                next is AssistModeSequence)
                slideTo = -1;

            for (var i = 0; i < Slots.Length; i++)
            {
                if (next is FileNamingSequence && SlotIndex == i)
                    Slots[i].MoveTo(Slots[i].IdlePosition.X, Slots[0].IdlePosition.Y);
                else if (next is AssistModeSequence && SlotIndex == i)
                    Slots[i].MoveTo(Slots[i].IdlePosition.X, -400f);
                else
                    Slots[i].Hide(slideTo, 0);

                yield return 0.02f;
            }
        }

        public void UnselectHighlighted()
        {
            SlotSelected = false;
            Slots[SlotIndex].Unselect();
            for (var i = 0; i < Slots.Length; i++)
                if (SlotIndex != i)
                    Slots[i].Show();
        }

        public void SelectSlot(bool reset)
        {
            if (!Slots[SlotIndex].Exists && reset)
            {
                if (((ISettingsContext)engine).Settings != null &&
                    !string.IsNullOrWhiteSpace(((ISettingsContext)engine).Settings.DefaultFileName))
                    Slots[SlotIndex].Name = ((ISettingsContext)engine).Settings.DefaultFileName;
                else
                    Slots[SlotIndex].Name = ((IOriginalGameTextEnvironment)engine).Text.Dialog.Clean("FILE_DEFAULT");

                Slots[SlotIndex].AssistModeEnabled = false;
                Slots[SlotIndex].VariantModeEnabled = false;
            }

            SlotSelected = true;
            Slots[SlotIndex].Select(reset);
            for (var i = 0; i < Slots.Length; i++)
                if (SlotIndex != i)
                    Slots[i].Hide(0, i >= SlotIndex ? 1 : -1);
        }

        public override void Update()
        {
            base.Update();
            if (!Focused) return;

            if (!SlotSelected)
            {
                if (Input.MenuUp.Pressed && SlotIndex > 0)
                {
                    Process.AudioSession.Play("event:/ui/main/savefile_rollover_up");
                    SlotIndex--;
                }
                else if (Input.MenuDown.Pressed && SlotIndex < Slots.Length - 1)
                {
                    Process.AudioSession.Play("event:/ui/main/savefile_rollover_down");
                    SlotIndex++;
                }
                else if (Input.MenuConfirm.Pressed)
                {
                    Process.AudioSession.Play("event:/ui/main/button_select");
                    Process.AudioSession.Play("event:/ui/main/whoosh_savefile_out");
                    SelectSlot(true);
                }
                else if (Input.MenuCancel.Pressed)
                {
                    Process.AudioSession.Play("event:/ui/main/button_back");
                    Overworld.Goto<MainMenuSequence>();
                }
            }
            else if (Input.MenuCancel.Pressed && !HasSlots && !Slots[SlotIndex].StartingGame)
            {
                Process.AudioSession.Play("event:/ui/main/button_back");
                Overworld.Goto<MainMenuSequence>();
            }
        }
    }
}
