using Celeste.Core.Display;
using Celeste.Graphics.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Maps;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Gameplay.Collectibles.Strawberries;
using Celeste.Game.Gameplay.Collectibles.Keys;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Presentation.PostProcessing.ColorGrading;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Simulation;
using Celeste.Simulation.Save.Progress;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Localization.Languages;
using Celeste.Graphics.Display.Colors;
using Celeste.Framework.Diagnostics.Commands;
using Celeste.Simulation.Audio;
using Celeste.Game.UI.Dialogue.Textboxes;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static partial class OriginalCelesteCommands
    {
        [SourceCommandAttribute("give_golden", "gives you a golden strawb")]
        private static void CmdGiveGolden()
        {
            if (Scene is OriginalLevelSceneRoot level)
            {
                RoomPlayerSession entity =
                    level.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (entity != null)
                {
                    EntityData entityData = new EntityData();
                    entityData.Position = entity.Position + new Vector2(0f, -16f);
                    entityData.ID = ((ISourceRandomEnvironment)Process).Random.Next();
                    entityData.Name = "goldenBerry";
                    OriginalStrawberryState entity2 = new OriginalStrawberryState(entityData, Vector2.Zero,
                        new MapEntityId(level.Session.Level, entityData.ID), (IOriginalStrawberryProcess)Process);
                    level.SourceScene.QueueSourceEntity(entity2);
                }
            }
        }


        [SourceCommandAttribute("bounce", "bounces the player!")]
        private static void CmdBounce()
        {
            RoomPlayerSession entity =
                Scene.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            entity?.Bounce(entity.Bottom);
        }


        [SourceCommandAttribute("lighting", "checks lightiing values")]
        private static void CmdLighting()
        {
            if (Scene is OriginalLevelSceneRoot level)
            {
                Console.Log("base(" + level.BaseLightingAlpha + "), session add(" + level.Session.LightingAlphaAdd +
                            "), current (" + level.Lighting.Alpha + ")");
            }
        }


        [SourceCommandAttribute("detailed_levels", "counts detailed levels")]
        private static void CmdDetailedLevels(int area = -1, int mode = 0)
        {
            if (area == -1)
            {
                int num = 0;
                int num2 = 0;
                foreach (IOriginalAreaData area2 in ((IOriginalAreaSourceTable)Process).Areas)
                {
                    for (int i = 0; i < area2.Mode.Length; i++)
                    {
                        OriginalAreaModeData modeProperties = area2.Mode[i];
                        if (modeProperties == null)
                        {
                            continue;
                        }

                        foreach (OriginalLevelRoomData level in modeProperties.MapData.Levels)
                        {
                            if (!level.Dummy)
                            {
                                num++;
                                if (level.BgDecals.Count + level.FgDecals.Count >= 2)
                                {
                                    num2++;
                                }
                            }
                        }
                    }
                }

                Console.Log(num2 + " / " + num);
                return;
            }

            int num3 = 0;
            int num4 = 0;
            List<string> list = new List<string>();
            foreach (OriginalLevelRoomData level2 in AreaKeys.GetAreaById(area).GetOriginalMode(mode).MapData.Levels)
            {
                if (!level2.Dummy)
                {
                    num3++;
                    if (level2.BgDecals.Count + level2.FgDecals.Count >= 2)
                    {
                        num4++;
                    }
                    else
                    {
                        list.Add(level2.Name);
                    }
                }
            }

            Console.Log(string.Join(", ", list), PackedColor.Red);
            Console.Log(num4 + " / " + num3);
        }


        [SourceCommandAttribute("hearts", "gives a certain number of hearts (default all)")]
        private static void CmdHearts(int amount = 24)
        {
            int num = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < CurrentSave.Areas.Count; j++)
                {
                    ChapterModeProgress areaModeStats = CurrentSave.Areas[j].Modes[i];
                    if (areaModeStats != null)
                    {
                        if (num < amount)
                        {
                            num++;
                            areaModeStats.HeartGem = true;
                        }
                        else
                        {
                            areaModeStats.HeartGem = false;
                        }
                    }
                }
            }

            global::System.Console.WriteLine(
                ((IOriginalSaveCounterEnvironment)Process).SaveCounters.TotalHeartGems(CurrentSave));
        }


        [SourceCommandAttribute("berries_order", "checks strawbs order")]
        private static void CmdBerriesOrder()
        {
            foreach (IOriginalAreaData area in ((IOriginalAreaSourceTable)Process).Areas)
            {
                for (int i = 0; i < area.Mode.Length; i++)
                {
                    if (area.Mode[i] == null)
                    {
                        continue;
                    }

                    HashSet<string> hashSet = new HashSet<string>();
                    EntityData[,] array = new EntityData[10, 25];
                    foreach (EntityData strawberry in area.Mode[i].MapData.Strawberries)
                    {
                        int num = EntityAttributeReader.Int(strawberry.Values, "checkpointID");
                        int num2 = EntityAttributeReader.Int(strawberry.Values, "order");
                        string item = num + ":" + num2;
                        if (hashSet.Contains(item))
                        {
                            Console.Log(
                                "Conflicting Berry: Area[" + area.ID + "] Mode[" + i + "] Checkpoint[" + num +
                                "] Order[" +
                                num2 + "]", PackedColor.Red);
                        }
                        else
                        {
                            hashSet.Add(item);
                        }

                        array[num, num2] = strawberry;
                    }

                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        for (int k = 1; k < array.GetLength(1); k++)
                        {
                            if (array[j, k] != null && array[j, k - 1] == null)
                            {
                                Console.Log(
                                    "Missing Berry Order #" + (k - 1) + ": Area[" + area.ID + "] Mode[" + i +
                                    "] Checkpoint[" + j + "]", PackedColor.Red);
                            }
                        }
                    }
                }
            }
        }


        [SourceCommandAttribute("core", "set the core mode of the level")]
        private static void CmdCore(int mode = 0, bool session = false)
        {
            (Scene as OriginalLevelSceneRoot).CoreMode = (RoomCoreMode)mode;
            if (session)
            {
                (Scene as OriginalLevelSceneRoot).Session.CoreMode = (RoomCoreMode)mode;
            }
        }


        [SourceCommandAttribute("audio", "checks audio state of session")]
        private static void CmdAudio()
        {
            if (!(Scene is OriginalLevelSceneRoot))
            {
                return;
            }

            RoomAudioState audio = (Scene as OriginalLevelSceneRoot).Session.Audio;
            Console.Log("MUSIC: " + audio.Music.Event, PackedColor.Green);
            foreach (EventParameter parameter in audio.Music.Parameters)
            {
                Console.Log("    " + parameter.Key + " = " + parameter.Value);
            }

            Console.Log("AMBIENCE: " + audio.Ambience.Event, PackedColor.Green);
            foreach (EventParameter parameter2 in audio.Ambience.Parameters)
            {
                Console.Log("    " + parameter2.Key + " = " + parameter2.Value);
            }
        }


        [SourceCommandAttribute("givekey", "creates a key on the player")]
        private static void CmdGiveKey()
        {
            RoomPlayerSession entity =
                Scene.SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

            if (entity != null)
            {
                OriginalLevelSceneRoot obj = Scene as OriginalLevelSceneRoot;
                OriginalKeyState key = new OriginalKeyState(entity,
                    new MapEntityId("unknown", 1073741823 + ((ISourceRandomEnvironment)Process).Random.Next(10000)),
                    (IOriginalKeyProcess)Process);
                obj.SourceScene.QueueSourceEntity(key);
                obj.Session.Keys.Add(key.ID);
            }
        }


        [SourceCommandAttribute("colorgrading", "sets color grading enabled (true/false)")]
        private static void CmdColorGrading(bool enabled)
        {
            ((IOriginalColorGradeEnvironment)Process).ColorGradeProcess.Enabled = enabled;
        }


        [SourceCommandAttribute("music_progress", "set music progress value")]
        private static void CmdMusProgress(int progress)
        {
            ((IOriginalGameplayProcess)Process).AudioSession.SetMusicParam("progress", progress);
        }


        [SourceCommandAttribute("berries", "check how many strawberries are in the given chapter, or the entire game")]
        private static void CmdStrawberries(int chapterID = -1)
        {
            PackedColor lime = PackedColor.Lime;
            PackedColor red = PackedColor.Red;
            PackedColor yellow = PackedColor.Yellow;
            PackedColor gray = PackedColor.Gray;
            if (chapterID == -1)
            {
                int num = 0;
                int[] array = new int[((IOriginalAreaSourceTable)Process).Areas.Count];
                for (int i = 0; i < ((IOriginalAreaSourceTable)Process).Areas.Count; i++)
                {
                    ((IOriginalChapterMapConstructionEnvironment)Process).CreateMapData(AreaKeys.Create(i))
                        .GetStrawberries(out array[i]);
                    num += array[i];
                }

                Console.Log("Grand Total Strawberries: " + num, yellow);
                for (int j = 0; j < array.Length; j++)
                {
                    PackedColor color =
                        ((array[j] == ((IOriginalAreaSourceTable)Process).Areas[j].Mode[0].TotalStrawberries)
                            ? ((array[j] != 0) ? lime : gray)
                            : red);
                    Console.Log("Chapter " + j + ": " + array[j], color);
                }

                return;
            }

            IOriginalAreaData areaData = ((IOriginalAreaSourceTable)Process).Areas[chapterID];
            int totalStrawberries = areaData.Mode[0].TotalStrawberries;
            int[] array2 = new int[areaData.Mode[0].Checkpoints.Length + 1];
            array2[0] = areaData.Mode[0].StartStrawberries;
            for (int k = 1; k < array2.Length; k++)
            {
                array2[k] = areaData.Mode[0].Checkpoints[k - 1].Strawberries;
            }

            int total;
            int[] strawberries = ((IOriginalChapterMapConstructionEnvironment)Process)
                .CreateMapData(AreaKeys.Create(chapterID)).GetStrawberries(out total);
            Console.Log("Chapter " + chapterID + " Strawberries");
            Console.Log("Total: " + total, (totalStrawberries == total) ? lime : red);
            for (int l = 0; l < array2.Length; l++)
            {
                PackedColor color2 = ((strawberries[l] == array2[l]) ? ((strawberries[l] != 0) ? lime : gray) : red);
                Console.Log("CP" + l + ": " + strawberries[l], color2);
            }
        }


        [SourceCommandAttribute("say", "initiate a dialog message")]
        private static void CmdSay(string id)
        {
            Scene.SourceScene.QueueSourceEntity(new TextboxState(id, Process));
        }


        [SourceCommandAttribute("level_count", "print out total level count!")]
        private static void CmdTotalLevels(int areaID = -1, int mode = 0)
        {
            if (areaID >= 0)
            {
                Console.Log(GetLevelsInArea(AreaKeys.Create(areaID, mode)));
                return;
            }

            int num = 0;
            foreach (IOriginalAreaData area in ((IOriginalAreaSourceTable)Process).Areas)
            {
                for (int i = 0; i < area.Mode.Length; i++)
                {
                    num += GetLevelsInArea(AreaKeys.Create(area.ID, i));
                }
            }

            Console.Log(num);
        }


        [SourceCommandAttribute("check_all_languages", "compares all langauges to english")]
        private static void CmdCheckLangauges(bool compareContent = false)
        {
            Console.Log("---------------------");
            bool flag = true;
            foreach (KeyValuePair<string, DialogLanguage> language in Text.Dialog.Languages)
            {
                flag &= CmdCheckLangauge(language.Key, compareContent);
            }

            Console.Log("---------------------");
            Console.Log("REUSLT: " + flag, flag ? PackedColor.LawnGreen : PackedColor.Red);
        }


        [SourceCommandAttribute("check_language", "compares all langauges to english")]
        private static bool CmdCheckLangauge(string id, bool compareContent = false)
        {
            bool flag = true;
            DialogLanguage language = Text.Dialog.Languages[id];
            DialogLanguage language2 = Text.Dialog.Languages["english"];
            int num;
            if (language.FontFace != language2.FontFace)
            {
                if (Settings != null)
                {
                    num = ((language.FontFace != Text.Dialog.Languages[Settings.LanguageId].FontFace) ? 1 : 0);
                    if (num == 0)
                    {
                        goto IL_0071;
                    }
                }
                else
                {
                    num = 1;
                }

                Text.Fonts.Load(language.FontFace);
            }
            else
            {
                num = 0;
            }

            goto IL_0071;
            IL_0071:
            bool flag2 = Text.CheckLanguageFontCharacters(id);
            bool flag3 = Text.CompareLanguages("english", id, compareContent);
            if (num != 0)
            {
                Text.Fonts.Unload(language.FontFace);
            }

            Console.Log(id + " [FONT: " + flag2 + ", MATCH: " + flag3 + "]",
                (flag2 && flag3) ? PackedColor.White : PackedColor.Red);
            return flag && flag2 && flag3;
        }


        [SourceCommandAttribute("characters", "gets all the characters of each text file (writes to console")]
        private static void CmdTextCharacters()
        {
            Text.CheckCharacters();
        }


        private static int GetLevelsInArea(OriginalAreaKey key)
        {
            return AreaKeys.GetArea(key).Mode[(int)key.Mode]?.MapData.Levels.Count ?? 0;
        }
    }
}
