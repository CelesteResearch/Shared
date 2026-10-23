using System;
using Celeste.Game.Execution.Levels;
using Celeste.Framework.Diagnostics.Commands;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static partial class OriginalCelesteCommands
    {
        [SourceCommandAttribute("heartgem", "give heart gem")]
        private static void CmdHeartGem(int area, int mode, bool gem = true)
        {
            CurrentSave.Areas[area].Modes[mode].HeartGem = gem;
        }

        [SourceCommandAttribute("dflag", "Set a savedata flag")]
        private static void CmdDFlag(string flag, bool setTo = true)
        {
            if (setTo)
            {
                CurrentSave.SetFlag(flag);
            }
            else
            {
                CurrentSave.Flags.Remove(flag);
            }
        }

        [SourceCommandAttribute("meet", "Sets flags as though you met Theo")]
        private static void CmdMeet(bool met = true, bool knowsName = true)
        {
            if (met)
            {
                CurrentSave.SetFlag("MetTheo");
            }
            else
            {
                CurrentSave.Flags.Remove("MetTheo");
            }

            if (knowsName)
            {
                CurrentSave.SetFlag("TheoKnowsName");
            }
            else
            {
                CurrentSave.Flags.Remove("TheoKnowsName");
            }
        }

        [SourceCommandAttribute("flag", "set a session flag")]
        private static void CmdFlag(string flag, bool setTo = true)
        {
            ((global::Celeste.Game.Save.Runtime.IOriginalSaveSessionSelectionEnvironment)Process)
                .SaveSessionSelection.GetCurrentSessionSafe(CurrentSave).SetFlag(flag, setTo);
        }

        [SourceCommandAttribute("level_flag", "set a session load flag")]
        private static void CmdLevelFlag(string flag)
        {
            ((global::Celeste.Game.Save.Runtime.IOriginalSaveSessionSelectionEnvironment)Process)
                .SaveSessionSelection.GetCurrentSessionSafe(CurrentSave).LevelFlags.Add(flag);
        }

        [SourceCommandAttribute("sd_clearflags", "clears all flags from the save file")]
        private static void CmdClearSave()
        {
            CurrentSave.Flags.Clear();
        }

        [SourceCommandAttribute("assist", "toggle assist mode for current savefile")]
        private static void CmdAssist()
        {
            CurrentSave.AssistMode = !CurrentSave.AssistMode;
            CurrentSave.VariantMode = false;
        }

        [SourceCommandAttribute("variants", "toggle varaint mode for current savefile")]
        private static void CmdVariants()
        {
            CurrentSave.VariantMode = !CurrentSave.VariantMode;
            CurrentSave.AssistMode = false;
        }

        [SourceCommandAttribute("cheat", "toggle cheat mode for the current savefile")]
        private static void CmdCheat()
        {
            CurrentSave.CheatMode = !CurrentSave.CheatMode;
        }

        [SourceCommandAttribute("time", "set the time speed")]
        private static void CmdTime(float rate = 1f)
        {
            Process.Effects.TimeRate = rate;
        }

        [SourceCommandAttribute("ltng", "disable lightning")]
        private static void CmdLightning(bool disabled = true)
        {
            (Scene as OriginalLevelSceneRoot).Session.SetFlag("disable_lightning", disabled);
        }

        [SourceCommandAttribute("summitgem", "gives summit gem")]
        private static void CmdSummitGem(string gem)
        {
            if (gem == "all")
            {
                for (int i = 0; i < 6; i++)
                {
                    (Scene as OriginalLevelSceneRoot).Session.SummitGems[i] = true;
                }
            }
            else
            {
                (Scene as OriginalLevelSceneRoot).Session.SummitGems[int.Parse(gem)] = true;
            }
        }

        [SourceCommandAttribute("p_dreamdash", "enable dream dashing")]
        private static void CmdDreamDash(bool set = true)
        {
            (Scene as OriginalLevelSceneRoot).Session.Inventory.DreamDash = set;
        }

        [SourceCommandAttribute("p_twodashes", "enable two dashes")]
        private static void CmdTwoDashes(bool set = true)
        {
            (Scene as OriginalLevelSceneRoot).Session.Inventory.Dashes = ((!set) ? 1 : 2);
        }

        [SourceCommandAttribute("screenpadding", "sets level screenpadding")]
        private static void CmdScreenPadding(int value)
        {
            if (Scene is OriginalLevelSceneRoot level)
            {
                level.ScreenPadding = value;
            }
        }
    }
}
